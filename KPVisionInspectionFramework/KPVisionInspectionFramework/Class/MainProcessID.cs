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
        public DIOControlWindow DIOWnd;
        public SerialWindow     SerialWnd;

        #region Initialize & DeInitialize
        public MainProcessID()
        {
            
        }

        public override void Initialize()
        {
            DIOWnd = new DIOControlWindow((int)eProjectType.DISPENSER);
            DIOWnd.InputChangedEvent += new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            DIOWnd.Initialize();

            SerialWnd = new SerialWindow();
            SerialWnd.SerialReceiveEvent += new SerialWindow.SerialReceiveHandler(SeraialReceiveEventFunction);
            SerialWnd.Initialize("COM1");
        }

        public override void DeInitialize()
        {
            DIOWnd.InputChangedEvent -= new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            DIOWnd.DeInitialize();

            SerialWnd.SerialReceiveEvent -= new SerialWindow.SerialReceiveHandler(SeraialReceiveEventFunction);
            SerialWnd.DeInitialize();
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
            SerialWnd.Show();
        }

        public override bool GetSerialWindowShown()
        {
            return true;
        }

        public override void SetSerialWindowTopMost(bool _IsTopMost)
        {
            SerialWnd.TopMost = _IsTopMost;
        }
        #endregion Serial Window Function

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

            int _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_COMPLETE);
            int _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_READY);

            if (_CompleteCmdBit >= 0)   DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0)      DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);

            return _Result;
        }


        #region Communication Event Function
        private void InputChangeEventFunction(short _BitNum, bool _Signal)
        {
            switch (_BitNum)
            {
                case DIO_DEF.IN_TRG:    TriggerOn(0); break;
                case DIO_DEF.IN_RESET:  Reset(0); break;
            }
        }

        private bool SeraialReceiveEventFunction(string _SerialData)
        {
            OnMainProcessCommand(eMainProcCmd.RCP_CHANGE, _SerialData);
            return true;
        }

        //LDH, 2018.08.20, Serial Data Send
        public override void SendSerialData(string _SendData)
        {
            SerialWnd.SendSequenceData(_SendData);
        }
        #endregion Communication Event Function
    }
}
