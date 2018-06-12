using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;

using ParameterManager;

namespace InspectionSystemManager
{
    public partial class TeachingWindow
    {
        #region InitializeEvent & DeInitializeEvent
        private void InitializeEvent()
        {
            ucCogBlobReferWnd.ApplyBlobReferValueEvent += new ucCogBlobReference.ApplyBlobReferValueHandler(ApplyBlobReferenceValueFunction);
            ucCogNeedleFindWnd.ApplyNeedleCircleFindValueEvent += new ucCogNeedleCircleFind.ApplyNeedleCircleFindValueHandler(ApplyNeedleCircleFindValueFunction);
            ucCogNeedleFindWnd.DrawNeedleCircleFindCaliperEvent += new ucCogNeedleCircleFind.DrawNeedleCircleFindCaliperHandler(DrawNeedleCircleFindCaliperFunction);
            ucCogLeadInspWnd.ApplyLeadInspValueEvent += new ucCogLeadInspection.ApplyLeadInspValueHandler(ApplyLeadInspValueFunction);
            kpTeachDisplay.CogDisplayMouseUpEvent += new KPDisplay.KPCogDisplayControl.CogDisplayMouseUpHandler(TeachDisplayMouseUpEvent);
        }

        private void DeInitializeEvent()
        {
            ucCogBlobReferWnd.ApplyBlobReferValueEvent -= new ucCogBlobReference.ApplyBlobReferValueHandler(ApplyBlobReferenceValueFunction);
            ucCogNeedleFindWnd.ApplyNeedleCircleFindValueEvent -= new ucCogNeedleCircleFind.ApplyNeedleCircleFindValueHandler(ApplyNeedleCircleFindValueFunction);
            ucCogNeedleFindWnd.DrawNeedleCircleFindCaliperEvent -= new ucCogNeedleCircleFind.DrawNeedleCircleFindCaliperHandler(DrawNeedleCircleFindCaliperFunction);
            ucCogLeadInspWnd.ApplyLeadInspValueEvent -= new ucCogLeadInspection.ApplyLeadInspValueHandler(ApplyLeadInspValueFunction);
            kpTeachDisplay.CogDisplayMouseUpEvent -= new KPDisplay.KPCogDisplayControl.CogDisplayMouseUpHandler(TeachDisplayMouseUpEvent);
        }
        #endregion InitializeEvent & DeInitializeEvent

        #region KPCogDisplay Control Event : KPCogDisplayControl -> TeachingWindow
        private void TeachDisplayMouseUpEvent(CogFindCircleTool _CircleCaliperTool)
        {
            if (CurrentAlgoType != eAlgoType.C_NEEDLE_FIND) return;
            if (CurrentTeachStep != eTeachStep.ALGO_SET)    return;

            double _CenterX = 0, _CenterY = 0, _Radius = 0, _AngleStart = 0, _AngleSpan = 0;
            _CircleCaliperTool.RunParams.ExpectedCircularArc.GetCenterRadiusAngleStartAngleSpan(out _CenterX, out _CenterY, out _Radius, out _AngleStart, out _AngleSpan);

            int _CaliperNumber = 0;
            double _CaliperSearchLength = 0, _CaliperProjectionLength = 0;
            eSearchDirection _CaliperSearchDir = eSearchDirection.IN_WARD;
            _CaliperNumber = _CircleCaliperTool.RunParams.NumCalipers;
            _CaliperSearchLength = _CircleCaliperTool.RunParams.CaliperSearchLength;
            _CaliperProjectionLength = _CircleCaliperTool.RunParams.CaliperProjectionLength;
            _CaliperSearchDir = (eSearchDirection)_CircleCaliperTool.RunParams.CaliperSearchDirection;

            ucCogNeedleFindWnd.SetCaliper(_CaliperNumber, _CaliperSearchLength, _CaliperProjectionLength, _CaliperSearchDir);
            ucCogNeedleFindWnd.SetCircularArc(_CenterX, _CenterY, _Radius, _AngleStart, _AngleSpan);
        }
        #endregion KPCogDisplay Control Event : KPCogDisplayControl -> TeachingWindow

