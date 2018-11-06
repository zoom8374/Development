﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using InspectionSystemManager;
using LogMessageManager;
using ParameterManager;
using DIOControlManager;
using EthernetServerManager;
//using EthernetManager;

namespace KPVisionInspectionFramework
{
    public class MainProcessDispensor : MainProcessBase
    {
        private DIOControlWindow    DIOWnd;
        private EthernetWindow      EthernetServWnd;
        //private EthernetWindow   EthernetWnd;

        private AckStruct[] AckStructs;

        private bool AckFlag = false;
        public bool NakFlag = false;

        private Thread ThreadAckSignalCheck;
        private bool IsThreadAckSignalCheckExit;
        private bool AckSignal = false;

        private short WaitingPeriod = 50;
        private short WaitingLimitTime = 5000;

        #region Initialize & DeInitialize
        public MainProcessDispensor()
        {
        }

        public override void Initialize(string _CommonFolderPath)
        {
            DIOWnd = new DIOControlWindow((int)eProjectType.DISPENSER, _CommonFolderPath);
            DIOWnd.InputChangedEvent += new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            DIOWnd.Initialize();

            EthernetServWnd = new EthernetWindow();
            EthernetServWnd.Initialize(_CommonFolderPath);
            EthernetServWnd.ReceiveStringEvent += new EthernetWindow.ReceiveStringHandler(ReceiveStringEventFunction);

            int _AutoCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            int _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            int _ReadyCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);
            int _LiveCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_LIVE);

