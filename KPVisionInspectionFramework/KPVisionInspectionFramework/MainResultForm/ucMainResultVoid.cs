using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

using CustomControl;
using ParameterManager;
using LogMessageManager;
using HistoryManager;

namespace KPVisionInspectionFramework
{
    public partial class ucMainResultVoid : UserControl
    {
        #region Count & Yield Variable
        private uint TotalCount
        {
            set { SegmentValueInvoke(SevenSegTotal, value.ToString()); }
            get { return Convert.ToUInt32(SevenSegTotal.Value); }
        }

        private uint GoodCount
        {
            set { SegmentValueInvoke(SevenSegGood, value.ToString()); }
            get { return Convert.ToUInt32(SevenSegGood.Value); }
        }

        private uint NgCount
        {
            set { SegmentValueInvoke(SevenSegNg, value.ToString()); }
            get { return Convert.ToUInt32(SevenSegNg.Value); }
        }

        private double Yield
        {
            set { SegmentValueInvoke(SevenSegYield, value.ToString()); }
            get { return Convert.ToDouble(SevenSegYield.Value); }
        }
        #endregion Count & Yield Variable

        #region Count & Yield Registry Variable
        private RegistryKey RegTotalCount;
        private RegistryKey RegGoodCount;
        private RegistryKey RegNgCount;
        private RegistryKey RegYield;

        private string RegTotalCountPath = String.Format(@"KPVision\ResultCount\TotalCount");
        private string RegGoodCountPath = String.Format(@"KPVision\ResultCount\GoodCount");
        private string RegNgCountPath = String.Format(@"KPVision\ResultCount\NgCount");
        private string RegYieldPath = String.Format(@"KPVision\ResultCount\Yield");
        #endregion Count & Yield Registry Variable

        //LDH, 2018.08.14, History 입력용 string 
        private string[] HistoryParam;
        private string LastRecipeName;
        private string LastResult;

        #region Initialize & DeInitialize
        public ucMainResultVoid(string _LastRecipeName)
        {
            SetLastRecipeName(_LastRecipeName);

            InitializeComponent();
            InitializeControl();
            this.Location = new Point(1, 1);

            RegTotalCount = Registry.CurrentUser.CreateSubKey(RegTotalCountPath);
            RegGoodCount = Registry.CurrentUser.CreateSubKey(RegGoodCountPath);
            RegNgCount = Registry.CurrentUser.CreateSubKey(RegNgCountPath);
            RegYield = Registry.CurrentUser.CreateSubKey(RegYieldPath);
            LoadResultCount();
        }

        private void InitializeControl()
        {
            for (int iLoopCount = 0; iLoopCount < 25; ++iLoopCount)
            {
                DataGridViewRow _GridRow = new DataGridViewRow();
                DataGridViewCell[] _GridCell = new DataGridViewCell[3];
                _GridCell[0] = gridLeadNum.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[1] = gridLeadBent.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[2] = gridLeadWidth.CellTemplate.Clone() as DataGridViewCell;
            
                _GridCell[0].Value = (iLoopCount + 1);
                _GridCell[0].Style.BackColor = Color.DarkGreen;
                _GridCell[0].Style.ForeColor = Color.White;
                //_GridCell[1].Style.BackColor = Color.PowderBluePowderBlue;
                //_GridCell[2].Style.BackColor = Color.PowderBlue;
                //_GridCell[3].Style.BackColor = Color.PowderBlue;
                //_GridCell[4].Style.BackColor = Color.PowderBlue;
            
                _GridRow.Height = 22;
                _GridRow.Cells.AddRange(_GridCell);
                QuickGridViewResult.Rows.Add(_GridRow);
            }
            QuickGridViewResult.ClearSelection();
        }

        public void DeInitialize()
        {

        }

