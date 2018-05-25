using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using LogMessageManager;
using ParameterManager;

namespace InspectionSystemManager
{
    public class CInspectionSystemManager
    {
        private InspectionWindow InspWnd;
        private string InspWndName;

        public int ID = 0;
        public bool IsSimulationMode = false;
        public eProjectType ProjectType = 0;
        public eProjectItem ProjectItem = 0;

        private Point WndLocation = new Point(0, 0);

        public delegate void InspSysManagerHandler(eISMCMD _Command, object _Value = null);
        public event InspSysManagerHandler InspSysManagerEvent;

        #region Initialize & DeInitialize
        public CInspectionSystemManager(int _ID, string _SystemName, bool _IsSimulationMode)
        {
            ID = _ID;
            IsSimulationMode = _IsSimulationMode;

            InspWnd = new InspectionWindow();
            InspWndName = String.Format(" {0} Inspection Window", _SystemName);
        }

        public void Initialize(Object _OwnerForm, int _ProjectType, InspectionSystemManagerParameter _InspSysManagerParam)
        {
            ProjectType = (eProjectType)_ProjectType;
            ProjectItem = (eProjectItem)_InspSysManagerParam.ProjectItem;

            SetISMParameter(_InspSysManagerParam);

            InspWnd.InspectionWindowEvent += new InspectionWindow.InspectionWindowHandler(InspectionWindowEventFunction);
            InspWnd.Initialize(_OwnerForm, ID, ProjectItem, InspWndName);
        }

        public void DeInitialize()
        {
            InspWnd.InspectionWindowEvent -= new InspectionWindow.InspectionWindowHandler(InspectionWindowEventFunction);
            InspWnd.Deinitialize();
        }

        public void GetDisplayWindowInfo(out double _DisplayZoom, out double _DisplayPanX, out double _DisplayPanY)
        {
            InspWnd.GetWindowDisplayInfo(out _DisplayZoom, out _DisplayPanX, out _DisplayPanY);
        }

        public void GetWindowLocation(out Point _InspWndLocation)
        {
            _InspWndLocation = InspWnd.Location;
        }

        public void GetWindowSize(out Size _InspWndSize)
        {
            _InspWndSize = InspWnd.Size;
        }

        public void ShowWindows()
        {
            InspWnd.Show();
            InspWnd.SetLocation(WndLocation.X, WndLocation.Y);
        }
        #endregion Initialize & DeInitialize

        #region Parameter Management
        /// <summary>
        ///  Set System Parameter (Main -> Inspection System Manager)
        /// </summary>
        /// <param name="_InspSysManagerParam">System Parameter</param>
        private void SetISMParameter(InspectionSystemManagerParameter _InspSysManagerParam)
        {
            //CameraType = _InspSysManagerParam.CameraType;
            InspWnd.SetLocation(_InspSysManagerParam.InspWndParam.LocationX, _InspSysManagerParam.InspWndParam.LocationY);
            InspWnd.SetWindowSize(_InspSysManagerParam.InspWndParam.Width, _InspSysManagerParam.InspWndParam.Height);
            
            WndLocation = new Point(_InspSysManagerParam.InspWndParam.LocationX, _InspSysManagerParam.InspWndParam.LocationY);
        }
        #endregion Parameter Management

        #region Event : Inspection Window Event & Function
        private void InspectionWindowEventFunction(eIWCMD _Command, object _Value)
        {
            switch (_Command)
            {
                case eIWCMD.TEACHING:   Teaching(_Value);   break;
            }
        }

        private void Teaching(object _Value)
        {
            InspSysManagerEvent(eISMCMD.TEACHING_STATUS, Convert.ToBoolean(_Value));
        }
        #endregion Event : Inspection Window Event
    }
}
