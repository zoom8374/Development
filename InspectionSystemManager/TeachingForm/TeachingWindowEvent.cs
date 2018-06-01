using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;

using ParameterManager;

namespace InspectionSystemManager
{
    public partial class TeachingWindow
    {
        #region InitializeEvent & DeInitializeEvent
        private void InitializeEvent()
        {
            ucCogBlobReferWnd.ApplyBlobReferValueEvent += new ucCogBlobReference.ApplyBlobReferValueHandler(ApplyBlobReferenceValueFunction);
        }

        private void DeInitializeEvent()
        {
            ucCogBlobReferWnd.ApplyBlobReferValueEvent -= new ucCogBlobReference.ApplyBlobReferValueHandler(ApplyBlobReferenceValueFunction);
        }
        #endregion InitializeEvent & DeInitializeEvent


        #region Blob Reference Window Event : ucCogBlobReferenceWindow -> TeachingWindow
        private void ApplyBlobReferenceValueFunction(TeachParam.BlobReferTeachParam _ApplyParam, ref TeachParam.BlobReferTeachReturnParam _ReturnParam)
        {
            if (eTeachStep.ALGO_SET != CurrentTeachStep) { MessageBox.Show("Not select \"Algorithm Set\" button"); return; }
            AlgorithmAreaDisplayRefresh();

            CogBlobProcess.SetHardFixedThreshold(_ApplyParam.ThresholdMin);
            CogBlobProcess.SetConnectivityMinimum(_ApplyParam.BlobAreaMin);
            CogBlobProcess.SetPolarity(Convert.ToBoolean(_ApplyParam.Foreground));

            if (true == CogBlobProcess.Inspection(InspectionImage, AlgoRegionRectangle))
                CogBlobProcess.GetResult(true);

            if (CogBlobProcess.GetResults().BlobCount > 0)
            {
                CogBlobReferenceResult _BlobResultParameter = new CogBlobReferenceResult();
                _BlobResultParameter = CogBlobProcess.GetResults();
                
                _ReturnParam.BlobCount = CogBlobProcess.GetResults().BlobCount;
                _ReturnParam.Area = new double[_ReturnParam.BlobCount];
                _ReturnParam.OriginX = new double[_ReturnParam.BlobCount];
                _ReturnParam.OriginY = new double[_ReturnParam.BlobCount];
                _ReturnParam.CenterX = new double[_ReturnParam.BlobCount];
                _ReturnParam.CenterY = new double[_ReturnParam.BlobCount];
                _ReturnParam.Width = new double[_ReturnParam.BlobCount];
                _ReturnParam.Height = new double[_ReturnParam.BlobCount];

                for (int iLoopCount = 0; iLoopCount < _ReturnParam.BlobCount; ++iLoopCount)
                {
                    _ReturnParam.Area[iLoopCount]    = _BlobResultParameter.BlobArea[iLoopCount];
                    _ReturnParam.OriginX[iLoopCount] = _BlobResultParameter.BlobCenterX[iLoopCount];
                    _ReturnParam.OriginY[iLoopCount] = _BlobResultParameter.BlobCenterY[iLoopCount];
                    _ReturnParam.CenterX[iLoopCount] = _BlobResultParameter.BlobCenterX[iLoopCount];
                    _ReturnParam.CenterY[iLoopCount] = _BlobResultParameter.BlobCenterY[iLoopCount];
                    _ReturnParam.Width[iLoopCount]   = _BlobResultParameter.Width[iLoopCount];
                    _ReturnParam.Height[iLoopCount]  = _BlobResultParameter.Height[iLoopCount];

                    CogRectangle _BlobRect = new CogRectangle();
                    _BlobRect.SetCenterWidthHeight(_ReturnParam.CenterX[iLoopCount], _ReturnParam.CenterY[iLoopCount], _ReturnParam.Width[iLoopCount], _ReturnParam.Height[iLoopCount]);
                    kpTeachDisplay.DrawStaticShape(_BlobRect, "BlobRect" + (iLoopCount + 1), CogColorConstants.Green);
                    kpTeachDisplay.DrawBlobResult(_BlobResultParameter.ResultGraphic[iLoopCount], "BlobRectGra" + (iLoopCount + 1));

                    double _X = 0, _Y = 0;
                    CogPointMarker _Point = new CogPointMarker();
                    eBenchMarkPosition _eBenchMark = (eBenchMarkPosition)_ApplyParam.BenchMarkPosition;
                    if (eBenchMarkPosition.TL == _eBenchMark)       { _X = _BlobResultParameter.BlobMinX[iLoopCount];     _Y = _BlobResultParameter.BlobMinY[iLoopCount];   }
                    else if (eBenchMarkPosition.TC == _eBenchMark)  { _X = _BlobResultParameter.BlobCenterX[iLoopCount];  _Y = _BlobResultParameter.BlobMinY[iLoopCount];   }
                    else if (eBenchMarkPosition.TR == _eBenchMark)  { _X = _BlobResultParameter.BlobMaxX[iLoopCount];     _Y = _BlobResultParameter.BlobMinY[iLoopCount];   }
                    else if (eBenchMarkPosition.ML == _eBenchMark)  { _X = _BlobResultParameter.BlobMinX[iLoopCount];     _Y = _BlobResultParameter.BlobCenterY[iLoopCount]; }
                    else if (eBenchMarkPosition.MC == _eBenchMark)  { _X = _BlobResultParameter.BlobCenterX[iLoopCount];  _Y = _BlobResultParameter.BlobCenterY[iLoopCount]; }
                    else if (eBenchMarkPosition.MR == _eBenchMark)  { _X = _BlobResultParameter.BlobMaxX[iLoopCount];     _Y = _BlobResultParameter.BlobCenterY[iLoopCount]; }
                    else if (eBenchMarkPosition.BL == _eBenchMark)  { _X = _BlobResultParameter.BlobMinX[iLoopCount];     _Y = _BlobResultParameter.BlobMaxY[iLoopCount];   }
                    else if (eBenchMarkPosition.BC == _eBenchMark)  { _X = _BlobResultParameter.BlobCenterX[iLoopCount];  _Y = _BlobResultParameter.BlobMaxY[iLoopCount];   }
                    else if (eBenchMarkPosition.BR == _eBenchMark)  { _X = _BlobResultParameter.BlobMaxX[iLoopCount];     _Y = _BlobResultParameter.BlobMaxY[iLoopCount];   }
                    _Point.SetCenterRotationSize(_X, _Y, 0, 1);
                    kpTeachDisplay.DrawStaticShape(_Point, "BlobSearchPoint", CogColorConstants.Green, 3);
                }
            }
        }

        #endregion Blob Reference Window Event : ucCogBlobReferenceWindow -> TeachingWindow
    }
}
