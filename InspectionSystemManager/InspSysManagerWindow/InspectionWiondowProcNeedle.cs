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
        private SendResultParameter GetNeedleFindResultAnalysis()
        {
            SendResultParameter _SendResParam = new SendResultParameter();
            _SendResParam.ID = ID;
            _SendResParam.NgType = eNgType.GOOD;
            _SendResParam.IsGood = true;
            _SendResParam.ProjectItem = ProjectItem;

            for (int iLoopCount = 0; iLoopCount < AlgoResultParamList.Count; ++iLoopCount)
            {
                if (eAlgoType.C_NEEDLE_FIND == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogNeedleFindResult;
                    SendNeedleAlignResult _SendResult = new SendNeedleAlignResult();
                    
                    _SendResult.AlignX = (_AlgoResultParam.IsGood == true) ? _AlgoResultParam.CenterX : 0;
                    _SendResult.AlignY = (_AlgoResultParam.IsGood == true) ? _AlgoResultParam.CenterY : 0;

                    _SendResParam.IsGood &= _AlgoResultParam.IsGood;
                    _SendResParam.SendResult = _SendResult;
                    if (_SendResParam.NgType == eNgType.GOOD)
                        _SendResParam.NgType = (_AlgoResultParam.IsGood == true) ? eNgType.GOOD : eNgType.NDL_CENTER;
                }

                else if (eAlgoType.C_BLOB_REFER == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogBlobReferenceResult;
                    SendIDResult _SendResult = new SendIDResult();

                    _SendResParam.IsGood &= _AlgoResultParam.IsGood;
                    if (_SendResParam.NgType == eNgType.GOOD)
                        _SendResParam.NgType = (_AlgoResultParam.BlobCount > 0) ? eNgType.GOOD : eNgType.NDL_FIND;
                }

                else if (eAlgoType.C_PATTERN == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogPatternResult;
                    SendNeedleAlignResult _SendResult = new SendNeedleAlignResult();
                    _SendResParam.IsGood = _AlgoResultParam.IsGood;
                    _SendResult.AlignX = (_AlgoResultParam.IsGood == true) ? _AlgoResultParam.OriginPointX[0] : 0;
                    _SendResult.AlignY = (_AlgoResultParam.IsGood == true) ? _AlgoResultParam.OriginPointY[0] : 0;
                }
            }

            return _SendResParam;
        }
    }
}
