using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InspectionSystemManager;

namespace KPVisionInspectionFramework
{
    public class MainProcessBase
    {
        public delegate void AckSignalSendHandler(object _Signal);
        public event AckSignalSendHandler AckSignalSendEvent;

        public virtual bool TriggerOn(CInspectionSystemManager[] _InspSysManager, int _ID)
        {
            return true;
        }

        public virtual bool Reset()
        {
            return true;
        }

        protected virtual void OnAckSignalSending(object _Signal)
        {
            var _AckSignalSendEvent = AckSignalSendEvent;
            _AckSignalSendEvent?.Invoke(_Signal);
        }
    }
}
