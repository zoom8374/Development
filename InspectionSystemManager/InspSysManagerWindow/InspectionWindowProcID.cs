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
        private SendResultParameter GetIDReadResultAnalysis()
        {
            SendResultParameter _SendResParam = new SendResultParameter();
            _SendResParam.ID = ID;
            _SendResParam.NgType = eNgType.GOOD;
            _SendResParam.IsGood = true;
            _SendResParam.ProjectItem = ProjectItem;

            for (int iLoopCount = 0; iLoopCount < AlgoResultParamList.Count; ++iLoopCount)
            {
                if (eAlgoType.C_ID == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogBarCodeIDResult;
                    SendIDResult _SendResult = new SendIDResult();
                    for (int jLoopCount = 0; jLoopCount < _AlgoResultParam.IDResult.Length; ++jLoopCount)
                    {
                        _SendResParam.IsGood &= _AlgoResultParam.IsGood;
                        _SendResult.ReadCode = (_AlgoResultParam.IsGood == true) ? _AlgoResultParam.IDResult[jLoopCount] : "";
                        if (_SendResParam.NgType == eNgType.GOOD)
                            _SendResParam.NgType = (_AlgoResultParam.IsGood == true) ? eNgType.GOOD : eNgType.ID;
                    }

                    _SendResParam.SendResult = _SendResult;
                }

                else if (eAlgoType.C_BLOB_REFER == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogBlobReferenceResult;
                    SendIDResult _SendResult = new SendIDResult();

                    _SendResParam.IsGood &= _AlgoResultParam.IsGood;
                    if (_SendResParam.NgType == eNgType.GOOD)
                        _SendResParam.NgType = (_AlgoResultParam.BlobCount > 0) ? eNgType.GOOD : eNgType.EMPTY;
                }

                else if (eAlgoType.C_PATTERN == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogPatternResult;
                    SendIDResult _SendResult = new SendIDResult();
                    _SendResParam.IsGood &= _AlgoResultParam.IsGood;
                    if (_SendResParam.NgType == eNgType.GOOD)
                        _SendResParam.NgType = (_AlgoResultParam.IsGood == true) ? eNgType.GOOD : eNgType.REF_NG;
                }
            }

            return _SendResParam;
        }
    }
}
