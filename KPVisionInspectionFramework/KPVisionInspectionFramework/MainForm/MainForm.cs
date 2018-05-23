using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using InspectionSystemManager;
using ParameterManager;
using LoadingManager;

namespace KPVisionInspectionFramework
{
    public partial class MainForm : RibbonForm
    {
        private CParameterManager           ParamManager;
        private CInspectionSystemManager[]  InspSysManager;

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

            #region InspSysManager Initialize
            ISMModuleCount = ParamManager.SystemParam.InspSystemManagerCount;
            InspSysManager = new CInspectionSystemManager[ISMModuleCount];
            for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
            {
                InspSysManager[iLoopCount] = new CInspectionSystemManager(iLoopCount, "Vision" + (iLoopCount + 1), ParamManager.SystemParam.IsSimulationMode);
                InspSysManager[iLoopCount].InspSysManagerEvent += new CInspectionSystemManager.InspSysManagerHandler(InspectionSystemManagerEventFunction);
                InspSysManager[iLoopCount].Initialize(this, ParamManager.SystemParam.ProjectType, ParamManager.InspSysManagerParam[iLoopCount]);
            }

            TimerShowWindow.Tick += new EventHandler(TimerShowWindowTick);
            TimerShowWindow.Interval = 500;
            #endregion InspSysManager Initialize
        }

        private void DeInitialize()
        {
            GetISMWindowInformation();


            ParamManager.DeInitialize();


            for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
                InspSysManager[iLoopCount].InspSysManagerEvent += new CInspectionSystemManager.InspSysManagerHandler(InspectionSystemManagerEventFunction);

            for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount)
                InspSysManager[iLoopCount].DeInitialize();
        }

        private void LoadDefaultRibbonTheme()
        {
            string content = System.IO.File.ReadAllText("MainTheme2.ini");
            Theme.ColorTable.ReadThemeIniFile(content);
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Text = "KP - CIPOS Inspection Program";

            string _CompileMode = "";
#if _DEBUG
            _CompileMode = " - [DEBUG]";
#endif
            string _Version = System.Windows.Forms.Application.ProductVersion;
            this.Text = this.Text + " - Ver " + _Version + _CompileMode;

            ribbonMain.Refresh();
            this.Refresh();
        }

        private void GetISMWindowInformation()
        {
            Point _DispLocation, _InspLocation;
            Size _DispSize, _InspSize;
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
                //ResultWnd.Show();
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
        private void rbExit_Click(object sender, EventArgs e)
        {
            try
            {
                //for (int iLoopCount = 0; iLoopCount < ISMModuleCount; ++iLoopCount) InspSysManager[iLoopCount].ImageGrabStop();

                DialogResult dlgResult = MessageBox.Show(new Form { TopMost = true }, "Do you want exit program ? ", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                if (DialogResult.Yes != dlgResult) return;
                DeInitialize();
                Environment.Exit(0);
            }

            catch
            {
                Environment.Exit(0);
            }
        }
        #endregion Riboon Button Event

        #region Event : Inspection System Manager Event & Function
        private void InspectionSystemManagerEventFunction(eISMCMD _Command, object _Value = null)
        {
            switch (_Command)
            {
                case eISMCMD.TEACHING_STATUS:   TeachingStatusCheck(Convert.ToBoolean(_Value));     break;
            }
        }

        private void TeachingStatusCheck(bool _IsTeaching)
        {
            //Teacing status check
            if (_IsTeaching)
            {
                ribbonPanelOperating.Enabled = false;
                ribbonPanelSetting.Enabled = false;
                ribbonPanelSystem.Enabled = false;
            }

            else
            {
                ribbonPanelOperating.Enabled = true;
                ribbonPanelSetting.Enabled = true;
                ribbonPanelSystem.Enabled = true;
            }
        }
        #endregion Event : Inspection System Manager Event & Function
    }
}