            if (_AutoCmdBit >= 0) DIOWnd.SetOutputSignal((short)_AutoCmdBit, false);
            if (_CompleteCmdBit >= 0) DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0) DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);
            if (_LiveCmdBit >= 0) DIOWnd.SetOutputSignal((short)_LiveCmdBit, true);

            AckStructs = new AckStruct[3];
            for (int iLoopCount = 0; iLoopCount < 3; ++iLoopCount) AckStructs[iLoopCount] = new AckStruct(); ;

            ThreadAckSignalCheck = new Thread(ThreadAckSignalCheckFunc);
            ThreadAckSignalCheck.IsBackground = true;
            IsThreadAckSignalCheckExit = false;
        }

        public override void DeInitialize()
        {
            int _AutoCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            int _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            int _ReadyCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);
            int _LiveCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_LIVE);

            if (_AutoCmdBit >= 0) DIOWnd.SetOutputSignal((short)_AutoCmdBit, false);
            if (_CompleteCmdBit >= 0) DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0) DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);
            if (_LiveCmdBit >= 0) DIOWnd.SetOutputSignal((short)_LiveCmdBit, false);

            DIOWnd.InputChangedEvent -= new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            DIOWnd.DeInitialize();

            EthernetServWnd.ReceiveStringEvent -= new EthernetWindow.ReceiveStringHandler(ReceiveStringEventFunction);
            EthernetServWnd.DeInitialize();

            if (ThreadAckSignalCheck != null) { IsThreadAckSignalCheckExit = true; Thread.Sleep(200); ThreadAckSignalCheck.Abort(); ThreadAckSignalCheck = null; }
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

        #region Ethernet Window Function
        public override void ShowEthernetWindow()
        {
            EthernetServWnd.ShowEthernetWindow();
        }

        public override bool GetEhernetWindowShown()
        {
            return EthernetServWnd.IsShowWindow;
        }

        public override void SetEthernetWindowTopMost(bool _IsTopMost)
        {
            EthernetServWnd.TopMost = _IsTopMost;
        }
        #endregion Ethernet Window Function

        public override bool AutoMode(bool _Flag)
        {
            bool _Result = true;

            int _AutoCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            DIOWnd.SetOutputSignal((short)_AutoCmdBit, _Flag);

            return _Result;
        }

        public override bool TriggerOn(int _ID)
        {
            bool _Result = false;

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : Trigger{0} On Event", _ID + 1));
            OnMainProcessCommand(eMainProcCmd.TRG, _ID);

            return _Result;
        }

        public override bool Reset(int _ID)
        {
            bool _Result = true;
            int _CompleteCmdBit, _ReadyCmdBit;

            if (0 == _ID)
            {
                _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
                _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);
            }

            else if (1 == _ID)
            {
                _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE_2);
                _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY_2);
            }

            else if (2 == _ID)
            {
                _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE_3);
                _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY_3);
            }

            else
            {
                _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
                _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);
            }

            if (_CompleteCmdBit >= 0)   DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0)      DIOWnd.SetOutputSignal((short)_ReadyCmdBit, true, 250);

            return _Result;
        }

        public override bool SendResultData(SendResultParameter _ResultParam)
        {
            bool _Result = true;

            if (_ResultParam.ProjectItem == eProjectItem.NEEDLE_ALIGN)
            {
                string _VisionString, _ResultString;
                _VisionString = String.Format("V{0}", _ResultParam.ID + 1);

                if (_ResultParam.IsGood) _ResultString = "OK";
                else                     _ResultString = "NG";

                var _SendResult = _ResultParam.SendResult as SendNeedleAlignResult;

                if (_SendResult == null)
                {
                    _SendResult = new SendNeedleAlignResult();
                    _SendResult.AlignX = 0;
                    _SendResult.AlignY = 0;
                    _ResultString = "NG";
                }
                
                //LDH, 2018.09.04, TILab 프로토콜 생성
                string[] _DataStringAlign = ChangeResult(_SendResult.AlignX, _SendResult.AlignY);
                string _ResultDataString = string.Format("{0},{1},{2},{3}", _VisionString, _ResultString, _DataStringAlign[0], _DataStringAlign[1]);
                EthernetServWnd.SendResultData(_ResultDataString);
                AckStructs[_ResultParam.ID].Initialize();
            }

            else if (_ResultParam.ProjectItem == eProjectItem.LEAD_INSP)
            {
                string _VisionString, _ResultString;
                _VisionString = String.Format("V{0}", _ResultParam.ID + 1);

                if (_ResultParam.IsGood) _ResultString = "OK";
                else _ResultString = "NG";

                var _SendResult = _ResultParam.SendResult as SendLeadResult;

                if (_SendResult == null)
                {
                    _SendResult = new SendLeadResult();
                    _ResultString = "NG";
                }

                string _ResultDataString = string.Format("{0},{1},00000,00000", _VisionString, _ResultString);
                EthernetServWnd.SendResultData(_ResultDataString);
                AckStructs[_ResultParam.ID].Initialize();
            }

            return _Result;
        }

        private string[] ChangeResult(double _ResultX, double _ResultY)
        {
            string[] LastResult = new string[2];
            int[] ResultTemp = new int[2];

            ResultTemp[0] = Convert.ToInt32(_ResultX * 100);
            ResultTemp[1] = Convert.ToInt32(_ResultY * 100);

            for (int iLoopCount = 0; iLoopCount < 2; iLoopCount++)
            {
                if (Math.Abs(ResultTemp[iLoopCount]) < 10000)
                {
                    if (ResultTemp[iLoopCount] < 0) { ResultTemp[iLoopCount] = -ResultTemp[iLoopCount]; LastResult[iLoopCount] = "0"; }
                    else { LastResult[iLoopCount] = "1"; }

                    for (int multipleCnt = 3; multipleCnt >= 0; multipleCnt--)
                    {
                        LastResult[iLoopCount] = LastResult[iLoopCount] + Math.Truncate(ResultTemp[iLoopCount] / Math.Pow(10, multipleCnt));
                        ResultTemp[iLoopCount] = Convert.ToInt32(Math.Truncate(ResultTemp[iLoopCount] % Math.Pow(10, multipleCnt)));
                    }
                }
                else LastResult[iLoopCount] = "00000";
            }

            return LastResult;
        }

        public override bool DataRequest(int _ID)
        {
            bool _Result = true;

            OnMainProcessCommand(eMainProcCmd.REQUEST, _ID);

            return _Result;
        }

        public override bool InspectionComplete(int _ID, bool _Flag)
        {
            bool _Result = true;
            int _CompleteCmdBit = 0;

            if (_ID == 0)       _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            else if (_ID == 1)  _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE_2);
            else if (_ID == 2)  _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE_3);

            DIOWnd.SetOutputSignal((short)_CompleteCmdBit, _Flag, 250);

            return _Result;
        }

        #region Communication Event Function
        /// <summary>
        /// DIO => MainProcess Event
        /// </summary>
        /// <param name="_BitNum"></param>
        /// <param name="_Signal"></param>
        private void InputChangeEventFunction(short _BitNum, bool _Signal)
        {
            switch (_BitNum)
            {
                case DIO_DEF.IN_RESET:      Reset(0);       break;
                case DIO_DEF.IN_TRG:        TriggerOn(0);   break;
                case DIO_DEF.IN_REQUEST:    DataRequest(0); break;
                case DIO_DEF.IN_RESET_2:    Reset(1);       break;
                case DIO_DEF.IN_TRG_2:      TriggerOn(1);   break;
                case DIO_DEF.IN_REQUEST_2:  DataRequest(1); break;
                case DIO_DEF.IN_RESET_3:    Reset(2);       break;
                case DIO_DEF.IN_TRG_3:      TriggerOn(2);   break;
                case DIO_DEF.IN_REQUEST_3:  DataRequest(2); break;
            }
        }

        /// <summary>
        /// Ethernet => MainProcess Event
        /// </summary>
        /// <param name="_RecvMessage"></param>
        private void ReceiveStringEventFunction(string[] _RecvMessage)
        {
            if (_RecvMessage[0] == "V1")      AckStructs[0].AckComplete = true;
            else if (_RecvMessage[0] == "V2") AckStructs[1].AckComplete = true;
            else if (_RecvMessage[0] == "V3") AckStructs[2].AckComplete = true;
        }
        #endregion Communication Event Function

        private void ThreadAckSignalCheckFunc()
        {
            try
            {
                while (false == IsThreadAckSignalCheckExit)
                {
                    Thread.Sleep(WaitingPeriod);

                    for (int iLoopCount = 0; iLoopCount < AckStructs.Length; ++iLoopCount)
                    {
                        if (true == AckStructs[iLoopCount].AckRequest)           AckStructs[iLoopCount].WaitTime += WaitingPeriod;
                        if (true == AckStructs[iLoopCount].AckComplete)          AckStructs[iLoopCount].SetStatus(ACK_STATUS.COMPLETE, false);
                        if (AckStructs[iLoopCount].WaitTime >= WaitingLimitTime) AckStructs[iLoopCount].SetStatus(ACK_STATUS.TIME_OVER, false);
                    }
                }
            }

            catch
            {

            }
        }
    }

    public class AckStruct
    {
        public ACK_STATUS AckStatus = ACK_STATUS.WAIT;
        public bool AckRequest = false;
        public bool AckComplete = false;
        public short WaitTime = 0;

        public void Initialize()
        {
            WaitTime = 0;
            AckRequest = true;
            AckComplete = false;
            AckStatus = ACK_STATUS.WAIT;
        }

        public void SetStatus(ACK_STATUS _AckStatus, bool _AckRequest)
        {
            AckStatus = _AckStatus;
            AckRequest = _AckRequest;
        }
    }

    public enum ACK_STATUS { TIME_OVER, COMPLETE, FAIL, WAIT }
}
