using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Blob;

using ParameterManager;
using LogMessageManager;

namespace InspectionSystemManager
{
    class InspectionBlob
    {
        CogBlob             BlobProc;
        CogBlobResults      BlobResults;
        CogBlobResult       BlobResult;
        CogBlobDefectResult InspResults;

        #region Initialize & Deinitialize
        public InspectionBlob()
        {
            BlobProc = new CogBlob();
            BlobResults = new CogBlobResults();
            BlobResult = new CogBlobResult();
            InspResults = new CogBlobDefectResult();

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

        public bool Run(CogImage8Grey _SrcImage, CogRectangleAffine _InspRegion, CogBlobAlgo _CogBlobAlgo, ref CogBlobDefectResult _CogBlobDefectResult, int _NgNumber = 0)
        {
            bool _Result = true;
            _CogBlobDefectResult.NgNumber = _NgNumber;
            _CogBlobDefectResult.InspArea = new CogRectangle();
            _CogBlobDefectResult.InspArea.SetCenterWidthHeight(_InspRegion.CenterX, _InspRegion.CenterY, _InspRegion.SideXLength, _InspRegion.SideYLength);

            List<int> _ResultIndexList = new List<int>();

            SetHardFixedThreshold(_CogBlobAlgo.ThresholdMin);
            SetConnectivityMinimum((int)_CogBlobAlgo.BlobAreaMin);
            SetPolarity(Convert.ToBoolean(_CogBlobAlgo.ForeGround));
            SetMeasurement(CogBlobMeasureConstants.Area, CogBlobMeasureModeConstants.Filter, CogBlobFilterModeConstants.IncludeBlobsInRange, _CogBlobAlgo.BlobAreaMin, _CogBlobAlgo.BlobAreaMax);
            if (true == Inspection(_SrcImage, _InspRegion)) GetResult(true);


            if (GetResults().BlobCount == 0)
            {
                _CogBlobDefectResult.IsGood = true;
            }

            else if (GetResults().BlobCount > 0)
            {
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, " - Blob Total Count : " + GetResults().BlobCount.ToString(), CLogManager.LOG_LEVEL.MID);

                CogBlobDefectResult _CogBlobDefectResultTemp = new CogBlobDefectResult();
                _CogBlobDefectResultTemp = GetResults();


                double _ResolutionX = _CogBlobAlgo.ResolutionX;
                double _ResolutionY = _CogBlobAlgo.ResolutionY;

                //LDH, 2019.12.17, Test Code 근접 알고리즘
                bool _MergeBlob = false;
                bool _MergePass = false;
                List<int> _MergeBlobNumList = new List<int>();
                CogBlobDefectResult _MergeBlobResult = new CogBlobDefectResult();

                List<int> _BlobPositionList = new List<int>();
                for (int iLoopCount = 0; iLoopCount < _CogBlobDefectResultTemp.BlobCount; iLoopCount++)
                {
                    if (iLoopCount == 0) _BlobPositionList.Add(iLoopCount);
                    else
                    {
                        for (int jLoopCount = 0; jLoopCount < _BlobPositionList.Count; jLoopCount++)
                        {
                            if (_CogBlobDefectResultTemp.BlobMinX[iLoopCount] < _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[jLoopCount]]) { _BlobPositionList.Insert(jLoopCount, iLoopCount); break; }

                            if (jLoopCount == _BlobPositionList.Count - 1) { _BlobPositionList.Add(iLoopCount); break; }
                        }
                    }
                }
                
                if (_MergeBlob)
                {
                    for (int iLoopCount = 0; iLoopCount < _CogBlobDefectResultTemp.BlobCount; iLoopCount++)
                    {
                        //이전 Blob에서 Merge를 수행했을 경우 Merge Algo Pass함 
                        if (!_MergePass)
                        {
                            if (iLoopCount != _CogBlobDefectResultTemp.BlobCount - 1)
                            {
                                double _BlobMergeWidth = Math.Abs(_CogBlobDefectResultTemp.BlobMaxX[_BlobPositionList[iLoopCount + 1]] - _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[iLoopCount]]) * _ResolutionX;

                                if (_BlobMergeWidth <= _CogBlobAlgo.WidthMin * 2)
                                {
                                    _MergeBlobNumList.Add(iLoopCount);
                                    _MergePass = true;
                                }
                                else _MergeBlobNumList.Add(iLoopCount);
                            }
                            else
                            {
                                _MergeBlobNumList.Add(iLoopCount);
                            }
                        }
                        else
                        {
                            _MergePass = false;
                        }
                    }

                    #region Blob Defect 할당
                    int _Count = _MergeBlobNumList.Count;
                    _MergeBlobResult.BlobCount = _Count;
                    _MergeBlobResult.BlobMessCenterX = new double[_Count];
                    _MergeBlobResult.BlobMessCenterY = new double[_Count];
                    _MergeBlobResult.BlobCenterX = new double[_Count];
                    _MergeBlobResult.BlobCenterY = new double[_Count];
                    _MergeBlobResult.BlobMinX = new double[_Count];
                    _MergeBlobResult.BlobMaxX = new double[_Count];
                    _MergeBlobResult.BlobMinY = new double[_Count];
                    _MergeBlobResult.BlobMaxY = new double[_Count];
                    _MergeBlobResult.Width = new double[_Count];
                    _MergeBlobResult.Height = new double[_Count];
                    _MergeBlobResult.BlobRatio = new double[_Count];
                    _MergeBlobResult.Angle = new double[_Count];
                    _MergeBlobResult.BlobXMinYMax = new double[_Count];
                    _MergeBlobResult.BlobXMaxYMin = new double[_Count];
                    _MergeBlobResult.BlobArea = new double[_Count];
                    _MergeBlobResult.OriginX = new double[_Count];
                    _MergeBlobResult.OriginY = new double[_Count];
                    _MergeBlobResult.IsGoods = new bool[_Count];
                    _MergeBlobResult.ResultGraphic = new CogCompositeShape[_Count];
                    #endregion

                    for (int iLoopCount = 0; iLoopCount < _Count; ++iLoopCount)
                    {
                        bool _MergeFlag = false;

                        if (iLoopCount == _Count - 1)
                        {
                            if (_MergeBlobNumList[iLoopCount] != _BlobPositionList.Count - 1) _MergeFlag = true;
                        }
                        else if (_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1] != _BlobPositionList[_MergeBlobNumList[iLoopCount + 1]]) _MergeFlag = true;

                        if (!_MergeFlag)
                        {
                            _MergeBlobResult.BlobMessCenterX[iLoopCount] = _CogBlobDefectResultTemp.BlobMessCenterX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobMessCenterY[iLoopCount] = _CogBlobDefectResultTemp.BlobMessCenterY[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobCenterX[iLoopCount] = _CogBlobDefectResultTemp.BlobCenterX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobCenterY[iLoopCount] = _CogBlobDefectResultTemp.BlobCenterY[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobMinX[iLoopCount] = _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobMaxX[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobMinY[iLoopCount] = _CogBlobDefectResultTemp.BlobMinY[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobMaxY[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxY[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.Width[iLoopCount] = _CogBlobDefectResultTemp.Width[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.Height[iLoopCount] = _CogBlobDefectResultTemp.Height[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobArea[iLoopCount] = _CogBlobDefectResultTemp.BlobArea[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.ResultGraphic[iLoopCount] = _CogBlobDefectResultTemp.ResultGraphic[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                        }
                        else
                        {
                            int _LargerIndex = (_CogBlobDefectResultTemp.Height[_BlobPositionList[_MergeBlobNumList[iLoopCount]]] > _CogBlobDefectResultTemp.Height[_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1]]) ? _BlobPositionList[_MergeBlobNumList[iLoopCount]] : _BlobPositionList[_MergeBlobNumList[iLoopCount] + 1];

                            //_MergeBlobResult.Width[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxX[_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1]] - _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            if(_CogBlobDefectResultTemp.BlobMaxX[_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1]] < _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]])
                                _MergeBlobResult.Width[iLoopCount] = _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]] - _CogBlobDefectResultTemp.BlobMaxX[_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1]];
                            else _MergeBlobResult.Width[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxX[_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1]] - _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];

                            _MergeBlobResult.Height[iLoopCount] = _CogBlobDefectResultTemp.Height[_LargerIndex];
                            _MergeBlobResult.BlobMessCenterX[iLoopCount] = _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]] + (_MergeBlobResult.Width[iLoopCount] / 2);
                            _MergeBlobResult.BlobMessCenterY[iLoopCount] = _CogBlobDefectResultTemp.BlobMessCenterY[_LargerIndex];
                            _MergeBlobResult.BlobCenterX[iLoopCount] = _MergeBlobResult.BlobMessCenterX[iLoopCount];
                            _MergeBlobResult.BlobCenterY[iLoopCount] = _MergeBlobResult.BlobMessCenterY[iLoopCount];
                            _MergeBlobResult.BlobMinX[iLoopCount] = _CogBlobDefectResultTemp.BlobMinX[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                            _MergeBlobResult.BlobMaxX[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxX[_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1]];
                            _MergeBlobResult.BlobMinY[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxY[_LargerIndex] - _MergeBlobResult.Height[iLoopCount];
                            _MergeBlobResult.BlobMaxY[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxY[_LargerIndex];
                            _MergeBlobResult.BlobArea[iLoopCount] = _CogBlobDefectResultTemp.BlobArea[_BlobPositionList[_MergeBlobNumList[iLoopCount]]] + _CogBlobDefectResultTemp.BlobArea[_BlobPositionList[_MergeBlobNumList[iLoopCount] + 1]];
                            _MergeBlobResult.ResultGraphic[iLoopCount] = _CogBlobDefectResultTemp.ResultGraphic[_BlobPositionList[_MergeBlobNumList[iLoopCount]]];
                        }
                    }
                }
                else
                {
                    _MergeBlobResult = _CogBlobDefectResultTemp;
                }

                #region 주석처리
                //for (int iLoopCount = 0; iLoopCount < _CogBlobDefectResultTemp.BlobCount; ++iLoopCount)
                //{
                //    double _ResultRealWidth = _CogBlobDefectResultTemp.Width[iLoopCount] * _ResolutionX;
                //    double _ResultRealHeight = _CogBlobDefectResultTemp.Height[iLoopCount] * _ResolutionY;

                //    if ((_CogBlobAlgo.WidthMin < _ResultRealWidth && _CogBlobAlgo.WidthMax > _ResultRealWidth) && (_CogBlobAlgo.HeightMin < _ResultRealHeight && _CogBlobAlgo.HeightMax > _ResultRealHeight))
                //    {
                //        CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format(" - W : {0}mm, H : {1}mm", _ResultRealWidth, _ResultRealHeight), CLogManager.LOG_LEVEL.MID);
                //        _ResultIndexList.Add(iLoopCount);
                //    }
                //}

                //if (_ResultIndexList.Count > 0)
                //{
                //    CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, " - Blob Condition Count : " + _ResultIndexList.Count.ToString(), CLogManager.LOG_LEVEL.MID);

                //    #region Blob Defect 할당
                //    int _Count = _ResultIndexList.Count;
                //    _CogBlobDefectResult.BlobCount = _Count;
                //    _CogBlobDefectResult.BlobMessCenterX = new double[_Count];
                //    _CogBlobDefectResult.BlobMessCenterY = new double[_Count];
                //    _CogBlobDefectResult.BlobCenterX = new double[_Count];
                //    _CogBlobDefectResult.BlobCenterY = new double[_Count];
                //    _CogBlobDefectResult.BlobMinX = new double[_Count];
                //    _CogBlobDefectResult.BlobMaxX = new double[_Count];
                //    _CogBlobDefectResult.BlobMinY = new double[_Count];
                //    _CogBlobDefectResult.BlobMaxY = new double[_Count];
                //    _CogBlobDefectResult.Width = new double[_Count];
                //    _CogBlobDefectResult.Height = new double[_Count];
                //    _CogBlobDefectResult.BlobRatio = new double[_Count];
                //    _CogBlobDefectResult.Angle = new double[_Count];
                //    _CogBlobDefectResult.BlobXMinYMax = new double[_Count];
                //    _CogBlobDefectResult.BlobXMaxYMin = new double[_Count];
                //    _CogBlobDefectResult.BlobArea = new double[_Count];
                //    _CogBlobDefectResult.OriginX = new double[_Count];
                //    _CogBlobDefectResult.OriginY = new double[_Count];
                //    _CogBlobDefectResult.IsGoods = new bool[_Count];
                //    _CogBlobDefectResult.ResultGraphic = new CogCompositeShape[_Count];
                //    #endregion

                //    for (int iLoopCount = 0; iLoopCount < _Count; ++iLoopCount)
                //    {
                //        _CogBlobDefectResult.BlobMessCenterX[iLoopCount] = _CogBlobDefectResultTemp.BlobMessCenterX[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobMessCenterY[iLoopCount] = _CogBlobDefectResultTemp.BlobMessCenterY[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobCenterX[iLoopCount] = _CogBlobDefectResultTemp.BlobCenterX[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobCenterY[iLoopCount] = _CogBlobDefectResultTemp.BlobCenterY[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobMinX[iLoopCount] = _CogBlobDefectResultTemp.BlobMinX[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobMaxX[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxX[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobMinY[iLoopCount] = _CogBlobDefectResultTemp.BlobMinY[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobMaxY[iLoopCount] = _CogBlobDefectResultTemp.BlobMaxY[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.Width[iLoopCount] = _CogBlobDefectResultTemp.Width[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.Height[iLoopCount] = _CogBlobDefectResultTemp.Height[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.BlobArea[iLoopCount] = _CogBlobDefectResultTemp.BlobArea[_ResultIndexList[iLoopCount]];
                //        _CogBlobDefectResult.ResultGraphic[iLoopCount] = _CogBlobDefectResultTemp.ResultGraphic[_ResultIndexList[iLoopCount]];
                //    }
                //    _CogBlobDefectResult.IsGood = false;
                //}
                #endregion 주석처리

                for (int iLoopCount = 0; iLoopCount < _MergeBlobResult.BlobCount; ++iLoopCount)
                {
                    double _ResultRealWidth = _MergeBlobResult.Width[iLoopCount] * _ResolutionX;
                    double _ResultRealHeight = _MergeBlobResult.Height[iLoopCount] * _ResolutionY;

                    if ((_CogBlobAlgo.WidthMin < _ResultRealWidth && _CogBlobAlgo.WidthMax > _ResultRealWidth) || (_CogBlobAlgo.HeightMin < _ResultRealHeight && _CogBlobAlgo.HeightMax > _ResultRealHeight))
                    {
                        CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format(" - W : {0}mm, H : {1}mm", _ResultRealWidth, _ResultRealHeight), CLogManager.LOG_LEVEL.MID);
                        _ResultIndexList.Add(iLoopCount);
                    }
                }

                if (_ResultIndexList.Count > 0)
                {
                    CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, " - Blob Condition Count : " + _ResultIndexList.Count.ToString(), CLogManager.LOG_LEVEL.MID);

                    #region Blob Defect 할당
                    int _Count = _ResultIndexList.Count;
                    _CogBlobDefectResult.BlobCount = _Count;
                    _CogBlobDefectResult.BlobMessCenterX = new double[_Count];
                    _CogBlobDefectResult.BlobMessCenterY = new double[_Count];
                    _CogBlobDefectResult.BlobCenterX = new double[_Count];
                    _CogBlobDefectResult.BlobCenterY = new double[_Count];
                    _CogBlobDefectResult.BlobMinX = new double[_Count];
                    _CogBlobDefectResult.BlobMaxX = new double[_Count];
                    _CogBlobDefectResult.BlobMinY = new double[_Count];
                    _CogBlobDefectResult.BlobMaxY = new double[_Count];
                    _CogBlobDefectResult.Width = new double[_Count];
                    _CogBlobDefectResult.Height = new double[_Count];
                    _CogBlobDefectResult.BlobRatio = new double[_Count];
                    _CogBlobDefectResult.Angle = new double[_Count];
                    _CogBlobDefectResult.BlobXMinYMax = new double[_Count];
                    _CogBlobDefectResult.BlobXMaxYMin = new double[_Count];
                    _CogBlobDefectResult.BlobArea = new double[_Count];
                    _CogBlobDefectResult.OriginX = new double[_Count];
                    _CogBlobDefectResult.OriginY = new double[_Count];
                    _CogBlobDefectResult.IsGoods = new bool[_Count];
                    _CogBlobDefectResult.ResultGraphic = new CogCompositeShape[_Count];
                    #endregion

                    for (int iLoopCount = 0; iLoopCount < _Count; ++iLoopCount)
                    {
                        _CogBlobDefectResult.BlobMessCenterX[iLoopCount] = _MergeBlobResult.BlobMessCenterX[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobMessCenterY[iLoopCount] = _MergeBlobResult.BlobMessCenterY[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobCenterX[iLoopCount] = _MergeBlobResult.BlobCenterX[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobCenterY[iLoopCount] = _MergeBlobResult.BlobCenterY[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobMinX[iLoopCount] = _MergeBlobResult.BlobMinX[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobMaxX[iLoopCount] = _MergeBlobResult.BlobMaxX[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobMinY[iLoopCount] = _MergeBlobResult.BlobMinY[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobMaxY[iLoopCount] = _MergeBlobResult.BlobMaxY[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.Width[iLoopCount] = _MergeBlobResult.Width[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.Height[iLoopCount] = _MergeBlobResult.Height[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.BlobArea[iLoopCount] = _MergeBlobResult.BlobArea[_ResultIndexList[iLoopCount]];
                        _CogBlobDefectResult.ResultGraphic[iLoopCount] = _MergeBlobResult.ResultGraphic[_ResultIndexList[iLoopCount]];
                    }
                    _CogBlobDefectResult.IsGood = false;
                }

                else
                    _CogBlobDefectResult.IsGood = true;
            }

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, " - Result : " + _CogBlobDefectResult.IsGood.ToString(), CLogManager.LOG_LEVEL.MID);
            return _Result;
        }

        public bool Inspection(CogImage8Grey _SrcImage, CogRectangleAffine _InspArea)
        {
            bool _Result = true;

            try
            {
                BlobResults = BlobProc.Execute(_SrcImage, _InspArea);
            }

            catch(System.Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "InspectionBlob - Inspection Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
                _Result = false;
            }

            return _Result;
        }

        public CogBlobDefectResult GetResults()
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
            if (_IsGraphicResult) InspResults.ResultGraphic = new CogCompositeShape[InspResults.BlobCount];

            for (int iLoopCount = 0; iLoopCount < InspResults.BlobCount; ++iLoopCount)
            {
                BlobResult = BlobResults.GetBlobByID(iLoopCount);

                InspResults.BlobArea[iLoopCount]         = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.Area, iLoopCount);
                InspResults.Width[iLoopCount]            = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeWidth, iLoopCount);
                InspResults.Height[iLoopCount]           = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeHeight, iLoopCount);
                InspResults.BlobMinX[iLoopCount]         = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMinX, iLoopCount);
                InspResults.BlobMinY[iLoopCount]         = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMinY, iLoopCount);
                InspResults.BlobMaxX[iLoopCount]         = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMaxX, iLoopCount);
                InspResults.BlobMaxY[iLoopCount]         = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.BoundingBoxPixelAlignedNoExcludeMaxY, iLoopCount);
                InspResults.BlobCenterX[iLoopCount]      = (InspResults.BlobMaxX[iLoopCount] + InspResults.BlobMinX[iLoopCount]) / 2;
                InspResults.BlobCenterY[iLoopCount]      = (InspResults.BlobMaxY[iLoopCount] + InspResults.BlobMinY[iLoopCount]) / 2;
                InspResults.BlobMessCenterX[iLoopCount]  = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.CenterMassX, iLoopCount);
                InspResults.BlobMessCenterY[iLoopCount]  = BlobResults.GetBlobMeasure(CogBlobMeasureConstants.CenterMassY, iLoopCount);

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
            else         BlobProc.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.DarkBlobs;
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
                case eMorphologyMode.OPEN:   BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.OpenSquare);       break;
                case eMorphologyMode.CLOSE:  BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.CloseSquare);      break;
                case eMorphologyMode.DILATE: BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateHorizontal); break;
                case eMorphologyMode.ERODE:  BlobProc.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeHorizontal);  break;
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