        private void LoadResultCount()
        {
            TotalCount  = Convert.ToUInt32(RegTotalCount.GetValue("Value"));
            GoodCount   = Convert.ToUInt32(RegGoodCount.GetValue("Value"));
            NgCount     = Convert.ToUInt32(RegNgCount.GetValue("Value"));
            Yield       = Convert.ToDouble(RegYield.GetValue("Value"));

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "Load Result Count");
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("TotalCount : {0}, GoodCount : {1}, NgCount : {2}, Yield : {3:F3}", TotalCount, GoodCount, NgCount, Yield));
        }

        private void SaveResultCount()
        {
            RegTotalCount.SetValue("Value", TotalCount, RegistryValueKind.String);
            RegGoodCount.SetValue("Value", GoodCount, RegistryValueKind.String);
            RegNgCount.SetValue("Value", NgCount, RegistryValueKind.String);
            RegYield.SetValue("Value", Yield, RegistryValueKind.String);

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "Save Result Count");
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("TotalCount : {0}, GoodCount : {1}, NgCount : {2}, Yield : {3:F3}", TotalCount, GoodCount, NgCount, Yield));
        }
        #endregion Initialize & DeInitialize

        #region Control Default Event
        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void gradientLabelTotalCount_DoubleClick(object sender, EventArgs e)
        {
            DialogResult _DlgResult = MessageBox.Show(new Form { TopMost = true }, "Clear Result Count ?", "Clear Count", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            if (_DlgResult != DialogResult.Yes) return;

            TotalCount = 0;
            GoodCount = 0;
            NgCount = 0;
            Yield = 0;

            SaveResultCount();
        }

        private void gradientLabelGoodCount_DoubleClick(object sender, EventArgs e)
        {
            DialogResult _DlgResult = MessageBox.Show(new Form { TopMost = true }, "Clear Result Count ?", "Clear Count", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            if (_DlgResult != DialogResult.Yes) return;

            GoodCount = 0;
            Yield = (double)GoodCount / (double)TotalCount * 100;

            SaveResultCount();
        }

        private void gradientLabelNgCount_DoubleClick(object sender, EventArgs e)
        {
            DialogResult _DlgResult = MessageBox.Show(new Form { TopMost = true }, "Clear Result Count ?", "Clear Count", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            if (_DlgResult != DialogResult.Yes) return;

            NgCount = 0;

            SaveResultCount();
        }
        #endregion

        #region Label Invoke
        /// <summary>
        /// Label Update
        /// </summary>
        /// <param name="_Control">Label Conrol</param>
        /// <param name="_Msg">Label Text</param>
        /// <param name="_BackColor">Label BackColor</param>
        /// <param name="_FontColor">Label ForeColor</param>
        private void LabelUpdateInvoke(Label _Control, string _Msg, Color _BackColor, Color _FontColor)
        {
            if (_Control.InvokeRequired)
            {
                _Control.Invoke(new MethodInvoker(delegate ()
                {
                    _Control.Text = _Msg;
                    _Control.BackColor = _BackColor;
                    _Control.ForeColor = _FontColor;
                }
                ));
            }

            else
            {
                _Control.Text = _Msg;
                _Control.BackColor = _BackColor;
                _Control.ForeColor = _FontColor;
            }
        }

        /// <summary>
        /// Label Update
        /// </summary>
        /// <param name="_Control">Label Conrol</param>
        /// <param name="_Msg">Label Text</param>
        /// <param name="_BackColor">Label BackColor</param>
        /// <param name="_FontColor">Label ForeColor</param>
        private void LabelUpdateInvoke(Label _Control, string _Msg)
        {
            if (_Control.InvokeRequired)
            {
                _Control.Invoke(new MethodInvoker(delegate ()
                {
                    _Control.Text = _Msg;
                }
                ));
            }

            else
            {
                _Control.Text = _Msg;
            }
        }
        #endregion Label Invoke

        #region Segment Invoke
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
        #endregion

        public void SetLastRecipeName(string _LastRecipeName)
        {
            LastRecipeName = _LastRecipeName;
        }

        public void SetVoidResultData(SendResultParameter _ResultParam)
        {
            var _Result = _ResultParam.SendResult as SendVoidResult;

            if (_ResultParam.IsGood)
            {
                if (CParameterManager.SystemMode == eSysMode.AUTO_MODE)
                {
                    TotalCount++;
                    GoodCount++;
                    Yield = (double)GoodCount / (double)TotalCount * 100;
                    SegmentValueInvoke(SevenSegTotal, TotalCount.ToString());
                    SegmentValueInvoke(SevenSegGood, GoodCount.ToString());
                    SegmentValueInvoke(SevenSegYield, Yield.ToString("F2"));
                }

                LastResult = "GOOD";
                ControlInvoke.GradientLabelText(gradientLabelResult, "GOOD", Color.Lime);
            }

            else
            {
                if (CParameterManager.SystemMode == eSysMode.AUTO_MODE)
                {
                    TotalCount++;
                    NgCount++;
                    Yield = (double)GoodCount / (double)TotalCount * 100;
                    SegmentValueInvoke(SevenSegTotal, TotalCount.ToString());
                    SegmentValueInvoke(SevenSegNg, NgCount.ToString());
                    SegmentValueInvoke(SevenSegYield, Yield.ToString("F2"));
                }

                for (int iLoopCount = 0; iLoopCount < _Result.DefectCount; ++iLoopCount)
                {
                    if (iLoopCount > 25) break;
                    QuickGridViewResult[1, iLoopCount].Value = _Result.Width[iLoopCount].ToString("F3") + " mm";
                    QuickGridViewResult[2, iLoopCount].Value = _Result.Height[iLoopCount].ToString("F3") + " mm";
                }

                LastResult = "NG";
                ControlInvoke.GradientLabelText(gradientLabelResult, "NG", Color.Red);
            }

            SaveResultCount();
            QuickGridViewResult.ClearSelection();
        }
    }
}
