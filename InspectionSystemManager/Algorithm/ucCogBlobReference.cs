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
    public partial class ucCogBlobReference : UserControl
    {
        private TeachParam.BlobReferTeachReturnParam TeachingReturnParam = new TeachParam.BlobReferTeachReturnParam();

        public delegate void ApplyBlobReferValueHandler(TeachParam.BlobReferTeachParam _ApplyParam, ref TeachParam.BlobReferTeachReturnParam _ReturnParam);
        public event ApplyBlobReferValueHandler ApplyBlobReferValueEvent;

        #region Initialize & DeInitialize
        public ucCogBlobReference()
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

        public void SetAlgoRecipe()
        {

        }

        public void SaveTeachingParameter()
        {

        }

        public void ApplySettingValue()
        {
            TeachParam.BlobReferTeachParam _BlobReferTeachingValue = new TeachParam.BlobReferTeachParam();
            _BlobReferTeachingValue.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            //_BlobReferTeachingValue.BlobAreaMin = Convert.ToInt32(textBoxBlobAreaMin.Text);
            //_BlobReferTeachingValue.BlobAreaMax = Convert.ToInt32(textBoxBlobAreaMax.Text);
            //_BlobReferTeachingValue.BlobWidthMin = Convert.ToInt32(textBoxWidthSizeMin.Text);
            //_BlobReferTeachingValue.BlobWidthMax = Convert.ToInt32(textBoxWidthSizeMax.Text);
            //_BlobReferTeachingValue.BlobHeightMin = Convert.ToInt32(textBoxHeightSizeMin.Text);
            //_BlobReferTeachingValue.BlobHeightMax = Convert.ToInt32(textBoxHeightSizeMax.Text);

            ApplyBlobReferValueEvent(_BlobReferTeachingValue, ref TeachingReturnParam);
        }
    }
}
