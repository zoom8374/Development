﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using InspectionSystemManager;
using ParameterManager;
using LogMessageManager;
using LoadingManager;
using DIOControlManager;
using LightManager;
using SerialManager;
using HistoryManager;
using CustonMsgBoxManager;

namespace KPVisionInspectionFramework
{
    public partial class MainForm : RibbonForm
    {
        private CParameterManager           ParamManager;
        private CInspectionSystemManager[]  InspSysManager;
        private CLogManager                 LogWnd;
        private MainResultBase              ResultBaseWnd;
		private CLightManager               LightControlManager;
        private RecipeWindow                RecipeWnd;
        private MainProcessBase             MainProcess;
        private CHistoryManager             HistoryManager;

        private int ISMModuleCount = 1;

        private Timer TimerShowWindow = new Timer(); //Dialog Show용 Timer
        private int TimerCount = 0;

        #region Window Message Variable
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int SC_SIZE = 0xF000;
        #endregion Window Message Variable

        #region Initialize & DeInitialize
        public MainForm()
        {
            CMsgBoxManager.Initialize();
            ProgramLogin();

            CLoadingManager.Show("Program Run", "Program Run Waiting...");
            InitializeComponent();
            Initialize();
            CLoadingManager.Hide();

            System.Threading.Thread.Sleep(150);
            TimerShowWindow.Start();
        }

        private void ProgramLogin()
        {
            #region Parameter Initialize
            ParamManager = new CParameterManager();
            ParamManager.Initialize("CIPOSLeadInspection");
            #endregion Parameter Initialize
        }

        private void Initialize()
        {
            LoadDefaultRibbonTheme();

            #region Ribbon Menu Setting
            UpdateRibbonRecipeName(ParamManager.SystemParam.LastRecipeName);

            if ((int)eProjectType.DISPENSER == ParamManager.SystemParam.ProjectType)
            {
                rbAlign.Visible = false;
                rbSerial.Visible = false;
                rbConfig.Visible = false;
                rbLabelCode.Visible = false;
            }

            else if ((int)eProjectType.BLOWER == ParamManager.SystemParam.ProjectType)
            {
                rbAlign.Visible = false;
                rbConfig.Visible = false;
            }
            #endregion Ribbon Menu Setting

            #region Log Window Initialize
                LogWnd = new CLogManager();
            CLogManager.LogSystemSetting(@"D:\VisionInspectionData\CIPOSLeadInspection\Log\SystemLog");
            CLogManager.LogInspectionSetting(@"D:\VisionInspectionData\CIPOSLeadInspection\Log\InspectionLog");
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "MainProcess : CIPOS lead inspection program run!!");
            #endregion Log Window Initialize

            #region SubWindow 생성 및 Event 등록
            //Recipe Initialize
            RecipeWnd = new RecipeWindow(ParamManager.SystemParam.LastRecipeName);
            RecipeWnd.RecipeChangeEvent += new RecipeWindow.RecipeChangeHandler(RecipeChange);

            //Result Initialize
            ResultBaseWnd = new MainResultBase(ParamManager.SystemParam.LastRecipeName);
            ResultBaseWnd.Initialize(this, ParamManager.SystemParam.ProjectType);
            ResultBaseWnd.SetWindowLocation(ParamManager.SystemParam.ResultWindowLocationX, ParamManager.SystemParam.ResultWindowLocationY);
            ResultBaseWnd.SetWindowSize(ParamManager.SystemParam.ResultWindowWidth, ParamManager.SystemParam.ResultWindowHeight);

            //Light Initialize
            LightControlManager = new CLightManager();
            if (!ParamManager.SystemParam.IsSimulationMode)
            {
                LightControlManager.Initialize(ParamManager.SystemParam.LastRecipeName);
            }

            HistoryManager = new CHistoryManager(((eProjectType)ParamManager.SystemParam.ProjectType).ToString());

            System.Threading.Thread.Sleep(100);
            #endregion SubWindow 생성 및 Event 등록

            #region Project 별 MainProcess Setting
            if ((int)eProjectType.DISPENSER == ParamManager.SystemParam.ProjectType)    MainProcess = new MainProcessDispensor();
            else if ((int)eProjectType.BLOWER == ParamManager.SystemParam.ProjectType)  MainProcess = new MainProcessID();

