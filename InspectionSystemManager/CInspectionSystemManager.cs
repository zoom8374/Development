﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

using LogMessageManager;
using ParameterManager;

namespace InspectionSystemManager
{
    public class CInspectionSystemManager
    {
        private InspectionParameter InspParam = new InspectionParameter();

        private InspectionWindow InspWnd;
        private string           InspWndName;

        private Thread ThreadInspection;
        private bool IsThreadInspectionExit = false;
        private bool IsThreadInspectionTrigger = false;

        private  int  ID = 0;
        private  bool IsSimulationMode = false;
        private string CameraType;
        private eProjectType ProjectType = 0;
        private eProjectItem ProjectItem = 0;

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

            ThreadInspection = new Thread(ThreadInspectionFunction);
            IsThreadInspectionExit = false;
            IsThreadInspectionTrigger = false;
            ThreadInspection.Start();
        }

        public void Initialize(Object _OwnerForm, int _ProjectType, InspectionSystemManagerParameter _InspSysManagerParam, InspectionParameter _InspParam)
        {
            ProjectType = (eProjectType)_ProjectType;
            ProjectItem = (eProjectItem)_InspSysManagerParam.ProjectItem;

            SetISMParameter(_InspSysManagerParam);
            SetInspectionParameter(_InspParam);

            InspWnd.Initialize(_OwnerForm, ID, InspParam, ProjectItem, InspWndName, IsSimulationMode);
            InspWnd.InitializeCam(_InspSysManagerParam.CameraType, _InspSysManagerParam.CameraConfigInfo, Convert.ToInt32(_InspSysManagerParam.ImageSizeWidth), Convert.ToInt32(_InspSysManagerParam.ImageSizeHeight));
            InspWnd.InspectionWindowEvent += new InspectionWindow.InspectionWindowHandler(InspectionWindowEventFunction);
        }

        public void DeInitialize()
        {
            InspWnd.InspectionWindowEvent -= new InspectionWindow.InspectionWindowHandler(InspectionWindowEventFunction);
            InspWnd.Deinitialize();
        }

        public void SetSystemMode(eSysMode _SystemMode)
        {
            InspWnd.SetSystemMode(_SystemMode);
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
            ////InspWnd.SetLocation(WndLocation.X, WndLocation.Y);
        }
        #endregion Initialize & DeInitialize

        #region Parameter Management
        /// <summary>
        ///  Set System Parameter (Main -> Inspection System Manager)
        /// </summary>
        /// <param name="_InspSysManagerParam">System Parameter</param>
        private void SetISMParameter(InspectionSystemManagerParameter _InspSysManagerParam)
        {
            CameraType = _InspSysManagerParam.CameraType;
            InspWnd.SetLocation(_InspSysManagerParam.InspWndParam.LocationX, _InspSysManagerParam.InspWndParam.LocationY);
            InspWnd.SetWindowSize(_InspSysManagerParam.InspWndParam.Width, _InspSysManagerParam.InspWndParam.Height);
            InspWnd.SetWindowDisplayInfo(_InspSysManagerParam.InspWndParam.DisplayZoomValue, _InspSysManagerParam.InspWndParam.DisplayPanXValue, _InspSysManagerParam.InspWndParam.DisplayPanYValue);

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

            InspWnd.SetInspectionParameter(InspParam, _IsNew);

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

        #region Vision Management
        private void ImageGrab()
        {
            ImageGrabSnap();
        }

        private void ImageGrabStop()
        {

        }

        private void ImageGrabSnap()
        {
            //Camera 모듈 Check


            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} ImageGrabSnap Complete", ID + 1));


            InspWnd.IsThreadInspectionProcessTrigger = true;
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, "ISM{0} IsThreadInspectionProcessTrigger = true");
        }

        private void ImageGrabLive()
        {

        }

        private void ImageGrabLiveStop()
        {

        }
        #endregion Vision Management

        #region Event : Inspection Window Event & Function
        private void InspectionWindowEventFunction(eIWCMD _Command, object _Value)
        {
            switch (_Command)
            {
                case eIWCMD.TEACHING:       Teaching(_Value);           break;
                case eIWCMD.TEACH_OK:       TeachingComplete(_Value);   break;
                case eIWCMD.TEACH_SAVE:     TeachingSave(_Value);       break;
                case eIWCMD.LIGHT_CONTROL:  LightControl(_Value);       break;
                case eIWCMD.SEND_DATA:      SendResultData(_Value);     break;
            }
        }

        private void Teaching(object _Value)
        {
            var _InspSysManagerEvent = InspSysManagerEvent;
            _InspSysManagerEvent?.Invoke(eISMCMD.TEACHING_STATUS, Convert.ToBoolean(_Value));
        }

        private void TeachingComplete(object _Value)
        {
            //InspectionParameter _InspParam = (InspectionParameter)_Value;
            var _InspParam = _Value as InspectionParameter;
            SetInspectionParameter(_InspParam, false);
        }

        private void TeachingSave(object _Value)
        {
            var _InspSysManagerEvent = InspSysManagerEvent;
            _InspSysManagerEvent?.Invoke(eISMCMD.TEACHING_SAVE, Convert.ToInt32(_Value));
        }

        private void LightControl(object _Value)
        {
            var _InspSysManagerEvent = InspSysManagerEvent;
            _InspSysManagerEvent?.Invoke(eISMCMD.LIGHT_CONTROL, Convert.ToBoolean(_Value));
        }

        private void SendResultData(object _Value)
        {
            InspSysManagerEvent(eISMCMD.SEND_DATA, _Value);
        }
        #endregion Event : Inspection Window Event

        public void TriggerOn()
        {
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} Trigger ON!", ID + 1));

            InspWnd.InspMode = eInspMode.TRI_INSP;
            InspWnd.IsInspectionComplete = false;
            IsThreadInspectionTrigger = true;
        }

        private void ThreadInspectionFunction()
        {
            try
            {
                while (false == IsThreadInspectionExit)
                {
                    if (true == IsThreadInspectionTrigger)
                    {
                        IsThreadInspectionTrigger = false;
                        InspWnd.IsInspectionComplete = false;
                        CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("Vision : ISM{0} IsInspectionComplete false", ID + 1));

                        if (!IsSimulationMode)  ImageGrabSnap();
                        else                    InspWnd.IsThreadInspectionProcessTrigger = true;
                    }

                    Thread.Sleep(10);
                }
            }

            catch
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, String.Format("Vision : ThreadInspectionFunction Exception!!"));
            }
        }
    }
}
