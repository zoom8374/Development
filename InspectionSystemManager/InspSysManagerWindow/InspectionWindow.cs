using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;

using LogMessageManager;
using ParameterManager;

namespace InspectionSystemManager
{
    public partial class InspectionWindow : Form
    {
        private InspectionBlobReference     InspBlobReferProc;
        private InspectionNeedleCircleFind  InspNeedleCircleFindProc;
        private InspectionLead              InspLeadProc;

        private TeachingWindow TeachWnd;
        private InspectionParameter InspParam = new InspectionParameter();
        public AreaResultParameterList AreaResultParamList = new AreaResultParameterList();
        public AlgoResultParameterList AlgoResultParamList = new AlgoResultParameterList();

        private int ID;
        private eProjectType ProjectType;
        private eProjectItem ProjectItem;
        private string FormName;
        private bool ResizingFlag = false;
        private bool IsResizing = false;
        private Point LastPosition = new Point(0, 0);

        private CogImageFileTool OriginImageFileTool = new CogImageFileTool();
        private CogImage8Grey    OriginImage = new CogImage8Grey();

        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;

        //검사 시 Area 별 Offset 값을 적용할 변수
        private double AreaBenchMarkOffsetX;
        private double AreaBenchMarkOffsetY;
        private int AreaAlgoCount;

        private int ImageSizeWidth = 0;
        private int ImageSizeHeight = 0;
        private bool IsCrossLine = false;

        private double DisplayZoomValue = 1;
        private double DisplayPanXValue = 0;
        private double DisplayPanYValue = 0;

        private Thread ThreadInspectionProcess;
        private bool IsThreadInspectionProcessExit = false;
        public bool IsThreadInspectionProcessTrigger = false;
        public bool IsInspectionComplete = false;
        private bool InspectionPassFlag = false;

        private Thread ThreadLiveCheck;
        private bool IsThreadLiveCheckExit = false;

        public delegate void InspectionWindowHandler(eIWCMD _Command, object _Value = null);
        public event InspectionWindowHandler InspectionWindowEvent;

        #region Initialize & DeInitialize
        public InspectionWindow()
        {
            InitializeComponent();

            #region Set Button Image Resource
            btnInspection.ButtonImage = InspectionSystemManager.Properties.Resources.Inspection;
            btnInspection.ButtonImageOver = InspectionSystemManager.Properties.Resources.InspectionOver;
            btnInspection.ButtonImageDown = InspectionSystemManager.Properties.Resources.InspectionOver;
            btnOneShot.ButtonImage = InspectionSystemManager.Properties.Resources.OneShot;
            btnOneShot.ButtonImageOver = InspectionSystemManager.Properties.Resources.OneShotOver;
            btnOneShot.ButtonImageDown = InspectionSystemManager.Properties.Resources.OneShotOver;
            btnRecipe.ButtonImage = InspectionSystemManager.Properties.Resources.Recipe;
            btnRecipe.ButtonImageOver = InspectionSystemManager.Properties.Resources.RecipeOver;
            btnRecipe.ButtonImageDown = InspectionSystemManager.Properties.Resources.RecipeOver;
            btnRecipeSave.ButtonImage = InspectionSystemManager.Properties.Resources.RecipeSave;
            btnRecipeSave.ButtonImageOver = InspectionSystemManager.Properties.Resources.RecipeSaveOver;
            btnRecipeSave.ButtonImageDown = InspectionSystemManager.Properties.Resources.RecipeSaveOver;
            btnLive.ButtonImage = InspectionSystemManager.Properties.Resources.Camera;
            btnLive.ButtonImageOver = InspectionSystemManager.Properties.Resources.CameraOver;
            btnLive.ButtonImageDown = InspectionSystemManager.Properties.Resources.CameraOver;
            btnImageSave.ButtonImage = InspectionSystemManager.Properties.Resources.ImageSave;
            btnImageSave.ButtonImageOver = InspectionSystemManager.Properties.Resources.ImageSaveOver;
            btnImageSave.ButtonImageDown = InspectionSystemManager.Properties.Resources.ImageSaveOver;
            btnImageLoad.ButtonImage = InspectionSystemManager.Properties.Resources.ImageLoad;
            btnImageLoad.ButtonImageOver = InspectionSystemManager.Properties.Resources.ImageLoadOver;
            btnImageLoad.ButtonImageDown = InspectionSystemManager.Properties.Resources.ImageLoadOver;
            #endregion Set Button Image Resource
        }