        #region Blob Reference Window Event : ucCogBlobReferenceWindow -> TeachingWindow
        private void ApplyBlobReferenceValueFunction(CogBlobReferenceAlgo _CogBlobReferAlgo, ref CogBlobReferenceResult _CogBlobReferResult)
        {
            if (eTeachStep.ALGO_SET != CurrentTeachStep) { MessageBox.Show("Not select \"Algorithm Set\" button"); return; }
            AlgorithmAreaDisplayRefresh();

            bool _Result = InspBlobReferProcess.Run(InspectionImage, AlgoRegionRectangle, _CogBlobReferAlgo, ref _CogBlobReferResult);

            for (int iLoopCount = 0; iLoopCount < _CogBlobReferResult.BlobCount; ++iLoopCount)
            {
                CogRectangle _BlobRect = new CogRectangle();
                _BlobRect.SetCenterWidthHeight(_CogBlobReferResult.BlobCenterX[iLoopCount], _CogBlobReferResult.BlobCenterY[iLoopCount], _CogBlobReferResult.Width[iLoopCount], _CogBlobReferResult.Height[iLoopCount]);
                kpTeachDisplay.DrawStaticShape(_BlobRect, "BlobRect" + (iLoopCount + 1), CogColorConstants.Green);
                kpTeachDisplay.DrawBlobResult(_CogBlobReferResult.ResultGraphic[iLoopCount], "BlobRectGra" + (iLoopCount + 1));

                CogPointMarker _Point = new CogPointMarker();
                _Point.X = _CogBlobReferResult.OriginX[iLoopCount];
                _Point.Y = _CogBlobReferResult.OriginY[iLoopCount];
                kpTeachDisplay.DrawStaticShape(_Point, "BlobSearchPoint", CogColorConstants.Green, 3);
            }
        }
        #endregion Blob Reference Window Event : ucCogBlobReferenceWindow -> TeachingWindow

        #region Needle Circle Find Window Event : ucCogNeedleCircleFind -> TeachingWindow
        private void ApplyNeedleCircleFindValueFunction(CogNeedleFindAlgo _CogNeedleFindAlgo, ref CogNeedleFindResult _CogNeedleFindResult)
        {
            if (eTeachStep.ALGO_SET != CurrentTeachStep) { MessageBox.Show("Not select \"Algorithm Set\" button"); return; }
            AlgorithmAreaDisplayRefresh();

            bool _Result = InspNeedleCircleFindProcess.Run(InspectionImage, _CogNeedleFindAlgo, ref _CogNeedleFindResult);

            CogCircle _CogCircle = new CogCircle();
            _CogCircle.SetCenterRadius(_CogNeedleFindResult.CenterX, _CogNeedleFindResult.CenterY, _CogNeedleFindResult.Radius);
            CogPointMarker _CogCenterPoint = new CogPointMarker();
            _CogCenterPoint.SetCenterRotationSize(_CogNeedleFindResult.CenterX, _CogNeedleFindResult.CenterY, 0, 2);
            kpTeachDisplay.DrawStaticShape(_CogCircle, "Circle", CogColorConstants.Green, 3);
            kpTeachDisplay.DrawStaticShape(_CogCenterPoint, "CirclePoint", CogColorConstants.Green);

            string _CenterName = string.Format("X = {0:F2}mm, Y = {1:F2}mm, R = {2:F2}mm", _CogNeedleFindResult.CenterX * ResolutionX, _CogNeedleFindResult.CenterY * ResolutionY, _CogNeedleFindResult.Radius * ResolutionX);
            kpTeachDisplay.DrawText(_CenterName, _CogNeedleFindResult.CenterX , _CogNeedleFindResult.CenterY + 30, CogColorConstants.Green, 10, CogGraphicLabelAlignmentConstants.BaselineCenter);
        }

        private void DrawNeedleCircleFindCaliperFunction(CogNeedleFindAlgo _CogNeedleFindAlgo)
        {
            if (eTeachStep.ALGO_SET != CurrentTeachStep) { MessageBox.Show("Not select \"Algorithm Set\" button"); return; }
            AlgorithmAreaDisplayRefresh();

            CogFindCircle _CogFindCircle = new CogFindCircle();
            _CogFindCircle.NumCalipers = _CogNeedleFindAlgo.CaliperNumber;
            _CogFindCircle.CaliperSearchLength = _CogNeedleFindAlgo.CaliperSearchLength;
            _CogFindCircle.CaliperProjectionLength = _CogNeedleFindAlgo.CaliperProjectionLength;
            _CogFindCircle.CaliperSearchDirection = (CogFindCircleSearchDirectionConstants)_CogNeedleFindAlgo.CaliperSearchDirection;

            _CogFindCircle.ExpectedCircularArc.CenterX = _CogNeedleFindAlgo.ArcCenterX;
            _CogFindCircle.ExpectedCircularArc.CenterY = _CogNeedleFindAlgo.ArcCenterY;
            _CogFindCircle.ExpectedCircularArc.Radius = _CogNeedleFindAlgo.ArcRadius;
            _CogFindCircle.ExpectedCircularArc.AngleStart = _CogNeedleFindAlgo.ArcAngleStart;
            _CogFindCircle.ExpectedCircularArc.AngleSpan = _CogNeedleFindAlgo.ArcAngleSpan;

            kpTeachDisplay.DrawFindCircleCaliper(_CogFindCircle);
        }
        #endregion Needle Circle Find Window Event : ucCogNeedleCircleFind -> TeachingWindow

