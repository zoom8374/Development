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
        private SendResultParameter GetVoidInspectionResultAnalysis()
        {
            SendResultParameter _SendResParam = new SendResultParameter();
            _SendResParam.ID = ID;
            _SendResParam.NgType = eNgType.GOOD;
            _SendResParam.IsGood = true;
            _SendResParam.ProjectItem = ProjectItem;

            for (int iLoopCount = 0; iLoopCount < AlgoResultParamList.Count; ++iLoopCount)
            {
                if (eAlgoType.C_BLOB == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogBlobDefectResult;
                    SendVoidResult _SendResult = new SendVoidResult();
                    for (int jLoopCount = 0; jLoopCount < _AlgoResultParam.BlobCount; ++jLoopCount)
                    {
                        _SendResult.DefectCount = _AlgoResultParam.BlobCount;
                        _SendResult.Width = new double[_AlgoResultParam.BlobCount];
                        _SendResult.Height = new double[_AlgoResultParam.BlobCount];

                        for (int zLoopCount = 0; zLoopCount < _AlgoResultParam.BlobCount; ++zLoopCount)
                        {
                            _SendResult.Width[zLoopCount] = _AlgoResultParam.Width[zLoopCount] * ResolutionX;
                            _SendResult.Height[zLoopCount] = _AlgoResultParam.Height[zLoopCount] * ResolutionY;
                        }

                        _SendResParam.IsGood &= _AlgoResultParam.IsGood;
                        if (_SendResParam.NgType == eNgType.GOOD)
                            _SendResParam.NgType = (_AlgoResultParam.IsGood == true) ? eNgType.GOOD : eNgType.DEFECT;
                    }
                    _SendResParam.SendResult = _SendResult;
                }
            }

            return _SendResParam;
        }
    }
}
