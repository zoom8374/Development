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

        public delegate void ScreenshotHandler(string ScreenshotImagePath);
        public event ScreenshotHandler ScreenshotEvent;

        private const int DEFECT_TOTAL_CNT = 25;

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
            for (int iLoopCount = 0; iLoopCount < DEFECT_TOTAL_CNT; ++iLoopCount)
            {
                DataGridViewRow _GridRow = new DataGridViewRow();
                DataGridViewCell[] _GridCell = new DataGridViewCell[4];
                _GridCell[0] = gridLeadNum.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[1] = gridDefectWidth.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[2] = gridDefectHeight.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[3] = gridDefectHeight.CellTemplate.Clone() as DataGridViewCell;

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

            //LDH, Hitory Parameter용 배열 초기화
            HistoryParam = new string[4];
            for (int iLoopCount = 0; iLoopCount < HistoryParam.Count(); iLoopCount++)
            {
                HistoryParam[iLoopCount] = "-";
            }
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

                for (int iLoopCount = 0; iLoopCount < DEFECT_TOTAL_CNT; ++iLoopCount)
                {
                    QuickGridViewResult[1, iLoopCount].Value = "0";
                    QuickGridViewResult[2, iLoopCount].Value = "0";
                    QuickGridViewResult[3, iLoopCount].Value = "0";
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

                int _DefectCount = _Result.DefectCount;
                if (_DefectCount > DEFECT_TOTAL_CNT) _DefectCount = DEFECT_TOTAL_CNT;

                for (int iLoopCount = 0; iLoopCount < DEFECT_TOTAL_CNT; ++iLoopCount)
                {
                    QuickGridViewResult[1, iLoopCount].Value = "0";
                    QuickGridViewResult[2, iLoopCount].Value = "0";
                    QuickGridViewResult[3, iLoopCount].Value = "0";
                }

                for (int iLoopCount = 0; iLoopCount < _DefectCount; ++iLoopCount)
                {
                    if (DEFECT_TOTAL_CNT <= iLoopCount) break;
                    QuickGridViewResult[1, iLoopCount].Value = _Result.WidthList[iLoopCount].ToString("F3") + " mm";
                    QuickGridViewResult[2, iLoopCount].Value = _Result.HeightList[iLoopCount].ToString("F3") + " mm";
                    QuickGridViewResult[3, iLoopCount].Value = _Result.NgNumber[iLoopCount].ToString();
                }

                LastResult = "NG";
                ControlInvoke.GradientLabelText(gradientLabelResult, "NG", Color.Red);
            }

            InspectionHistory(_ResultParam.ID, LastResult);

            SaveResultCount();
            QuickGridViewResult.ClearSelection();
        }

        private void InspectionHistory(int _ID, string _Result)
        {
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("InspectionHistory Start"), CLogManager.LOG_LEVEL.LOW);

            DateTime dateTime = DateTime.Now;
            string InspScreenshotPath = @"D:\VisionInspectionData\CIPOSVoidInspection\HistoryData\Screenshot\";
            string ImageSaveFolder = String.Format("{0}{1:D4}\\{2:D2}\\{3:D2}", InspScreenshotPath, dateTime.Year, dateTime.Month, dateTime.Day);

            if (false == Directory.Exists(ImageSaveFolder)) Directory.CreateDirectory(ImageSaveFolder);

            string ImageSaveFile;
            ImageSaveFile = String.Format("{0}\\{1:D2}{2:D2}{3:D2}{4:D3}.bmp", ImageSaveFolder, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            //LDH, 2018.08.13, 프로젝트별로 DB에 해당하는 history 내역을 string 배열로 전달
            HistoryParam[0] = LastRecipeName;
            HistoryParam[1] = _ID.ToString();
            HistoryParam[2] = _Result;
            HistoryParam[3] = ImageSaveFile;

            CHistoryManager.AddHistory(HistoryParam);
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("InspectionHistory End"), CLogManager.LOG_LEVEL.LOW);

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("Screenshot Start"), CLogManager.LOG_LEVEL.LOW);
            var _ScreenshotEvent = ScreenshotEvent;
            _ScreenshotEvent?.Invoke(ImageSaveFile);
            //ScreenshotEvent(ImageSaveFile);
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("Screenshot End"), CLogManager.LOG_LEVEL.LOW);
        }
    }
}
