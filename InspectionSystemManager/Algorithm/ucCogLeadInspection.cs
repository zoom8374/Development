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

        private void rbBenchMarkPosition_MouseUp(object sender, MouseEventArgs e)
        {
            RadioButton _RadioBenchPos = (RadioButton)sender;
            int _BenchMarkPosition = Convert.ToInt32(_RadioBenchPos.Tag);
            SetBenchMarkPositionComboBox(_BenchMarkPosition);
            textBoxBenchMarkPosition.Text = _BenchMarkPosition.ToString();
            ApplySettingValue();
        }

        private void hScrollBarThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            graLabelThresholdValue.Text = hScrollBarThreshold.Value.ToString();
            ApplySettingValue();
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

        private void SetBenchMarkPositionComboBox(int _BenchMarkPosition)
        {
            rbBenchMarkTopLeft.Checked = false;
            rbBenchMarkTopCenter.Checked = false;
            rbBenchMarkTopRight.Checked = false;
            rbBenchMarkMiddleLeft.Checked = false;
            rbBenchMarkMiddleCenter.Checked = false;
            rbBenchMarkMiddleRight.Checked = false;
            rbBenchMarkBottomLeft.Checked = false;
            rbBenchMarkBottomCenter.Checked = false;
            rbBenchMarkBottomRight.Checked = false;

            switch ((eBenchMarkPosition)_BenchMarkPosition)
            {
                case eBenchMarkPosition.TL: rbBenchMarkTopLeft.Checked = true; break;
                case eBenchMarkPosition.TC: rbBenchMarkTopCenter.Checked = true; break;
                case eBenchMarkPosition.TR: rbBenchMarkTopRight.Checked = true; break;
                case eBenchMarkPosition.ML: rbBenchMarkMiddleLeft.Checked = true; break;
                case eBenchMarkPosition.MC: rbBenchMarkMiddleCenter.Checked = true; break;
                case eBenchMarkPosition.MR: rbBenchMarkMiddleRight.Checked = true; break;
                case eBenchMarkPosition.BL: rbBenchMarkBottomLeft.Checked = true; break;
                case eBenchMarkPosition.BC: rbBenchMarkBottomCenter.Checked = true; break;
                case eBenchMarkPosition.BR: rbBenchMarkBottomRight.Checked = true; break;
                case eBenchMarkPosition.GC: rbBenchMarkGravityCenter.Checked = true; break;
            }
        }

        public void SetAlgoRecipe(Object _Algorithm, double _ResolutionX, double _ResolutionY)
        {
            CogLeadAlgoRcp = _Algorithm as CogLeadAlgo;

        }

        public void SaveAlgoRecipe()
        {

        }

        private void ApplySettingValue()
        {
            
        }
    }
}
