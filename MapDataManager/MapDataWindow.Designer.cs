namespace MapDataManager
{
    partial class MapDataWindow
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnManualSearchAreaSet = new System.Windows.Forms.Button();
            this.btnManualSearchArea = new System.Windows.Forms.Button();
            this.btnShowSearchArea = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUnitPatternSearchAreaShow = new System.Windows.Forms.Button();
            this.btnUnitPatternOriginCenterSet = new System.Windows.Forms.Button();
            this.btnUnitPatternSearchAreaSet = new System.Windows.Forms.Button();
            this.btnUnitPatternAreaShow = new System.Windows.Forms.Button();
            this.btnUnitPatternAreaSet = new System.Windows.Forms.Button();
            this.btnFindSearchArea = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownAngleLimit = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel8 = new CustomControl.GradientLabel();
            this.numericUpDownFindCount = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel10 = new CustomControl.GradientLabel();
            this.numericUpDownFindScore = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel11 = new CustomControl.GradientLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kpPatternDisplay = new KPDisplay.KPCogDisplayControl();
            this.btnUnitPatternAreaCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUnitTotalCount = new System.Windows.Forms.TextBox();
            this.gradientLabel6 = new CustomControl.GradientLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numUpDownSectionColumnCount = new System.Windows.Forms.NumericUpDown();
            this.numUpDownSectionRowCount = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.gradientLabel5 = new CustomControl.GradientLabel();
            this.numUpDownUnitColumnCount = new System.Windows.Forms.NumericUpDown();
            this.numUpDownUnitRowCount = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel3 = new CustomControl.GradientLabel();
            this.gradientLabel9 = new CustomControl.GradientLabel();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.gradientLabel1 = new CustomControl.GradientLabel();
            this.btnOk = new System.Windows.Forms.Button();
            this.kpTeachDisplay = new KPDisplay.KPCogDisplayControl();
            this.labelInputTitle = new CustomControl.GradientLabel();
            this.chAreaAutoSearch = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chAreaManualSearch = new System.Windows.Forms.CheckBox();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindScore)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSectionColumnCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSectionRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownUnitColumnCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownUnitRowCount)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1262, 30);
            this.labelTitle.TabIndex = 45;
            this.labelTitle.Text = " Map Data Setting Window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitle_Paint);
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.chAreaManualSearch);
            this.panelMain.Controls.Add(this.panel3);
            this.panelMain.Controls.Add(this.chAreaAutoSearch);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.gradientLabel2);
            this.panelMain.Controls.Add(this.gradientLabel1);
            this.panelMain.Controls.Add(this.btnOk);
            this.panelMain.Controls.Add(this.kpTeachDisplay);
            this.panelMain.Controls.Add(this.labelInputTitle);
            this.panelMain.Location = new System.Drawing.Point(0, 32);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1262, 838);
            this.panelMain.TabIndex = 46;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(997, 800);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 35);
            this.btnCancel.TabIndex = 314;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(867, 800);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 35);
            this.btnSave.TabIndex = 313;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnShowSearchArea);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnFindSearchArea);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.kpPatternDisplay);
            this.panel2.Controls.Add(this.btnUnitPatternAreaCancel);
            this.panel2.Location = new System.Drawing.Point(639, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 394);
            this.panel2.TabIndex = 312;
            // 
            // btnManualSearchAreaSet
            // 
            this.btnManualSearchAreaSet.BackColor = System.Drawing.SystemColors.Control;
            this.btnManualSearchAreaSet.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnManualSearchAreaSet.ForeColor = System.Drawing.Color.Black;
            this.btnManualSearchAreaSet.Location = new System.Drawing.Point(489, 5);
            this.btnManualSearchAreaSet.Name = "btnManualSearchAreaSet";
            this.btnManualSearchAreaSet.Size = new System.Drawing.Size(124, 40);
            this.btnManualSearchAreaSet.TabIndex = 318;
            this.btnManualSearchAreaSet.Text = "Set Manual\r\nSearch Area";
            this.btnManualSearchAreaSet.UseVisualStyleBackColor = false;
            this.btnManualSearchAreaSet.Click += new System.EventHandler(this.btnManualSearchAreaSet_Click);
            // 
            // btnManualSearchArea
            // 
            this.btnManualSearchArea.BackColor = System.Drawing.SystemColors.Control;
            this.btnManualSearchArea.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnManualSearchArea.ForeColor = System.Drawing.Color.Black;
            this.btnManualSearchArea.Location = new System.Drawing.Point(356, 5);
            this.btnManualSearchArea.Name = "btnManualSearchArea";
            this.btnManualSearchArea.Size = new System.Drawing.Size(124, 40);
            this.btnManualSearchArea.TabIndex = 317;
            this.btnManualSearchArea.Text = "Show Manual\r\nSearch Area";
            this.btnManualSearchArea.UseVisualStyleBackColor = false;
            this.btnManualSearchArea.Click += new System.EventHandler(this.btnManualSearchArea_Click);
            // 
            // btnShowSearchArea
            // 
            this.btnShowSearchArea.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowSearchArea.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnShowSearchArea.ForeColor = System.Drawing.Color.Black;
            this.btnShowSearchArea.Location = new System.Drawing.Point(356, 335);
            this.btnShowSearchArea.Name = "btnShowSearchArea";
            this.btnShowSearchArea.Size = new System.Drawing.Size(124, 40);
            this.btnShowSearchArea.TabIndex = 316;
            this.btnShowSearchArea.Text = "Show Search Area";
            this.btnShowSearchArea.UseVisualStyleBackColor = false;
            this.btnShowSearchArea.Click += new System.EventHandler(this.btnShowSearchArea_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUnitPatternSearchAreaShow);
            this.groupBox1.Controls.Add(this.btnUnitPatternOriginCenterSet);
            this.groupBox1.Controls.Add(this.btnUnitPatternSearchAreaSet);
            this.groupBox1.Controls.Add(this.btnUnitPatternAreaShow);
            this.groupBox1.Controls.Add(this.btnUnitPatternAreaSet);
            this.groupBox1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(334, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 192);
            this.groupBox1.TabIndex = 315;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Pattern Setting ";
            // 
            // btnUnitPatternSearchAreaShow
            // 
            this.btnUnitPatternSearchAreaShow.BackColor = System.Drawing.Color.SandyBrown;
            this.btnUnitPatternSearchAreaShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitPatternSearchAreaShow.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnUnitPatternSearchAreaShow.ForeColor = System.Drawing.Color.Black;
            this.btnUnitPatternSearchAreaShow.Location = new System.Drawing.Point(8, 20);
            this.btnUnitPatternSearchAreaShow.Name = "btnUnitPatternSearchAreaShow";
            this.btnUnitPatternSearchAreaShow.Size = new System.Drawing.Size(128, 45);
            this.btnUnitPatternSearchAreaShow.TabIndex = 304;
            this.btnUnitPatternSearchAreaShow.Text = "Show Pattern \r\nSearch Area";
            this.btnUnitPatternSearchAreaShow.UseVisualStyleBackColor = false;
            this.btnUnitPatternSearchAreaShow.Click += new System.EventHandler(this.btnUnitPatternSearchAreaShow_Click);
            // 
            // btnUnitPatternOriginCenterSet
            // 
            this.btnUnitPatternOriginCenterSet.BackColor = System.Drawing.Color.PaleGreen;
            this.btnUnitPatternOriginCenterSet.Enabled = false;
            this.btnUnitPatternOriginCenterSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitPatternOriginCenterSet.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnUnitPatternOriginCenterSet.ForeColor = System.Drawing.Color.Black;
            this.btnUnitPatternOriginCenterSet.Location = new System.Drawing.Point(142, 122);
            this.btnUnitPatternOriginCenterSet.Name = "btnUnitPatternOriginCenterSet";
            this.btnUnitPatternOriginCenterSet.Size = new System.Drawing.Size(128, 45);
            this.btnUnitPatternOriginCenterSet.TabIndex = 314;
            this.btnUnitPatternOriginCenterSet.Text = "Set \rOrigin Center";
            this.btnUnitPatternOriginCenterSet.UseVisualStyleBackColor = false;
            this.btnUnitPatternOriginCenterSet.Visible = false;
            this.btnUnitPatternOriginCenterSet.Click += new System.EventHandler(this.btnUnitPatternOriginCenterSet_Click);
            // 
            // btnUnitPatternSearchAreaSet
            // 
            this.btnUnitPatternSearchAreaSet.BackColor = System.Drawing.Color.SandyBrown;
            this.btnUnitPatternSearchAreaSet.Enabled = false;
            this.btnUnitPatternSearchAreaSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitPatternSearchAreaSet.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnUnitPatternSearchAreaSet.ForeColor = System.Drawing.Color.Black;
            this.btnUnitPatternSearchAreaSet.Location = new System.Drawing.Point(142, 20);
            this.btnUnitPatternSearchAreaSet.Name = "btnUnitPatternSearchAreaSet";
            this.btnUnitPatternSearchAreaSet.Size = new System.Drawing.Size(128, 45);
            this.btnUnitPatternSearchAreaSet.TabIndex = 305;
            this.btnUnitPatternSearchAreaSet.Text = "Set Pattern\r\nSearch Area";
            this.btnUnitPatternSearchAreaSet.UseVisualStyleBackColor = false;
            this.btnUnitPatternSearchAreaSet.Click += new System.EventHandler(this.btnUnitPatternSearchAreaSet_Click);
            // 
            // btnUnitPatternAreaShow
            // 
            this.btnUnitPatternAreaShow.BackColor = System.Drawing.Color.PaleGreen;
            this.btnUnitPatternAreaShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitPatternAreaShow.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnUnitPatternAreaShow.ForeColor = System.Drawing.Color.Black;
            this.btnUnitPatternAreaShow.Location = new System.Drawing.Point(8, 71);
            this.btnUnitPatternAreaShow.Name = "btnUnitPatternAreaShow";
            this.btnUnitPatternAreaShow.Size = new System.Drawing.Size(128, 45);
            this.btnUnitPatternAreaShow.TabIndex = 306;
            this.btnUnitPatternAreaShow.Text = "Show\r\nPattern Area";
            this.btnUnitPatternAreaShow.UseVisualStyleBackColor = false;
            this.btnUnitPatternAreaShow.Click += new System.EventHandler(this.btnUnitPatternAreaShow_Click);
            // 
            // btnUnitPatternAreaSet
            // 
            this.btnUnitPatternAreaSet.BackColor = System.Drawing.Color.PaleGreen;
            this.btnUnitPatternAreaSet.Enabled = false;
            this.btnUnitPatternAreaSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitPatternAreaSet.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnUnitPatternAreaSet.ForeColor = System.Drawing.Color.Black;
            this.btnUnitPatternAreaSet.Location = new System.Drawing.Point(142, 71);
            this.btnUnitPatternAreaSet.Name = "btnUnitPatternAreaSet";
            this.btnUnitPatternAreaSet.Size = new System.Drawing.Size(128, 45);
            this.btnUnitPatternAreaSet.TabIndex = 307;
            this.btnUnitPatternAreaSet.Text = "Set \r\nPattern Area";
            this.btnUnitPatternAreaSet.UseVisualStyleBackColor = false;
            this.btnUnitPatternAreaSet.Click += new System.EventHandler(this.btnUnitPatternAreaSet_Click);
            // 
            // btnFindSearchArea
            // 
            this.btnFindSearchArea.BackColor = System.Drawing.SystemColors.Control;
            this.btnFindSearchArea.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnFindSearchArea.ForeColor = System.Drawing.Color.Black;
            this.btnFindSearchArea.Location = new System.Drawing.Point(486, 335);
            this.btnFindSearchArea.Name = "btnFindSearchArea";
            this.btnFindSearchArea.Size = new System.Drawing.Size(124, 40);
            this.btnFindSearchArea.TabIndex = 312;
            this.btnFindSearchArea.Text = "Find Search Area";
            this.btnFindSearchArea.UseVisualStyleBackColor = false;
            this.btnFindSearchArea.Click += new System.EventHandler(this.btnFindSearchArea_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownAngleLimit);
            this.groupBox2.Controls.Add(this.gradientLabel8);
            this.groupBox2.Controls.Add(this.numericUpDownFindCount);
            this.groupBox2.Controls.Add(this.gradientLabel10);
            this.groupBox2.Controls.Add(this.numericUpDownFindScore);
            this.groupBox2.Controls.Add(this.gradientLabel11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(334, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 127);
            this.groupBox2.TabIndex = 309;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Condition Setting ";
            // 
            // numericUpDownAngleLimit
            // 
            this.numericUpDownAngleLimit.DecimalPlaces = 2;
            this.numericUpDownAngleLimit.Location = new System.Drawing.Point(150, 83);
            this.numericUpDownAngleLimit.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownAngleLimit.Name = "numericUpDownAngleLimit";
            this.numericUpDownAngleLimit.Size = new System.Drawing.Size(87, 21);
            this.numericUpDownAngleLimit.TabIndex = 65;
            this.numericUpDownAngleLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownAngleLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // gradientLabel8
            // 
            this.gradientLabel8.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel8.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel8.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel8.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel8.ForeColor = System.Drawing.Color.White;
            this.gradientLabel8.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel8.Location = new System.Drawing.Point(8, 81);
            this.gradientLabel8.Name = "gradientLabel8";
            this.gradientLabel8.Size = new System.Drawing.Size(136, 26);
            this.gradientLabel8.TabIndex = 64;
            this.gradientLabel8.Text = "Angle Limit";
            this.gradientLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownFindCount
            // 
            this.numericUpDownFindCount.Location = new System.Drawing.Point(150, 53);
            this.numericUpDownFindCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFindCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFindCount.Name = "numericUpDownFindCount";
            this.numericUpDownFindCount.Size = new System.Drawing.Size(87, 21);
            this.numericUpDownFindCount.TabIndex = 63;
            this.numericUpDownFindCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownFindCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gradientLabel10
            // 
            this.gradientLabel10.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel10.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel10.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel10.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel10.ForeColor = System.Drawing.Color.White;
            this.gradientLabel10.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel10.Location = new System.Drawing.Point(8, 51);
            this.gradientLabel10.Name = "gradientLabel10";
            this.gradientLabel10.Size = new System.Drawing.Size(136, 26);
            this.gradientLabel10.TabIndex = 62;
            this.gradientLabel10.Text = "Find Count";
            this.gradientLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownFindScore
            // 
            this.numericUpDownFindScore.DecimalPlaces = 2;
            this.numericUpDownFindScore.Location = new System.Drawing.Point(150, 23);
            this.numericUpDownFindScore.Name = "numericUpDownFindScore";
            this.numericUpDownFindScore.Size = new System.Drawing.Size(87, 21);
            this.numericUpDownFindScore.TabIndex = 61;
            this.numericUpDownFindScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownFindScore.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // gradientLabel11
            // 
            this.gradientLabel11.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel11.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel11.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel11.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel11.ForeColor = System.Drawing.Color.White;
            this.gradientLabel11.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel11.Location = new System.Drawing.Point(8, 21);
            this.gradientLabel11.Name = "gradientLabel11";
            this.gradientLabel11.Size = new System.Drawing.Size(136, 26);
            this.gradientLabel11.TabIndex = 60;
            this.gradientLabel11.Text = "Find Score";
            this.gradientLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(240, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 14);
            this.label9.TabIndex = 73;
            this.label9.Text = "˚";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(239, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 74;
            this.label5.Text = "ea";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(240, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 14);
            this.label4.TabIndex = 75;
            this.label4.Text = "%";
            // 
            // kpPatternDisplay
            // 
            this.kpPatternDisplay.BackColor = System.Drawing.Color.White;
            this.kpPatternDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpPatternDisplay.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kpPatternDisplay.Location = new System.Drawing.Point(2, 2);
            this.kpPatternDisplay.Name = "kpPatternDisplay";
            this.kpPatternDisplay.Size = new System.Drawing.Size(325, 325);
            this.kpPatternDisplay.TabIndex = 308;
            this.kpPatternDisplay.UseStatusBar = false;
            // 
            // btnUnitPatternAreaCancel
            // 
            this.btnUnitPatternAreaCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnitPatternAreaCancel.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnUnitPatternAreaCancel.ForeColor = System.Drawing.Color.Black;
            this.btnUnitPatternAreaCancel.Location = new System.Drawing.Point(226, 335);
            this.btnUnitPatternAreaCancel.Name = "btnUnitPatternAreaCancel";
            this.btnUnitPatternAreaCancel.Size = new System.Drawing.Size(124, 40);
            this.btnUnitPatternAreaCancel.TabIndex = 311;
            this.btnUnitPatternAreaCancel.Text = "Setting Cancel";
            this.btnUnitPatternAreaCancel.UseVisualStyleBackColor = false;
            this.btnUnitPatternAreaCancel.Click += new System.EventHandler(this.btnUnitPatternAreaCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtUnitTotalCount);
            this.panel1.Controls.Add(this.gradientLabel6);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.numUpDownSectionColumnCount);
            this.panel1.Controls.Add(this.numUpDownSectionRowCount);
            this.panel1.Controls.Add(this.gradientLabel4);
            this.panel1.Controls.Add(this.gradientLabel5);
            this.panel1.Controls.Add(this.numUpDownUnitColumnCount);
            this.panel1.Controls.Add(this.numUpDownUnitRowCount);
            this.panel1.Controls.Add(this.gradientLabel3);
            this.panel1.Controls.Add(this.gradientLabel9);
            this.panel1.Location = new System.Drawing.Point(639, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 205);
            this.panel1.TabIndex = 311;
            // 
            // txtUnitTotalCount
            // 
            this.txtUnitTotalCount.Location = new System.Drawing.Point(231, 68);
            this.txtUnitTotalCount.Name = "txtUnitTotalCount";
            this.txtUnitTotalCount.ReadOnly = true;
            this.txtUnitTotalCount.Size = new System.Drawing.Size(86, 21);
            this.txtUnitTotalCount.TabIndex = 321;
            this.txtUnitTotalCount.Text = "1";
            this.txtUnitTotalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gradientLabel6
            // 
            this.gradientLabel6.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel6.ColorBottom = System.Drawing.Color.SkyBlue;
            this.gradientLabel6.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel6.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel6.ForeColor = System.Drawing.Color.White;
            this.gradientLabel6.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel6.Location = new System.Drawing.Point(61, 65);
            this.gradientLabel6.Name = "gradientLabel6";
            this.gradientLabel6.Size = new System.Drawing.Size(163, 26);
            this.gradientLabel6.TabIndex = 320;
            this.gradientLabel6.Text = "  Unit Total Count";
            this.gradientLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::MapDataManager.Properties.Resources.FrameSection;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(3, 107);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 57);
            this.pictureBox2.TabIndex = 319;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MapDataManager.Properties.Resources.FrameCell;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.TabIndex = 318;
            this.pictureBox1.TabStop = false;
            // 
            // numUpDownSectionColumnCount
            // 
            this.numUpDownSectionColumnCount.Location = new System.Drawing.Point(230, 140);
            this.numUpDownSectionColumnCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownSectionColumnCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownSectionColumnCount.Name = "numUpDownSectionColumnCount";
            this.numUpDownSectionColumnCount.Size = new System.Drawing.Size(87, 21);
            this.numUpDownSectionColumnCount.TabIndex = 317;
            this.numUpDownSectionColumnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownSectionColumnCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numUpDownSectionRowCount
            // 
            this.numUpDownSectionRowCount.Location = new System.Drawing.Point(230, 109);
            this.numUpDownSectionRowCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownSectionRowCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownSectionRowCount.Name = "numUpDownSectionRowCount";
            this.numUpDownSectionRowCount.Size = new System.Drawing.Size(87, 21);
            this.numUpDownSectionRowCount.TabIndex = 316;
            this.numUpDownSectionRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownSectionRowCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.BackColor = System.Drawing.Color.ForestGreen;
            this.gradientLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel4.ColorBottom = System.Drawing.Color.DarkSeaGreen;
            this.gradientLabel4.ColorTop = System.Drawing.Color.Green;
            this.gradientLabel4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel4.ForeColor = System.Drawing.Color.White;
            this.gradientLabel4.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel4.Location = new System.Drawing.Point(61, 138);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(163, 26);
            this.gradientLabel4.TabIndex = 315;
            this.gradientLabel4.Text = "  Section Column Count";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.BackColor = System.Drawing.Color.ForestGreen;
            this.gradientLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel5.ColorBottom = System.Drawing.Color.DarkSeaGreen;
            this.gradientLabel5.ColorTop = System.Drawing.Color.Green;
            this.gradientLabel5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel5.ForeColor = System.Drawing.Color.White;
            this.gradientLabel5.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel5.Location = new System.Drawing.Point(61, 107);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Size = new System.Drawing.Size(163, 26);
            this.gradientLabel5.TabIndex = 314;
            this.gradientLabel5.Text = "  Section Row Count";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numUpDownUnitColumnCount
            // 
            this.numUpDownUnitColumnCount.Location = new System.Drawing.Point(230, 37);
            this.numUpDownUnitColumnCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownUnitColumnCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownUnitColumnCount.Name = "numUpDownUnitColumnCount";
            this.numUpDownUnitColumnCount.Size = new System.Drawing.Size(87, 21);
            this.numUpDownUnitColumnCount.TabIndex = 313;
            this.numUpDownUnitColumnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownUnitColumnCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownUnitColumnCount.ValueChanged += new System.EventHandler(this.numUpDownUnitColumnCount_ValueChanged);
            // 
            // numUpDownUnitRowCount
            // 
            this.numUpDownUnitRowCount.Location = new System.Drawing.Point(230, 6);
            this.numUpDownUnitRowCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownUnitRowCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownUnitRowCount.Name = "numUpDownUnitRowCount";
            this.numUpDownUnitRowCount.Size = new System.Drawing.Size(87, 21);
            this.numUpDownUnitRowCount.TabIndex = 312;
            this.numUpDownUnitRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownUnitRowCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownUnitRowCount.ValueChanged += new System.EventHandler(this.numUpDownUnitRowCount_ValueChanged);
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel3.ColorBottom = System.Drawing.Color.SkyBlue;
            this.gradientLabel3.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel3.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel3.ForeColor = System.Drawing.Color.White;
            this.gradientLabel3.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel3.Location = new System.Drawing.Point(61, 34);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(163, 26);
            this.gradientLabel3.TabIndex = 311;
            this.gradientLabel3.Text = "  Unit Column Total Count";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel9
            // 
            this.gradientLabel9.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel9.ColorBottom = System.Drawing.Color.SkyBlue;
            this.gradientLabel9.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel9.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel9.ForeColor = System.Drawing.Color.White;
            this.gradientLabel9.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel9.Location = new System.Drawing.Point(61, 3);
            this.gradientLabel9.Name = "gradientLabel9";
            this.gradientLabel9.Size = new System.Drawing.Size(163, 26);
            this.gradientLabel9.TabIndex = 310;
            this.gradientLabel9.Text = "  Unit Row Total Count";
            this.gradientLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.gradientLabel2.ColorBottom = System.Drawing.Color.LightSteelBlue;
            this.gradientLabel2.ColorTop = System.Drawing.Color.LightSlateGray;
            this.gradientLabel2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel2.ForeColor = System.Drawing.Color.White;
            this.gradientLabel2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel2.Location = new System.Drawing.Point(639, 250);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(620, 30);
            this.gradientLabel2.TabIndex = 309;
            this.gradientLabel2.Text = "Inspection Area Setting";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.gradientLabel1.ColorBottom = System.Drawing.Color.LightSteelBlue;
            this.gradientLabel1.ColorTop = System.Drawing.Color.LightSlateGray;
            this.gradientLabel1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel1.ForeColor = System.Drawing.Color.White;
            this.gradientLabel1.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel1.Location = new System.Drawing.Point(639, 3);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(620, 30);
            this.gradientLabel1.TabIndex = 308;
            this.gradientLabel1.Text = "Map Data Array Setting";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(1127, 800);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 35);
            this.btnOk.TabIndex = 303;
            this.btnOk.Text = "Confirm";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // kpTeachDisplay
            // 
            this.kpTeachDisplay.BackColor = System.Drawing.Color.White;
            this.kpTeachDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpTeachDisplay.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kpTeachDisplay.Location = new System.Drawing.Point(3, 36);
            this.kpTeachDisplay.Name = "kpTeachDisplay";
            this.kpTeachDisplay.Size = new System.Drawing.Size(630, 758);
            this.kpTeachDisplay.TabIndex = 302;
            this.kpTeachDisplay.UseStatusBar = true;
            // 
            // labelInputTitle
            // 
            this.labelInputTitle.BackColor = System.Drawing.Color.LightSlateGray;
            this.labelInputTitle.ColorBottom = System.Drawing.Color.LightSteelBlue;
            this.labelInputTitle.ColorTop = System.Drawing.Color.LightSlateGray;
            this.labelInputTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelInputTitle.ForeColor = System.Drawing.Color.White;
            this.labelInputTitle.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.labelInputTitle.Location = new System.Drawing.Point(3, 3);
            this.labelInputTitle.Name = "labelInputTitle";
            this.labelInputTitle.Size = new System.Drawing.Size(630, 30);
            this.labelInputTitle.TabIndex = 301;
            this.labelInputTitle.Text = " Map Data Setting Image";
            this.labelInputTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chAreaAutoSearch
            // 
            this.chAreaAutoSearch.AutoSize = true;
            this.chAreaAutoSearch.ForeColor = System.Drawing.Color.White;
            this.chAreaAutoSearch.Location = new System.Drawing.Point(639, 284);
            this.chAreaAutoSearch.Name = "chAreaAutoSearch";
            this.chAreaAutoSearch.Size = new System.Drawing.Size(124, 18);
            this.chAreaAutoSearch.TabIndex = 315;
            this.chAreaAutoSearch.Text = "Area Auto Search";
            this.chAreaAutoSearch.UseVisualStyleBackColor = true;
            this.chAreaAutoSearch.CheckedChanged += new System.EventHandler(this.chAreaAutoSearch_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnManualSearchAreaSet);
            this.panel3.Controls.Add(this.btnManualSearchArea);
            this.panel3.Location = new System.Drawing.Point(639, 737);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(620, 57);
            this.panel3.TabIndex = 316;
            // 
            // chAreaManualSearch
            // 
            this.chAreaManualSearch.AutoSize = true;
            this.chAreaManualSearch.ForeColor = System.Drawing.Color.White;
            this.chAreaManualSearch.Location = new System.Drawing.Point(639, 715);
            this.chAreaManualSearch.Name = "chAreaManualSearch";
            this.chAreaManualSearch.Size = new System.Drawing.Size(139, 18);
            this.chAreaManualSearch.TabIndex = 317;
            this.chAreaManualSearch.Text = "Area Manual Search";
            this.chAreaManualSearch.UseVisualStyleBackColor = true;
            this.chAreaManualSearch.CheckedChanged += new System.EventHandler(this.chAreaManualSearch_CheckedChanged);
            // 
            // MapDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(1262, 873);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 148);
            this.Name = "MapDataWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Map Data Window";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindScore)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSectionColumnCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSectionRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownUnitColumnCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownUnitRowCount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private CustomControl.GradientLabel labelInputTitle;
        private KPDisplay.KPCogDisplayControl kpTeachDisplay;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnUnitPatternSearchAreaSet;
        private System.Windows.Forms.Button btnUnitPatternSearchAreaShow;
        private System.Windows.Forms.Button btnUnitPatternAreaSet;
        private System.Windows.Forms.Button btnUnitPatternAreaShow;
        private CustomControl.GradientLabel gradientLabel2;
        private CustomControl.GradientLabel gradientLabel1;
        private System.Windows.Forms.Panel panel1;
        private CustomControl.GradientLabel gradientLabel3;
        private CustomControl.GradientLabel gradientLabel9;
        private System.Windows.Forms.NumericUpDown numUpDownUnitColumnCount;
        private System.Windows.Forms.NumericUpDown numUpDownUnitRowCount;
        private System.Windows.Forms.NumericUpDown numUpDownSectionColumnCount;
        private System.Windows.Forms.NumericUpDown numUpDownSectionRowCount;
        private CustomControl.GradientLabel gradientLabel4;
        private CustomControl.GradientLabel gradientLabel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private KPDisplay.KPCogDisplayControl kpPatternDisplay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownAngleLimit;
        private CustomControl.GradientLabel gradientLabel8;
        private System.Windows.Forms.NumericUpDown numericUpDownFindCount;
        private CustomControl.GradientLabel gradientLabel10;
        private System.Windows.Forms.NumericUpDown numericUpDownFindScore;
        private CustomControl.GradientLabel gradientLabel11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUnitPatternAreaCancel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFindSearchArea;
        private System.Windows.Forms.TextBox txtUnitTotalCount;
        private CustomControl.GradientLabel gradientLabel6;
        private System.Windows.Forms.Button btnUnitPatternOriginCenterSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowSearchArea;
        private System.Windows.Forms.Button btnManualSearchArea;
        private System.Windows.Forms.Button btnManualSearchAreaSet;
        private System.Windows.Forms.CheckBox chAreaManualSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chAreaAutoSearch;
    }
}

