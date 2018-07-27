using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InspectionSystemManager;
using LogMessageManager;
using ParameterManager;
using DIOControlManager;

namespace KPVisionInspectionFramework
{
    public class MainProcessID : MainProcessBase
    {
        private DIOControlWindow DIOWnd;

        public void InitDioControlWindow(DIOControlWindow _DioWnd)
        {
            DIOWnd = _DioWnd;
        }

        public override bool TriggerOn(CInspectionSystemManager[] _InspSysManager, int _ID)
        {
            bool _Result = false;

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : Trigger{0} On Event", _ID + 1));
            _InspSysManager[_ID].TriggerOn();

            return _Result;
        }

        public override bool Reset()
        {
            bool _Result = false;

            int _CompleteCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_COMPLETE);
            int _ReadyCmdBit = (short)DIOWnd.DioBaseCmd.OutputBitCheck(AirBlowCmd.OUT_READY);

            if (_CompleteCmdBit >= 0)   DIOWnd.SetOutputSignal((short)_CompleteCmdBit, false);
            if (_ReadyCmdBit >= 0)      DIOWnd.SetOutputSignal((short)_ReadyCmdBit, false);

            return _Result;
        }

        public void SetIOModule(DIOControlWindow _DioWnd)
        {
            _DioWnd.SetOutputSignal(DIO_DEF.OUT_COMPLETE, false);
        }
    }
}
