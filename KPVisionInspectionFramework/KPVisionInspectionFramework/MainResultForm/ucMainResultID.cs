using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using CustomControl;
using ParameterManager;
using LogMessageManager;
using HistoryManager;

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

        //LDH, 2018.08.13, History 입력용 string 
        string[] HistoryParam;
        string LastRecipeName;
        string LastResult;

        public delegate void ScreenshotHandler(string ScreenshotImagePath);
        public event ScreenshotHandler ScreenshotEvent;

        #region Initialize & DeInitialize
        public ucMainResultID(string _LastRecipeName)
        {
            LastRecipeName = _LastRecipeName;

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

            //LDH, 2018.08.13, Hitory Parameter용 배열 초기화
            HistoryParam = new string[4];
            for (int iLoopCount = 0; iLoopCount < HistoryParam.Count(); iLoopCount++)
            {
                HistoryParam[iLoopCount] = "-";
            }
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

                LastResult = "GOOD";
                ControlInvoke.GradientLabelText(gradientLabelResult, LastResult, Color.Lime);
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
                    LastResult = "CODE NG";
                }

                else if (eNgType.EMPTY == _ResultParam.NgType)
                {
                    BlankErrCount++;
                    SegmentValueInvoke(SevenSegBlankErr, BlankErrCount.ToString());
                    LastResult = "EMPTY";
                }

                else if (eNgType.REF_NG == _ResultParam.NgType)
                {
                    MixErrCount++;
                    SegmentValueInvoke(SevenSegMixErr, MixErrCount.ToString());
                    LastResult = "MIX NG";
                }

                else
                {
                    LastResult = "CODE NG";
                }

                ControlInvoke.GradientLabelText(gradientLabelResult, LastResult, Color.Red);
            }

            InspectionHistory(_Result);
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
        private void InspectionHistory(SendIDResult _ResultParam)
        {
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("InspectionHistory Start"));

            DateTime dateTime = DateTime.Now;
            string InspScreenshotPath = @"D:\VisionInspectionData\CIPOSLeadInspection\HistoryData\Screenshot\";
            string ImageSaveFolder = String.Format("{0}{1:D4}\\{2:D2}\\{3:D2}", InspScreenshotPath, dateTime.Year, dateTime.Month, dateTime.Day);

            if (false == Directory.Exists(ImageSaveFolder)) Directory.CreateDirectory(ImageSaveFolder);

            string ImageSaveFile;
            ImageSaveFile = String.Format("{0}\\{1:D2}{2:D2}{3:D2}{4:D3}.bmp", ImageSaveFolder, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            //LDH, 2018.08.13, 프로젝트별로 DB에 해당하는 history 내역을 string 배열로 전달
            HistoryParam[0] = LastRecipeName;
            HistoryParam[1] = LastResult;
            HistoryParam[2] = _ResultParam.ReadCode;
            HistoryParam[3] = ImageSaveFile;

            CHistoryManager.AddIDHistory(HistoryParam);
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("InspectionHistory End"));

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("Screenshot Start"));
            ScreenshotEvent(ImageSaveFile);
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("Screenshot End"));
        }
    }
}