        private void ApplyLeadInspValueFunction(CogLeadAlgo _CogLeadAlgo, ref CogLeadResult _CogLeadResult, bool _IsDisplay = true)
        {
            if (eTeachStep.ALGO_SET != CurrentTeachStep) { MessageBox.Show("Not select \"Algorithm Set\" button"); return; }
            AlgorithmAreaDisplayRefresh();

            bool _Result = InspLeadProcess.Run(InspectionImage, AlgoRegionRectangle, _CogLeadAlgo, ref _CogLeadResult);

            #region Result Display
            if (_IsDisplay)
            {
                for (int iLoopCount = 0; iLoopCount < _CogLeadResult.BlobCount; ++iLoopCount)
                {
                    //Blob Boundary
                    CogRectangleAffine _BlobRectAffine = new CogRectangleAffine();
                    _BlobRectAffine.SetCenterLengthsRotationSkew(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount], _CogLeadResult.PrincipalWidth[iLoopCount], _CogLeadResult.PrincipalHeight[iLoopCount], _CogLeadResult.Angle[iLoopCount], 0);
                    kpTeachDisplay.DrawStaticShape(_BlobRectAffine, "BlobRectAffine" + (iLoopCount + 1), CogColorConstants.Green);
                    kpTeachDisplay.DrawBlobResult(_CogLeadResult.ResultGraphic[iLoopCount], "BlobRectGra" + (iLoopCount + 1));

                    CogLineSegment _CenterLine = new CogLineSegment();
                    kpTeachDisplay.DrawStaticLine(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount], _CogLeadResult.PrincipalWidth[iLoopCount] / 2 + 20, _CogLeadResult.Angle[iLoopCount], 2, "CenterLine+_" + (iLoopCount + 1), CogColorConstants.Cyan);
                    kpTeachDisplay.DrawStaticLine(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount], _CogLeadResult.PrincipalWidth[iLoopCount] / 2 + 20, (Math.PI) + _CogLeadResult.Angle[iLoopCount], 2, "CenterLine-_" + (iLoopCount + 1), CogColorConstants.Cyan);

                    CogPointMarker _PitchPoint = new CogPointMarker();
                    _PitchPoint.SetCenterRotationSize(_CogLeadResult.LeadPitchTopX[iLoopCount], _CogLeadResult.LeadPitchTopY[iLoopCount], 0, 1);
                    kpTeachDisplay.DrawStaticShape(_PitchPoint, "PointStart" + (iLoopCount + 1), CogColorConstants.Red, 2);
                    _PitchPoint.SetCenterRotationSize(_CogLeadResult.LeadPitchBottomX[iLoopCount], _CogLeadResult.LeadPitchBottomY[iLoopCount], 0, 1);
                    kpTeachDisplay.DrawStaticShape(_PitchPoint, "PointEnd" + (iLoopCount + 1), CogColorConstants.Yellow, 2);
                }
            }
            #endregion Result Display

            #region Pitch Average 측정
            double[] _LeadPitchX = new double[_CogLeadResult.BlobCount];
            Array.Copy(_CogLeadResult.LeadPitchTopX, _LeadPitchX, _CogLeadResult.BlobCount);
            Array.Sort(_LeadPitchX);

            double[] _LeadPitches = new double[_CogLeadResult.BlobCount - 1];
            for (int iLoopCount = 0; iLoopCount < _CogLeadResult.BlobCount - 1; ++iLoopCount)
                _LeadPitches[iLoopCount] = _LeadPitchX[iLoopCount + 1] - _LeadPitchX[iLoopCount];

            Array.Sort(_LeadPitches);
            double _Gab = _LeadPitches[4];
            int _Index = 1;
            double _PitchSum = _LeadPitches[4], _PitchArray = 0;
            for (int iLoopCount = 5; iLoopCount < _CogLeadResult.BlobCount - 1; ++iLoopCount)
            {
                if (_Gab + 20 < _LeadPitches[iLoopCount]) break;
                _PitchSum += _LeadPitches[iLoopCount];
                _Index++;
            }

            _PitchArray = _PitchSum / _Index;
            _CogLeadResult.LeadPitchAvg = _PitchArray;
            #endregion Pitch Average 측정

            #region Lead Angle Average 측정
            double[] _LeadAngles = new double[_CogLeadResult.BlobCount];
            Array.Copy(_CogLeadResult.Angle, _LeadAngles, _CogLeadResult.BlobCount);
            Array.Sort(_LeadAngles);

            _Index = 0;
            double _AngleSum = 0, _AngleAvg = 0;
            for (int iLoopCount = 5; iLoopCount < _CogLeadResult.BlobCount - 5; ++iLoopCount)
            {
                _AngleSum += _CogLeadResult.Angle[iLoopCount];
                _Index++;
            }
            _AngleAvg = _AngleSum / _Index;
            _CogLeadResult.LeadAngleAvg = _AngleAvg;
            #endregion Lead Angle Average 측정
        }
    }
}
