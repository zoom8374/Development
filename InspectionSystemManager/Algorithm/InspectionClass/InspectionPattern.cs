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

            for (int iLoopCount = 0; iLoopCount < _CogPatternAlgo.ReferenceInfoList.Count; ++iLoopCount)
            {
                if (false == Inspection(_SrcImage, _InspRegion, _CogPatternAlgo.ReferenceInfoList[iLoopCount].Reference)) continue;

                if (PatternResults != null && PatternResults.Count > 0)
                {
                    _CogPatternResult.FindCount = PatternResults.Count;
                    _CogPatternResult.IsGood = true;

                    _CogPatternResult.Score = new double[PatternResults.Count];
                    _CogPatternResult.Scale = new double[PatternResults.Count];
                    _CogPatternResult.Angle = new double[PatternResults.Count];
                    _CogPatternResult.CenterX = new double[PatternResults.Count];
                    _CogPatternResult.CenterY = new double[PatternResults.Count];
                    _CogPatternResult.OriginPointX = new double[PatternResults.Count];
                    _CogPatternResult.OriginPointY = new double[PatternResults.Count];
                    _CogPatternResult.Width = new double[PatternResults.Count];
                    _CogPatternResult.Height = new double[PatternResults.Count];

                    for (int jLoopCount = 0; jLoopCount < PatternResults.Count; ++jLoopCount)
                    {
                        _CogPatternResult.Score[jLoopCount] = PatternResults[jLoopCount].Score;
                        _CogPatternResult.Scale[jLoopCount] = PatternResults[jLoopCount].GetPose().Scaling;
                        _CogPatternResult.Angle[jLoopCount] = PatternResults[jLoopCount].GetPose().Skew;
                        _CogPatternResult.OriginPointX[jLoopCount] = PatternResults[jLoopCount].GetPose().TranslationX;
                        _CogPatternResult.OriginPointY[jLoopCount] = PatternResults[jLoopCount].GetPose().TranslationY;
                        _CogPatternResult.CenterX[jLoopCount] = _CogPatternResult.OriginPointX[jLoopCount] + _CogPatternAlgo.ReferenceInfoList[iLoopCount].OriginPointOffsetX;
                        _CogPatternResult.CenterY[jLoopCount] = _CogPatternResult.OriginPointY[jLoopCount] + _CogPatternAlgo.ReferenceInfoList[iLoopCount].OriginPointOffsetY;
                        _CogPatternResult.Width[jLoopCount] = _CogPatternAlgo.ReferenceInfoList[iLoopCount].Width;
                        _CogPatternResult.Height[jLoopCount] = _CogPatternAlgo.ReferenceInfoList[iLoopCount].Height;
                    }
                    break;
                }

                else
                {
                    _CogPatternResult.IsGood = false;

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
            }

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

        public CogPMAlignPattern GetPatternReference(CogImage8Grey _SrcImage, CogRectangle _Region, double _OriginX, double _OriginY)
        {
            CogPMAlignPattern _Pattern = new CogPMAlignPattern();

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
            _Pattern.Train();

            return _Pattern;
        }
    }
}