        public void Initialize(Object _OwnerForm, int _ID, InspectionParameter _InspParam, eProjectItem _ProjectItem, string _FormName)
        {
            ID = _ID;
            ProjectItem = _ProjectItem;
            FormName = _FormName;
            this.labelTitle.Text = _FormName;
            this.Owner = (Form)_OwnerForm;

            InspBlobReferProc = new InspectionBlobReference();
            InspBlobReferProc.Initialize();

            InspNeedleCircleFindProc = new InspectionNeedleCircleFind();
            InspNeedleCircleFindProc.Initialize();

            InspLeadProc = new InspectionLead();
            InspLeadProc.Initialize();

            AreaResultParamList = new AreaResultParameterList();
            AlgoResultParamList = new AlgoResultParameterList();

            ThreadInspectionProcess = new Thread(ThreadInspectionProcessFunction);
            IsThreadInspectionProcessExit = false;
            IsThreadInspectionProcessTrigger = false;
            ThreadInspectionProcess.Start();

            ThreadLiveCheck = new Thread(ThreadLiveCheckFunction);
            ThreadLiveCheck.IsBackground = true;
            IsThreadLiveCheckExit = false;
            ThreadLiveCheck.Start();

            TeachWnd = new TeachingWindow();

            SetInspectionParameter(_InspParam);
        }

        public void Deinitialize()
        {
            InspBlobReferProc.DeInitialize();
            InspNeedleCircleFindProc.DeInitialize();
            InspLeadProc.DeInitialize();
        }

        public void SetLocation(int _StartX, int _StartY)
        {
            this.Location = new Point(_StartX, _StartY);
        }

        public void SetWindowSize(int _Width, int _Height)
        {
            this.Size = new Size(_Width, _Height);
        }

        public void SetWindowDisplayInfo(double _Zoom, double _PanX, double _PanY)
        {
            DisplayZoomValue = _Zoom;
            DisplayPanXValue = _PanX;
            DisplayPanYValue = _PanY;
        }

        public void GetWindowDisplayInfo(out double _Zoom, out double _PanX, out double _PanY)
        {
            _Zoom = DisplayZoomValue;
            _PanX = DisplayPanXValue;
            _PanY = DisplayPanYValue;
        }

        public void SetInspectionParameter(InspectionParameter _InspParam, bool _IsNew = true)
        {
            if (InspParam != null) FreeInspectionParameters(ref InspParam);
            CParameterManager.RecipeCopy(_InspParam, ref InspParam);

            //Reference File(VPP) Load
        }

        public void FreeInspectionParameters(ref InspectionParameter _InspParam)
        {
            for (int iLoopCount = 0; iLoopCount < _InspParam.InspAreaParam.Count; ++iLoopCount)
            {
                for (int jLoopCount = 0; jLoopCount < _InspParam.InspAreaParam[iLoopCount].InspAlgoParam.Count; ++jLoopCount)
                    FreeInspectionParameter(ref _InspParam, iLoopCount, jLoopCount);
            }
        }

        public void FreeInspectionParameter(ref InspectionParameter _InspParam, int _AreaIndex, int _AlgoIndex)
        {
            if (eAlgoType.C_PATTERN == (eAlgoType)_InspParam.InspAreaParam[_AreaIndex].InspAlgoParam[_AlgoIndex].AlgoType)
            {

            }
        }
        #endregion Initialize & DeInitialize

        #region Set Image Display Control
        public void SetDisplayImage(CogImage8Grey _DisplayImage)
        {
            if (_DisplayImage != null)
            {
                ImageSizeWidth = _DisplayImage.Width;
                ImageSizeHeight = _DisplayImage.Height;
            }
            kpCogDisplayMain.ClearDisplay();
            kpCogDisplayMain.SetDisplayImage(_DisplayImage);
            GC.Collect();
        }
        #endregion Set Image Display Control

        #region Control Default Event
        private void InspectionWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            if (!IsResizing) // handle cursor type
            {
                bool resize_x = e.X > (this.Width - 8);
                bool resize_y = e.Y > (this.Height - 8);

                if (resize_x && resize_y) this.Cursor = Cursors.SizeNWSE;
                else if (resize_x) this.Cursor = Cursors.SizeWE;
                else if (resize_y) this.Cursor = Cursors.SizeNS;
                else this.Cursor = Cursors.Default;
            }
            else // handle resize
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Right) return;

                int w = this.Size.Width;
                int h = this.Size.Height;

                if (this.Cursor.Equals(Cursors.SizeNWSE)) this.Size = new Size(w + (e.Location.X - this.LastPosition.X), h + (e.Location.Y - this.LastPosition.Y));
                else if (this.Cursor.Equals(Cursors.SizeWE)) this.Size = new Size(w + (e.Location.X - this.LastPosition.X), h);
                else if (this.Cursor.Equals(Cursors.SizeNS)) this.Size = new Size(w, h + (e.Location.Y - this.LastPosition.Y));

