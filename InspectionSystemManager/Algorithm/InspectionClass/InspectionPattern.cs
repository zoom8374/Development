using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ImageProcessing;

using ParameterManager;
using LogMessageManager;

namespace InspectionSystemManager
{
    class InspectionPattern
    {
        private CogPMAlignTool PatternProc;
        private CogPMAlignResults PatternResults;

        public InspectionPattern()
        {
            PatternProc = new CogPMAlignTool();
            PatternProc.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatQuick;
            PatternResults = new CogPMAlignResults();
        }

        public void Initialize()
        {
            
        }

        public void DeInitialize()
        {
            PatternProc.Dispose();
        }

        public bool Run(CogImage8Grey _SrcImage, CogRectangle _InspRegion, CogPatternAlgo _CogPatternAlgo, ref CogPatternResult _CogPatternResult)
        {
            bool _Result = false;

            PatternProc.RunParams.AcceptThreshold = _CogPatternAlgo.MatchingScore / 100;
            PatternProc.RunParams.ApproximateNumberToFind = _CogPatternAlgo.MatchingCount;
            PatternProc.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
            PatternProc.RunParams.ZoneAngle.Low = _CogPatternAlgo.MatchingAngle * -1 * Math.PI / 180;
            PatternProc.RunParams.ZoneAngle.High = _CogPatternAlgo.MatchingAngle * 1 * Math.PI / 180;


            for (int iLoopCount = 0; iLoopCount < _CogPatternAlgo.ReferenceInfoList.Count; ++iLoopCount)
            {
                if (false == Inspection(_SrcImage, _InspRegion, _CogPatternAlgo.ReferenceInfoList[iLoopCount].Reference)) continue;

                if (PatternResults != null && PatternResults.Count > 0)
                {
                    CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, " - Find Count : " + PatternResults.Count.ToString(), CLogManager.LOG_LEVEL.MID);

                    _CogPatternResult.FindCount = 0;
                    for (int jLoopCount = 0; jLoopCount < PatternResults.Count; ++jLoopCount)
                    {
                        if (PatternResults[jLoopCount].Score * 100 >= _CogPatternAlgo.MatchingScore)
                            _CogPatternResult.FindCount++;
                    }

                    if (_CogPatternResult.FindCount > 0)
                    {
                        _CogPatternResult.Score = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.Scale = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.Angle = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.CenterX = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.CenterY = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.OriginPointX = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.OriginPointY = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.Width = new double[_CogPatternResult.FindCount];
                        _CogPatternResult.Height = new double[_CogPatternResult.FindCount];

                        int _Index = 0;
                        for (int jLoopCount = 0; jLoopCount < PatternResults.Count; ++jLoopCount)
                        {
                            if (PatternResults[jLoopCount].Score * 100 >= _CogPatternAlgo.MatchingScore)
                            {
                                _CogPatternResult.Score[_Index] = PatternResults[jLoopCount].Score;
                                _CogPatternResult.Scale[_Index] = PatternResults[jLoopCount].GetPose().Scaling;
                                _CogPatternResult.Angle[_Index] = PatternResults[jLoopCount].GetPose().Rotation;
                                _CogPatternResult.OriginPointX[_Index] = PatternResults[jLoopCount].GetPose().TranslationX;
                                _CogPatternResult.OriginPointY[_Index] = PatternResults[jLoopCount].GetPose().TranslationY;
                                _CogPatternResult.CenterX[_Index] = _CogPatternResult.OriginPointX[jLoopCount] + _CogPatternAlgo.ReferenceInfoList[iLoopCount].OriginPointOffsetX;
                                _CogPatternResult.CenterY[_Index] = _CogPatternResult.OriginPointY[jLoopCount] + _CogPatternAlgo.ReferenceInfoList[iLoopCount].OriginPointOffsetY;
                                _CogPatternResult.Width[_Index] = _CogPatternAlgo.ReferenceInfoList[iLoopCount].Width;
                                _CogPatternResult.Height[_Index] = _CogPatternAlgo.ReferenceInfoList[iLoopCount].Height;
                                _Index++;
                                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, " - Find Score : " + (_CogPatternResult.Score[jLoopCount] * 100).ToString("F2"), CLogManager.LOG_LEVEL.MID);
                            }
                        }

                        _CogPatternResult.IsGood = true;
                        break;
                    }

                    else
                    {
                        _CogPatternResult.IsGood = false;
                    }
                }

                else
                {
                    _CogPatternResult.IsGood = false;
                }
            }

            if (false == _CogPatternResult.IsGood)
            {
                _CogPatternResult.Score = new double[1];
                _CogPatternResult.Scale = new double[1];
                _CogPatternResult.Angle = new double[1];
                _CogPatternResult.CenterX = new double[1];
                _CogPatternResult.CenterY = new double[1];
                _CogPatternResult.OriginPointX = new double[1];
                _CogPatternResult.OriginPointY = new double[1];
                _CogPatternResult.Width = new double[1];
                _CogPatternResult.Height = new double[1];

                _CogPatternResult.Score[0] = 0;
                _CogPatternResult.Scale[0] = 0;
                _CogPatternResult.Angle[0] = 0;
                _CogPatternResult.OriginPointX[0] = _InspRegion.CenterX;
                _CogPatternResult.OriginPointY[0] = _InspRegion.CenterY;
                _CogPatternResult.CenterX[0] = _InspRegion.CenterX;
                _CogPatternResult.CenterY[0] = _InspRegion.CenterY;
                _CogPatternResult.Width[0] = _InspRegion.Width;
                _CogPatternResult.Height[0] = _InspRegion.Height;
            }

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, " - Result : " + (_CogPatternResult.IsGood).ToString(), CLogManager.LOG_LEVEL.MID);

            return _Result;
        }

        private bool Inspection(CogImage8Grey _SrcImage, CogRectangle _Region, CogPMAlignPattern _Pattern)
        {
            bool _Result = true;

            try
            {
                PatternProc.InputImage = _SrcImage;
                PatternProc.SearchRegion = _Region;
                PatternProc.Pattern = _Pattern;
                PatternProc.Run();
                GetResult();
            }

            catch(System.Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "InspectionPattern - Inspection Exception : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
                _Result = false;
            }

            return _Result;
        }

        private void GetResult()
        {
            PatternResults = new CogPMAlignResults();
            PatternResults = PatternProc.Results;
        }

        public bool GetPatternReference(CogImage8Grey _SrcImage, CogRectangle _Region, double _OriginX, double _OriginY, ref CogPMAlignPattern _Pattern)
        {
            //CogPMAlignPattern _Pattern = new CogPMAlignPattern();

            _Pattern = new CogPMAlignPattern();
            CogRectangleAffine _ReferRegionAffine = new CogRectangleAffine();
            _ReferRegionAffine.SetCenterLengthsRotationSkew(_Region.CenterX, _Region.CenterY, _Region.Width, _Region.Height, 0, 0);

            CogAffineTransformTool _AffineTool = new CogAffineTransformTool();
            _AffineTool.InputImage = _SrcImage;
            _AffineTool.Region = _ReferRegionAffine;
            _AffineTool.Run();

            _Pattern.TrainImage = (CogImage8Grey)_AffineTool.OutputImage;
            _Pattern.TrainRegion = _ReferRegionAffine;
            _Pattern.Origin.TranslationX = _OriginX;
            _Pattern.Origin.TranslationY = _OriginY;

            try
            {
                _Pattern.Train();
            }

            catch
            {
                return false;
            }

            return true;
        }
    }
}
