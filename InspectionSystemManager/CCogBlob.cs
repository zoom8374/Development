using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Blob;

using ParameterManager;

namespace InspectionSystemManager
{
    public class CCogBlob
    {
        CogBlob BlobProc;
        CogBlobResults BlobResults;
        CogBlobResult BlobResult;
        CogBlobReferenceResult InspResults;

        public CCogBlob()
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

        public bool Inspection(CogImage8Grey _SrcImage, CogRectangle _InspArea)
        {
            bool _Result = true;

            try
            {
                BlobResults = BlobProc.Execute(_SrcImage, _InspArea);
            }

            catch
            {
                _Result = false;
            }

            return _Result;
        }

        public CogBlobReferenceResult GetResults()
        {
            return InspResults;
        }

        public CogCompositeShape[] GetGraphicResult()
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

        public bool GetResult(bool _IsGraphicResult)
        {
            bool _Result = true;

            if (null == BlobResults || BlobResults.GetBlobs().Count < 0) return false;
            InspResults.BlobCount = BlobResults.GetBlobs().Count;
            
            //InspResults.Width = new double[BlobResults.GetBlobs().Count];
            //InspResults.Height = new double[BlobResults.GetBlobs().Count];
            //InspResults.BlobCenterX = new double[BlobResults.GetBlobs().Count];
            //InspResults.BlobCenterY = new double[BlobResults.GetBlobs().Count];
            //InspResults.BlobMinX = new double[BlobResults.GetBlobs().Count];
            //InspResults.BlobMinY = new double[BlobResults.GetBlobs().Count];
            //InspResults.BlobMaxX = new double[BlobResults.GetBlobs().Count];
            //InspResults.BlobMaxY = new double[BlobResults.GetBlobs().Count];

            if (_IsGraphicResult) InspResults.ResultGraphic = new CogCompositeShape[InspResults.BlobCount];

            int[] _BlobIDs = new int[InspResults.BlobCount];
            for (int iLoopCount = 0; iLoopCount < InspResults.BlobCount; ++iLoopCount) _BlobIDs[iLoopCount] = iLoopCount;

            InspResults.Width            = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.BoundingBoxPrincipalAxisWidth, _BlobIDs);
            InspResults.Height           = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.BoundingBoxPrincipalAxisHeight, _BlobIDs);
            InspResults.BlobBoundCenterX = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.CenterMassX, _BlobIDs);
            InspResults.BlobBoundCenterY = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.CenterMassY, _BlobIDs);
            InspResults.BlobMinX         = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.BoundingBoxExtremaAngleMinX, _BlobIDs);
            InspResults.BlobMinY         = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.BoundingBoxExtremaAngleMinY, _BlobIDs);
            InspResults.BlobMaxX         = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.BoundingBoxExtremaAngleMaxX, _BlobIDs);
            InspResults.BlobMaxY         = BlobResults.GetBlobMeasures(CogBlobMeasureConstants.BoundingBoxExtremaAngleMaxY, _BlobIDs);

            for (int iLoopCount = 0; iLoopCount < InspResults.BlobCount; ++iLoopCount)
            {
                BlobResult = BlobResults.GetBlobByID(iLoopCount);
                InspResults.ResultGraphic[iLoopCount] = BlobResult.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary);
            }

            return _Result;
        }

        public void SetPolarity(bool _IsMode)
        {
            if (_IsMode) BlobProc.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs;
            else         BlobProc.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.DarkBlobs;
        }

        public void SetHardFixedThreshold(int _ThresholdValue)
        {
            BlobProc.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
            BlobProc.SegmentationParams.HardFixedThreshold = _ThresholdValue;
        }

        public void SetConnectivityMinimum(int _MinValue)
        {
            BlobProc.ConnectivityMinPixels = _MinValue;
        }

        public void SetMorphology(eMorphologyMode _OperationMode)
        {
            switch (_OperationMode)
            {
                case eMorphologyMode.OPEN:   BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.OpenSquare);       break;
                case eMorphologyMode.CLOSE:  BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.CloseSquare);      break;
                case eMorphologyMode.DILATE: BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateHorizontal); break;
                case eMorphologyMode.ERODE:  BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeHorizontal);  break;
            }
        }

        public void SetMorphologyHorizon(int _Time)
        {
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeHorizontal);
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateHorizontal);
        }

        public void SetMorphologyVertical(int _Time)
        {
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeVertical);
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateVertical);
        }

        public void SetMorphologySquare(int _Time)
        {
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeSquare);
            for (int iLoopCount = 0; iLoopCount < _Time; ++iLoopCount)
                BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateSquare);
        }
    }
}
