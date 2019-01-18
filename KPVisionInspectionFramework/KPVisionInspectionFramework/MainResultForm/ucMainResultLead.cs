using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

using CustomControl;
using ParameterManager;
using LogMessageManager;
using HistoryManager;

namespace KPVisionInspectionFramework
{
    public partial class ucMainResultLead : UserControl
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

        private string RegTotalCountPath    = String.Format(@"KPVision\ResultCount\TotalCount");
        private string RegGoodCountPath     = String.Format(@"KPVision\ResultCount\GoodCount");
        private string RegNgCountPath       = String.Format(@"KPVision\ResultCount\NgCount");
        private string RegYieldPath         = String.Format(@"KPVision\ResultCount\Yield");
        #endregion Count & Yield Registry Variable

        //LDH, 2018.08.14, History 입력용 string 
        private string[] HistoryParam;
        private string[] LastRecipeName;
        private string LastResult;

        public delegate void ScreenshotHandler(string ScreenshotImagePath);
        public event ScreenshotHandler ScreenshotEvent;

        #region Initialize & DeInitialize
        public ucMainResultLead(string[] _LastRecipeName)
        {
            LastRecipeName = new string[_LastRecipeName.Count()];
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
            for (int iLoopCount = 0; iLoopCount < 22; ++iLoopCount)
            {
                DataGridViewRow _GridRow = new DataGridViewRow();
                DataGridViewCell[] _GridCell = new DataGridViewCell[5];
                _GridCell[0] = gridLeadNum.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[1] = gridLeadBent.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[2] = gridLeadWidth.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[3] = gridLeadLength.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[4] = gridLeadPitch.CellTemplate.Clone() as DataGridViewCell;

                _GridCell[0].Value = (iLoopCount + 1);
                _GridCell[0].Style.BackColor = Color.DarkGreen;
                _GridCell[0].Style.ForeColor = Color.White;
                //_GridCell[1].Style.BackColor = Color.PowderBluePowderBlue;
                //_GridCell[2].Style.BackColor = Color.PowderBlue;
                //_GridCell[3].Style.BackColor = Color.PowderBlue;
                //_GridCell[4].Style.BackColor = Color.PowderBlue;

                _GridRow.Height = 22;
                _GridRow.Cells.AddRange(_GridCell);
                QuickGridViewLeadResult.Rows.Add(_GridRow);
            }
            QuickGridViewLeadResult.ClearSelection();

            //LDH, 2018.08.14, Hitory Parameter용 배열 초기화
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
            //TotalCount  = (Convert.ToUInt32(RegTotalCount.GetValue("Value")) != null) ? Convert.ToUInt32(RegTotalCount.GetValue("Value") : 0;
            TotalCount = Convert.ToUInt32(RegTotalCount.GetValue("Value"));
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
        #endregion Control Default Event

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

        //LDH, 2018.10.12, AutoMode 관리
        public void SetAutoMode(bool _AutoModeFlag)
        {

        }

        public void SetLastRecipeName(string[] _LastRecipeName)
        {
            for (int iLoopCount = 0; iLoopCount < _LastRecipeName.Count(); iLoopCount++)
            {
                LastRecipeName[iLoopCount] = _LastRecipeName[iLoopCount];
            }
        }

        //LDH, 2018.10.01, Result clear
        public void ClearResult()
        {

        }

        public void SetNeedleResultData(SendResultParameter _ResultParam)
        {
            if (_ResultParam.ID == 0)   //Needle Align Vision1
            {
                var _Result = _ResultParam.SendResult as SendNeedleAlignResult;
                if (_Result != null)
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, _Result.AlignX.ToString("F3"));
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, _Result.AlignY.ToString("F3"));
                }
                else
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, "-");
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, "-");
                }

                if (_ResultParam.IsGood)
                {
                    LastResult = "GOOD";
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, Color.Black, Color.White);
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, Color.Black, Color.White);
                    ControlInvoke.GradientLabelText(gradientLabelResult, "GOOD", Color.Lime);
                }

                else
                {
                    if (eNgType.NDL_FIND == _ResultParam.NgType)
                    {
                        LastResult = "Not Found";
                    }

                    else if (eNgType.NDL_CENTER == _ResultParam.NgType)
                    {
                        LastResult = "Not Found";
                    }

                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, Color.White, Color.Red);
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, Color.White, Color.Red);
                    ControlInvoke.GradientLabelText(gradientLabelResult, "Not Found", Color.Red);
                }
            }

            else if (_ResultParam.ID == 1)   //Needle Align Vision2
            {
                var _Result = _ResultParam.SendResult as SendNeedleAlignResult;
                if (_Result != null)
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX2, _Result.AlignX.ToString("F3"));
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY2, _Result.AlignY.ToString("F3"));
                }
                else
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX2, "-");
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY2, "-");
                }

                if (_ResultParam.IsGood)
                {
                    LastResult = "GOOD";
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX2, Color.Black, Color.White);
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY2, Color.Black, Color.White);
                    ControlInvoke.GradientLabelText(gradientLabelResult, "GOOD", Color.Lime);
                }

                else
                {
                    if (eNgType.NDL_FIND == _ResultParam.NgType)
                    {
                        LastResult = "Not Found";
                    }

                    else if (eNgType.NDL_CENTER == _ResultParam.NgType)
                    {
                        LastResult = "Not Found";
                    }

                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX2, Color.White, Color.Red);
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY2, Color.White, Color.Red);
                    ControlInvoke.GradientLabelText(gradientLabelResult, "Not Found", Color.Red);
                }
            }

            else
            {
                //LOG
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, "ucMainResultLead - SetNeedleData ID Match Error", CLogManager.LOG_LEVEL.LOW);
            }

            InspectionHistory(_ResultParam.ID, LastResult);
        }

        public void SetLeadResultData(SendResultParameter _ResultParam)
        {
            var _Result = _ResultParam.SendResult as SendLeadResult;

            if (_Result != null)
            {
                for (int iLoopCount = 0; iLoopCount < _Result.LeadCount; ++iLoopCount)
                {
                    double _Angle = _Result.LeadAngle[iLoopCount] * 180 / Math.PI;
                    if (_Angle > 0) _Angle = 90 - (_Result.LeadAngle[iLoopCount] * 180 / Math.PI);
                    else _Angle = -(90 + (_Result.LeadAngle[iLoopCount] * 180 / Math.PI));

                    QuickGridViewLeadResult[1, iLoopCount].Value = _Angle.ToString("F3");
                    QuickGridViewLeadResult[2, iLoopCount].Value = _Result.LeadWidthReal[iLoopCount].ToString("F3");
                    QuickGridViewLeadResult[3, iLoopCount].Value = _Result.LeadLengthReal[iLoopCount].ToString("F3");

                    if (_Result.IsLeadBendGood[iLoopCount] && iLoopCount % 2 == 0) QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.PowderBlue;
                    else if (_Result.IsLeadBendGood[iLoopCount] && iLoopCount % 2 == 1) QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.White;
                    else QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.Red;
                }

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

                    if (eNgType.LEAD_BENT == _ResultParam.NgType)
                    {
                        LastResult = "LEAD BENT";
                        ControlInvoke.GradientLabelText(gradientLabelResult, "LEAD BENT", Color.Red);
                    }

                    else if (eNgType.LEAD_CNT == _ResultParam.NgType)
                    {
                        LastResult = "LEAD COUNT";
                        ControlInvoke.GradientLabelText(gradientLabelResult, "LEAD COUNT", Color.Red);
                    }
                }
            }

            SaveResultCount();

            InspectionHistory(_ResultParam.ID, LastResult);
            QuickGridViewLeadResult.ClearSelection();
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

        //LDH, 2018.08.13, History 추가용 함수
        private void InspectionHistory(int _ID, string _Result)
        {
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("InspectionHistory Start"), CLogManager.LOG_LEVEL.LOW);

            DateTime dateTime = DateTime.Now;
            string InspScreenshotPath = @"D:\VisionInspectionData\CIPOSLeadInspection\HistoryData\Screenshot\";
            string ImageSaveFolder = String.Format("{0}{1:D4}\\{2:D2}\\{3:D2}", InspScreenshotPath, dateTime.Year, dateTime.Month, dateTime.Day);

            if (false == Directory.Exists(ImageSaveFolder)) Directory.CreateDirectory(ImageSaveFolder);

            string ImageSaveFile;
            ImageSaveFile = String.Format("{0}\\{1:D2}{2:D2}{3:D2}{4:D3}.bmp", ImageSaveFolder, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            //LDH, 2018.08.13, 프로젝트별로 DB에 해당하는 history 내역을 string 배열로 전달
            HistoryParam[0] = LastRecipeName[0];
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
