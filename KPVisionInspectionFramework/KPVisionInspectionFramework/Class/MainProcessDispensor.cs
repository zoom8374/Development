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
        }

        public void DeInitialize()
        {
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

        public override bool TriggerOn(int _ID)
        {
            bool _Result = false;

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : Trigger{0} On Event", _ID + 1));
            OnMainProcessCommand(eMainProcCmd.TRG, _ID);

            return _Result;
        }

        public override bool Reset()
        {
            bool _Result = false;

            int _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_COMPLETE);
            int _ReadyCmdBit    = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_READY);

            if (_CompleteCmdBit >= 0)   DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0)      DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);

            return _Result;
        }

        #region Communication Event Function
        private void InputChangeEventFunction(short _BitNum, bool _Signal)
        {
            switch (_BitNum)
            {
                case DIO_DEF.IN_TRG1:   TriggerOn(0); break;
                case DIO_DEF.IN_RESET:  Reset(); break;
            }
        }
        #endregion Communication Event Function
    }
}
