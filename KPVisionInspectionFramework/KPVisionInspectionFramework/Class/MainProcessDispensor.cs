using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        #region Initialize & DeInitialize
        public MainProcessDispensor()
        {
            DIOWnd = new DIOControlWindow((int)eProjectType.DISPENSER);
            DIOWnd.InputChangedEvent += new DIOControlWindow.InputChangedHandler(InputChangeEventFunction);
            DIOWnd.Initialize();

            EthernetWnd = new EthernetWindow();
            EthernetWnd.Initialize("192.168.0.100", 5050);

            int _AutoCmdBit     = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_AUTO);
            int _CompleteCmdBit = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            int _ReadyCmdBit    = DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);

            if (_AutoCmdBit >= 0)     DIOWnd.SetOutputSignal((short)_AutoCmdBit, false);
            if (_CompleteCmdBit >= 0) DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0)    DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);
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

        public override bool Reset()
        {
            bool _Result = true;

            int _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_COMPLETE);
            int _ReadyCmdBit    = (short)DIOWnd.DioBaseCmd.OutputBitIndexCheck((int)DIO_DEF.OUT_READY);

            if (_CompleteCmdBit >= 0)   DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0)      DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);

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

            DIOWnd.SetOutputSignal((short)_CompleteCmdBit, _Flag);

            return _Result;
        }

        #region Communication Event Function
        private void InputChangeEventFunction(short _BitNum, bool _Signal)
        {
            switch (_BitNum)
            {
                case DIO_DEF.IN_RESET:      Reset();        break;
                case DIO_DEF.IN_TRG:        TriggerOn(0);   break;
                case DIO_DEF.IN_REQUEST:    DataRequest(0); break;
                case DIO_DEF.IN_RESET_2:    Reset();        break;
                case DIO_DEF.IN_TRG_2:      TriggerOn(1);   break;
                case DIO_DEF.IN_REQUEST_2:  DataRequest(1); break;
                case DIO_DEF.IN_RESET_3:    Reset();        break;
                case DIO_DEF.IN_TRG_3:      TriggerOn(2);   break;
                case DIO_DEF.IN_REQUEST_3:  DataRequest(2); break;
            }
        }
        #endregion Communication Event Function
    }
}
