﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Blob;

using ParameterManager;
using LogMessageManager;

namespace InspectionSystemManager
{
    class InspectionBlobReference
    {
        private CogBlob         BlobProc;
        private CogBlobResults  BlobResults;
        private CogBlobResult   BlobResult;
        private CogBlobReferenceResult InspResults;

        #region Initialize & Deinitialize
        public InspectionBlobReference()
        {
            BlobProc = new CogBlob();
            BlobResults = new CogBlobResults();
            BlobResult = new CogBlobResult();
            InspResults = new CogBlobReferenceResult();

            BlobProc.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
            BlobProc.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs;
            BlobProc.SegmentationParams.HardFixedThreshold = 100;
            BlobProc.ConnectivityMode = CogBlobConnectivityModeConstants.GreyScale;
            BlobProc.ConnectivityCleanup = CogBlobConnectivityCleanupConstants.Fill;
            BlobProc.ConnectivityMinPixels = 10;
        }

        public void Initialize()
        {

        }

        public void DeInitialize()
        {
            BlobResults.Dispose();
            BlobResult.Dispose();
            BlobProc.Dispose();
        }
        #endregion Initialize & Deinitialize

        public bool Run(CogImage8Grey _SrcImage, CogRectangle _InspRegion, CogBlobReferenceAlgo _CogBlobReferAlgo, ref CogBlobReferenceResult _CogBlobReferResult, int _NgNumber = 0)
        {
            bool _Result = true;
            double _X = 0, _Y = 0;

            SetHardFixedThreshold(_CogBlobReferAlgo.ThresholdMin);
            SetConnectivityMinimum((int)_CogBlobReferAlgo.BlobAreaMin);
            SetPolarity(Convert.ToBoolean(_CogBlobReferAlgo.ForeGround));
            SetMeasurement(CogBlobMeasureConstants.Area, CogBlobMeasureModeConstants.Filter, CogBlobFilterModeConstants.IncludeBlobsInRange, _CogBlobReferAlgo.BlobAreaMin, _CogBlobReferAlgo.BlobAreaMax);

            if (true == Inspection(_SrcImage, _InspRegion)) GetResult(true);
            
            if (GetResults().BlobCount > 0)
            {
                _CogBlobReferResult = GetResults();

                for (int iLoopCount = 0; iLoopCount < _CogBlobReferResult.BlobCount; ++iLoopCount)
                {
                    _CogBlobReferResult.IsGoods[iLoopCount] = true;
                    if (_CogBlobReferAlgo.UseBodyArea)
                    {
                        double _BodyAreaGap = Math.Abs(_CogBlobReferResult.BlobArea[iLoopCount] - _CogBlobReferAlgo.BodyArea);
                        if ((_CogBlobReferAlgo.BodyArea * _CogBlobReferAlgo.BodyAreaPermitPercent / 100) > _BodyAreaGap) { _CogBlobReferResult.IsGoods[iLoopCount] = false; continue; }
                    }

                    if (_CogBlobReferAlgo.UseBodyWidth)
                    {
                        double _BodyWidthGap = Math.Abs(_CogBlobReferResult.Width[iLoopCount] - _CogBlobReferAlgo.BodyWidth);
                        if ((_CogBlobReferAlgo.BodyWidth * _CogBlobReferAlgo.BodyWidthPermitPercent / 100) > _BodyWidthGap) { _CogBlobReferResult.IsGoods[iLoopCount] = false; continue; }
                    }

                    if (_CogBlobReferAlgo.UseBodyHeight)
                    {
                        double _BodyHeightGap = Math.Abs(_CogBlobReferResult.Height[iLoopCount] - _CogBlobReferAlgo.BodyHeight);
                        if ((_CogBlobReferAlgo.BodyHeight * _CogBlobReferAlgo.BodyHeightPermitPercent / 100) > _BodyHeightGap) { _CogBlobReferResult.IsGoods[iLoopCount] = false; continue; }
                    }

                    eBenchMarkPosition _eBenchMark = (eBenchMarkPosition)_CogBlobReferAlgo.BenchMarkPosition;
                    if (eBenchMarkPosition.TL == _eBenchMark) { _X = _CogBlobReferResult.BlobMinX[iLoopCount]; _Y = _CogBlobReferResult.BlobMinY[iLoopCount]; }
                    else if (eBenchMarkPosition.TC == _eBenchMark) { _X = _CogBlobReferResult.BlobCenterX[iLoopCount]; _Y = _CogBlobReferResult.BlobMinY[iLoopCount]; }
                    else if (eBenchMarkPosition.TR == _eBenchMark) { _X = _CogBlobReferResult.BlobMaxX[iLoopCount]; _Y = _CogBlobReferResult.BlobMinY[iLoopCount]; }
                    else if (eBenchMarkPosition.ML == _eBenchMark) { _X = _CogBlobReferResult.BlobMinX[iLoopCount]; _Y = _CogBlobReferResult.BlobCenterY[iLoopCount]; }
                    else if (eBenchMarkPosition.MC == _eBenchMark) { _X = _CogBlobReferResult.BlobCenterX[iLoopCount]; _Y = _CogBlobReferResult.BlobCenterY[iLoopCount]; }
                    else if (eBenchMarkPosition.MR == _eBenchMark) { _X = _CogBlobReferResult.BlobMaxX[iLoopCount]; _Y = _CogBlobReferResult.BlobCenterY[iLoopCount]; }
                    else if (eBenchMarkPosition.BL == _eBenchMark) { _X = _CogBlobReferResult.BlobMinX[iLoopCount]; _Y = _CogBlobReferResult.BlobMaxY[iLoopCount]; }
                    else if (eBenchMarkPosition.BC == _eBenchMark) { _X = _CogBlobReferResult.BlobCenterX[iLoopCount]; _Y = _CogBlobReferResult.BlobMaxY[iLoopCount]; }
                    else if (eBenchMarkPosition.BR == _eBenchMark) { _X = _CogBlobReferResult.BlobMaxX[iLoopCount]; _Y = _CogBlobReferResult.BlobMaxY[iLoopCount]; }
                    _CogBlobReferResult.OriginX[iLoopCount] = _X;
                    _CogBlobReferResult.OriginY[iLoopCount] = _Y;
                }

                _CogBlobReferResult.IsGood = true;
            }

            else
            {
                _CogBlobReferResult.BlobMinX = new double[1];
                _CogBlobReferResult.BlobMaxY = new double[1];
                _CogBlobReferResult.BlobCenterX = new double[1];
                _CogBlobReferResult.BlobCenterY = new double[1];
                _CogBlobReferResult.Width = new double[1];
                _CogBlobReferResult.Height = new double[1];
                _CogBlobReferResult.OriginX = new double[1];
                _CogBlobReferResult.OriginY = new double[1];
                _CogBlobReferResult.IsGoods = new bool[1];
                _CogBlobReferResult.BlobMinX[0] = _InspRegion.X;
                _CogBlobReferResult.BlobMaxY[0] = _InspRegion.Y + _InspRegion.Height;
                _CogBlobReferResult.BlobCenterX[0] = _InspRegion.CenterX;
                _CogBlobReferResult.BlobCenterY[0] = _InspRegion.CenterY;
                _CogBlobReferResult.Width[0] = _InspRegion.Width;
                _CogBlobReferResult.Height[0] = _InspRegion.Height;
                _CogBlobReferResult.OriginX[0] = _InspRegion.CenterX;
                _CogBlobReferResult.OriginY[0] = _InspRegion.CenterY;

                _CogBlobReferResult.IsGood = false;
            }
            return _Result;
        }

