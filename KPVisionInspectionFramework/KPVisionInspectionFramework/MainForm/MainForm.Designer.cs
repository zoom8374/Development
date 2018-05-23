namespace KPVisionInspectionFramework
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonMain = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanelOperating = new System.Windows.Forms.RibbonPanel();
            this.rbStart = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelSetting = new System.Windows.Forms.RibbonPanel();
            this.rbEthernet = new System.Windows.Forms.RibbonButton();
            this.rbLight = new System.Windows.Forms.RibbonButton();
            this.rbDIO = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanelSystem = new System.Windows.Forms.RibbonPanel();
            this.rbExit = new System.Windows.Forms.RibbonButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ribbonMain.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.ribbonMain.ForeColor = System.Drawing.SystemColors.Window;
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.Minimized = false;
            this.ribbonMain.Name = "ribbonMain";
            // 
            // 
            // 
            this.ribbonMain.OrbDropDown.BorderRoundness = 8;
            this.ribbonMain.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.OrbDropDown.Name = "";
            this.ribbonMain.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbonMain.OrbDropDown.TabIndex = 0;
            this.ribbonMain.OrbImage = null;
            this.ribbonMain.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbonMain.RibbonTabFont = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.ribbonMain.Size = new System.Drawing.Size(1904, 140);
            this.ribbonMain.TabIndex = 0;
            this.ribbonMain.Tabs.Add(this.ribbonTab1);
            this.ribbonMain.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbonMain.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanelOperating);
            this.ribbonTab1.Panels.Add(this.ribbonPanelSetting);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Panels.Add(this.ribbonPanelSystem);
            this.ribbonTab1.Text = "Inspection Main";
            // 
            // ribbonPanelOperating
            // 
            this.ribbonPanelOperating.ButtonMoreVisible = false;
            this.ribbonPanelOperating.Items.Add(this.rbStart);
            this.ribbonPanelOperating.Items.Add(this.ribbonButton2);
            this.ribbonPanelOperating.Text = "Inspection Operating";
            // 
            // rbStart
            // 
            this.rbStart.Image = global::KPVisionInspectionFramework.Properties.Resources.Start;
            this.rbStart.MinimumSize = new System.Drawing.Size(70, 60);
            this.rbStart.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbStart.SmallImage")));
            this.rbStart.Text = " Auto";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::KPVisionInspectionFramework.Properties.Resources.Stop;
            this.ribbonButton2.MinimumSize = new System.Drawing.Size(70, 60);
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = " Stop";
            // 
            // ribbonPanelSetting
            // 
            this.ribbonPanelSetting.Items.Add(this.rbEthernet);
            this.ribbonPanelSetting.Items.Add(this.rbLight);
            this.ribbonPanelSetting.Items.Add(this.rbDIO);
            this.ribbonPanelSetting.Text = "Setting ";
            // 
            // rbEthernet
            // 
            this.rbEthernet.Image = global::KPVisionInspectionFramework.Properties.Resources.Ethernet;
            this.rbEthernet.MinimumSize = new System.Drawing.Size(70, 60);
            this.rbEthernet.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEthernet.SmallImage")));
            this.rbEthernet.Text = " Ethernet";
            // 
            // rbLight
            // 
            this.rbLight.Image = global::KPVisionInspectionFramework.Properties.Resources.Light;
            this.rbLight.MinimumSize = new System.Drawing.Size(70, 60);
            this.rbLight.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbLight.SmallImage")));
            this.rbLight.Text = " Light";
            // 
            // rbDIO
            // 
            this.rbDIO.Image = global::KPVisionInspectionFramework.Properties.Resources.DIO;
            this.rbDIO.MinimumSize = new System.Drawing.Size(70, 60);
            this.rbDIO.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDIO.SmallImage")));
            this.rbDIO.Text = " DIO";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Text = "ribbonPanel2";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Text = "ribbonPanel3";
            // 
            // ribbonPanelSystem
            // 
            this.ribbonPanelSystem.Items.Add(this.rbExit);
            this.ribbonPanelSystem.Text = "System";
            // 
            // rbExit
            // 
            this.rbExit.Image = global::KPVisionInspectionFramework.Properties.Resources.Exit;
            this.rbExit.MinimumSize = new System.Drawing.Size(70, 60);
            this.rbExit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbExit.SmallImage")));
            this.rbExit.Text = " Exit";
            this.rbExit.Click += new System.EventHandler(this.rbExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 140);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1904, 901);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.ribbonMain);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " KV CIPOS Inspection Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbonMain;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanelOperating;
        private System.Windows.Forms.RibbonButton rbStart;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonPanel ribbonPanelSetting;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel ribbonPanelSystem;
        private System.Windows.Forms.RibbonButton rbExit;
        private System.Windows.Forms.RibbonButton rbEthernet;
        private System.Windows.Forms.RibbonButton rbLight;
        private System.Windows.Forms.RibbonButton rbDIO;
    }
}