                this.LastPosition = e.Location;
            }
        }

        private void InspectionWindow_MouseDown(object sender, MouseEventArgs e)
        {
            this.IsResizing = true;
            this.LastPosition = e.Location;
        }

        private void InspectionWindow_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsResizing = false;
        }

        private void InspectionWindow_Resize(object sender, EventArgs e)
        {
            Size _TitleSize = new Size(this.Size.Width, labelTitle.Size.Height);
            Point _Location = panelMain.Location;

            labelTitle.Size = new Size(_TitleSize.Width - 6, _TitleSize.Height);
            labelTitle.Location = new Point(3, 2);

            panelMain.Size = new Size(_TitleSize.Width - 6, this.Size.Height - _TitleSize.Height - 6);
            panelMain.Location = new Point(3, _Location.Y);

            panelMenu.Size = new Size(panelMain.Width - 6, panelMenu.Height);
            panelMenu.Location = new Point(2, 2);

            Size _DisplayMain = kpCogDisplayMain.Size;
            kpCogDisplayMain.Size = new Size(panelMain.Width - 6, panelMain.Height - panelMenu.Height - 6);
            kpCogDisplayMain.Location = new Point(2, panelMenu.Height + 3);

            panelMain.Invalidate();
            labelTitle.Invalidate();
            panelMenu.Invalidate();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void panelMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            this.Cursor = Cursors.Default;
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMenu.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void labelTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.labelTitle.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void labelTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResizingFlag = !ResizingFlag;
            if (true == ResizingFlag) labelTitle.ForeColor = Color.Chocolate;
            else labelTitle.ForeColor = Color.WhiteSmoke;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            var s = sender as Label;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);

            this.Cursor = Cursors.Default;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            s.Tag = new Point(e.X, e.Y);
        }

        private void InspectionWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;
        }
        #endregion Control Default Event

        #region Control Event
        private void btnInspection_Click(object sender, EventArgs e)
        {
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM{0} Single Inspection Run", ID + 1));
            Inspection();
        }

        private void btnOneShot_Click(object sender, EventArgs e)
        {
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM{0} Single One-Shot Inspection Run", ID + 1));
            InspectionWindowEvent(eIWCMD.ONESHOT_INSP);
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            InspectionWindowEvent(eIWCMD.TEACHING, true);
            Teaching();
            InspectionWindowEvent(eIWCMD.TEACHING, false);
        }

        private void btnRecipeSave_Click(object sender, EventArgs e)
        {
            InspectionWindowEvent(eIWCMD.TEACH_SAVE, ID);
        }

        private void btnLive_Click(object sender, EventArgs e)
        {

        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            LoadCogImage();
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {
            SaveCogImage();
        }
        #endregion Control Event

        #region Image Load & Save
        private string LoadCogImage()
        {
            string _ImageFileName = "";
            string _ImageFilePath = "";

            OpenFileDialog _OpenDialog = new OpenFileDialog();
            _OpenDialog.InitialDirectory = @"D:\VisionInspectionData";
            _OpenDialog.Filter = "BmpFile (*.bmp)|*.bmp";

            try
            {
                if (_OpenDialog.ShowDialog() == DialogResult.OK)
                {
                    _ImageFileName = _OpenDialog.SafeFileName;
                    _ImageFilePath = _OpenDialog.FileName;
                    OriginImageFileTool.Operator.Open(_ImageFilePath, CogImageFileModeConstants.Read);
                    OriginImageFileTool.Run();
                    OriginImage = (CogImage8Grey)OriginImageFileTool.OutputImage;

                    SetDisplayImage(OriginImage);
                } 
            }

            catch
            {
                MessageBox.Show(new Form { TopMost = true }, "Could not open image file.");
            }

            return _ImageFileName;
        }

        private void SaveCogImage(string _SaveDirectory = null)
        {
            if (_SaveDirectory == null) _SaveDirectory = @"D:\VisionInspectionData\" + FormName;
            kpCogDisplayMain.SaveDisplayImage(_SaveDirectory);
        }
        #endregion Image Load & Save

        #region Call Teaching  Window & Parameter Set
        private void Teaching()
        {
            TeachWnd = new TeachingWindow();
            TeachWnd.Initialize(ID, InspParam, ProjectItem);
            TeachWnd.SetResultData(AreaResultParamList, AlgoResultParamList);
            TeachWnd.SetTeachingImage(OriginImage, OriginImage.Width, OriginImage.Height);
            TeachWnd.ShowDialog();
            
            if (DialogResult.OK == TeachWnd.DialogResult)
            {
                //Teaching 한 Recipe Update
                SetInspectionParameter(TeachWnd.GetInspectionParameter());
                InspectionWindowEvent(eIWCMD.TEACH_OK, TeachWnd.GetInspectionParameter());
            }
            TeachWnd.DeInitialize();
            TeachWnd.Dispose();
            GC.Collect();
        }
        #endregion Call Teaching  Window & Parameter Set

        #region Inspection Process
        private bool Inspection()
        {
            bool _Result = false;

            IsInspectionComplete = false;

            do
            {
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - Inspection Start", ID + 1));
                if (false == InspectionResultClear()) break;
                if (false == InspectionProcess()) break;
                if (false == InspectionDataSend()) break;
                if (false == InspectionResultDsiplay()) break;

                _Result = true;
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - Inspection End", ID + 1));
            } while (false);

            GC.Collect();

            //CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - Inspection Result : {1}", ID, ));
            return _Result;
        }

        private bool InspectionResultClear()
        {
            bool _Result = true;
            AreaAlgoCount = 0;
            AreaResultParamList.Clear();
            AlgoResultParamList.Clear();
            DisplayClear(true, true);
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - Inspection Resut Clear", ID + 1));
            return _Result;
        }

        private bool InspectionProcess()
        {
            bool _Result = true;
            System.Diagnostics.Stopwatch _ProcessWatch = new System.Diagnostics.Stopwatch();
            _ProcessWatch.Reset(); _ProcessWatch.Start();
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - InspectionProcess Start", ID + 1));

            for (int iLoopCount = 0; iLoopCount < InspParam.InspAreaParam.Count; ++iLoopCount)
            {
                if (iLoopCount > 0 && InspParam.InspAreaParam[iLoopCount - 1].Enable == true)
                {
                    for (int jLoopCount = 0; jLoopCount < InspParam.InspAreaParam[iLoopCount - 1].InspAlgoParam.Count; ++jLoopCount)
                    {
                        if (InspParam.InspAreaParam[iLoopCount - 1].InspAlgoParam[jLoopCount].AlgoEnable == true)
                            AreaAlgoCount++;
                    }   
                }

                //Area 단위로 검사. Return은 Area 단위별 결과
                AreaStepInspection(InspParam.InspAreaParam[iLoopCount]);
            }

            IsInspectionComplete = true;
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - InspectionProcess End", ID + 1));

            _ProcessWatch.Stop();
            string _ProcessTime = String.Format("ISM {0} - InspectionProcess Time : {1} ms", ID + 1, _ProcessWatch.Elapsed.TotalSeconds.ToString());
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, _ProcessTime);

            return _Result;
        }

        private void AreaStepInspection(InspectionAreaParameter _InspAreaParam)
        {
            if (false == _InspAreaParam.Enable) return; //검사 Enable 확인
            bool _InspectionResult = true;

            
            for (int iLoopCount = 0; iLoopCount < _InspAreaParam.InspAlgoParam.Count; ++iLoopCount)
            {
                int _BenchMark = _InspAreaParam.AreaBenchMark - 1;
                AreaBenchMarkOffsetX = AreaBenchMarkOffsetY = 0;

                //한 Area 에서 Algorithm NG가 발생했을 시 Algorithm Pass를 하면 비어있는 Result를 채워 준다
                if (false == _InspectionResult && true == InspectionPassFlag)
                {
                    AlgoResultParameter _AlgoResultParam = new AlgoResultParameter();
                    AlgoResultParamList.Add(_AlgoResultParam);
                    continue;
                }

                //Area 단위로 Benchmark가 있는 경우 Offset 값 계산. (각 Area의 첫번째 알고리즘의 Offset 값이 적용 됨)
                if (_InspAreaParam.AreaBenchMark > 0 && AreaResultParamList.Count > _BenchMark)
                {
                    AreaBenchMarkOffsetX = AreaResultParamList[_BenchMark].OffsetX;
                    AreaBenchMarkOffsetY = AreaResultParamList[_BenchMark].OffsetY;
                }

                //Algorithm 단위로 검사. Return은 Algorithm 단위의 결과
                double _StartX = _InspAreaParam.AreaRegionCenterX - (_InspAreaParam.AreaRegionWidth / 2) + AreaBenchMarkOffsetX;
                double _StartY = _InspAreaParam.AreaRegionCenterY - (_InspAreaParam.AreaRegionHeight / 2) + AreaBenchMarkOffsetY;
                double _Width = _InspAreaParam.AreaRegionWidth;
                double _Height = _InspAreaParam.AreaRegionHeight;

                _InspectionResult = AlgorithmStepInspection(_InspAreaParam.InspAlgoParam[iLoopCount], _StartX, _StartY, _Width, _Height, _InspAreaParam.NgAreaNumber);

                //각 Area의 첫번째 알고리즘의 Offset 값이 Area 검사 Offset에 적용 됨
                if (iLoopCount == 0)
                {
                    AreaResultParameter _AreaResParam = new AreaResultParameter();
                    int _Index = AlgoResultParamList.Count - 1;
                    if (AlgoResultParamList.Count < _Index)
                    {
                        _AreaResParam.OffsetX = AlgoResultParamList[_Index].OffsetX;
                        _AreaResParam.OffsetY = AlgoResultParamList[_Index].OffsetY;
                        AreaResultParamList.Add(_AreaResParam);
                    }

                    else
                    {
                        _AreaResParam.OffsetX = 0;
                        _AreaResParam.OffsetY = 0;
                        AreaResultParamList.Add(_AreaResParam);
                    }
                }
            }
         }

        #region Algorithm 별 Inspection Step
        private bool AlgorithmStepInspection(InspectionAlgorithmParameter _InspAlgoParam, double _AreaStartX, double _AreaStartY, double _AreaWidth, double _AreaHeight, int _NgAreaNumber)
        {
            bool _Result = true;

            if (false == _InspAlgoParam.AlgoEnable) return true;
            double _BenchMarkOffsetX = 0, _BenchMarkOffsetY = 0;

            #region Buffer Area Calculate
            int _BenchMark = AreaAlgoCount + (_InspAlgoParam.AlgoBenchMark - 1);
            if (_InspAlgoParam.AlgoBenchMark > 0 && AlgoResultParamList.Count > _BenchMark)
            {
                if (AlgoResultParamList[_BenchMark].ResultParam != null)
                {
                    _BenchMarkOffsetX = AlgoResultParamList[_BenchMark].OffsetX - AreaBenchMarkOffsetX;
                    _BenchMarkOffsetY = AlgoResultParamList[_BenchMark].OffsetY - AreaBenchMarkOffsetY;
                }
            }

            double _CenterX = _InspAlgoParam.AlgoRegionCenterX + _BenchMarkOffsetX;
            double _CenterY = _InspAlgoParam .AlgoRegionCenterY + _BenchMarkOffsetY;
            double _Width = _InspAlgoParam.AlgoRegionWidth;
            double _Height = _InspAlgoParam.AlgoRegionHeight;
            CogRectangle _InspRegion = new CogRectangle();
            _InspRegion.SetCenterWidthHeight(_CenterX, _CenterY, _Width, _Height);
            #endregion Buffer Area Calculate

            eAlgoType _AlgoType = (eAlgoType)_InspAlgoParam.AlgoType;
            if (eAlgoType.C_PATTERN == _AlgoType)           _Result = CogPatternAlgorithmStep(_InspAlgoParam.Algorithm, _InspRegion, _NgAreaNumber);
            else if (eAlgoType.C_BLOB_REFER == _AlgoType)   _Result = CogBlobReferenceAlgorithmStep(_InspAlgoParam.Algorithm, _InspRegion, _NgAreaNumber);
            else if (eAlgoType.C_BLOB == _AlgoType)         _Result = CogBlobAlgorithmStep(_InspAlgoParam.Algorithm, _InspRegion, _NgAreaNumber);
            else if (eAlgoType.C_LEAD == _AlgoType)         _Result = CogLeadAlgorithmStep(_InspAlgoParam.Algorithm, _InspRegion, _NgAreaNumber);
            else if (eAlgoType.C_NEEDLE_FIND == _AlgoType)  _Result = CogNeedleCircleFindAlgorithmStep(_InspAlgoParam.Algorithm, _InspRegion, _NgAreaNumber);

            return _Result;
        }

        private bool CogPatternAlgorithmStep(Object _Algorithm, CogRectangle _InspRegion, int _NgAreaNumber)
        {

            return true;
        }

        private bool CogBlobReferenceAlgorithmStep(Object _Algorithm, CogRectangle _InspRegion, int _NgAreaNumber)
        {
            //CogBlobReferenceAlgo    _CogBlobReferAlgo = (CogBlobReferenceAlgo)_Algorithm;
            var _CogBlobReferAlgo = _Algorithm as CogBlobReferenceAlgo;
            CogBlobReferenceResult  _CogBlobReferResult = new CogBlobReferenceResult();

            bool _Result = InspBlobReferProc.Run(OriginImage, _InspRegion, _CogBlobReferAlgo, ref _CogBlobReferResult, _NgAreaNumber);

            AlgoResultParameter _AlgoResultParam = new AlgoResultParameter(eAlgoType.C_BLOB_REFER, _CogBlobReferResult);
            AlgoResultParamList.Add(_AlgoResultParam);

            return _CogBlobReferResult.IsGood;
        }

        private bool CogBlobAlgorithmStep(Object _Algorithm, CogRectangle _InspRegion, int _NgAreaNumber)
        {

            return true;
        }

        private bool CogLeadAlgorithmStep(Object _Algorithm, CogRectangle _InspRegion, int _NgAreaNumber)
        {
            CogLeadAlgo _CogLeadAlgo = _Algorithm as CogLeadAlgo;
            CogLeadResult _CogLeadResult = new CogLeadResult();

            bool _Result = InspLeadProc.Run(OriginImage, _InspRegion, _CogLeadAlgo, ref _CogLeadResult);
            AlgoResultParameter _AlgoResultParam = new AlgoResultParameter(eAlgoType.C_LEAD, _CogLeadResult);
            AlgoResultParamList.Add(_AlgoResultParam);

            return _CogLeadResult.IsGood;
        }

        private bool CogNeedleCircleFindAlgorithmStep(Object _Algorithm, CogRectangle _InspRegion, int _NgAreaNumber)
        {
            CogNeedleFindAlgo   _CogNeedleFindAlgo = _Algorithm as CogNeedleFindAlgo;
            CogNeedleFindResult _CogNeedleFindResult = new CogNeedleFindResult();

            bool _Result = InspNeedleCircleFindProc.Run(OriginImage, _CogNeedleFindAlgo, ref _CogNeedleFindResult);

            AlgoResultParameter _AlgoResultParam = new AlgoResultParameter(eAlgoType.C_NEEDLE_FIND, _CogNeedleFindResult);
            AlgoResultParamList.Add(_AlgoResultParam);

            return _CogNeedleFindResult.IsGood;
        }
        #endregion Algorithm 별 Inspection Step

        #region Algorithm 별 Display
        private bool InspectionResultDsiplay()
        {
            bool _IsLastGood = true, _IsGood = false;

            for (int iLoopCount = 0; iLoopCount < AlgoResultParamList.Count; ++iLoopCount)
            {
                eAlgoType _AlgoType = AlgoResultParamList[iLoopCount].ResultAlgoType;
                if (eAlgoType.C_PATTERN == _AlgoType)           _IsGood = DisplayResultPatternMatching(AlgoResultParamList[iLoopCount].ResultParam, iLoopCount);
                else if (eAlgoType.C_BLOB_REFER == _AlgoType)   _IsGood = DisplayResultBlobReference(AlgoResultParamList[iLoopCount].ResultParam, iLoopCount); 
                else if (eAlgoType.C_BLOB == _AlgoType)         _IsGood = DisplayResultBlob(AlgoResultParamList[iLoopCount].ResultParam, iLoopCount);
                else if (eAlgoType.C_LEAD == _AlgoType)         _IsGood = DisplayResultLeadMeasure(AlgoResultParamList[iLoopCount].ResultParam, iLoopCount);
                else if (eAlgoType.C_NEEDLE_FIND == _AlgoType)  _IsGood = DisplayResultNeedleFind(AlgoResultParamList[iLoopCount].ResultParam, iLoopCount);

                if (true == _IsLastGood) _IsLastGood = _IsGood;
            }
            DisplayLastResultMessage(_IsLastGood);

            return _IsLastGood;
        }

        public void DisplayClear(bool _StaticClear, bool _InteractiveClear)
        {
            //DisplayClear(_StaticClear, _InteractiveClear);
            kpCogDisplayMain.ClearDisplay(_StaticClear, _InteractiveClear);
        }

        private bool DisplayResultPatternMatching(Object _ResultParam, int _Index)
        {
            bool _IsGood = true;

            return _IsGood;
        }

        private bool DisplayResultBlobReference(Object _ResultParam, int _Index)
        {
            bool _IsGood = false;
            //CogBlobReferenceResult _BlobReferResult = (CogBlobReferenceResult)_ResultParam;
            var _BlobReferResult = _ResultParam as CogBlobReferenceResult;

            CogRectangle _Region = new CogRectangle();
            CogPointMarker _Point = new CogPointMarker();
            if (_BlobReferResult.BlobCount > 0)
            {
                for (int iLoopCount = 0; iLoopCount < _BlobReferResult.BlobCount; ++iLoopCount)
                {
                    _IsGood = _BlobReferResult.IsGood;

                    string _DrawName = String.Format("BlobReference_{0}_{1}", _Index, iLoopCount);
                    _Region.SetCenterWidthHeight(_BlobReferResult.BlobCenterX[iLoopCount], _BlobReferResult.BlobCenterY[iLoopCount], _BlobReferResult.Width[iLoopCount], _BlobReferResult.Height[iLoopCount]);
                    _Point.SetCenterRotationSize(_BlobReferResult.OriginX[iLoopCount], _BlobReferResult.OriginY[iLoopCount], 0, 10);
                    ResultDisplay(_Region, _Point, _DrawName, _IsGood);

                    double _WidthSize = _BlobReferResult.Width[iLoopCount] * ResolutionX;
                    double _HeightSize = _BlobReferResult.Height[iLoopCount] * ResolutionY;
                    string _RstName = String.Format("BlobResult_{0}_{1}", _Index, iLoopCount);
                    string _Message = String.Format("W : {0:F3}, H : {1:F3}", _WidthSize, _HeightSize);
                    ResultDisplayMessage(_BlobReferResult.BlobMinX[iLoopCount], _BlobReferResult.BlobMaxY[iLoopCount] + 4, _Message, _IsGood);
                }
            }

            else
            {
                _IsGood = _BlobReferResult.IsGood;

                string _DrawName = String.Format("BlobReference_{0}_{1}", _Index, 0);
                _Region.SetCenterWidthHeight(_BlobReferResult.BlobCenterX[0], _BlobReferResult.BlobCenterY[0], _BlobReferResult.Width[0], _BlobReferResult.Height[0]);
                _Point.SetCenterRotationSize(_BlobReferResult.OriginX[0], _BlobReferResult.OriginY[0], 0, 10);
                ResultDisplay(_Region, _Point, _DrawName, _IsGood);
                
                string _Message = String.Format("BlobReference_{0} NG", _Index);
                ResultDisplayMessage(_BlobReferResult.BlobMinX[0], _BlobReferResult.BlobMaxY[0] + 4, _Message, _IsGood);
            }

            return _IsGood;
        }

        private bool DisplayResultBlob(Object _ResultParam, int _Index)
        {
            bool _IsGood = true;

            return _IsGood;
        }

        private bool DisplayResultLeadMeasure(Object _ResultParam, int _Index)
        {
            CogLeadResult _CogLeadResult = _ResultParam as CogLeadResult;

            for (int iLoopCount = 0; iLoopCount < _CogLeadResult.BlobCount; ++iLoopCount)
            {
                CogRectangleAffine _BlobRectAffine = new CogRectangleAffine();
                _BlobRectAffine.SetCenterLengthsRotationSkew(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount],
                                                            _CogLeadResult.PrincipalWidth[iLoopCount], _CogLeadResult.PrincipalHeight[iLoopCount], _CogLeadResult.Angle[iLoopCount], 0);
                kpCogDisplayMain.DrawStaticShape(_BlobRectAffine, "BlobRectAffine" + (iLoopCount + 1), CogColorConstants.Green);
                kpCogDisplayMain.DrawBlobResult(_CogLeadResult.ResultGraphic[iLoopCount], "BlobRectGra" + (iLoopCount + 1));

                //CogPointMarker _Point = new CogPointMarker();
                //_Point.SetCenterRotationSize(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount], 0, 1);
                //kpTeachDisplay.DrawStaticShape(_Point, "BlobSearchPoint" + (iLoopCount + 1), CogColorConstants.Green, 2);

                CogLineSegment _CenterLineStart = new CogLineSegment();
                _CenterLineStart.SetStartLengthRotation(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount],
                                                    _CogLeadResult.PrincipalWidth[iLoopCount] / 2, _CogLeadResult.Angle[iLoopCount]);
                CogLineSegment _CenterLineEnd = new CogLineSegment();
                _CenterLineEnd.SetStartLengthRotation(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount],
                                                    _CogLeadResult.PrincipalWidth[iLoopCount] / 2, (Math.PI) + _CogLeadResult.Angle[iLoopCount]);

                kpCogDisplayMain.DrawStaticLine(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount],
                                            _CogLeadResult.PrincipalWidth[iLoopCount] / 2 + 20, _CogLeadResult.Angle[iLoopCount], 2, "CenterLine+_" + (iLoopCount + 1), CogColorConstants.Green);
                kpCogDisplayMain.DrawStaticLine(_CogLeadResult.BlobCenterX[iLoopCount], _CogLeadResult.BlobCenterY[iLoopCount],
                                            _CogLeadResult.PrincipalWidth[iLoopCount] / 2 + 20, (Math.PI) + _CogLeadResult.Angle[iLoopCount], 2, "CenterLine-_" + (iLoopCount + 1), CogColorConstants.Green);

                CogPointMarker _PointStart = new CogPointMarker();
                _PointStart.SetCenterRotationSize(_CenterLineStart.EndX, _CenterLineStart.EndY, 0, 1);
                kpCogDisplayMain.DrawStaticShape(_PointStart, "PointStart" + (iLoopCount + 1), CogColorConstants.Red, 2);

                CogPointMarker _PointEnd = new CogPointMarker();
                _PointEnd.SetCenterRotationSize(_CenterLineEnd.EndX, _CenterLineEnd.EndY, 0, 1);
                kpCogDisplayMain.DrawStaticShape(_PointEnd, "PointEnd" + (iLoopCount + 1), CogColorConstants.Yellow, 2);
            }

            return _CogLeadResult.IsGood;
        }

        private bool DisplayResultNeedleFind(Object _ResultParam, int _Index)
        {
            CogNeedleFindResult _CogNeedleFindResult = _ResultParam as CogNeedleFindResult;

            CogCircle _Circle = new CogCircle();
            CogPointMarker _CirclePoint = new CogPointMarker();

            if (_CogNeedleFindResult != null)// && _CogNeedleFindResult.IsGood)
            {

                _Circle.SetCenterRadius(_CogNeedleFindResult.CenterX, _CogNeedleFindResult.CenterY, _CogNeedleFindResult.Radius);
                _CirclePoint.SetCenterRotationSize(_CogNeedleFindResult.CenterX, _CogNeedleFindResult.CenterY, 0, 1);
                ResultDisplay(_Circle, _CirclePoint, "NeedleCircle", _CogNeedleFindResult.IsGood);

                string _CenterPointName = string.Format("X = {0:F2}mm, Y = {1:F2}mm, R = {2:F2}mm", _CogNeedleFindResult.CenterX * ResolutionX, _CogNeedleFindResult.CenterY * ResolutionY, _CogNeedleFindResult.Radius * ResolutionY);
                ResultDisplayMessage(_CogNeedleFindResult.CenterX, _CogNeedleFindResult.CenterY + 30, _CenterPointName, _CogNeedleFindResult.IsGood, CogGraphicLabelAlignmentConstants.BaselineCenter);
            }

            else
            {
                //LOG
            }

            return _CogNeedleFindResult.IsGood;
        }
        #endregion Algorithm 별 Display

        #region Display Result function
        public void ResultDisplay(CogRectangle _Region, CogPointMarker _Point, string _Name, bool _IsGood)
        {
            if (true == _IsGood)    kpCogDisplayMain.DrawStaticShape(_Region, _Name + "_Rect", CogColorConstants.Green);
            else                    kpCogDisplayMain.DrawStaticShape(_Region, _Name + "_Rect", CogColorConstants.Red);

            if (true == _IsGood)    kpCogDisplayMain.DrawStaticShape(_Point, _Name + "_PointOrigin", CogColorConstants.Green);
            else                    kpCogDisplayMain.DrawStaticShape(_Point, _Name + "_PointOrigin", CogColorConstants.Red);
        }

        public void ResultDisplay(CogCircle _Circle, CogPointMarker _Point, string _Name, bool _IsGood)
        {
            if (true == _IsGood)    kpCogDisplayMain.DrawStaticShape(_Circle, "Circle", CogColorConstants.Green, 3);
            else                    kpCogDisplayMain.DrawStaticShape(_Circle, "Circle", CogColorConstants.Red, 3);

            if (true == _IsGood)    kpCogDisplayMain.DrawStaticShape(_Point, _Name + "_PointOrigin", CogColorConstants.Green);
            else                    kpCogDisplayMain.DrawStaticShape(_Point, _Name + "_PointOrigin", CogColorConstants.Red);
        }

        public void ResultDisplayMessage(double _StartX, double _StartY, string _Message, bool _IsGood = true, CogGraphicLabelAlignmentConstants _Align = CogGraphicLabelAlignmentConstants.TopLeft)
        {
            if (true == _IsGood)    kpCogDisplayMain.DrawText(_Message, _StartX, _StartY, CogColorConstants.Green, 8, _Align);
            else                    kpCogDisplayMain.DrawText(_Message, _StartX, _StartY, CogColorConstants.Red, 8, _Align);
        }

        private void DisplayLastResultMessage(bool _IsGood)
        {
            if (_IsGood)    kpCogDisplayMain.DrawText("Result : Good", 50, 50, CogColorConstants.Green);
            else            kpCogDisplayMain.DrawText("Result : NG", 50, 50, CogColorConstants.Red);
        }
        #endregion Display Result function

        private bool InspectionDataSend()
        {
            bool _Result = true;

            InspectionWindowEvent(eIWCMD.SEND_DATA);

            return _Result;
        }
        #endregion Inspection Process

        #region Thread Funtion
        private void ThreadInspectionProcessFunction()
        {
            try
            {
                while (false == IsThreadInspectionProcessExit)
                {
                    if (true == IsThreadInspectionProcessTrigger)
                    {
                        IsThreadInspectionProcessTrigger = false;
                        Inspection();
                    }
                    Thread.Sleep(10);
                }
            }

            catch
            {

            }
        }

        private void ThreadLiveCheckFunction()
        {
            try
            {
                while (false == IsThreadLiveCheckExit)
                {
                    Thread.Sleep(50);
                    CheckInspectionProcessThreadAlive();
                }
            }

            catch
            {
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.ERR, String.Format("ISM {0} - ThreadLiveCheckFunction Exception", ID + 1));

            }
        }

        private void CheckInspectionProcessThreadAlive()
        {
            try
            {
                if (ThreadLiveCheck == null) return;
                if (ThreadLiveCheck.IsAlive == false)
                {
                    ThreadInspectionProcess = null;
                    ThreadInspectionProcess = new Thread(ThreadInspectionProcessFunction);
                    IsThreadInspectionProcessTrigger = false;
                    ThreadInspectionProcess.Start();
                    CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.WARN, String.Format("ISM {0} - ThreadInspectionProcess Re-Start!!", ID + 1));
                }
            }

            catch
            {
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.ERR, String.Format("ISM {0} - CheckInspectionProcessThreadAlive Exception", ID + 1));
            }
        }
        #endregion Thread Funtion
    }
}
