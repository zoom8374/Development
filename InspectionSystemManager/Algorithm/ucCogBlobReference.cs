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
        private CogBlobReferenceAlgo CogBlobReferAlgoRcp = new CogBlobReferenceAlgo();
        private TeachParam.BlobReferTeachReturnParam TeachingReturnParam = new TeachParam.BlobReferTeachReturnParam();

        private double OriginX = 0;
        private double OriginY = 0;
        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;

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
        #endregion Control Event

        public void SetAlgoRecipe(Object _Algorithm, double _ResolutionX, double _ResolutionY)
        {
            CogBlobReferAlgoRcp = (CogBlobReferenceAlgo)_Algorithm;

            ResolutionX = _ResolutionX;
            ResolutionY = _ResolutionY;

            graLabelForeground.Text = CogBlobReferAlgoRcp.ForeGround.ToString();
            graLabelThresholdValue.Text = CogBlobReferAlgoRcp.ThresholdMin.ToString();
            hScrollBarThreshold.Value = CogBlobReferAlgoRcp.ThresholdMin;
            textBoxBlobAreaMin.Text = CogBlobReferAlgoRcp.BlobAreaMin.ToString();
            textBoxBlobAreaMax.Text = CogBlobReferAlgoRcp.BlobAreaMax.ToString();
            textBoxWidthSizeMin.Text = CogBlobReferAlgoRcp.WidthMin.ToString();
            textBoxWidthSizeMax.Text = CogBlobReferAlgoRcp.WidthMax.ToString();
            textBoxHeightSizeMin.Text = CogBlobReferAlgoRcp.HeightMin.ToString();
            textBoxHeightSizeMax.Text = CogBlobReferAlgoRcp.HeightMax.ToString();
            textBoxBenchMarkPosition.Text = CogBlobReferAlgoRcp.BenchMarkPosition.ToString();

            SetForegroundComboBox(CogBlobReferAlgoRcp.ForeGround);
            SetBenchMarkPositionComboBox(CogBlobReferAlgoRcp.BenchMarkPosition);
        }

        public void SaveAlgoRecipe()
        {
            CogBlobReferAlgoRcp.ForeGround = Convert.ToInt32(graLabelForeground.Text);
            CogBlobReferAlgoRcp.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            CogBlobReferAlgoRcp.BlobAreaMin = Convert.ToDouble(textBoxBlobAreaMin.Text);
            CogBlobReferAlgoRcp.BlobAreaMax = Convert.ToDouble(textBoxBlobAreaMax.Text);
            CogBlobReferAlgoRcp.WidthMin = Convert.ToDouble(textBoxWidthSizeMin.Text);
            CogBlobReferAlgoRcp.WidthMax = Convert.ToDouble(textBoxWidthSizeMax.Text);
            CogBlobReferAlgoRcp.HeightMin = Convert.ToDouble(textBoxHeightSizeMin.Text);
            CogBlobReferAlgoRcp.HeightMax = Convert.ToDouble(textBoxHeightSizeMax.Text);
            CogBlobReferAlgoRcp.BenchMarkPosition = Convert.ToInt32(textBoxBenchMarkPosition.Text);
            CogBlobReferAlgoRcp.OriginX = 0;
            CogBlobReferAlgoRcp.OriginY = 0;
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
                case eBenchMarkPosition.TL: rbBenchMarkTopLeft.Checked = true;       break;
                case eBenchMarkPosition.TC: rbBenchMarkTopCenter.Checked = true;     break;
                case eBenchMarkPosition.TR: rbBenchMarkTopRight.Checked = true;      break;
                case eBenchMarkPosition.ML: rbBenchMarkMiddleLeft.Checked = true;    break;
                case eBenchMarkPosition.MC: rbBenchMarkMiddleCenter.Checked = true;  break;
                case eBenchMarkPosition.MR: rbBenchMarkMiddleRight.Checked = true;   break;
                case eBenchMarkPosition.BL: rbBenchMarkBottomLeft.Checked = true;    break;
                case eBenchMarkPosition.BC: rbBenchMarkBottomCenter.Checked = true;  break;
                case eBenchMarkPosition.BR: rbBenchMarkBottomRight.Checked = true;   break;
                case eBenchMarkPosition.GC: rbBenchMarkGravityCenter.Checked = true; break;
            }
        }

        public void ApplySettingValue()
        {
            TeachParam.BlobReferTeachParam _BlobReferTeachingValue = new TeachParam.BlobReferTeachParam();
            _BlobReferTeachingValue.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            _BlobReferTeachingValue.BlobAreaMin = Convert.ToInt32(textBoxBlobAreaMin.Text);
            _BlobReferTeachingValue.BlobAreaMax = Convert.ToInt32(textBoxBlobAreaMax.Text);
            _BlobReferTeachingValue.BlobWidthMin = Convert.ToInt32(textBoxWidthSizeMin.Text);
            _BlobReferTeachingValue.BlobWidthMax = Convert.ToInt32(textBoxWidthSizeMax.Text);
            _BlobReferTeachingValue.BlobHeightMin = Convert.ToInt32(textBoxHeightSizeMin.Text);
            _BlobReferTeachingValue.BlobHeightMax = Convert.ToInt32(textBoxHeightSizeMax.Text);
            _BlobReferTeachingValue.Foreground = Convert.ToInt32(graLabelForeground.Text);
            _BlobReferTeachingValue.BenchMarkPosition = Convert.ToInt32(textBoxBenchMarkPosition.Text);

            ApplyBlobReferValueEvent(_BlobReferTeachingValue, ref TeachingReturnParam);

            double _MaxArea = TeachingReturnParam.Area.Max();
            int _MaxIndex = Array.IndexOf(TeachingReturnParam.Area, _MaxArea);
            textBoxBodyArea.Text    = TeachingReturnParam.Area[_MaxIndex].ToString("F2");
            textBoxBodyWidth.Text   = TeachingReturnParam.Width[_MaxIndex].ToString("F2");
            textBoxBodyHeight.Text  = TeachingReturnParam.Height[_MaxIndex].ToString("F2");

            OriginX = TeachingReturnParam.OriginX[_MaxIndex];
            OriginY = TeachingReturnParam.OriginY[_MaxIndex];
        }
    }
}
