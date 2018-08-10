using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InspectionSystemManager;
using ParameterManager;

namespace KPVisionInspectionFramework
{
    public class MainProcessBase
    {
        public delegate void MainProcessCommandHandler(eMainProcCmd _MainCmd, object _Value);
        public event MainProcessCommandHandler MainProcessCommandEvent;

        #region DIO Window Function
        public virtual void ShowDIOWindow()
        {

        }

        public virtual bool GetDIOWindowShown()
        {
            return true;
        }

        public virtual void SetDIOWindowTopMost(bool _IsTopMost)
        {
            
        }

        public virtual void SetDIOOutputSignal(short _BitNumber, bool _Signal)
        {

        }
        #endregion DIO Window Function

        #region Serial Window Function
        public virtual void ShowSerialWindow()
        {

        }

        public virtual bool GetSerialWindowShown()
        {
            return true;
        }

        public virtual void SetSerialWindowTopMost(bool _IsTopMost)
        {

        }
        #endregion Serial Window Function

        protected virtual void OnMainProcessCommand(eMainProcCmd _MainCmd, object _Value)
        {
            var _MainProcessCommandEvent = MainProcessCommandEvent;
            _MainProcessCommandEvent?.Invoke(_MainCmd, _Value);
        }


        public virtual bool TriggerOn(int _ID)
        {
            return true;
        }

        public virtual bool Reset()
        {
            return true;
        }
    }
}
