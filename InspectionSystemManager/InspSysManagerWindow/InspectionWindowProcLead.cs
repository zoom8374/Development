using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;


using ParameterManager;

namespace InspectionSystemManager
{
    public partial class InspectionWindow : Form
    {
        private SendResultParameter GetLeadInspectionResultAnalysys()
        {
            SendResultParameter _SendResParam = new SendResultParameter();
            _SendResParam.ID = ID;
            _SendResParam.IsGood = true;
            _SendResParam.ProjectItem = ProjectItem;

            SendLeadResult _SendResult = new SendLeadResult();
            for (int iLoopCount = 0; iLoopCount < AlgoResultParamList.Count; ++iLoopCount)
            {
                if (AlgoResultParamList[iLoopCount].ResultAlgoType == eAlgoType.C_LEAD)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogLeadResult;
                    
                    _SendResult.LeadCount = _AlgoResultParam.LeadCount;
                    _SendResult.LeadAngle = _AlgoResultParam.Angle;
                    _SendResult.LeadWidth = _AlgoResultParam.Width;
                    _SendResult.LeadLength = _AlgoResultParam.LeadLength;
                    _SendResult.LeadPitchTopX = _AlgoResultParam.LeadPitchTopX;
                    _SendResult.LeadPitchTopY = _AlgoResultParam.LeadPitchTopY;
                    _SendResult.IsLeadBendGood = _AlgoResultParam.IsLeadBentGood;

                    _SendResParam.SendResult = _SendResult;
                }

                else if (AlgoResultParamList[iLoopCount].ResultAlgoType == eAlgoType.C_LINE_FIND)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogLineFindResult;

                    _SendResult.BodyReferenceX = (_AlgoResultParam.StartX + _AlgoResultParam.EndX) / 2;
                    _SendResult.BodyReferenceY = (_AlgoResultParam.StartY + _AlgoResultParam.EndY) / 2;
                }

                else if (AlgoResultParamList[iLoopCount].ResultAlgoType == eAlgoType.C_BLOB_REFER)
                {
                    
                }

                else if (AlgoResultParamList[iLoopCount].ResultAlgoType == eAlgoType.C_PATTERN)
                {

                }
            }

            //Mergy Result
            for (int iLoopCount = 0; iLoopCount < _SendResult.LeadPitchTopX.Length; ++iLoopCount)
            {
                _SendResult.LeadLength[iLoopCount] = Math.Abs(_SendResult.BodyReferenceY - _SendResult.LeadPitchTopY[iLoopCount]);

                CogLineSegment _LengthLine = new CogLineSegment();
                _LengthLine.SetStartEnd(_SendResult.LeadPitchTopX[iLoopCount], _SendResult.LeadPitchTopY[iLoopCount], 
                                        _SendResult.LeadPitchTopX[iLoopCount], _SendResult.BodyReferenceY);
                ResultDisplay(_LengthLine, "LengthLine" + (iLoopCount + 1), CogColorConstants.Orange);
            }

            return _SendResParam;
        }
    }
}
