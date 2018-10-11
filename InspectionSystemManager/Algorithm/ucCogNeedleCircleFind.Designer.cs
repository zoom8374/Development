namespace InspectionSystemManager
{
    partial class ucCogNeedleCircleFind
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new CustomControl.GradientLabel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gradientLabel6 = new CustomControl.GradientLabel();
            this.rbSearchDirectionIn = new System.Windows.Forms.RadioButton();
            this.rbSearchDirectionOut = new System.Windows.Forms.RadioButton();
            this.numUpDownProjectionLength = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.numUpDownSearchLength = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel1 = new CustomControl.GradientLabel();
            this.numUpDownCaliperNumber = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel7 = new CustomControl.GradientLabel();
            this.graLabelSearchDirection = new CustomControl.GradientLabel();
            this.btnDrawCaliper = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numUpDownAngleSpan = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel9 = new CustomControl.GradientLabel();
            this.numUpDownAngleStart = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel8 = new CustomControl.GradientLabel();
            this.numUpDownArcRadius = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel5 = new CustomControl.GradientLabel();
            this.numUpDownArcCenterY = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.numUpDownArcCenterX = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel3 = new CustomControl.GradientLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxRadius = new System.Windows.Forms.TextBox();
            this.textBoxCenterY = new System.Windows.Forms.TextBox();
            this.textBoxCenterX = new System.Windows.Forms.TextBox();
            this.gradientLabel12 = new CustomControl.GradientLabel();
            this.gradientLabel13 = new CustomControl.GradientLabel();
            this.gradientLabel14 = new CustomControl.GradientLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownProjectionLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSearchLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCaliperNumber)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAngleSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAngleStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownArcRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownArcCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownArcCenterX)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.White;
            this.labelTitle.ColorBottom = System.Drawing.Color.White;
            this.labelTitle.ColorTop = System.Drawing.Color.SteelBlue;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.labelTitle.Location = new System.Drawing.Point(2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(497, 30);
            this.labelTitle.TabIndex = 12;
            this.labelTitle.Text = " Needle Find Teaching Window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetting.ForeColor = System.Drawing.Color.Black;
            this.btnSetting.Location = new System.Drawing.Point(395, 333);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(100, 37);
            this.btnSetting.TabIndex = 51;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradientLabel6);
            this.groupBox1.Controls.Add(this.rbSearchDirectionIn);
            this.groupBox1.Controls.Add(this.rbSearchDirectionOut);
            this.groupBox1.Controls.Add(this.numUpDownProjectionLength);
            this.groupBox1.Controls.Add(this.gradientLabel2);
            this.groupBox1.Controls.Add(this.numUpDownSearchLength);
            this.groupBox1.Controls.Add(this.gradientLabel1);
            this.groupBox1.Controls.Add(this.numUpDownCaliperNumber);
            this.groupBox1.Controls.Add(this.gradientLabel7);
            this.groupBox1.Controls.Add(this.graLabelSearchDirection);
            this.groupBox1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 150);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Caliper Setting ";
            // 
            // gradientLabel6
            // 
            this.gradientLabel6.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel6.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel6.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel6.ForeColor = System.Drawing.Color.White;
            this.gradientLabel6.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel6.Location = new System.Drawing.Point(10, 112);
            this.gradientLabel6.Name = "gradientLabel6";
            this.gradientLabel6.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel6.TabIndex = 68;
            this.gradientLabel6.Text = "Search direction";
            this.gradientLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbSearchDirectionIn
            // 
            this.rbSearchDirectionIn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSearchDirectionIn.ForeColor = System.Drawing.Color.Black;
            this.rbSearchDirectionIn.Location = new System.Drawing.Point(140, 112);
            this.rbSearchDirectionIn.Name = "rbSearchDirectionIn";
            this.rbSearchDirectionIn.Size = new System.Drawing.Size(64, 28);
            this.rbSearchDirectionIn.TabIndex = 67;
            this.rbSearchDirectionIn.Tag = "0";
            this.rbSearchDirectionIn.Text = "Inward";
            this.rbSearchDirectionIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSearchDirectionIn.UseVisualStyleBackColor = true;
            this.rbSearchDirectionIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbSearchDirection_MouseUp);
            // 
            // rbSearchDirectionOut
            // 
            this.rbSearchDirectionOut.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSearchDirectionOut.Checked = true;
            this.rbSearchDirectionOut.ForeColor = System.Drawing.Color.Black;
            this.rbSearchDirectionOut.Location = new System.Drawing.Point(204, 112);
            this.rbSearchDirectionOut.Name = "rbSearchDirectionOut";
            this.rbSearchDirectionOut.Size = new System.Drawing.Size(64, 28);
            this.rbSearchDirectionOut.TabIndex = 66;
            this.rbSearchDirectionOut.TabStop = true;
            this.rbSearchDirectionOut.Tag = "1";
            this.rbSearchDirectionOut.Text = "Outward";
            this.rbSearchDirectionOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSearchDirectionOut.UseVisualStyleBackColor = true;
            this.rbSearchDirectionOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbSearchDirection_MouseUp);
            // 
            // numUpDownProjectionLength
            // 
            this.numUpDownProjectionLength.DecimalPlaces = 2;
            this.numUpDownProjectionLength.Location = new System.Drawing.Point(140, 85);
            this.numUpDownProjectionLength.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numUpDownProjectionLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownProjectionLength.Name = "numUpDownProjectionLength";
            this.numUpDownProjectionLength.Size = new System.Drawing.Size(128, 21);
            this.numUpDownProjectionLength.TabIndex = 65;
            this.numUpDownProjectionLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownProjectionLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownProjectionLength.ValueChanged += new System.EventHandler(this.numUpDownProjectionLength_ValueChanged);
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel2.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel2.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel2.ForeColor = System.Drawing.Color.White;
            this.gradientLabel2.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel2.Location = new System.Drawing.Point(10, 81);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel2.TabIndex = 64;
            this.gradientLabel2.Text = "Projection length";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpDownSearchLength
            // 
            this.numUpDownSearchLength.DecimalPlaces = 2;
            this.numUpDownSearchLength.Location = new System.Drawing.Point(140, 54);
            this.numUpDownSearchLength.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numUpDownSearchLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownSearchLength.Name = "numUpDownSearchLength";
            this.numUpDownSearchLength.Size = new System.Drawing.Size(128, 21);
            this.numUpDownSearchLength.TabIndex = 63;
            this.numUpDownSearchLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownSearchLength.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numUpDownSearchLength.ValueChanged += new System.EventHandler(this.numUpDownSearchLength_ValueChanged);
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel1.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel1.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel1.ForeColor = System.Drawing.Color.White;
            this.gradientLabel1.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel1.Location = new System.Drawing.Point(10, 51);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel1.TabIndex = 62;
            this.gradientLabel1.Text = "Search length";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpDownCaliperNumber
            // 
            this.numUpDownCaliperNumber.Location = new System.Drawing.Point(140, 24);
            this.numUpDownCaliperNumber.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpDownCaliperNumber.Name = "numUpDownCaliperNumber";
            this.numUpDownCaliperNumber.Size = new System.Drawing.Size(128, 21);
            this.numUpDownCaliperNumber.TabIndex = 61;
            this.numUpDownCaliperNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownCaliperNumber.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpDownCaliperNumber.ValueChanged += new System.EventHandler(this.numUpDownCaliperNumber_ValueChanged);
            // 
            // gradientLabel7
            // 
            this.gradientLabel7.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel7.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel7.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel7.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel7.ForeColor = System.Drawing.Color.White;
            this.gradientLabel7.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel7.Location = new System.Drawing.Point(10, 21);
            this.gradientLabel7.Name = "gradientLabel7";
            this.gradientLabel7.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel7.TabIndex = 60;
            this.gradientLabel7.Text = "Number of calipers";
            this.gradientLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graLabelSearchDirection
            // 
            this.graLabelSearchDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.graLabelSearchDirection.ColorBottom = System.Drawing.Color.Empty;
            this.graLabelSearchDirection.ColorTop = System.Drawing.Color.Empty;
            this.graLabelSearchDirection.ForeColor = System.Drawing.Color.White;
            this.graLabelSearchDirection.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.graLabelSearchDirection.Location = new System.Drawing.Point(261, 113);
            this.graLabelSearchDirection.Name = "graLabelSearchDirection";
            this.graLabelSearchDirection.Size = new System.Drawing.Size(27, 26);
            this.graLabelSearchDirection.TabIndex = 69;
            this.graLabelSearchDirection.Text = "0";
            this.graLabelSearchDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.graLabelSearchDirection.Visible = false;
            // 
            // btnDrawCaliper
            // 
            this.btnDrawCaliper.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDrawCaliper.ForeColor = System.Drawing.Color.Black;
            this.btnDrawCaliper.Location = new System.Drawing.Point(295, 333);
            this.btnDrawCaliper.Name = "btnDrawCaliper";
            this.btnDrawCaliper.Size = new System.Drawing.Size(100, 37);
            this.btnDrawCaliper.TabIndex = 70;
            this.btnDrawCaliper.Text = "Draw Caliper";
            this.btnDrawCaliper.UseVisualStyleBackColor = true;
            this.btnDrawCaliper.Click += new System.EventHandler(this.btnDrawCaliper_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numUpDownAngleSpan);
            this.groupBox2.Controls.Add(this.gradientLabel9);
            this.groupBox2.Controls.Add(this.numUpDownAngleStart);
            this.groupBox2.Controls.Add(this.gradientLabel8);
            this.groupBox2.Controls.Add(this.numUpDownArcRadius);
            this.groupBox2.Controls.Add(this.gradientLabel5);
            this.groupBox2.Controls.Add(this.numUpDownArcCenterY);
            this.groupBox2.Controls.Add(this.gradientLabel4);
            this.groupBox2.Controls.Add(this.numUpDownArcCenterX);
            this.groupBox2.Controls.Add(this.gradientLabel3);
            this.groupBox2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 181);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Expected circular Arc ";
            // 
            // numUpDownAngleSpan
            // 
            this.numUpDownAngleSpan.DecimalPlaces = 2;
            this.numUpDownAngleSpan.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUpDownAngleSpan.Location = new System.Drawing.Point(143, 147);
            this.numUpDownAngleSpan.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownAngleSpan.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numUpDownAngleSpan.Name = "numUpDownAngleSpan";
            this.numUpDownAngleSpan.Size = new System.Drawing.Size(128, 21);
            this.numUpDownAngleSpan.TabIndex = 71;
            this.numUpDownAngleSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownAngleSpan.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numUpDownAngleSpan.ValueChanged += new System.EventHandler(this.numUpDownAngleSpan_ValueChanged);
            // 
            // gradientLabel9
            // 
            this.gradientLabel9.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel9.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel9.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel9.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel9.ForeColor = System.Drawing.Color.White;
            this.gradientLabel9.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel9.Location = new System.Drawing.Point(13, 144);
            this.gradientLabel9.Name = "gradientLabel9";
            this.gradientLabel9.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel9.TabIndex = 70;
            this.gradientLabel9.Text = "Angle Span";
            this.gradientLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpDownAngleStart
            // 
            this.numUpDownAngleStart.DecimalPlaces = 2;
            this.numUpDownAngleStart.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUpDownAngleStart.Location = new System.Drawing.Point(143, 116);
            this.numUpDownAngleStart.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownAngleStart.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numUpDownAngleStart.Name = "numUpDownAngleStart";
            this.numUpDownAngleStart.Size = new System.Drawing.Size(128, 21);
            this.numUpDownAngleStart.TabIndex = 69;
            this.numUpDownAngleStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownAngleStart.ValueChanged += new System.EventHandler(this.numUpDownAngleStart_ValueChanged);
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
            this.gradientLabel8.Location = new System.Drawing.Point(13, 113);
            this.gradientLabel8.Name = "gradientLabel8";
            this.gradientLabel8.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel8.TabIndex = 68;
            this.gradientLabel8.Text = "Angle Start";
            this.gradientLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpDownArcRadius
            // 
            this.numUpDownArcRadius.DecimalPlaces = 2;
            this.numUpDownArcRadius.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUpDownArcRadius.Location = new System.Drawing.Point(143, 86);
            this.numUpDownArcRadius.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownArcRadius.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numUpDownArcRadius.Name = "numUpDownArcRadius";
            this.numUpDownArcRadius.Size = new System.Drawing.Size(128, 21);
            this.numUpDownArcRadius.TabIndex = 67;
            this.numUpDownArcRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownArcRadius.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUpDownArcRadius.ValueChanged += new System.EventHandler(this.numUpDownArcRadius_ValueChanged);
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel5.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel5.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel5.ForeColor = System.Drawing.Color.White;
            this.gradientLabel5.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel5.Location = new System.Drawing.Point(13, 83);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel5.TabIndex = 66;
            this.gradientLabel5.Text = "Radius";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpDownArcCenterY
            // 
            this.numUpDownArcCenterY.DecimalPlaces = 2;
            this.numUpDownArcCenterY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUpDownArcCenterY.Location = new System.Drawing.Point(143, 55);
            this.numUpDownArcCenterY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownArcCenterY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numUpDownArcCenterY.Name = "numUpDownArcCenterY";
            this.numUpDownArcCenterY.Size = new System.Drawing.Size(128, 21);
            this.numUpDownArcCenterY.TabIndex = 65;
            this.numUpDownArcCenterY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownArcCenterY.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDownArcCenterY.ValueChanged += new System.EventHandler(this.numUpDownArcCenterY_ValueChanged);
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel4.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel4.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel4.ForeColor = System.Drawing.Color.White;
            this.gradientLabel4.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel4.Location = new System.Drawing.Point(13, 52);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel4.TabIndex = 64;
            this.gradientLabel4.Text = " Center Y";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpDownArcCenterX
            // 
            this.numUpDownArcCenterX.DecimalPlaces = 2;
            this.numUpDownArcCenterX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUpDownArcCenterX.Location = new System.Drawing.Point(143, 24);
            this.numUpDownArcCenterX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownArcCenterX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numUpDownArcCenterX.Name = "numUpDownArcCenterX";
            this.numUpDownArcCenterX.Size = new System.Drawing.Size(128, 21);
            this.numUpDownArcCenterX.TabIndex = 63;
            this.numUpDownArcCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownArcCenterX.Value = new decimal(new int[] {
            15000,
            0,
            0,
            131072});
            this.numUpDownArcCenterX.ValueChanged += new System.EventHandler(this.numUpDownArcCenterX_ValueChanged);
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel3.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel3.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel3.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel3.ForeColor = System.Drawing.Color.White;
            this.gradientLabel3.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel3.Location = new System.Drawing.Point(13, 21);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(124, 26);
            this.gradientLabel3.TabIndex = 62;
            this.gradientLabel3.Text = " Center X";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxRadius);
            this.groupBox3.Controls.Add(this.textBoxCenterY);
            this.groupBox3.Controls.Add(this.textBoxCenterX);
            this.groupBox3.Controls.Add(this.gradientLabel12);
            this.groupBox3.Controls.Add(this.gradientLabel13);
            this.groupBox3.Controls.Add(this.gradientLabel14);
            this.groupBox3.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(295, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 148);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Result Condition";
            // 
            // textBoxRadius
            // 
            this.textBoxRadius.Location = new System.Drawing.Point(128, 86);
            this.textBoxRadius.Name = "textBoxRadius";
            this.textBoxRadius.ReadOnly = true;
            this.textBoxRadius.Size = new System.Drawing.Size(69, 21);
            this.textBoxRadius.TabIndex = 68;
            this.textBoxRadius.Text = "0";
            this.textBoxRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCenterY
            // 
            this.textBoxCenterY.Location = new System.Drawing.Point(128, 55);
            this.textBoxCenterY.Name = "textBoxCenterY";
            this.textBoxCenterY.ReadOnly = true;
            this.textBoxCenterY.Size = new System.Drawing.Size(69, 21);
            this.textBoxCenterY.TabIndex = 68;
            this.textBoxCenterY.Text = "0";
            this.textBoxCenterY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCenterX
            // 
            this.textBoxCenterX.Location = new System.Drawing.Point(128, 24);
            this.textBoxCenterX.Name = "textBoxCenterX";
            this.textBoxCenterX.ReadOnly = true;
            this.textBoxCenterX.Size = new System.Drawing.Size(69, 21);
            this.textBoxCenterX.TabIndex = 68;
            this.textBoxCenterX.Text = "0";
            this.textBoxCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gradientLabel12
            // 
            this.gradientLabel12.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel12.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel12.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel12.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel12.ForeColor = System.Drawing.Color.White;
            this.gradientLabel12.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel12.Location = new System.Drawing.Point(10, 83);
            this.gradientLabel12.Name = "gradientLabel12";
            this.gradientLabel12.Size = new System.Drawing.Size(113, 26);
            this.gradientLabel12.TabIndex = 66;
            this.gradientLabel12.Text = "Radius";
            this.gradientLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel13
            // 
            this.gradientLabel13.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel13.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel13.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel13.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel13.ForeColor = System.Drawing.Color.White;
            this.gradientLabel13.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel13.Location = new System.Drawing.Point(10, 52);
            this.gradientLabel13.Name = "gradientLabel13";
            this.gradientLabel13.Size = new System.Drawing.Size(113, 26);
            this.gradientLabel13.TabIndex = 64;
            this.gradientLabel13.Text = " Center Y";
            this.gradientLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel14
            // 
            this.gradientLabel14.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel14.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel14.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel14.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel14.ForeColor = System.Drawing.Color.White;
            this.gradientLabel14.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel14.Location = new System.Drawing.Point(10, 21);
            this.gradientLabel14.Name = "gradientLabel14";
            this.gradientLabel14.Size = new System.Drawing.Size(113, 26);
            this.gradientLabel14.TabIndex = 62;
            this.gradientLabel14.Text = " Center X";
            this.gradientLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucCogNeedleCircleFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDrawCaliper);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.labelTitle);
            this.Name = "ucCogNeedleCircleFind";
            this.Size = new System.Drawing.Size(500, 388);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownProjectionLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSearchLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCaliperNumber)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAngleSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAngleStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownArcRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownArcCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownArcCenterX)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.GradientLabel labelTitle;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numUpDownProjectionLength;
        private CustomControl.GradientLabel gradientLabel2;
        private System.Windows.Forms.NumericUpDown numUpDownSearchLength;
        private CustomControl.GradientLabel gradientLabel1;
        private System.Windows.Forms.NumericUpDown numUpDownCaliperNumber;
        private CustomControl.GradientLabel gradientLabel7;
        private CustomControl.GradientLabel gradientLabel6;
        private System.Windows.Forms.RadioButton rbSearchDirectionIn;
        private System.Windows.Forms.RadioButton rbSearchDirectionOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numUpDownAngleSpan;
        private CustomControl.GradientLabel gradientLabel9;
        private System.Windows.Forms.NumericUpDown numUpDownAngleStart;
        private CustomControl.GradientLabel gradientLabel8;
        private System.Windows.Forms.NumericUpDown numUpDownArcRadius;
        private CustomControl.GradientLabel gradientLabel5;
        private System.Windows.Forms.NumericUpDown numUpDownArcCenterY;
        private CustomControl.GradientLabel gradientLabel4;
        private System.Windows.Forms.NumericUpDown numUpDownArcCenterX;
        private CustomControl.GradientLabel gradientLabel3;
        private CustomControl.GradientLabel graLabelSearchDirection;
        private System.Windows.Forms.Button btnDrawCaliper;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomControl.GradientLabel gradientLabel12;
        private CustomControl.GradientLabel gradientLabel13;
        private CustomControl.GradientLabel gradientLabel14;
        private System.Windows.Forms.TextBox textBoxRadius;
        private System.Windows.Forms.TextBox textBoxCenterY;
        private System.Windows.Forms.TextBox textBoxCenterX;
    }
}
