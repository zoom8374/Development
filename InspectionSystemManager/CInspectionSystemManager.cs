using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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

        #region Initialize & DeInitialize
        public CInspectionSystemManager(int _ID, string _SystemName, bool _IsSimulationMode)
        {
            ID = _ID;
            IsSimulationMode = _IsSimulationMode;

            InspWnd = new InspectionWindow();
            InspWndName = _SystemName + " Display";
        }

        //public void Initialize(Object _OwnerForm, InspectionSystemManagerParameter _InspSysManagerParam, InspectionParameter _InspParameter, eProjectType _ProjectType)
        public void Initialize(Object _OwnerForm, InspectionSystemManagerParameter _InspSysManagerParam, eProjectType _ProjectType)
        {
            SetISMParameter(_InspSysManagerParam);

            InspWnd.Initialize(_OwnerForm, this, InspWndName);
        }

        public void DeInitialize()
        {

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
    }
}
