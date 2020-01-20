using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ParameterManager;
using LogMessageManager;

namespace InspectionSystemManager
{
    public partial class ucCogLineFind : UserControl
    {
        private CogLineFindAlgo CogLineFindAlgoRcp = new CogLineFindAlgo();

        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;
        private double BenchMarkOffsetX = 0;
        private double BenchMarkOffsetY = 0;

        private double OriginX = 0;
        private double OriginY = 0;
        private double OriginTempX = 0;
        private double OriginTempY = 0;

        private bool AlgoInitFlag = false;

        public delegate void ApplyLineFindHandler(CogLineFindAlgo _CogLineFindAlgo, ref CogLineFindResult _CogLineFindResult);
        public event ApplyLineFindHandler ApplyLineFindEvent;

        public delegate void DrawLineFindCaliperHandler(CogLineFindAlgo _CogLineFindAlgo);
        public event DrawLineFindCaliperHandler DrawLineFindCaliperEvent;

        #region Initialize & DeInitialize
        public ucCogLineFind()
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
        private void btnDrawCaliper_Click(object sender, EventArgs e)
        {
            DrawLineFindCaliper();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ApplySettingValue();
        }

        private void rbSearchDirection_MouseUp(object sender, MouseEventArgs e)
        {
            RadioButton _RadioDirection = (RadioButton)sender;
            int _Direction = Convert.ToInt32(_RadioDirection.Tag);

            SetSearchDirection(_Direction);
            graLabelSearchDirection.Text = _Direction.ToString();
            DrawLineFindCaliper();
        }

        private void btnOriginSet_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show(new Form { TopMost = true }, "Set Origin Value ? ", "Origin value setting", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            if (DialogResult.Yes != dlgResult) return;

            OriginX = OriginTempX;
            OriginY = OriginTempY;
        }
        #endregion Control Event