            MainProcess.MainProcessCommandEvent += new MainProcessBase.MainProcessCommandHandler(MainProcessCommandEventFunction);
            MainProcess.Initialize();
            #endregion MainProcess Setting

            #region InspSysManager Initialize
            ISMModuleCount = ParamManager.SystemParam.InspSystemManagerCount;
            InspSysManager = new CInspectionSystemManager[ISMModuleCount];
            for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
            {
                InspSysManager[iLoopCount] = new CInspectionSystemManager(iLoopCount, "Vision" + (iLoopCount + 1), ParamManager.SystemParam.IsSimulationMode);
                InspSysManager[iLoopCount].InspSysManagerEvent += new CInspectionSystemManager.InspSysManagerHandler(InspectionSystemManagerEventFunction);
                InspSysManager[iLoopCount].Initialize(this, ParamManager.SystemParam.ProjectType, ParamManager.InspSysManagerParam[iLoopCount], ParamManager.InspParam[iLoopCount], ParamManager.SystemParam.LastRecipeName);
            }

            TimerShowWindow.Tick += new EventHandler(TimerShowWindowTick);
            TimerShowWindow.Interval = 500;
            #endregion InspSysManager Initialize
        }

        private void DeInitialize()
        {
            GetISMWindowInformation();

            ParamManager.SystemParam.ResultWindowLocationX = ResultBaseWnd.Location.X;
            ParamManager.SystemParam.ResultWindowLocationY = ResultBaseWnd.Location.Y;
            ParamManager.SystemParam.ResultWindowWidth = ResultBaseWnd.Width;
            ParamManager.SystemParam.ResultWindowHeight = ResultBaseWnd.Height;
            ResultBaseWnd.DeInitialize();

            RecipeWnd.RecipeChangeEvent -= new RecipeWindow.RecipeChangeHandler(RecipeChange);

            ParamManager.DeInitialize();

            LightControlManager.DeInitialize();

            MainProcess.MainProcessCommandEvent -= new MainProcessBase.MainProcessCommandHandler(MainProcessCommandEventFunction);
            MainProcess.DeInitialize();

            if ((int)eProjectType.DISPENSER == ParamManager.SystemParam.ProjectType)    ((MainProcessDispensor)MainProcess).DeInitialize();
            else if ((int)eProjectType.BLOWER == ParamManager.SystemParam.ProjectType)  ((MainProcessID)MainProcess).DeInitialize();

            for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
                InspSysManager[iLoopCount].InspSysManagerEvent -= new CInspectionSystemManager.InspSysManagerHandler(InspectionSystemManagerEventFunction);

            for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
                InspSysManager[iLoopCount].DeInitialize();
        }

        private void LoadDefaultRibbonTheme()
        {
            string content = System.IO.File.ReadAllText("MainTheme2.ini");
            Theme.ColorTable.ReadThemeIniFile(content);
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;

            if ((eProjectType)ParamManager.SystemParam.ProjectType == eProjectType.DISPENSER)     this.Text = "(주)KP Vision - CIPOS Inspection Program";
            else if ((eProjectType)ParamManager.SystemParam.ProjectType == eProjectType.BLOWER)   this.Text = "(주)KP Vision - Air Blower Inspection Program";

            string _CompileMode = "";
#if DEBUG
            _CompileMode = " - [DEBUG]";
#endif
            string _Version = System.Windows.Forms.Application.ProductVersion;
            this.Text = this.Text + " - Ver " + _Version + _CompileMode;

            ribbonMain.Refresh();
            this.Refresh();
        }

