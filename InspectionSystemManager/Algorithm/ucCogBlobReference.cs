using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ParameterManager;
using LogMessageManager;

namespace InspectionSystemManager
{
    public partial class ucCogBlobReference : UserControl
    {
        private CogBlobReferenceAlgo CogBlobReferAlgoRcp = new CogBlobReferenceAlgo();

        private double BodyAreaSize = 0;
        private double BodyWidthSize = 0;
        private double BodyHeightSize = 0;

        private double OriginX = 0;
        private double OriginY = 0;
        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;

        public delegate void ApplyBlobReferValueHandler(CogBlobReferenceAlgo _CogBlobReferAlgo, ref CogBlobReferenceResult _CogBlobReferResult);
        public event ApplyBlobReferValueHandler ApplyBlobReferValueEvent;

        public delegate double GetHistogramValueHandler();
        public event GetHistogramValueHandler GetHistogramValueEvent;


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

        private void btnGet_Click(object sender, EventArgs e)
        {
            ApplySettingValue();

            textBoxBodyArea.Text = BodyAreaSize.ToString();
            textBoxBodyWidth.Text = (BodyWidthSize * ResolutionX).ToString("F2");
            textBoxBodyHeight.Text = (BodyHeightSize * ResolutionY).ToString("F2");
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

        private void ckBodyArea_CheckedChanged(object sender, EventArgs e)
        {
            numUpDownBodyArea.Enabled = ckBodyArea.Checked;
        }

        private void ckBodyWidth_CheckedChanged(object sender, EventArgs e)
        {
            numUpDownBodyWidth.Enabled = ckBodyWidth.Checked;
        }

        private void ckBodyHeight_CheckedChanged(object sender, EventArgs e)
        {
            numUpDownBodyHeight.Enabled = ckBodyHeight.Checked;
        }

        private void btnDummyHistogramMean_Click(object sender, EventArgs e)
        {
            var _GetHistogramValueEvent = GetHistogramValueEvent;
            double? _HistoMeanValue = _GetHistogramValueEvent?.Invoke();

            numUpDownDummyValue.Value = Convert.ToDecimal(_HistoMeanValue);
        }

        private void ckDummyUsable_CheckedChanged(object sender, EventArgs e)
        {
            numUpDownDummyValue.Enabled = ckDummyUsable.Checked;
            btnDummyHistogramMean.Enabled = ckDummyUsable.Checked;
        }
        #endregion Control Event

        public void SetAlgoRecipe(Object _Algorithm, double _ResolutionX, double _ResolutionY)
        {
            if (_Algorithm != null)
            {
                CogBlobReferAlgoRcp = _Algorithm as CogBlobReferenceAlgo;

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
                textBoxBodyArea.Text = CogBlobReferAlgoRcp.BodyArea.ToString("F2");
                textBoxBodyWidth.Text = CogBlobReferAlgoRcp.BodyWidth.ToString("F2");
                textBoxBodyHeight.Text = CogBlobReferAlgoRcp.BodyHeight.ToString("F2");
                numUpDownBodyArea.Value = Convert.ToDecimal(CogBlobReferAlgoRcp.BodyAreaPermitPercent);
                numUpDownBodyWidth.Value = Convert.ToDecimal(CogBlobReferAlgoRcp.BodyWidthPermitPercent);
                numUpDownBodyHeight.Value = Convert.ToDecimal(CogBlobReferAlgoRcp.BodyHeightPermitPercent);
                numUpDownDummyValue.Value = Convert.ToDecimal(CogBlobReferAlgoRcp.DummyHistoMeanValue);
                ckBodyArea.Checked = CogBlobReferAlgoRcp.UseBodyArea;
                ckBodyWidth.Checked = CogBlobReferAlgoRcp.UseBodyWidth;
                ckBodyHeight.Checked = CogBlobReferAlgoRcp.UseBodyHeight;
                ckDummyUsable.Checked = CogBlobReferAlgoRcp.UseDummyValue;
                numUpDownBodyArea.Enabled = CogBlobReferAlgoRcp.UseBodyArea;
                numUpDownBodyWidth.Enabled = CogBlobReferAlgoRcp.UseBodyWidth;
                numUpDownBodyHeight.Enabled = CogBlobReferAlgoRcp.UseBodyHeight;
                numUpDownDummyValue.Enabled = CogBlobReferAlgoRcp.UseDummyValue;
                btnDummyHistogramMean.Enabled = CogBlobReferAlgoRcp.UseDummyValue;

                SetForegroundComboBox(CogBlobReferAlgoRcp.ForeGround);
                SetBenchMarkPositionComboBox(CogBlobReferAlgoRcp.BenchMarkPosition);
            }

            else
            {
                //LOG
            }
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
            CogBlobReferAlgoRcp.BodyArea = Convert.ToDouble(textBoxBodyArea.Text);
            CogBlobReferAlgoRcp.BodyWidth = Convert.ToDouble(textBoxBodyWidth.Text);
            CogBlobReferAlgoRcp.BodyHeight = Convert.ToDouble(textBoxBodyHeight.Text);
            CogBlobReferAlgoRcp.BodyAreaPermitPercent = Convert.ToDouble(numUpDownBodyArea.Value);
            CogBlobReferAlgoRcp.BodyWidthPermitPercent = Convert.ToDouble(numUpDownBodyWidth.Value);
            CogBlobReferAlgoRcp.BodyHeightPermitPercent = Convert.ToDouble(numUpDownBodyHeight.Value);
            CogBlobReferAlgoRcp.DummyHistoMeanValue = Convert.ToDouble(numUpDownDummyValue.Value);
            CogBlobReferAlgoRcp.UseBodyArea = ckBodyArea.Checked;
            CogBlobReferAlgoRcp.UseBodyWidth = ckBodyWidth.Checked;
            CogBlobReferAlgoRcp.UseBodyHeight = ckBodyHeight.Checked;
            CogBlobReferAlgoRcp.UseDummyValue = ckDummyUsable.Checked;
            CogBlobReferAlgoRcp.OriginX = OriginX;
            CogBlobReferAlgoRcp.OriginY = OriginY;

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, "Teaching BlobReference SaveAlgoRecipe", CLogManager.LOG_LEVEL.MID);
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

        private void ApplySettingValue()
        {
            CogBlobReferenceResult _CogBlobReferResult = new CogBlobReferenceResult();
            CogBlobReferenceAlgo _CogBlobReferAlgoRcp = new CogBlobReferenceAlgo();
            _CogBlobReferAlgoRcp.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            _CogBlobReferAlgoRcp.BlobAreaMin = Convert.ToDouble(textBoxBlobAreaMin.Text);
            _CogBlobReferAlgoRcp.BlobAreaMax = Convert.ToDouble(textBoxBlobAreaMax.Text);
            _CogBlobReferAlgoRcp.WidthMin = Convert.ToDouble(textBoxWidthSizeMin.Text);
            _CogBlobReferAlgoRcp.WidthMax = Convert.ToDouble(textBoxWidthSizeMax.Text);
            _CogBlobReferAlgoRcp.HeightMin = Convert.ToDouble(textBoxHeightSizeMin.Text);
            _CogBlobReferAlgoRcp.HeightMax = Convert.ToDouble(textBoxHeightSizeMax.Text);
            _CogBlobReferAlgoRcp.ForeGround = Convert.ToInt32(graLabelForeground.Text);
            _CogBlobReferAlgoRcp.BenchMarkPosition = Convert.ToInt32(textBoxBenchMarkPosition.Text);
            _CogBlobReferAlgoRcp.ResolutionX = ResolutionX;
            _CogBlobReferAlgoRcp.ResolutionY = ResolutionY;

            var _ApplyBlobReferValueEvent = ApplyBlobReferValueEvent;
            if (_ApplyBlobReferValueEvent != null)
                _ApplyBlobReferValueEvent(_CogBlobReferAlgoRcp, ref _CogBlobReferResult);

            if (_CogBlobReferResult.BlobArea != null)
            {
                double _MaxArea = _CogBlobReferResult.BlobArea.Max();
                int _MaxIndex = Array.IndexOf(_CogBlobReferResult.BlobArea, _MaxArea);
                BodyAreaSize = _CogBlobReferResult.BlobArea[_MaxIndex];
                BodyWidthSize = _CogBlobReferResult.Width[_MaxIndex];
                BodyHeightSize = _CogBlobReferResult.Height[_MaxIndex];

                OriginX = _CogBlobReferResult.OriginX[_MaxIndex];
                OriginY = _CogBlobReferResult.OriginY[_MaxIndex];
            }

            else
            {
                textBoxBodyArea.Text = "0";
                textBoxBodyWidth.Text = "0";
                textBoxBodyHeight.Text = "0";

                OriginX = 0;
                OriginY = 0;
            }
        }
    }
}
