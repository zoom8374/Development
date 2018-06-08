using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;

using ParameterManager;

namespace InspectionSystemManager
{
    class InspectionNeedleCircleFind
    {
        private CogFindCircleTool       FindCircleProc;
        private CogFindCircleResults    FindCircleResults;

        #region Initialize & Deinitialize
        public InspectionNeedleCircleFind()
        {
            FindCircleProc = new CogFindCircleTool();
            FindCircleResults = new CogFindCircleResults();
        }

        public void Initialize()
        {

        }

        public void DeInitialize()
        {
            FindCircleProc.Dispose();
        }
        #endregion Initialize & Deinitialize

        public bool Run(CogImage8Grey _SrcImage, CogNeedleFindAlgo _CogNeedleFindAlgo, ref CogNeedleFindResult _CogNeedleFindResult, int _NgNumber = 0)
        {
            bool _Result = true;

            SetCaliper(_CogNeedleFindAlgo.CaliperNumber, _CogNeedleFindAlgo.CaliperSearchLength, _CogNeedleFindAlgo.CaliperProjectionLength, _CogNeedleFindAlgo.CaliperSearchDirection);
            SetCircularArc(_CogNeedleFindAlgo.ArcCenterX, _CogNeedleFindAlgo.ArcCenterY, _CogNeedleFindAlgo.ArcRadius, _CogNeedleFindAlgo.ArcAngleStart, _CogNeedleFindAlgo.ArcAngleSpan);

            if (true == Inspection(_SrcImage)) GetResult();

            if (FindCircleResults != null && FindCircleResults.Count > 0)_CogNeedleFindResult.IsGood = true;
            else    _CogNeedleFindResult.IsGood = false;

            if (!_CogNeedleFindResult.IsGood)
            {
                _CogNeedleFindResult.CenterX = _CogNeedleFindAlgo.ArcCenterX;
                _CogNeedleFindResult.CenterY = _CogNeedleFindAlgo.ArcCenterY;
                _CogNeedleFindResult.Radius = _CogNeedleFindAlgo.ArcRadius;
                _CogNeedleFindResult.OriginX = 0;
                _CogNeedleFindResult.OriginY = 0;
            }

            else
            {
                _CogNeedleFindResult.CenterX = FindCircleResults.GetCircle().CenterX;
                _CogNeedleFindResult.CenterY = FindCircleResults.GetCircle().CenterY;
                _CogNeedleFindResult.Radius = FindCircleResults.GetCircle().Radius;
                _CogNeedleFindResult.OriginX = FindCircleResults.GetCircle().CenterX;
                _CogNeedleFindResult.OriginY = FindCircleResults.GetCircle().CenterY;
            }

            return _Result;
        }

        private bool Inspection(CogImage8Grey _SrcImage)
        {
            bool _Result = true;

            try
            {
                FindCircleProc.InputImage = _SrcImage;
                FindCircleProc.Run();
            }

            catch
            {
                _Result = false;
            }

            return _Result;
        }

        private void SetCaliper(int _CaliperNumber, double _SearchLength, double _ProjectionLength, int _eSearchDir)
        {
            FindCircleProc.RunParams.NumCalipers = _CaliperNumber;
            FindCircleProc.RunParams.CaliperSearchLength = _SearchLength;
            FindCircleProc.RunParams.CaliperProjectionLength = _ProjectionLength;
            FindCircleProc.RunParams.CaliperSearchDirection = (CogFindCircleSearchDirectionConstants)_eSearchDir;
        }

        private void SetCircularArc(double _CenterX, double _CenterY, double _Radius, double _AngleStart, double _AngleSpan)
        {
            FindCircleProc.RunParams.ExpectedCircularArc.CenterX = _CenterX;
            FindCircleProc.RunParams.ExpectedCircularArc.CenterY = _CenterY;
            FindCircleProc.RunParams.ExpectedCircularArc.Radius = _Radius;
            FindCircleProc.RunParams.ExpectedCircularArc.AngleStart = _AngleStart;
            FindCircleProc.RunParams.ExpectedCircularArc.AngleSpan = _AngleSpan;
        }

        private void GetResult()
        {
            FindCircleResults = FindCircleProc.Results;
        }
    }
}
