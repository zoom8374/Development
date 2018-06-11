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
    public partial class ucCogLeadInspection : UserControl
    {
        private CogLeadAlgo CogLeadAlgoRcp = new CogLeadAlgo();

        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;

        public delegate void ApplyLeadInspValueHandler(CogLeadAlgo _CogLeadAlgo, ref CogLeadResult _CogLeadResult);
        public event ApplyLeadInspValueHandler ApplyLeadInspValueEvent;

        #region Initialize & DeInitialize
        public ucCogLeadInspection()
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

        private void rbForeground_MouseUp(object sender, MouseEventArgs e)
        {
            RadioButton _RadioForeColor = (RadioButton)sender;
            int _ForeColor = Convert.ToInt32(_RadioForeColor.Tag);
            SetForegroundComboBox(_ForeColor);
            graLabelForeground.Text = _ForeColor.ToString();
            ApplySettingValue();
        }

        private void hScrollBarThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            graLabelThresholdValue.Text = hScrollBarThreshold.Value.ToString();
            ApplySettingValue();
        }
        #endregion Control Event

        public void SetAlgoRecipe(Object _Algorithm, double _ResolutionX, double _ResolutionY)
        {
            if (_Algorithm != null)
            {
                CogLeadAlgoRcp = _Algorithm as CogLeadAlgo;

                ResolutionX = _ResolutionX;
                ResolutionY = _ResolutionY;

                graLabelForeground.Text = CogLeadAlgoRcp.ForeGround.ToString();
                graLabelThresholdValue.Text = CogLeadAlgoRcp.ThresholdMin.ToString();
                hScrollBarThreshold.Value = CogLeadAlgoRcp.ThresholdMin;
                textBoxBlobAreaMin.Text = CogLeadAlgoRcp.BlobAreaMin.ToString();
                textBoxBlobAreaMax.Text = CogLeadAlgoRcp.BlobAreaMax.ToString();
                textBoxWidthSizeMin.Text = CogLeadAlgoRcp.WidthMin.ToString();
                textBoxWidthSizeMax.Text = CogLeadAlgoRcp.WidthMax.ToString();
                textBoxHeightSizeMin.Text = CogLeadAlgoRcp.HeightMin.ToString();
                textBoxHeightSizeMax.Text = CogLeadAlgoRcp.HeightMax.ToString();

                SetForegroundComboBox(CogLeadAlgoRcp.ForeGround);
            }

            else
            {
                //LOG
            }
        }

        public void SaveAlgoRecipe()
        {
            CogLeadAlgoRcp.ForeGround = Convert.ToInt32(graLabelForeground.Text);
            CogLeadAlgoRcp.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            CogLeadAlgoRcp.BlobAreaMin = Convert.ToInt32(textBoxBlobAreaMin.Text);
            CogLeadAlgoRcp.BlobAreaMax = Convert.ToInt32(textBoxBlobAreaMax.Text);
            CogLeadAlgoRcp.WidthMin = Convert.ToInt32(textBoxWidthSizeMin.Text);
            CogLeadAlgoRcp.WidthMax = Convert.ToInt32(textBoxWidthSizeMax.Text);
            CogLeadAlgoRcp.HeightMin = Convert.ToInt32(textBoxHeightSizeMin.Text);
            CogLeadAlgoRcp.HeightMax = Convert.ToInt32(textBoxHeightSizeMax.Text);
        }
        private void SetForegroundComboBox(int _RangeType)
        {
            rbForegroundWhite.Checked = false;
            rbForegroundBlack.Checked = false;

            switch ((eForeColor)_RangeType)
            {
                case eForeColor.BLACK: rbForegroundBlack.Checked = true; break;
                case eForeColor.WHITE: rbForegroundWhite.Checked = true; break;
            }
        }

        private void ApplySettingValue()
        {
            CogLeadResult _CogLeadResult = new CogLeadResult();
            CogLeadAlgo _CogLeadAlgoRcp = new CogLeadAlgo();
            _CogLeadAlgoRcp.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            _CogLeadAlgoRcp.BlobAreaMin = Convert.ToInt32(textBoxBlobAreaMin.Text);
            _CogLeadAlgoRcp.BlobAreaMax = Convert.ToInt32(textBoxBlobAreaMax.Text);
            _CogLeadAlgoRcp.WidthMin = Convert.ToInt32(textBoxWidthSizeMin.Text);
            _CogLeadAlgoRcp.WidthMax = Convert.ToInt32(textBoxWidthSizeMax.Text);
            _CogLeadAlgoRcp.HeightMin = Convert.ToInt32(textBoxHeightSizeMin.Text);
            _CogLeadAlgoRcp.HeightMax = Convert.ToInt32(textBoxHeightSizeMax.Text);
            _CogLeadAlgoRcp.ForeGround = Convert.ToInt32(graLabelForeground.Text);
            
            var _ApplyLeadInspValueEvent = ApplyLeadInspValueEvent;
            if (ApplyLeadInspValueEvent != null)
                ApplyLeadInspValueEvent(_CogLeadAlgoRcp, ref _CogLeadResult);
        }
    }
}
