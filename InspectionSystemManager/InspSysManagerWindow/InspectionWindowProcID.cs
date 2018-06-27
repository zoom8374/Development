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
                        _SendResParam.IsGood = _AlgoResultParam.IsGood;
                        _SendResult.ReadCode = (_AlgoResultParam.IsGood == true) ? _AlgoResultParam.IDResult[jLoopCount] : "";
                    }

                    _SendResParam.SendResult = _SendResult;
                }
            }

            return _SendResParam;
        }
    }
}
