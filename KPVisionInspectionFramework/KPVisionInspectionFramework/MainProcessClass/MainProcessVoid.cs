using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LogMessageManager;
using ParameterManager;
using DIOControlManager;
using EthernetServerManager;

namespace KPVisionInspectionFramework
{
    public class MainProcessVoid : MainProcessBase
    {
        private DIOControlWindow DIOWnd;
        private EthernetWindow EthernetServWnd;

        private AckStruct[] AckStructs;

        private bool AckFlag = false;
        public bool NakFlag = false;

        private Thread ThreadAckSignalCheck;
        private bool IsThreadAckSignalCheckExit;
        private bool AckSignal = false;

        private short WaitingPeriod = 50;
        private short WaitingLimitTime = 5000;

        #region Initialize & DeInitialize
        public MainProcessVoid()
        {

        }

        public override void Initialize(string _CommonFolderPath)
        {
            DIOWnd = new DIOControlWindow((int)eProjectType.VOID, _CommonFolderPath);
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

        #region DIO Window
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
        #endregion

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

            _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);

            if (_CompleteCmdBit >= 0) DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0) DIOWnd.SetOutputSignal((short)_ReadyCmdBit, true, 250);

            return _Result;
        }

        public override bool SendResultData(SendResultParameter _ResultParam)
        {
            bool _Result = true;

            if (_ResultParam.ProjectItem == eProjectItem.VOID_INSP)
            {
                string _VisionString, _ResultString;
                _VisionString = String.Format("V{0}", _ResultParam.ID + 4);

                if (_ResultParam.IsGood) _ResultString = "OK";
                else _ResultString = "NG";

                var _SendResult = _ResultParam.SendResult as SendVoidResult;

                if (_SendResult == null)
                {
                    _SendResult = new SendVoidResult();
                    _ResultString = "NG";
                }

                string _ResultDataString = string.Format("{0},{1},00000,00000", _VisionString, _ResultString);
                EthernetServWnd.SendResultData(_ResultDataString);
                AckStructs[_ResultParam.ID].Initialize();
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

            if (_ID == 0) _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);

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
            }
        }

        /// <summary>
        /// Ethernet => MainProcess Event
        /// </summary>
        /// <param name="_RecvMessage"></param>
        private void ReceiveStringEventFunction(string[] _RecvMessage)
        {
            if (_RecvMessage[0] == "V1") AckStructs[0].AckComplete = true;
        }
        #endregion

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
}
