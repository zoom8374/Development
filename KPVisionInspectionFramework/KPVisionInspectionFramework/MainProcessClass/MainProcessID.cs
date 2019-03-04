using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InspectionSystemManager;
using LogMessageManager;
using ParameterManager;
using DIOControlManager;
using SerialManager;

namespace KPVisionInspectionFramework
{
    public class MainProcessID : MainProcessBase
    {
        public const string CR = "cr";

        public DIOControlWindow DIOWnd;
        public SerialWindow     SerialWnd;

        public bool IsDIOInitialize;
        public bool IsSerialInitialize;

        #region Initialize & DeInitialize
        public MainProcessID()
        {
            IsDIOInitialize = false;
            IsSerialInitialize = false;
        }

        public override void Initialize(string _CommonFolderPath)
        {
            DIOWnd = new DIOControlWindow((int)eProjectType.BLOWER, _CommonFolderPath);
            DIOWnd.InputChangedEvent += new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            IsDIOInitialize = DIOWnd.Initialize();

            SerialWnd = new SerialWindow();
            SerialWnd.SerialReceiveEvent += new SerialWindow.SerialReceiveHandler(SeraialReceiveEventFunction);
            IsSerialInitialize = SerialWnd.Initialize("COM1");
        }

        public override void DeInitialize()
        {
            DIOWnd.InputChangedEvent -= new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            if (IsDIOInitialize) DIOWnd.DeInitialize();

            SerialWnd.SerialReceiveEvent -= new SerialWindow.SerialReceiveHandler(SeraialReceiveEventFunction);
            if (IsSerialInitialize) SerialWnd.DeInitialize();
        }
        #endregion Initialize & DeInitialize

        #region DIO Window Function
        public override void ShowDIOWindow()
        {
            DIOWnd.ShowDIOWindow();
        }

        public override bool GetDIOWindowShown()
        {
            return DIOWnd.IsShowWindow;
        }

        public override void SetDIOWindowTopMost(bool _IsTopMost)
        {
            DIOWnd.TopMost = _IsTopMost;
        }

        public override void SetDIOOutputSignal(short _BitNumber, bool _Signal)
        {
            DIOWnd.SetOutputSignal(_BitNumber, _Signal);
        }
        #endregion DIO Window Function

        #region Serial Window Function
        public override void ShowSerialWindow()
        {
            //SerialWnd.Show();
            SerialWnd.ShowSerialWindow();
        }

        public override bool GetSerialWindowShown()
        {
            return SerialWnd.IsShowWindow;
        }

        public override void SetSerialWindowTopMost(bool _IsTopMost)
        {
            SerialWnd.TopMost = _IsTopMost;
        }
        #endregion Serial Window Function

        public override bool AutoMode(bool _Flag)
        {
            bool _Result = true;

            int _AutoCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            DIOWnd.SetOutputSignal((short)_AutoCmdBit, _Flag);

            int _CompleteBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            DIOWnd.SetOutputSignal((short)_CompleteBit, false);

            return _Result;
        }

        //LDH, 내부 Test 용. 실제로는 Camera Trigger로 동작
        public override bool TriggerOn(int _ID)
        {
            bool _Result = false;

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : Trigger{0} On Event", _ID + 1));
            OnMainProcessCommand(eMainProcCmd.TRG, _ID);

            return _Result;
        }

