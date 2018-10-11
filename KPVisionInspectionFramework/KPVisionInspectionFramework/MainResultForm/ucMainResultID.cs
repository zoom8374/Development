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

        //LDH, 2018.09.28, InData용
        List<string> InDataList = new List<string>();
        List<string> OutDataList = new List<string>();
        int InDataLimitCount = 0;
        string NowInspectionID;
        string InspectionTime;
        

        public delegate void ScreenshotHandler(string ScreenshotImagePath);
        public event ScreenshotHandler ScreenshotEvent;

        #region Initialize & DeInitialize
        public ucMainResultID(string _LastRecipeName)
        {
            SetLastRecipeName(_LastRecipeName);

            InitializeComponent();
            InitializeControl();
            this.Location = new Point(1, 1);
        }

        public void InitializeControl()
        {
            ClearResult();
        }

        public void DeInitialize()
        {

        }
        #endregion Initialize & DeInitialize

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.Green, ButtonBorderStyle.Solid);
        }

        public void SetLastRecipeName(string _LastRecipeName)
        {
            LastRecipeName = _LastRecipeName;
        }

        //LDH, 2018.10.01, Result clear
        public void ClearResult(string LotNum = "")
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

            //LDH, 2018.09.27, InData List 
            ReadInData(@"D:\MITfileTest.txt");
            InDataLimitCount = 13;

            //LDH, 2018.08.13, Hitory Parameter용 배열 초기화
            HistoryParam = new string[4];
            for (int iLoopCount = 0; iLoopCount < HistoryParam.Count(); iLoopCount++)
            {
                HistoryParam[iLoopCount] = "-";
            }
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

                //LDH, 2018.09.27, AirBlower file 관리 
                //NowInspectionID = _DataMatrixString;
                //SetOutData(_DataMatrixString);

                LastResult = "GOOD";
                if (eNgType.DUMMY == _ResultParam.NgType)   {   LastResult = "DUMMY"; }
                else                                        {   NowInspectionID = _DataMatrixString;    LastResult = SetOutData(_DataMatrixString);  }

                if (LastResult == "OK")         ControlInvoke.GradientLabelText(gradientLabelResult, LastResult, Color.Lime);
                else if (LastResult == "DUMMY") ControlInvoke.GradientLabelText(gradientLabelResult, LastResult, Color.Lime);
                else                            ControlInvoke.GradientLabelText(gradientLabelResult, LastResult, Color.Red);

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

            InspectionHistory(_DataMatrixString);
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

        //LDH, 2018.09.27, InData 읽어오기
        private void ReadInData(string InDataLotNum)
        {
            FileManager objFileManager = new FileManager();
            List<string> FileReadTemp;

            string FolderPath = "";

            if (InDataLotNum == "") FolderPath = @"F:\MITfileTest.txt";
            else
            {
                FolderPath = "F:\\" + InDataLotNum;

                try
                {
                    if (Directory.Exists(FolderPath))
                    {
                        DirectoryInfo DInfo = new DirectoryInfo(FolderPath);
                        List<string> FileList = new List<string>();

                        foreach (var item in DInfo.GetFiles())
                        {
                            FileList.Add(item.Name);
                        }

                        FileList.Sort();
                        FolderPath = FolderPath + "\\" + FileList[FileList.Count - 1];
                    }
                    else
                    {
                        MessageBox.Show("LOT InData 폴더가 없습니다."); return;
                    }
                }
                catch
                {
                    MessageBox.Show("LOT InData 파일이 없습니다."); return;
                }
            }

            FileReadTemp = objFileManager.txtFileRead(FolderPath);

            for(int iLoopCount = 0; iLoopCount < FileReadTemp.Count; iLoopCount++)
            {
                if (FileReadTemp[iLoopCount] != "")
                {
                    InDataList.Add(FileReadTemp[iLoopCount]);
                    OutDataList.Add(FileReadTemp[iLoopCount]);
                }
            }
        }

        //LDH, 2018.09.28, OutData 쓰기
        private void WriteOutData(string OutDataFilePath)
        {
            FileManager objFileManager = new FileManager();

            objFileManager.txtFileWrite(OutDataFilePath, OutDataList);
        }

        //LDH, 2018.09.27, Outdata 추가
        private string SetOutData(string ResultID)
        {
            int IDIndex = -1;
            int ErrorCode = 0;
            string Result = "OK";

            string TempInData;
            string[] ArrInData;

            try
            {
                IDIndex = OutDataList.FindIndex(FindText);

                TempInData = OutDataList[IDIndex];
                ArrInData = OutDataList[IDIndex].Split(',');

                if (ResultID.Contains(ArrInData[1]))
                {
                    if (InDataLimitCount < Convert.ToInt32(ArrInData[2])) ErrorCode = 1;
                }
                else ErrorCode = 2;
            }
            catch
            {
                TempInData = OutDataList[0];

                string[] LOTInfo = TempInData.Split(',');

                if (ResultID.Contains(LOTInfo[0])) ErrorCode = 3;
                else ErrorCode = 2;

                string[] AddListData = new string[12];
                AddListData[0] = ResultID;
                AddListData[1] = ResultID.Substring(0, ResultID.IndexOf(' '));
                AddListData[2] = "1";
                AddListData[11] = "EOS";
                IDIndex = OutDataList.Count;

                OutDataList.Add("");
                ArrInData = AddListData;
            }

            if (ErrorCode != 0) Result = "NG";
            
            DateTime dateTime = DateTime.Now;
            InspectionTime = String.Format("{0:D2}{1:D2}{2:D2}{3:D3}", dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            string OutDataTime = String.Format("{0:D4}{1:D2}{2:D2}{3}", dateTime.Year, dateTime.Month, dateTime.Day, InspectionTime.Substring(0,6));

            ArrInData[7] = OutDataTime;
            ArrInData[8] = TotalCount.ToString();
            ArrInData[9] = ErrorCode.ToString();
            ArrInData[10] = Result;

            OutDataList[IDIndex] = string.Join(",", ArrInData);

            WriteOutData(@"F:\MITfileTest_Out.txt");

            return Result;
        }

        private bool FindText(string Text)
        {
            if (Text.Contains(NowInspectionID))
            {
                string[] TextTemp = Text.Split(',');

                if(TextTemp[0] == NowInspectionID) return true;
            }
            return false;
        }

        //LDH, 2018.08.13, History 추가용 함수
        private void InspectionHistory(string _ReadCodeData)
        {
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("InspectionHistory Start"), CLogManager.LOG_LEVEL.LOW);

            DateTime dateTime = DateTime.Now;
            string InspScreenshotPath = @"D:\VisionInspectionData\CIPOSLeadInspection\HistoryData\Screenshot\";
            string ImageSaveFolder = String.Format("{0}{1:D4}\\{2:D2}\\{3:D2}", InspScreenshotPath, dateTime.Year, dateTime.Month, dateTime.Day);

            if (false == Directory.Exists(ImageSaveFolder)) Directory.CreateDirectory(ImageSaveFolder);

            string ImageSaveFile;
            //ImageSaveFile = String.Format("{0}\\{1:D2}{2:D2}{3:D2}{4:D3}.bmp", ImageSaveFolder, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
            ImageSaveFile = String.Format("{0}\\{1}.bmp", ImageSaveFolder, InspectionTime);

            //LDH, 2018.08.13, 프로젝트별로 DB에 해당하는 history 내역을 string 배열로 전달
            HistoryParam[0] = LastRecipeName;
            HistoryParam[1] = LastResult;
            HistoryParam[2] = _ReadCodeData;
            HistoryParam[3] = ImageSaveFile;

            CHistoryManager.AddHistory(HistoryParam);
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("InspectionHistory End"), CLogManager.LOG_LEVEL.LOW);

            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("Screenshot Start"), CLogManager.LOG_LEVEL.LOW);
            ScreenshotEvent(ImageSaveFile);
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("Screenshot End"), CLogManager.LOG_LEVEL.LOW);
        }
    }
}