        private void GetISMWindowInformation()
        {
            Point _InspLocation;
            Size _InspSize;
            double _Zoom, _PanX, _PanY;
            for (int iLoopCount = 0; iLoopCount < ParamManager.SystemParam.InspSystemManagerCount; iLoopCount++)
            {
                InspSysManager[iLoopCount].GetDisplayWindowInfo(out _Zoom, out _PanX, out _PanY);
                ParamManager.InspSysManagerParam[iLoopCount].InspWndParam.DisplayZoomValue = _Zoom;
                ParamManager.InspSysManagerParam[iLoopCount].InspWndParam.DisplayPanXValue = _PanX;
                ParamManager.InspSysManagerParam[iLoopCount].InspWndParam.DisplayPanYValue = _PanY;

                InspSysManager[iLoopCount].GetWindowLocation(out _InspLocation);
                ParamManager.InspSysManagerParam[iLoopCount].InspWndParam.LocationX = _InspLocation.X;
                ParamManager.InspSysManagerParam[iLoopCount].InspWndParam.LocationY = _InspLocation.Y;

                InspSysManager[iLoopCount].GetWindowSize(out _InspSize);
                ParamManager.InspSysManagerParam[iLoopCount].InspWndParam.Width = _InspSize.Width;
                ParamManager.InspSysManagerParam[iLoopCount].InspWndParam.Height = _InspSize.Height;
            }
        }

        private void TimerShowWindowTick(object sender, EventArgs e)
        {
            TimerCount++;
            if (TimerCount >= 2)
            {
                TimerCount = 0;
                TimerShowWindow.Stop();
                CLoadingManager.Show("Recent Recipe", "Recipe Loading...");
                for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
                {
                    InspSysManager[iLoopCount].ShowWindows();
                }
                ResultBaseWnd.Show();
                CLoadingManager.Hide();
            }
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int _Command = message.WParam.ToInt32() & 0xfff0;
                    if (_Command == SC_MOVE || _Command == SC_SIZE) return;
                    break;
            }

            base.WndProc(ref message);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show(new Form { TopMost = true }, "Do you want exit program ? ", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            if (DialogResult.Yes != dlgResult) { e.Cancel = true; return; }
            DeInitialize();
            Environment.Exit(0);
        }
        #endregion Initialize & DeInitialize