        private bool Inspection(CogImage8Grey _SrcImage, CogRectangle _InspArea)
        {
            bool _Result = true;

            try
            {
                BlobResults = BlobProc.Execute(_SrcImage, _InspArea);
            }

            catch(System.Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "InspectionBlobReference - Inspection Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
                _Result = false;
            }

            return _Result;
        }

        private CogBlobReferenceResult GetResults()
        {
            return InspResults;
        }

        private CogCompositeShape[] GetGraphicResult()
        {
            CogCompositeShape[] _GraphicResult = new CogCompositeShape[BlobResults.GetBlobs().Count];
            CogBlobResult _BlobResult = new CogBlobResult();

            for (int iLoopCount = 0; iLoopCount < BlobResults.GetBlobs().Count; ++iLoopCount)
            {
                BlobResult = BlobResults.GetBlobByID(iLoopCount);
                _GraphicResult[iLoopCount] = BlobResult.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary);
            }

            return _GraphicResult;
        }

        private bool GetResult(bool _IsGraphicResult)
        {
            bool _Result = true;

            if (null == BlobResults || BlobResults.GetBlobs().Count < 0) return false;
            InspResults.BlobCount = BlobResults.GetBlobs().Count;
            InspResults.BlobArea = new double[BlobResults.GetBlobs().Count];
            InspResults.Width = new double[BlobResults.GetBlobs().Count];
            InspResults.Height = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobMinX = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobMinY = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobMaxX = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobMaxY = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobCenterX = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobCenterY = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobMessCenterX = new double[BlobResults.GetBlobs().Count];
            InspResults.BlobMessCenterY = new double[BlobResults.GetBlobs().Count];
            InspResults.OriginX = new double[BlobResults.GetBlobs().Count];
            InspResults.OriginY = new double[BlobResults.GetBlobs().Count];
            InspResults.IsGoods = new bool[BlobResults.GetBlobs().Count];
            if (_IsGraphicResult) InspResults.ResultGraphic = new CogCompositeShape[InspResults.BlobCount];

            for (int iLoopCount = 0; iLoopCount < InspResults.BlobCount; ++iLoopCount)
            {
                BlobResult = BlobResults.GetBlobByID(iLoopCount);

                InspResults.BlobArea[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.Area, iLoopCount);
                InspResults.Width[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeWidth, iLoopCount);
                InspResults.Height[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeHeight, iLoopCount);
                InspResults.BlobMinX[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMinX, iLoopCount);
                InspResults.BlobMinY[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMinY, iLoopCount);
                InspResults.BlobMaxX[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMaxX, iLoopCount);
                InspResults.BlobMaxY[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMaxY, iLoopCount);
                InspResults.BlobCenterX[iLoopCount] = (InspResults.BlobMaxX[iLoopCount] + InspResults.BlobMinX[iLoopCount]) / 2;
                InspResults.BlobCenterY[iLoopCount] = (InspResults.BlobMaxY[iLoopCount] + InspResults.BlobMinY[iLoopCount]) / 2;
                InspResults.BlobMessCenterX[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.CenterMassX, iLoopCount);
                InspResults.BlobMessCenterY[iLoopCount] = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.CenterMassY, iLoopCount);

                if (_IsGraphicResult) InspResults.ResultGraphic[iLoopCount] = BlobResult.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary);
            }

            return _Result;
        }

        private void SetMeasurement(CogBlobMeasureConstants _Properties, CogBlobMeasureModeConstants _Filter, CogBlobFilterModeConstants _Range, double _RangeLow, double _RangeHigh, bool _IsNew = true)
        {
            if (_IsNew) BlobProc.RunTimeMeasures.Clear();

            CogBlobMeasure _BlobMeasure = new CogBlobMeasure();
            _BlobMeasure.Measure = _Properties;
            _BlobMeasure.Mode = _Filter;
            _BlobMeasure.FilterMode = _Range;
            _BlobMeasure.FilterRangeLow = _RangeLow;
            _BlobMeasure.FilterRangeHigh = _RangeHigh;
            BlobProc.RunTimeMeasures.Add(_BlobMeasure);
        }

        private void SetPolarity(bool _IsMode)
        {
            if (_IsMode) BlobProc.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs;
            else BlobProc.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.DarkBlobs;
        }

        private void SetHardFixedThreshold(int _ThresholdValue)
        {
            BlobProc.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
            BlobProc.SegmentationParams.HardFixedThreshold = _ThresholdValue;
        }

        private void SetConnectivityMinimum(int _MinValue)
        {
            BlobProc.ConnectivityMinPixels = _MinValue;
        }

        private void SetMorphology(eMorphologyMode _OperationMode)
        {
            switch (_OperationMode)
            {
                case eMorphologyMode.OPEN: BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.OpenSquare); break;
                case eMorphologyMode.CLOSE: BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.CloseSquare); break;
                case eMorphologyMode.DILATE: BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateHorizontal); break;
                case eMorphologyMode.ERODE: BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeHorizontal); break;
            }
        }

        private void SetMorphologyHorizon(int _Time)
        {
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeHorizontal);
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateHorizontal);
        }

        private void SetMorphologyVertical(int _Time)
        {
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeVertical);
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateVertical);
        }

        private void SetMorphologySquare(int _Time)
        {
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeSquare);
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateSquare);
        }
    }
}
