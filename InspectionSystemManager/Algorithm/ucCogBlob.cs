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
    public partial class ucCogBlob : UserControl
    {
        private CogBlobAlgo CogBlobAlgoRcp = new CogBlobAlgo();

        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;
        private double BenchMarkOffsetX = 0;
        private double BenchMarkOffsetY = 0;

        public delegate void ApplyBlobValueHandler(CogBlobAlgo _CogBlobReferAlgo, ref CogBlobDefectResult _CogBlobReferResult);
        public event ApplyBlobValueHandler ApplyBlobValueEvent;

        #region Initialize & DeInitialize
        public ucCogBlob()
        {
            InitializeComponent();
        }

        public void Initialize()
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

        private void hScrollBarThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            graLabelThresholdValue.Text = hScrollBarThreshold.Value.ToString();
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

        private string TextboxValueCheckNumbers(string _TextBoxValue, bool _UseDecimalPoint = false)
        {
            string _ResultValue = String.Empty;
            foreach (char _c in _TextBoxValue)
            {

                if (true == _UseDecimalPoint && (char.IsNumber(_c) || _c.Equals('.'))) _ResultValue = String.Format("{0}{1}", _ResultValue, _c);
                else if (false == _UseDecimalPoint && char.IsNumber(_c)) _ResultValue = String.Format("{0}{1}", _ResultValue, _c);
            }

            return _ResultValue;
        }

        private void textBoxBlobAreaMin_TextChanged(object sender, EventArgs e)
        {
            string _TextBoxValue = TextboxValueCheckNumbers(textBoxBlobAreaMin.Text);
            if (!textBoxBlobAreaMin.Text.Equals(_TextBoxValue))
            {
                textBoxBlobAreaMin.Text = _TextBoxValue;
                textBoxBlobAreaMin.Select(textBoxBlobAreaMin.Text.Length, 0);
            }
        }

        private void textBoxBlobAreaMax_TextChanged(object sender, EventArgs e)
        {
            string _TextBoxValue = TextboxValueCheckNumbers(textBoxBlobAreaMax.Text);
            if (!textBoxBlobAreaMax.Text.Equals(_TextBoxValue))
            {
                textBoxBlobAreaMax.Text = _TextBoxValue;
                textBoxBlobAreaMax.Select(textBoxBlobAreaMax.Text.Length, 0);
            }
        }

        private void textBoxWidthSizeMin_TextChanged(object sender, EventArgs e)
        {
            string _TextBoxValue = TextboxValueCheckNumbers(textBoxWidthSizeMin.Text, true);
            if (!textBoxWidthSizeMin.Text.Equals(_TextBoxValue))
            {
                textBoxWidthSizeMin.Text = _TextBoxValue;
                textBoxWidthSizeMin.Select(textBoxWidthSizeMin.Text.Length, 0);
            }
        }

        private void textBoxWidthSizeMax_TextChanged(object sender, EventArgs e)
        {
            string _TextBoxValue = TextboxValueCheckNumbers(textBoxWidthSizeMax.Text, true);
            if (!textBoxWidthSizeMax.Text.Equals(_TextBoxValue))
            {
                textBoxWidthSizeMax.Text = _TextBoxValue;
                textBoxWidthSizeMax.Select(textBoxWidthSizeMax.Text.Length, 0);
            }
        }

        private void textBoxHeightSizeMin_TextChanged(object sender, EventArgs e)
        {
            string _TextBoxValue = TextboxValueCheckNumbers(textBoxHeightSizeMin.Text, true);
            if (!textBoxHeightSizeMin.Text.Equals(_TextBoxValue))
            {
                textBoxHeightSizeMin.Text = _TextBoxValue;
                textBoxHeightSizeMin.Select(textBoxHeightSizeMin.Text.Length, 0);
            }
        }

        private void textBoxHeightSizeMax_TextChanged(object sender, EventArgs e)
        {
            string _TextBoxValue = TextboxValueCheckNumbers(textBoxHeightSizeMax.Text, true);
            if (!textBoxHeightSizeMax.Text.Equals(_TextBoxValue))
            {
                textBoxHeightSizeMax.Text = _TextBoxValue;
                textBoxHeightSizeMax.Select(textBoxHeightSizeMax.Text.Length, 0);
            }
        }
        #endregion Control Event


        public void SetAlgoRecipe(Object _Algorithm, double _BenchMarkOffsetX, double _BenchMarkOffsetY, double _ResolutionX, double _ResolutionY)
        {
            if (_Algorithm != null)
            {
                CogBlobAlgoRcp = _Algorithm as CogBlobAlgo;

                ResolutionX = _ResolutionX;
                ResolutionY = _ResolutionY;
                BenchMarkOffsetX = _BenchMarkOffsetX;
                BenchMarkOffsetY = _BenchMarkOffsetY;

                graLabelForeground.Text = CogBlobAlgoRcp.ForeGround.ToString();
                graLabelThresholdValue.Text = CogBlobAlgoRcp.ThresholdMin.ToString();
                hScrollBarThreshold.Value = CogBlobAlgoRcp.ThresholdMin;
                textBoxBlobAreaMin.Text = CogBlobAlgoRcp.BlobAreaMin.ToString();
                textBoxBlobAreaMax.Text = CogBlobAlgoRcp.BlobAreaMax.ToString();
                textBoxWidthSizeMin.Text = CogBlobAlgoRcp.WidthMin.ToString();
                textBoxWidthSizeMax.Text = CogBlobAlgoRcp.WidthMax.ToString();
                textBoxHeightSizeMin.Text = CogBlobAlgoRcp.HeightMin.ToString();
                textBoxHeightSizeMax.Text = CogBlobAlgoRcp.HeightMax.ToString();

                SetForegroundComboBox(CogBlobAlgoRcp.ForeGround);
            }

            else
            {

            }
        }

        public void SaveAlgoRecipe()
        {
            CogBlobAlgoRcp.ForeGround = Convert.ToInt32(graLabelForeground.Text);
            CogBlobAlgoRcp.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            CogBlobAlgoRcp.BlobAreaMin = Convert.ToInt32(textBoxBlobAreaMin.Text);
            CogBlobAlgoRcp.BlobAreaMax = Convert.ToInt32(textBoxBlobAreaMax.Text);
            CogBlobAlgoRcp.WidthMin = Convert.ToDouble(textBoxWidthSizeMin.Text);
            CogBlobAlgoRcp.WidthMax = Convert.ToDouble(textBoxWidthSizeMax.Text);
            CogBlobAlgoRcp.HeightMin = Convert.ToDouble(textBoxHeightSizeMin.Text);
            CogBlobAlgoRcp.HeightMax = Convert.ToDouble(textBoxHeightSizeMax.Text);

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, "Teaching Blob SaveAlgoRecipe", CLogManager.LOG_LEVEL.MID);
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
            CogBlobDefectResult _CogBlobResult = new CogBlobDefectResult();
            CogBlobAlgo _CogBlobAlgoRcp = new CogBlobAlgo();
            _CogBlobAlgoRcp.ThresholdMin = Convert.ToInt32(graLabelThresholdValue.Text);
            _CogBlobAlgoRcp.BlobAreaMin = Convert.ToDouble(textBoxBlobAreaMin.Text);
            _CogBlobAlgoRcp.BlobAreaMax = Convert.ToDouble(textBoxBlobAreaMax.Text);
            _CogBlobAlgoRcp.WidthMin = Convert.ToDouble(textBoxWidthSizeMin.Text);
            _CogBlobAlgoRcp.WidthMax = Convert.ToDouble(textBoxWidthSizeMax.Text);
            _CogBlobAlgoRcp.HeightMin = Convert.ToDouble(textBoxHeightSizeMin.Text);
            _CogBlobAlgoRcp.HeightMax = Convert.ToDouble(textBoxHeightSizeMax.Text);
            _CogBlobAlgoRcp.ForeGround = Convert.ToInt32(graLabelForeground.Text);
            _CogBlobAlgoRcp.BenchMarkPosition = Convert.ToInt32(textBoxBenchMarkPosition.Text);
            _CogBlobAlgoRcp.ResolutionX = ResolutionX;
            _CogBlobAlgoRcp.ResolutionY = ResolutionY;

            var _ApplyBlobValuEvent = ApplyBlobValueEvent;
            if (_ApplyBlobValuEvent != null)
                _ApplyBlobValuEvent(_CogBlobAlgoRcp, ref _CogBlobResult);

            //if (_CogBlobResult.BlobArea != null)
            //{
            //
            //}
        }
    }
}
