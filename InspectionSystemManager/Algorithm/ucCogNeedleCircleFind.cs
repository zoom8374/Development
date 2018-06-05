using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ParameterManager;

namespace InspectionSystemManager
{
    public partial class ucCogNeedleCircleFind : UserControl
    {
        private CogNeedleFindAlgo CogNeedleFindAlgoRcp = new CogNeedleFindAlgo();

        public delegate void ApplyNeedleCircleFindValueHandler(CogNeedleFindAlgo _CogNeedleFindAlgo, ref CogNeedleFindResult _CogNeedleFindResult);
        public event ApplyNeedleCircleFindValueHandler ApplyNeedleCircleFindValueEvent;

        #region Initialize & DeInitialize
        public ucCogNeedleCircleFind()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

        }

        private void InitializeControl()
        {

        }

        public void DeInitialize()
        {

        }
        #endregion Initialize & DeInitialize

        #region Control Event
        private void btnSetting_Click(object sender, EventArgs e)
        {
            ApplySettingValue();
        }
        #endregion Control Event

        public void SaveAlgoRecipe()
        {

        }
        
        private void ApplySettingValue()
        {
            CogNeedleFindAlgo _CogNeedleFindAlgoRcp = new CogNeedleFindAlgo();



            CogNeedleFindResult _CogNeedleFindResult = new CogNeedleFindResult();
            ApplyNeedleCircleFindValueEvent(_CogNeedleFindAlgoRcp, ref _CogNeedleFindResult);
        }
    }
}