        public void SetAlgoRecipe(Object _Algorithm, double _BenchMarkOffsetX, double _BenchMarkOffsetY, double _ResolutionX, double _ResolutionY)
        {
            if (_Algorithm != null)
            {
                AlgoInitFlag = false;

                CogLineFindAlgoRcp = _Algorithm as CogLineFindAlgo;

                ResolutionX = _ResolutionX;
                ResolutionY = _ResolutionY;
                BenchMarkOffsetX = _BenchMarkOffsetX;
                BenchMarkOffsetY = _BenchMarkOffsetY;

                numUpDownCaliperNumber.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperNumber);
                numUpDownSearchLength.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperSearchLength);
                numUpDownProjectionLength.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperProjectionLength);
                numUpDownIgnoreNumber.Value = Convert.ToDecimal(CogLineFindAlgoRcp.IgnoreNumber);
                numUpDownContrastThreshold.Value = Convert.ToDecimal(CogLineFindAlgoRcp.ContrastThreshold);
                numUpDownFilterHalfSizePixels.Value = Convert.ToDecimal(CogLineFindAlgoRcp.FilterHalfSizePixels);
                numUpDownStartX.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperLineStartX);
                numUpDownStartY.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperLineStartY);
                numUpDownEndX.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperLineEndX);
                numUpDownEndY.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperLineEndY);
                ckUseAlignment.Checked = CogLineFindAlgoRcp.UseAlignment;

                OriginX = CogLineFindAlgoRcp.OriginX;
                OriginY = CogLineFindAlgoRcp.OriginY;

                SetSearchDirection(CogLineFindAlgoRcp.CaliperSearchDirection);

                AlgoInitFlag = true;
            }
        }

        public void SaveAlgoRecipe()
        {
            CogLineFindAlgoRcp.CaliperNumber = Convert.ToInt32(numUpDownCaliperNumber.Value);
            CogLineFindAlgoRcp.CaliperSearchLength = Convert.ToInt32(numUpDownSearchLength.Value);
            CogLineFindAlgoRcp.CaliperProjectionLength = Convert.ToInt32(numUpDownProjectionLength.Value);
            CogLineFindAlgoRcp.CaliperSearchDirection = Convert.ToInt32(graLabelSearchDirection.Text);
            CogLineFindAlgoRcp.IgnoreNumber = Convert.ToInt32(numUpDownIgnoreNumber.Value);
            CogLineFindAlgoRcp.ContrastThreshold = Convert.ToInt32(numUpDownContrastThreshold.Value);
            CogLineFindAlgoRcp.FilterHalfSizePixels = Convert.ToInt32(numUpDownFilterHalfSizePixels.Value);
            CogLineFindAlgoRcp.CaliperLineStartX = Convert.ToInt32(numUpDownStartX.Value);
            CogLineFindAlgoRcp.CaliperLineStartY = Convert.ToInt32(numUpDownStartY.Value);
            CogLineFindAlgoRcp.CaliperLineEndX = Convert.ToInt32(numUpDownEndX.Value);
            CogLineFindAlgoRcp.CaliperLineEndY = Convert.ToInt32(numUpDownEndY.Value);
            CogLineFindAlgoRcp.UseAlignment = ckUseAlignment.Checked;
            CogLineFindAlgoRcp.OriginX = OriginX;
            CogLineFindAlgoRcp.OriginY = OriginY;

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, "Teaching CogLineFind SaveAlgoRecipe", CLogManager.LOG_LEVEL.MID);
        }

        public void SetCaliper(int _CaliperNumber, double _SearchLength, double _ProjectionLength, double _SearchDirection)
        {
            numUpDownCaliperNumber.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperNumber);
            numUpDownSearchLength.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperSearchLength);
            numUpDownProjectionLength.Value = Convert.ToDecimal(CogLineFindAlgoRcp.CaliperProjectionLength);
            SetSearchDirection(CogLineFindAlgoRcp.CaliperSearchDirection);
        }

        public void SetCaliperLine(double _StartX, double _StartY, double _EndX, double _EndY)
        {
            numUpDownStartX.Value = Convert.ToDecimal(_StartX);
            numUpDownStartY.Value = Convert.ToDecimal(_StartY);
            numUpDownEndX.Value = Convert.ToDecimal(_EndX);
            numUpDownEndY.Value = Convert.ToDecimal(_EndY);
        }

        private void SetSearchDirection(int _Direction)
        {
            rbSearchDirectionIn.Checked = false;
            rbSearchDirectionOut.Checked = false;

            switch (_Direction)
            {
                case 90:    rbSearchDirectionIn.Checked = true; break;
                case -90:   rbSearchDirectionOut.Checked = true; break;
            }
        }

        private void ApplySettingValue()
        {
            CogLineFindResult _CogLineFindResult = new CogLineFindResult();
            CogLineFindAlgo _CogLineFindAlgoRcp = new CogLineFindAlgo();
            _CogLineFindAlgoRcp.CaliperNumber = Convert.ToInt32(numUpDownCaliperNumber.Value);
            _CogLineFindAlgoRcp.CaliperSearchLength = Convert.ToDouble(numUpDownSearchLength.Value);
            _CogLineFindAlgoRcp.CaliperProjectionLength = Convert.ToDouble(numUpDownProjectionLength.Value);
            _CogLineFindAlgoRcp.CaliperSearchDirection = Convert.ToInt32(graLabelSearchDirection.Text);

            _CogLineFindAlgoRcp.ContrastThreshold = Convert.ToInt32(numUpDownContrastThreshold.Value);
            _CogLineFindAlgoRcp.FilterHalfSizePixels = Convert.ToInt32(numUpDownFilterHalfSizePixels.Value);

            _CogLineFindAlgoRcp.IgnoreNumber = Convert.ToInt32(numUpDownIgnoreNumber.Text);
            _CogLineFindAlgoRcp.CaliperLineStartX = Convert.ToDouble(numUpDownStartX.Value);
            _CogLineFindAlgoRcp.CaliperLineStartY = Convert.ToDouble(numUpDownStartY.Value);
            _CogLineFindAlgoRcp.CaliperLineEndX = Convert.ToDouble(numUpDownEndX.Value);
            _CogLineFindAlgoRcp.CaliperLineEndY = Convert.ToDouble(numUpDownEndY.Value);

            var _ApplyLineFindEvent = ApplyLineFindEvent;
            _ApplyLineFindEvent?.Invoke(_CogLineFindAlgoRcp, ref _CogLineFindResult);

            OriginTempX = _CogLineFindResult.OriginX;
            OriginTempY = _CogLineFindResult.OriginY;
        }

        private void DrawLineFindCaliper()
        {
            CogLineFindAlgo _CogLineFindAlgoRcp = new CogLineFindAlgo();
            _CogLineFindAlgoRcp.CaliperNumber = Convert.ToInt32(numUpDownCaliperNumber.Value);
            _CogLineFindAlgoRcp.CaliperSearchLength = Convert.ToDouble(numUpDownSearchLength.Value);
            _CogLineFindAlgoRcp.CaliperProjectionLength = Convert.ToDouble(numUpDownProjectionLength.Value);
            _CogLineFindAlgoRcp.CaliperSearchDirection = Convert.ToInt32(graLabelSearchDirection.Text);
            _CogLineFindAlgoRcp.CaliperLineStartX = Convert.ToDouble(numUpDownStartX.Value);
            _CogLineFindAlgoRcp.CaliperLineStartY = Convert.ToDouble(numUpDownStartY.Value);
            _CogLineFindAlgoRcp.CaliperLineEndX = Convert.ToDouble(numUpDownEndX.Value);
            _CogLineFindAlgoRcp.CaliperLineEndY = Convert.ToDouble(numUpDownEndY.Value);

            _CogLineFindAlgoRcp.IgnoreNumber = Convert.ToInt32(numUpDownIgnoreNumber.Value);
            _CogLineFindAlgoRcp.ContrastThreshold = Convert.ToInt32(numUpDownContrastThreshold.Value);
            _CogLineFindAlgoRcp.FilterHalfSizePixels = Convert.ToInt32(numUpDownFilterHalfSizePixels.Value);

            var _DrawLineFindCaliperEvent = DrawLineFindCaliperEvent;
            _DrawLineFindCaliperEvent?.Invoke(_CogLineFindAlgoRcp);
        }
    }
}
