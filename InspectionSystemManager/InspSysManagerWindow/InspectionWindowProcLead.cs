using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                    _SendResParam.SendResult = _SendResult;
                }

                else if (AlgoResultParamList[iLoopCount].ResultAlgoType == eAlgoType.C_BLOB_REFER)
                {
                    //var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogBlobReferenceResult;
                    //
                    //if (_AlgoResultParam.OriginX.Length != 0 && _AlgoResultParam.OriginY.Length != 0)
                    //{
                    //    _SendResult.ReferenceX = _AlgoResultParam.OriginX[0];
                    //    _SendResult.ReferenceY = _AlgoResultParam.OriginY[0];
                    //}
                    //
                    //_SendResParam.SendResult = _SendResult;
                }

                else if (AlgoResultParamList[iLoopCount].ResultAlgoType == eAlgoType.C_PATTERN)
                {

                }
            }

            return _SendResParam;
        }
    }
}
