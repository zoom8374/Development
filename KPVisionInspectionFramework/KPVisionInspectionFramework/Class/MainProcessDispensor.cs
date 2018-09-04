using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using InspectionSystemManager;
using LogMessageManager;
using ParameterManager;
using DIOControlManager;
using EthernetManager;

namespace KPVisionInspectionFramework
{
    public class MainProcessDispensor : MainProcessBase
    {
        private DIOControlWindow DIOWnd;
        private EthernetWindow   EthernetWnd;

        private AckStruct[] AckStructs;

        private bool AckFlag = false;
        public bool NakFlag = false;

        private Thread ThreadAckSignalCheck;
        private bool IsThreadAckSignalCheckExit;
        private bool IsThreadAckSignalTrigger;
        private bool AckSignal = false;

        private short WaitingPeriod = 50;
        private short WaitingLimitTime = 5000;
        private short WaitingTime = 0;
        
        #region Initialize & DeInitialize
        public MainProcessDispensor()
        {
            DIOWnd = new DIOControlWindow((int)eProjectType.DISPENSER);
            DIOWnd.InputChangedEvent += new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            DIOWnd.Initialize();

            EthernetWnd = new EthernetWindow();
            EthernetWnd.Initialize();
            EthernetWnd.ReceiveStringEvent += new EthernetWindow.ReceiveStringHandler(ReceiveStringEventFunction);

            int _AutoCmdBit     = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            int _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            int _ReadyCmdBit    = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);

            if (_AutoCmdBit >= 0)     DIOWnd.SetOutputSignal((short)_AutoCmdBit, false);
            if (_CompleteCmdBit >= 0) DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0)    DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);

            AckStructs = new AckStruct[3];
            for (int iLoopCount = 0; iLoopCount < 3; ++iLoopCount) AckStructs[iLoopCount] = new AckStruct(); ;

            ThreadAckSignalCheck = new Thread(ThreadAckSignalCheckFunc);
            ThreadAckSignalCheck.IsBackground = true;
            IsThreadAckSignalCheckExit = false;
            IsThreadAckSignalTrigger = false;
        }

        public void DeInitialize()
        {
            int _AutoCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            int _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            int _ReadyCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);

            if (_AutoCmdBit >= 0) DIOWnd.SetOutputSignal((short)_AutoCmdBit, false);
            if (_CompleteCmdBit >= 0) DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0) DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);

            DIOWnd.InputChangedEvent -= new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            DIOWnd.DeInitialize();

            EthernetWnd.ReceiveStringEvent -= new EthernetWindow.ReceiveStringHandler(ReceiveStringEventFunction);
            EthernetWnd.DeInitialize();
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
            EthernetWnd.ShowEthernetWindow();
        }

        public override bool GetEhernetWindowShown()
        {
            return EthernetWnd.IsShowWindow;
        }

        public override void SetEthernetWindowTopMost(bool _IsTopMost)
        {
            EthernetWnd.TopMost = _IsTopMost;
        }
        #endregion Ethernet Window Function

        public override bool AutoMode(bool _Flag)
        {
            bool _Result = true;

            int _AutoCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            int _ReadyCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);
            DIOWnd.SetOutputSignal((short)_AutoCmdBit, _Flag);
            DIOWnd.SetOutputSignal((short)_ReadyCmdBit, _Flag);

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
                _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE_2);
                _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY_2);
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
                string _VisionString, _ResultString, _DataStringLowX, _DataStringHiX, _DataStringLowY, _DataStringHiY;
                _VisionString = String.Format("V{0}", _ResultParam.ID + 1);

                if (_ResultParam.IsGood) _ResultString = "OK";
                else                     _ResultString = "NG";

                var _SendResult = _ResultParam.SendResult as SendNeedleAlignResult;
                //_DataStringHiX = String.Format("{0:D2}", _SendResult.AlignX);
                //_DataStringLowX = String.Format("{0:F2}", _SendResult.AlignX);
                //_DataStringHiY = String.Format("{0:D2}", _SendResult.AlignY);
                //_DataStringLowY = String.Format("{0:F2", _SendResult.AlignY);

                string _ResultDataString = String.Format("{0},{1},{2},{3}", _VisionString, _ResultString, _SendResult.AlignX, _SendResult.AlignY);
                EthernetWnd.SendResultData(_ResultDataString);

                //AckStructs[_ResultParam.ID].WaitTime = 0;
                //AckStructs[_ResultParam.ID].AckRequest = true;
                //AckStructs[_ResultParam.ID].AckComplete = false;
                //AckStructs[_ResultParam.ID].AckStatus = ACK_STATUS.WAIT;
                AckStructs[_ResultParam.ID].Initialize();
            }

            else if (_ResultParam.ProjectItem == eProjectItem.LEAD_INSP)
            {

            }

            return _Result;
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
            if (_RecvMessage[1] == "V1") AckStructs[0].AckComplete = true;
            else if (_RecvMessage[1] == "V2") AckStructs[1].AckComplete = true;
            else if (_RecvMessage[1] == "V3") AckStructs[2].AckComplete = true;
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
                        if (true == AckStructs[iLoopCount].AckRequest)      AckStructs[iLoopCount].WaitTime += WaitingPeriod;
                        if (true == AckStructs[iLoopCount].AckComplete)     AckStructs[iLoopCount].SetStatus(ACK_STATUS.COMPLETE, false);
                        if (AckStructs[iLoopCount].WaitTime >= WaitingTime) AckStructs[iLoopCount].SetStatus(ACK_STATUS.TIME_OVER, false);
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
