﻿using System;
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
        private InspectionParameter InspParam = new InspectionParameter();

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

        public void Initialize(Object _OwnerForm, int _ProjectType, InspectionSystemManagerParameter _InspSysManagerParam, InspectionParameter _InspParam)
        {
            ProjectType = (eProjectType)_ProjectType;
            ProjectItem = (eProjectItem)_InspSysManagerParam.ProjectItem;

            SetISMParameter(_InspSysManagerParam);
            SetInspectionParameter(_InspParam);

            InspWnd.InspectionWindowEvent += new InspectionWindow.InspectionWindowHandler(InspectionWindowEventFunction);
            InspWnd.Initialize(_OwnerForm, ID, InspParam, ProjectItem, InspWndName);
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

        /// <summary>
        /// Set Inspection Parameter : (InspectionWindow(Teaching) -> Inspection System Manager)
        /// </summary>
        /// <param name="_InspParam">Inspection Parameter</param>
        /// <param name="_IsNew">Is New Parameter</param>
        public void SetInspectionParameter(InspectionParameter _InspParam, bool _IsNew = true)
        {
            if (InspParam != null) FreeInspectionParameters(ref InspParam);
            CParameterManager.RecipeCopy(_InspParam, ref InspParam);

            //Reference File(VPP) Load
        }

        public void FreeInspectionParameters(ref InspectionParameter _InspParam)
        {
            for (int iLoopCount = 0; iLoopCount < _InspParam.InspAreaParam.Count; ++iLoopCount)
            {
                for (int jLoopCount = 0; jLoopCount < _InspParam.InspAreaParam[iLoopCount].InspAlgoParam.Count; ++jLoopCount)
                    FreeInspectionParameter(ref _InspParam, iLoopCount, jLoopCount);
            }
        }

        public void FreeInspectionParameter(ref InspectionParameter _InspParam, int _AreaIndex, int _AlgoIndex)
        {
            if (eAlgoType.C_PATTERN == (eAlgoType)_InspParam.InspAreaParam[_AreaIndex].InspAlgoParam[_AlgoIndex].AlgoType)
            {

            }
        }

        public void GetInspectionParameterRef(ref InspectionParameter _InspParamDest)
        {
            if (_InspParamDest != null) FreeInspectionParameters(ref _InspParamDest);
            CParameterManager.RecipeCopy(InspParam, ref _InspParamDest);

            for (int iLoopCount = 0; iLoopCount < InspParam.InspAreaParam.Count; ++iLoopCount)
            {
                for (int jLoopCount = 0; jLoopCount < InspParam.InspAreaParam[iLoopCount].InspAlgoParam.Count; ++jLoopCount)
                {
                    eAlgoType _AlgoType = (eAlgoType)InspParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoType;

                    if (eAlgoType.C_PATTERN == _AlgoType)
                    {

                    }
                }
            }
        }
        #endregion Parameter Management

        #region Event : Inspection Window Event & Function
        private void InspectionWindowEventFunction(eIWCMD _Command, object _Value)
        {
            switch (_Command)
            {
                case eIWCMD.TEACHING:   Teaching(_Value);           break;
                case eIWCMD.TEACH_OK:   TeachingComplete(_Value);   break;
                case eIWCMD.TEACH_SAVE: TeachingSave(_Value);       break;
            }
        }

        private void Teaching(object _Value)
        {
            InspSysManagerEvent(eISMCMD.TEACHING_STATUS, Convert.ToBoolean(_Value));
        }

        private void TeachingComplete(object _Value)
        {
            InspectionParameter _InspParam = (InspectionParameter)_Value;
            SetInspectionParameter(_InspParam, false);
        }
        private void TeachingSave(object _Value)
        {
            InspSysManagerEvent(eISMCMD.TEACHING_SAVE, Convert.ToInt32(_Value));
        }
        #endregion Event : Inspection Window Event
    }
}
