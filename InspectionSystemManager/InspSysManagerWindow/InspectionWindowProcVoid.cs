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

            SendVoidResult _SendResult = new SendVoidResult();
            for (int iLoopCount = 0; iLoopCount < AlgoResultParamList.Count; ++iLoopCount)
            {
                if (eAlgoType.C_BLOB == AlgoResultParamList[iLoopCount].ResultAlgoType)
                {
                    var _AlgoResultParam = AlgoResultParamList[iLoopCount].ResultParam as CogBlobDefectResult;
                    
                    for (int jLoopCount = 0; jLoopCount < _AlgoResultParam.BlobCount; ++jLoopCount)
                    {
                        _SendResult.DefectCount++;
                        //for (int zLoopCount = 0; zLoopCount < _AlgoResultParam.BlobCount; ++zLoopCount)
                        {
                            double _Width = _AlgoResultParam.Width[jLoopCount] * ResolutionX;
                            double _Height = _AlgoResultParam.Height[jLoopCount] * ResolutionY;
                            _SendResult.WidthList.Add(_Width);
                            _SendResult.HeightList.Add(_Height);
                            _SendResult.NgNumber.Add(_AlgoResultParam.NgNumber);
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