        public override bool Reset(int _ID)
        {
            bool _Result = false;

            //int _Result1Bit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_RESULT1);
            //int _Result2Bit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_RESULT2);
            //int _Result3Bit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_RESULT3);
            //int _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_COMPLETE);
            int _Result1Bit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_RESULT_1);
            int _Result2Bit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_RESULT_2);
            int _Result3Bit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_RESULT_3);
            int _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);

            if (_Result1Bit >= 0) DIOWnd.SetOutputSignal((short)_Result1Bit, false);
            if (_Result2Bit >= 0) DIOWnd.SetOutputSignal((short)_Result2Bit, false);
            if (_Result3Bit >= 0) DIOWnd.SetOutputSignal((short)_Result3Bit, false);
            if (_CompleteCmdBit >= 0)   DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);

            return _Result;
        }

        public override bool SendResultData(SendResultParameter _ResultParam)
        {
            bool _Result = true;

            bool _ResultFlag = _ResultParam.IsGood;
            int SendResultBit = 0;

            if (!_ResultFlag)
            {
                switch (_ResultParam.NgType)
                {
                    case eNgType.REF_NG: SendResultBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck(DIO_DEF.OUT_RESULT_1); break;
                    case eNgType.ID:     SendResultBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck(DIO_DEF.OUT_RESULT_1); break;
                    case eNgType.DEFECT: SendResultBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck(DIO_DEF.OUT_RESULT_1); break;
                    //case eNgType.DUMMY:  SendResultBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck(DIO_DEF.OUT_RESULT_3); break;
                }
                DIOWnd.SetOutputSignal((short)SendResultBit, true);
            }
            InspectionComplete(0, true);

            //AckStructs[_ResultParam.ID].Initialize();

            return _Result;
        }

        #region Communication Event Function
        private void InputChangeEventFunction(short _BitNum, bool _Signal)
        {
            switch (_BitNum)
            {
                case DIO_DEF.IN_TRG:        TriggerOn(0); break;
                case DIO_DEF.IN_RESET:      Reset(0); break;
                case DIO_DEF.IN_RESET_2:    Reset(0); break;
            }
        }

        private bool SeraialReceiveEventFunction(string _SerialData)
        {
            string[] ReceiveData = _SerialData.Split(',');
            eMainProcCmd ReceiveCmd = eMainProcCmd.LOT_CHANGE;

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, _SerialData, CLogManager.LOG_LEVEL.LOW);

            switch (ReceiveData[0])
            {
                case "@S": ReceiveCmd = eMainProcCmd.RCP_CHANGE; break;
                case "@L": ReceiveCmd = eMainProcCmd.LOT_CHANGE; break;
                case "@E": ReceiveCmd = eMainProcCmd.LOT_CHANGE; break;
                case "@N": ReceiveCmd = eMainProcCmd.LOT_CHANGE; break;
            }

            if(ReceiveCmd == eMainProcCmd.LOT_CHANGE) OnMainProcessCommand(ReceiveCmd, _SerialData);
            else                                      OnMainProcessCommand(ReceiveCmd, ReceiveData[1]);

            return true;
        }

        //LDH, 2018.08.20, Serial Data Send
        public override void SendSerialData(eMainProcCmd _SendCmd, string _SendData = "")
        {
            string SendBit = "";

            switch (_SendCmd)
            {
                case eMainProcCmd.RCP_CHANGE: SendBit = "@D_OK"; break;
                case eMainProcCmd.LOT_CHANGE:
                    {
                        if (_SendData == "RELOAD")   SendBit = "@N_OK"; 
                        if (_SendData == "END") SendBit = "@E_OK";
                        //else                         SendBit = "@L_OK"; 
                    }break;
                case eMainProcCmd.REQUEST:
                    {
                        if(_SendData == "LOT") SendBit = "@R_L";
                        else                   SendBit = "@R_D";
                    }
                    break;
                case eMainProcCmd.LOT_RETURN: SendBit = string.Format("@L_OK,{0}",_SendData); break;
            }

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, SendBit + "," + '\r', CLogManager.LOG_LEVEL.LOW);
            SerialWnd.SendSequenceData(SendBit + "," + '\r');
        }

        public override bool InspectionComplete(int _ID, bool _Flag)
        {
            bool _Result = true;
            int _CompleteCmdBit = 0;

            _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);


            DIOWnd.SetOutputSignal((short)_CompleteCmdBit, _Flag);

            return _Result;
        }
        #endregion Communication Event Function
    }
}