        #region Riboon Button Event
        private void rbStart_Click(object sender, EventArgs e)
        {
            for (int iLoopCount = 0; iLoopCount < ParamManager.SystemParam.InspSystemManagerCount; ++iLoopCount)
                InspSysManager[iLoopCount].SetSystemMode(eSysMode.AUTO_MODE);

            rbStart.Enabled = false;

            CParameterManager.SystemMode = eSysMode.AUTO_MODE;
            MainProcess.AutoMode(true);
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "MainProcess AutoMode ON", CLogManager.LOG_LEVEL.MID);
        }

        private void rbStop_Click(object sender, EventArgs e)
        {
            for (int iLoopCount = 0; iLoopCount < ParamManager.SystemParam.InspSystemManagerCount; ++iLoopCount)
                InspSysManager[iLoopCount].SetSystemMode(eSysMode.MANUAL_MODE);

            rbStart.Enabled = true;

            CParameterManager.SystemMode = eSysMode.MANUAL_MODE;
            MainProcess.AutoMode(false);
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "MainProcess AutoMode STOP", CLogManager.LOG_LEVEL.MID);
        }

        private void rbEthernet_Click(object sender, EventArgs e)
        {
            if (false == MainProcess.GetEhernetWindowShown())   MainProcess.ShowEthernetWindow();
            else                                                MainProcess.SetEthernetWindowTopMost(true);

            //MainProcess.SetEthernetWindowTopMost(false);
        }

        private void rbSerial_Click(object sender, EventArgs e)
        {
            if (false == MainProcess.GetSerialWindowShown())    MainProcess.ShowSerialWindow();
            else                                                MainProcess.SetSerialWindowTopMost(true);

            //MainProcess.SetSerialWindowTopMost(false);
        }

        private void rbLight_Click(object sender, EventArgs e)
        {
            LightControlManager.ShowLightWindow();
        }

        private void rbDIO_Click(object sender, EventArgs e)
        {
            if (false == MainProcess.GetDIOWindowShown())   MainProcess.ShowDIOWindow();
            else                                            MainProcess.SetDIOWindowTopMost(true);

            //MainProcess.SetDIOWindowTopMost(false);
        }

        private void rbConfig_Click(object sender, EventArgs e)
        {

        }

        private void rbRecipe_Click(object sender, EventArgs e)
        {
            RecipeWnd.ShowDialog();
        }

        private void rbLog_Click(object sender, EventArgs e)
        {
            LogWnd.ShowLogWindow(!LogWnd.IsShowLogWindow);
        }

        private void rbHistory_Click(object sender, EventArgs e)
        {
            HistoryManager.ShowHistoryWindow();
        }

        private void rbFolder_Click(object sender, EventArgs e)
        {

        }

        private void rbLabelCode_DoubleClick(object sender, EventArgs e)
        {
            string code = "";
            CodeSettingWindow CodeSettingWnd = new CodeSettingWindow();
            CodeSettingWnd.BarcodeReaderEvent += new CodeSettingWindow.BarcodeReaderHandler(SetBarcodeTextbox);
            CodeSettingWnd.ShowDialog();
            CodeSettingWnd.BarcodeReaderEvent -= new CodeSettingWindow.BarcodeReaderHandler(SetBarcodeTextbox);
        }

		private void SetBarcodeTextbox(string _ReadBarcode)
        {
			rbLabelCode.Text = "CODE : " + _ReadBarcode;
        }
		
        private void rbExit_Click(object sender, EventArgs e)
        {
            try
            {
                for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount) InspSysManager[iLoopCount].ImageContinuesGrabStop();

                DialogResult dlgResult = MessageBox.Show(new Form { TopMost = true }, "Do you want exit program ? ", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != dlgResult) return;
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "MainProcess : CIPOS lead inspection program exit!!");

                DeInitialize();
                Environment.Exit(0);
            }

            catch (Exception ex)
            {
                CLogManager.AddSystemLog(CLogManager.LOG_TYPE.ERR, "MainForm Exit : " + ex.ToString(), CLogManager.LOG_LEVEL.LOW);
                Environment.Exit(0);
            }
        }
        #endregion Riboon Button Event

        #region Event : Inspection System Manager Event & Function
        private void InspectionSystemManagerEventFunction(eISMCMD _Command, object _Value = null, int _ID = 0)
        {
            switch (_Command)
            {
                case eISMCMD.TEACHING_STATUS:   TeachingStatusCheck(Convert.ToBoolean(_Value)); break;
                case eISMCMD.TEACHING_SAVE:     TeachingParameterSave(Convert.ToInt32(_Value)); break;
                case eISMCMD.SEND_DATA:         SendResultData(_Value);                         break;
                case eISMCMD.SET_RESULT:        SetResultData(_Value);                          break;
                case eISMCMD.INSP_COMPLETE:     InspectionComplete(_Value, _ID);                break;
                case eISMCMD.LIGHT_CONTROL:     LightControl(_Value);                           break;
            }
        }

        private void TeachingStatusCheck(bool _IsTeaching)
        {
            //Teacing status check
            if (_IsTeaching)
            {
                ribbonPanelOperating.Enabled = false;
                ribbonPanelSetting.Enabled = false;
                ribbonPanelData.Enabled = false;
                ribbonPanelStatus.Enabled = false;
                ribbonPanelSystem.Enabled = false;
                CParameterManager.SystemMode = eSysMode.TEACH_MODE;
            }

            else
            {
                ribbonPanelOperating.Enabled = true;
                ribbonPanelSetting.Enabled = true;
                ribbonPanelData.Enabled = true;
                ribbonPanelStatus.Enabled = true;
                ribbonPanelSystem.Enabled = true;
                CParameterManager.SystemMode = eSysMode.MANUAL_MODE;
            }
        }

        private void TeachingParameterSave(int _ID)
        {
            InspSysManager[_ID].GetInspectionParameterRef(ref ParamManager.InspParam[_ID]);

            ParamManager.WriteInspectionParameter(_ID);
        }
        #endregion Event : Inspection System Manager Event & Function

        #region Event : I/O Event & Function
        private void InputChangeEventFunction(short _BitNum, bool _Signal)
        {
            //if ((short)DIO_DEF.IN_TRG1 == _BitNum) EventInspectionTriggerOn(_Signal);
            //if ((short)DIO_DEF.IN_TRG1 == _BitNum) MainProcess.TriggerOn(InspSysManager, 0);
            switch (_BitNum)
            {
                //case DIO_DEF.IN_TRG1:   MainProcess.TriggerOn(InspSysManager, 0);  break;
                //case DIO_DEF.IN_RESET:  MainProcess.Reset(); break;
            }
        }
        #endregion Event : I/O Event & Function

        #region Sub Window Events
        private bool RecipeChange(string _RecipeName, string _SrcRecipe = "")
        {
            bool _Result = true;

            ParamManager.RecipeReload(_RecipeName);

            //LDH, 2018.07.26, Light File 따로 관리
            LightControlManager.RecipeChange(_RecipeName, _SrcRecipe);
            ResultBaseWnd.SetLastRecipeName((eProjectType)ParamManager.SystemParam.ProjectType, _RecipeName);

            for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
            {
                InspSysManager[iLoopCount].SetInspectionParameter(ParamManager.InspParam[iLoopCount], false);
                InspSysManager[iLoopCount].GetInspectionParameterRef(ref ParamManager.InspParam[iLoopCount]);
            }

            UpdateRibbonRecipeName(_RecipeName);

            return _Result;
        }

        private void UpdateRibbonRecipeName(string _RecipeName)
        {
            rbLabelCurrentRecipe.Text = "Recipe : " + _RecipeName + " ";
        }
        #endregion Sub Window Events

        #region Main Process
        private void MainProcessCommandEventFunction(eMainProcCmd _MainProcCmd, object _Value)
        {
            switch (_MainProcCmd)
            {
                case eMainProcCmd.TRG:          MainProcessTriggerOn(_Value);    break;
                case eMainProcCmd.REQUEST:      MainProcessDataRequest(_Value); break;
                case eMainProcCmd.RCP_CHANGE:   MainProcessRcpChange(_Value);    break;
                case eMainProcCmd.LOT_CHANGE:   MainProcessLOTChange(_Value);   break;
            }
        }

        private void MainProcessTriggerOn(object _Value)
        {
            if (CParameterManager.SystemMode != eSysMode.AUTO_MODE) return; 
            int _ID = Convert.ToInt32(_Value);
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : Trigger{0} On Event", _ID + 1));
            InspSysManager[_ID].TriggerOn();
        }

        private bool MainProcessRcpChange(object _Value)
        {
            bool _Result = true;

            string _RecipeName = _Value as string;

            _Result = RecipeChange(_RecipeName);

            if (!_Result) return false;

            if (eProjectType.BLOWER == (eProjectType)ParamManager.SystemParam.ProjectType)
                MainProcess.SendSerialData(eMainProcCmd.RCP_CHANGE);

            return _Result;
        }

        private bool MainProcessLOTChange(object _Value)
        {
            bool _Result = true;

            string _ReceiveData = _Value as string;

            if (eProjectType.BLOWER == (eProjectType)ParamManager.SystemParam.ProjectType)
            {
                if(_ReceiveData == "LotEnd") MainProcess.SendSerialData(eMainProcCmd.LOT_CHANGE, "END");
                else
                    MainProcess.SendSerialData(eMainProcCmd.LOT_CHANGE);
            }

            return _Result;
        }

        private void MainProcessDataRequest(object _Value)
        {
            if (CParameterManager.SystemMode != eSysMode.AUTO_MODE) return;

            int _ID = Convert.ToInt32(_Value);
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : Data Request{0} Event", _ID + 1));
            InspSysManager[_ID].DataSend();
        }

        //private void EventInspectionTriggerOn(object _Value)
        //{
        //    if (false == Convert.ToBoolean(_Value)) return;
        //    int _ID = 2;
        //    CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : Trigger{0} On Event", _ID + 1));
        //
        //    InspSysManager[_ID].TriggerOn();
        //}

        private void SendResultData(object _Result)
        {
            SendResultParameter _SendResParam = _Result as SendResultParameter;
            MainProcess.SendResultData(_SendResParam);
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : SendResultData"));
        }

        private void SetResultData(object _Result)
        {
            SendResultParameter _SendResParam = _Result as SendResultParameter;
            ResultBaseWnd.SetResultData(_SendResParam);
            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, String.Format("Main : SetResultData"));
        }

        private void LightControl(object _LightOnOff)
        {
            if ((bool)_LightOnOff == true) LightControlManager.LightControl(0, true);
            else                              LightControlManager.LightControl(0, false);
        }

        private void InspectionComplete(object _Value, int _ID)
        {
            if ((eProjectType)ParamManager.SystemParam.ProjectType != eProjectType.BLOWER)
            {
                bool _Flag = Convert.ToBoolean(_Value);
                MainProcess.InspectionComplete(_ID, _Flag);
            }
        }
        #endregion Main Process
    }
}
