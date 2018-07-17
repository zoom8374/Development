using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ParameterManager; 

namespace CameraManager
{
    public class CCameraManager
    {
        public delegate void ImageGrabHandler(byte[] GrabImage);
        public event ImageGrabHandler ImageGrabEvent;

        public delegate void ImageGrabIntPtrHandler(IntPtr GrabImage);
        public event ImageGrabIntPtrHandler ImageGrabIntPtrEvent;

        private CEuresysManager objEuresysManager;
        private CBaslerManager objBaslerManager;

        private string CameraType;
        bool CamLiveFlag = false;

        public CCameraManager()
        {

        }

        public bool Initialize(int _ID, string _CamType, string _CamInfo)
        {
            bool _Result = true;

            CameraType = _CamType;

            if (CameraType == eCameraType.Euresys.ToString())
            {
                if (_ID == 0)
                {
                    objEuresysManager = new CEuresysManager();
                    objEuresysManager.EuresysGrabEvent += new CEuresysManager.EuresysGrabHandler(ImageGrabEvent);
                }
            }

            else if (CameraType == eCameraType.BaslerGE.ToString())
            {
                objBaslerManager = new CBaslerManager(1);
                objBaslerManager.Initialize(_ID, _CamInfo);
                objBaslerManager.BaslerGrabEvent += new CBaslerManager.BaslerGrabHandler(ImageGrabEvent);
                //objBaslerManager.BaslerGrabEvent += new CBaslerManager.BaslerGrabHandler(ImageGrabIntPtrEvent);
            }

            return _Result;
        }

        public void DeInitialilze()
        {
            if (CameraType == eCameraType.Euresys.ToString())
            {
                objEuresysManager.EuresysGrabEvent -= new CEuresysManager.EuresysGrabHandler(ImageGrabEvent);
                objEuresysManager.DeInitialize();
            }

            else if (CameraType == eCameraType.BaslerGE.ToString())
            {
                objBaslerManager.BaslerGrabEvent -= new CBaslerManager.BaslerGrabHandler(ImageGrabEvent);
                objBaslerManager.DeInitialize();
            }
        }

        public void CamLive(bool _IsLive = false)
        {
            CamLiveFlag = !CamLiveFlag;
            if (CameraType == eCameraType.Euresys.ToString())       objEuresysManager.SetActive(_IsLive);
            else if (CameraType == eCameraType.BaslerGE.ToString()) objBaslerManager.Continuous(_IsLive);
        }
    }
}
