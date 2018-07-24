using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomControl;
using ParameterManager;

namespace KPVisionInspectionFramework
{
    public partial class ucMainResultID : UserControl
    {
        private uint TotalCount = 0;
        private uint GoodCount = 0;
        private uint NgCount = 0;
        private double Yield = 0;

        private uint CodeErrCount = 0;
        private uint BlankErrCount = 0;
        private uint MixErrCount = 0;

        #region Initialize & DeInitialize
        public ucMainResultID()
        {
            InitializeComponent();
            InitializeControl();
            this.Location = new Point(1, 1);
        }

        public void InitializeControl()
        {
            TotalCount = 0;
            GoodCount = 0;
            NgCount = 0;
            Yield = 0.0;

            CodeErrCount = 0;
            BlankErrCount = 0;
            MixErrCount = 0;

            SevenSegTotal.Value = TotalCount.ToString();
            SevenSegGood.Value = GoodCount.ToString();
            SevenSegNg.Value = NgCount.ToString();
            SevenSegYield.Value = Yield.ToString("F2");

            SevenSegCodeErr.Value = CodeErrCount.ToString();
            SevenSegBlankErr.Value = BlankErrCount.ToString();
            SevenSegMixErr.Value = MixErrCount.ToString();
        }

        public void DeInitialize()
        {

        }
        #endregion Initialize & DeInitialize

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.Green, ButtonBorderStyle.Solid);
        }

        public void SetResultData(SendResultParameter _ResultParam)
        {
            string _DataMatrixString = "-";
            var _Result = _ResultParam.SendResult as SendIDResult;

            if (_Result != null) _DataMatrixString = (_ResultParam.IsGood == true) ? _Result.ReadCode : "-----";
            else                _DataMatrixString = "-";
            ControlInvoke.GradientLabelText(gradientLabelDataMatrix, _DataMatrixString);

            if (_ResultParam.IsGood)
            {
                TotalCount++;
                GoodCount++;
                Yield = (double)GoodCount / (double)TotalCount * 100;

                SegmentValueInvoke(SevenSegTotal, TotalCount.ToString());
                SegmentValueInvoke(SevenSegGood, GoodCount.ToString());
                SegmentValueInvoke(SevenSegYield, Yield.ToString("F2"));

                ControlInvoke.GradientLabelText(gradientLabelResult, "GOOD", Color.Lime);
            }

            else
            {
                TotalCount++;
                NgCount++;
                Yield = (double)GoodCount / (double)TotalCount * 100;

                SegmentValueInvoke(SevenSegTotal, TotalCount.ToString());
                SegmentValueInvoke(SevenSegNg, NgCount.ToString());
                SegmentValueInvoke(SevenSegYield, Yield.ToString("F2"));

                //gradientLabelDataMatrix
                if (eNgType.ID == _ResultParam.NgType)
                {
                    CodeErrCount++;
                    SegmentValueInvoke(SevenSegCodeErr, CodeErrCount.ToString());
                    ControlInvoke.GradientLabelText(gradientLabelResult, "CODE NG", Color.Red);
                }

                else if (eNgType.EMPTY == _ResultParam.NgType)
                {
                    BlankErrCount++;
                    SegmentValueInvoke(SevenSegBlankErr, BlankErrCount.ToString());
                    ControlInvoke.GradientLabelText(gradientLabelResult, "EMPTY", Color.Red);
                }

                else if (eNgType.REF_NG == _ResultParam.NgType)
                {
                    MixErrCount++;
                    SegmentValueInvoke(SevenSegMixErr, MixErrCount.ToString());
                    ControlInvoke.GradientLabelText(gradientLabelResult, "MIX NG", Color.Red);
                }

                else
                {
                    ControlInvoke.GradientLabelText(gradientLabelResult, "CODE NG", Color.Red);
                }
            }
        }

        private void SegmentValueInvoke(DmitryBrant.CustomControls.SevenSegmentArray _Control, string _Value)
        {
            if (_Control.InvokeRequired)
            {
                _Control.Invoke(new MethodInvoker(delegate () { _Control.Value = _Value; }));
            }
            else
            {
                _Control.Value = _Value;
            }
        }
    }
}
