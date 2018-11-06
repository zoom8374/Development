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
    class InspectionMultiPattern
    {
        private CogPMAlignTool PatternProc;
        private CogPMAlignResults PatternResults;

        public InspectionMultiPattern()
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

        public bool Run(CogImage8Grey _SrcImage, CogRectangle _InspRegion, CogMultiPatternAlgo _CogMultiPatternAlgo, ref CogMultiPatternResult _CogMultiPatternResult)
        {
            bool _Result = false;

            return _Result;
        }

        public bool Inspection(CogImage8Grey _SrcImage)
        {
            bool _Result = true;

            try
            {

            }
            catch(System.Exception ex)
            {

            }

            return _Result;
        }

        private void GetResult()
        {

        }
        
        public CogPMAlignPattern GetPatternReference(CogImage8Grey _SrcImage)
        {
            CogPMAlignPattern _Pattern = new CogPMAlignPattern();
            
            return _Pattern;
        }
    }
}
