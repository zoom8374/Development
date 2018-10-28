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
        private SendResultParameter GetLeadInspectionResultAnalysis()
        {
            SendResultParameter _SendResParam = new SendResultParameter();
            _SendResParam.ID = ID;
            _SendResParam.NgType = eNgType.GOOD;
            _SendResParam.IsGood = true;
            _SendResParam.ProjectItem = ProjectItem;

            SendLeadResult _SendResult = new SendLeadResult();
            for (int iLoopCount = 0; iLoopCount < AlgoResultParamList.Count; ++iLoopCount)
            {
                if (eAlgoType.C_LEAD == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogLeadResult;
                    
                    _SendResult.LeadCount = _AlgoResultParam.LeadCount;
                    _SendResult.LeadAngle = _AlgoResultParam.Angle;
                    _SendResult.LeadWidth = _AlgoResultParam.Width;
                    _SendResult.LeadLength = _AlgoResultParam.LeadLength;
                    _SendResult.LeadPitchTopX = _AlgoResultParam.LeadPitchTopX;
                    _SendResult.LeadPitchTopY = _AlgoResultParam.LeadPitchTopY;
                    _SendResult.IsLeadBendGood = _AlgoResultParam.IsLeadBentGood;

                    _SendResParam.IsGood &= _AlgoResultParam.IsGood;
                    _SendResParam.SendResult = _SendResult;
                    if (_SendResParam.NgType == eNgType.GOOD)
                        _SendResParam.NgType = (_AlgoResultParam.IsGood == true) ? eNgType.GOOD : eNgType.LEAD_BENT;

                    _SendResParam.IsGood &= _AlgoResultParam.IsLeadCountGood;
                    if (false == _AlgoResultParam.IsLeadCountGood)
                        _SendResParam.NgType = eNgType.LEAD_CNT;
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
            if (_SendResult.LeadPitchTopX != null && _SendResult.LeadPitchTopY != null && _SendResult.LeadLength != null)
            {
                _SendResult.LeadWidthReal = new double[_SendResult.LeadPitchTopX.Length];
                _SendResult.LeadLengthReal = new double[_SendResult.LeadPitchTopX.Length];

                for (int iLoopCount = 0; iLoopCount < _SendResult.LeadPitchTopX.Length; ++iLoopCount)
                {
                    _SendResult.LeadLength[iLoopCount] = Math.Abs(_SendResult.BodyReferenceY - _SendResult.LeadPitchTopY[iLoopCount]);
                    _SendResult.LeadLengthReal[iLoopCount] = _SendResult.LeadLength[iLoopCount] * ResolutionY;
                    _SendResult.LeadWidthReal[iLoopCount] = _SendResult.LeadWidth[iLoopCount] * ResolutionY;

                    CogLineSegment _LengthLine = new CogLineSegment();
                    _LengthLine.SetStartEnd(_SendResult.LeadPitchTopX[iLoopCount], _SendResult.LeadPitchTopY[iLoopCount],
                                            _SendResult.LeadPitchTopX[iLoopCount], _SendResult.BodyReferenceY);
                    ResultDisplay(_LengthLine, "LengthLine" + (iLoopCount + 1), CogColorConstants.Green);
                }
            }

            return _SendResParam;
        }
    }
}
