using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

enum eCameraType { Dalsa, Euresys }

namespace CameraManager
{
    public class CCameraManager
    {
        public delegate void ImageDisplayHandler(byte[] GrabImage);
        public event ImageDisplayHandler ImageDisplayEvent;

        private CEuresysManager objEuresysManager;

        private string CameraType;
        bool CamLiveFlag = false;

        public CCameraManager()
        {

        }

        public bool Initialize(int ID, string CamType)
        {
            bool _Result = true;

            CameraType = CamType;

            if (CameraType == eCameraType.Euresys.ToString())
            {
                if (ID == 0)
                {
                    objEuresysManager = new CEuresysManager();
                    objEuresysManager.EuresysGrabEvent += new CEuresysManager.EuresysGrabHandler(ImageDisplayEvent);
                }
            }

            return _Result;
        }

        public void DeInitialilze()
        {
            if (CameraType == eCameraType.Euresys.ToString())
            {
                objEuresysManager.EuresysGrabEvent -= new CEuresysManager.EuresysGrabHandler(ImageDisplayEvent);
                objEuresysManager.DeInitialize();
            }
        }

        public void CamLive()
        {
            CamLiveFlag = !CamLiveFlag;
            if (CameraType == eCameraType.Euresys.ToString()) objEuresysManager.SetActive(CamLiveFlag);
        }
    }
}
