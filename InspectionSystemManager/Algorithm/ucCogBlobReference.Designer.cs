﻿namespace InspectionSystemManager
{
    partial class ucCogBlobReference
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxBodyHeight = new System.Windows.Forms.TextBox();
            this.textBoxBodyWidth = new System.Windows.Forms.TextBox();
            this.textBoxBodyArea = new System.Windows.Forms.TextBox();
            this.gradientLabel5 = new CustomControl.GradientLabel();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.gradientLabel3 = new CustomControl.GradientLabel();
            this.label19 = new CustomControl.GradientLabel();
            this.label20 = new CustomControl.GradientLabel();
            this.label21 = new CustomControl.GradientLabel();
            this.label18 = new CustomControl.GradientLabel();
            this.label17 = new CustomControl.GradientLabel();
            this.label16 = new CustomControl.GradientLabel();
            this.label14 = new CustomControl.GradientLabel();
            this.label13 = new CustomControl.GradientLabel();
            this.label11 = new CustomControl.GradientLabel();
            this.label4 = new CustomControl.GradientLabel();
            this.label5 = new CustomControl.GradientLabel();
            this.label6 = new CustomControl.GradientLabel();
            this.label7 = new CustomControl.GradientLabel();
            this.label8 = new CustomControl.GradientLabel();
            this.label9 = new CustomControl.GradientLabel();
            this.textBoxHeightSizeMax = new System.Windows.Forms.TextBox();
            this.textBoxBlobAreaMin = new System.Windows.Forms.TextBox();
            this.textBoxHeightSizeMin = new System.Windows.Forms.TextBox();
            this.textBoxBlobAreaMax = new System.Windows.Forms.TextBox();
            this.textBoxWidthSizeMax = new System.Windows.Forms.TextBox();
            this.textBoxWidthSizeMin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gradientLabel6 = new CustomControl.GradientLabel();
            this.rbForegroundWhite = new System.Windows.Forms.RadioButton();
            this.rbForegroundBlack = new System.Windows.Forms.RadioButton();
            this.btnSetting = new System.Windows.Forms.Button();
            this.gradientLabel1 = new CustomControl.GradientLabel();
            this.rbRangeUpper = new System.Windows.Forms.RadioButton();
            this.hScrollBarThreshold = new System.Windows.Forms.HScrollBar();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.graLabelThresholdValue = new CustomControl.GradientLabel();
            this.graLabelForeground = new CustomControl.GradientLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbBenchMarkGravityCenter = new System.Windows.Forms.RadioButton();
            this.textBoxBenchMarkPosition = new System.Windows.Forms.TextBox();
            this.rbBenchMarkBottomRight = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkBottomCenter = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkBottomLeft = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkMiddleRight = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkMiddleCenter = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkMiddleLeft = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkTopCenter = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkTopRight = new System.Windows.Forms.RadioButton();
            this.rbBenchMarkTopLeft = new System.Windows.Forms.RadioButton();
            this.gradientLabel7 = new CustomControl.GradientLabel();
            this.ckBodyArea = new System.Windows.Forms.CheckBox();
            this.ckBodyWidth = new System.Windows.Forms.CheckBox();
            this.gradientLabel8 = new CustomControl.GradientLabel();
            this.ckBodyHeight = new System.Windows.Forms.CheckBox();
            this.gradientLabel9 = new CustomControl.GradientLabel();
            this.numUpDownBodyArea = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel10 = new CustomControl.GradientLabel();
            this.gradientLabel11 = new CustomControl.GradientLabel();
            this.numUpDownBodyWidth = new System.Windows.Forms.NumericUpDown();
            this.gradientLabel12 = new CustomControl.GradientLabel();
            this.numUpDownBodyHeight = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownBodyArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownBodyWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownBodyHeight)).BeginInit();
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
            this.labelTitle.Size = new System.Drawing.Size(818, 30);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = " Body Reference Teaching Window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(2, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 352);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(804, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Condition";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numUpDownBodyHeight);
            this.groupBox2.Controls.Add(this.numUpDownBodyWidth);
            this.groupBox2.Controls.Add(this.numUpDownBodyArea);
            this.groupBox2.Controls.Add(this.ckBodyHeight);
            this.groupBox2.Controls.Add(this.gradientLabel9);
            this.groupBox2.Controls.Add(this.ckBodyWidth);
            this.groupBox2.Controls.Add(this.gradientLabel8);
            this.groupBox2.Controls.Add(this.ckBodyArea);
            this.groupBox2.Controls.Add(this.textBoxBodyHeight);
            this.groupBox2.Controls.Add(this.textBoxBodyWidth);
            this.groupBox2.Controls.Add(this.textBoxBodyArea);
            this.groupBox2.Controls.Add(this.gradientLabel5);
            this.groupBox2.Controls.Add(this.gradientLabel4);
            this.groupBox2.Controls.Add(this.gradientLabel7);
            this.groupBox2.Controls.Add(this.gradientLabel3);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.gradientLabel12);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.gradientLabel11);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.gradientLabel10);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxHeightSizeMax);
            this.groupBox2.Controls.Add(this.textBoxBlobAreaMin);
            this.groupBox2.Controls.Add(this.textBoxHeightSizeMin);
            this.groupBox2.Controls.Add(this.textBoxBlobAreaMax);
            this.groupBox2.Controls.Add(this.textBoxWidthSizeMax);
            this.groupBox2.Controls.Add(this.textBoxWidthSizeMin);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(6, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 206);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Inspection Condition ";
            // 
            // textBoxBodyHeight
            // 
            this.textBoxBodyHeight.Location = new System.Drawing.Point(614, 123);
            this.textBoxBodyHeight.Name = "textBoxBodyHeight";
            this.textBoxBodyHeight.ReadOnly = true;
            this.textBoxBodyHeight.Size = new System.Drawing.Size(116, 21);
            this.textBoxBodyHeight.TabIndex = 54;
            this.textBoxBodyHeight.Text = "0";
            this.textBoxBodyHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxBodyWidth
            // 
            this.textBoxBodyWidth.Location = new System.Drawing.Point(370, 123);
            this.textBoxBodyWidth.Name = "textBoxBodyWidth";
            this.textBoxBodyWidth.ReadOnly = true;
            this.textBoxBodyWidth.Size = new System.Drawing.Size(116, 21);
            this.textBoxBodyWidth.TabIndex = 53;
            this.textBoxBodyWidth.Text = "0";
            this.textBoxBodyWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxBodyArea
            // 
            this.textBoxBodyArea.Location = new System.Drawing.Point(124, 123);
            this.textBoxBodyArea.Name = "textBoxBodyArea";
            this.textBoxBodyArea.ReadOnly = true;
            this.textBoxBodyArea.Size = new System.Drawing.Size(116, 21);
            this.textBoxBodyArea.TabIndex = 52;
            this.textBoxBodyArea.Text = "0";
            this.textBoxBodyArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.gradientLabel5.Location = new System.Drawing.Point(501, 121);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel5.TabIndex = 51;
            this.gradientLabel5.Text = "Body Height";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gradientLabel4.Location = new System.Drawing.Point(257, 121);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel4.TabIndex = 50;
            this.gradientLabel4.Text = "Body Width";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gradientLabel3.Location = new System.Drawing.Point(11, 121);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel3.TabIndex = 50;
            this.gradientLabel3.Text = "Body Area";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ColorBottom = System.Drawing.Color.Empty;
            this.label19.ColorTop = System.Drawing.Color.Empty;
            this.label19.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label19.Location = new System.Drawing.Point(456, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 14);
            this.label19.TabIndex = 49;
            this.label19.Text = "mm";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ColorBottom = System.Drawing.Color.Empty;
            this.label20.ColorTop = System.Drawing.Color.Empty;
            this.label20.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label20.Location = new System.Drawing.Point(456, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 14);
            this.label20.TabIndex = 48;
            this.label20.Text = "mm";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ColorBottom = System.Drawing.Color.Empty;
            this.label21.ColorTop = System.Drawing.Color.Empty;
            this.label21.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label21.Location = new System.Drawing.Point(456, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 14);
            this.label21.TabIndex = 47;
            this.label21.Text = "mm";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ColorBottom = System.Drawing.Color.Empty;
            this.label18.ColorTop = System.Drawing.Color.Empty;
            this.label18.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label18.Location = new System.Drawing.Point(211, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 14);
            this.label18.TabIndex = 46;
            this.label18.Text = "mm";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ColorBottom = System.Drawing.Color.Empty;
            this.label17.ColorTop = System.Drawing.Color.Empty;
            this.label17.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label17.Location = new System.Drawing.Point(211, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 14);
            this.label17.TabIndex = 45;
            this.label17.Text = "mm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ColorBottom = System.Drawing.Color.Empty;
            this.label16.ColorTop = System.Drawing.Color.Empty;
            this.label16.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label16.Location = new System.Drawing.Point(211, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 14);
            this.label16.TabIndex = 44;
            this.label16.Text = "mm";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ColorBottom = System.Drawing.Color.Empty;
            this.label14.ColorTop = System.Drawing.Color.Empty;
            this.label14.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label14.Location = new System.Drawing.Point(240, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 14);
            this.label14.TabIndex = 43;
            this.label14.Text = "~";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ColorBottom = System.Drawing.Color.Empty;
            this.label13.ColorTop = System.Drawing.Color.Empty;
            this.label13.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label13.Location = new System.Drawing.Point(240, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 14);
            this.label13.TabIndex = 41;
            this.label13.Text = "~";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ColorBottom = System.Drawing.Color.Empty;
            this.label11.ColorTop = System.Drawing.Color.Empty;
            this.label11.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label11.Location = new System.Drawing.Point(240, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 14);
            this.label11.TabIndex = 42;
            this.label11.Text = "~";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ColorBottom = System.Drawing.Color.Empty;
            this.label4.ColorTop = System.Drawing.Color.Empty;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label4.Location = new System.Drawing.Point(11, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "Blob Area Min";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.ColorBottom = System.Drawing.Color.Empty;
            this.label5.ColorTop = System.Drawing.Color.Empty;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label5.Location = new System.Drawing.Point(257, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 26);
            this.label5.TabIndex = 35;
            this.label5.Text = "Blob Area Max";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ColorBottom = System.Drawing.Color.Empty;
            this.label6.ColorTop = System.Drawing.Color.Empty;
            this.label6.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label6.Location = new System.Drawing.Point(11, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 26);
            this.label6.TabIndex = 36;
            this.label6.Text = "Width Min";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ColorBottom = System.Drawing.Color.Empty;
            this.label7.ColorTop = System.Drawing.Color.Empty;
            this.label7.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label7.Location = new System.Drawing.Point(257, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 26);
            this.label7.TabIndex = 38;
            this.label7.Text = "Width Max";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.ColorBottom = System.Drawing.Color.Empty;
            this.label8.ColorTop = System.Drawing.Color.Empty;
            this.label8.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label8.Location = new System.Drawing.Point(11, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 26);
            this.label8.TabIndex = 39;
            this.label8.Text = "Height Min";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.ColorBottom = System.Drawing.Color.Empty;
            this.label9.ColorTop = System.Drawing.Color.Empty;
            this.label9.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label9.Location = new System.Drawing.Point(257, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 26);
            this.label9.TabIndex = 40;
            this.label9.Text = "Height Max";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxHeightSizeMax
            // 
            this.textBoxHeightSizeMax.Location = new System.Drawing.Point(371, 74);
            this.textBoxHeightSizeMax.Name = "textBoxHeightSizeMax";
            this.textBoxHeightSizeMax.Size = new System.Drawing.Size(84, 21);
            this.textBoxHeightSizeMax.TabIndex = 37;
            this.textBoxHeightSizeMax.Text = "0";
            this.textBoxHeightSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxBlobAreaMin
            // 
            this.textBoxBlobAreaMin.Location = new System.Drawing.Point(125, 20);
            this.textBoxBlobAreaMin.Name = "textBoxBlobAreaMin";
            this.textBoxBlobAreaMin.Size = new System.Drawing.Size(84, 21);
            this.textBoxBlobAreaMin.TabIndex = 29;
            this.textBoxBlobAreaMin.Text = "10000";
            this.textBoxBlobAreaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxHeightSizeMin
            // 
            this.textBoxHeightSizeMin.Location = new System.Drawing.Point(125, 73);
            this.textBoxHeightSizeMin.Name = "textBoxHeightSizeMin";
            this.textBoxHeightSizeMin.Size = new System.Drawing.Size(84, 21);
            this.textBoxHeightSizeMin.TabIndex = 34;
            this.textBoxHeightSizeMin.Text = "0";
            this.textBoxHeightSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxBlobAreaMax
            // 
            this.textBoxBlobAreaMax.Location = new System.Drawing.Point(371, 19);
            this.textBoxBlobAreaMax.Name = "textBoxBlobAreaMax";
            this.textBoxBlobAreaMax.Size = new System.Drawing.Size(84, 21);
            this.textBoxBlobAreaMax.TabIndex = 30;
            this.textBoxBlobAreaMax.Text = "500000";
            this.textBoxBlobAreaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxWidthSizeMax
            // 
            this.textBoxWidthSizeMax.Location = new System.Drawing.Point(371, 46);
            this.textBoxWidthSizeMax.Name = "textBoxWidthSizeMax";
            this.textBoxWidthSizeMax.Size = new System.Drawing.Size(84, 21);
            this.textBoxWidthSizeMax.TabIndex = 32;
            this.textBoxWidthSizeMax.Text = "0";
            this.textBoxWidthSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxWidthSizeMin
            // 
            this.textBoxWidthSizeMin.Location = new System.Drawing.Point(125, 47);
            this.textBoxWidthSizeMin.Name = "textBoxWidthSizeMin";
            this.textBoxWidthSizeMin.Size = new System.Drawing.Size(84, 21);
            this.textBoxWidthSizeMin.TabIndex = 31;
            this.textBoxWidthSizeMin.Text = "0";
            this.textBoxWidthSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradientLabel6);
            this.groupBox1.Controls.Add(this.rbForegroundWhite);
            this.groupBox1.Controls.Add(this.rbForegroundBlack);
            this.groupBox1.Controls.Add(this.btnSetting);
            this.groupBox1.Controls.Add(this.gradientLabel1);
            this.groupBox1.Controls.Add(this.rbRangeUpper);
            this.groupBox1.Controls.Add(this.hScrollBarThreshold);
            this.groupBox1.Controls.Add(this.gradientLabel2);
            this.groupBox1.Controls.Add(this.graLabelThresholdValue);
            this.groupBox1.Controls.Add(this.graLabelForeground);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 92);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Threshold Condition ";
            // 
            // gradientLabel6
            // 
            this.gradientLabel6.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel6.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel6.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel6.ForeColor = System.Drawing.Color.White;
            this.gradientLabel6.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel6.Location = new System.Drawing.Point(224, 22);
            this.gradientLabel6.Name = "gradientLabel6";
            this.gradientLabel6.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel6.TabIndex = 54;
            this.gradientLabel6.Text = "Foreground";
            this.gradientLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbForegroundWhite
            // 
            this.rbForegroundWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbForegroundWhite.ForeColor = System.Drawing.Color.Black;
            this.rbForegroundWhite.Location = new System.Drawing.Point(336, 21);
            this.rbForegroundWhite.Name = "rbForegroundWhite";
            this.rbForegroundWhite.Size = new System.Drawing.Size(51, 28);
            this.rbForegroundWhite.TabIndex = 53;
            this.rbForegroundWhite.Tag = "1";
            this.rbForegroundWhite.Text = "W";
            this.rbForegroundWhite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbForegroundWhite.UseVisualStyleBackColor = true;
            this.rbForegroundWhite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbForeground_MouseUp);
            // 
            // rbForegroundBlack
            // 
            this.rbForegroundBlack.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbForegroundBlack.ForeColor = System.Drawing.Color.Black;
            this.rbForegroundBlack.Location = new System.Drawing.Point(389, 21);
            this.rbForegroundBlack.Name = "rbForegroundBlack";
            this.rbForegroundBlack.Size = new System.Drawing.Size(51, 28);
            this.rbForegroundBlack.TabIndex = 52;
            this.rbForegroundBlack.Tag = "0";
            this.rbForegroundBlack.Text = "B";
            this.rbForegroundBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbForegroundBlack.UseVisualStyleBackColor = true;
            this.rbForegroundBlack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbForeground_MouseUp);
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetting.ForeColor = System.Drawing.Color.Black;
            this.btnSetting.Location = new System.Drawing.Point(686, 47);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(100, 37);
            this.btnSetting.TabIndex = 50;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel1.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel1.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel1.ForeColor = System.Drawing.Color.White;
            this.gradientLabel1.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel1.Location = new System.Drawing.Point(11, 22);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel1.TabIndex = 0;
            this.gradientLabel1.Text = "Range Mode";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbRangeUpper
            // 
            this.rbRangeUpper.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbRangeUpper.BackgroundImage = global::InspectionSystemManager.Properties.Resources.Rang_Upper;
            this.rbRangeUpper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbRangeUpper.Location = new System.Drawing.Point(124, 21);
            this.rbRangeUpper.Name = "rbRangeUpper";
            this.rbRangeUpper.Size = new System.Drawing.Size(84, 28);
            this.rbRangeUpper.TabIndex = 16;
            this.rbRangeUpper.Tag = "7";
            this.rbRangeUpper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbRangeUpper.UseVisualStyleBackColor = true;
            // 
            // hScrollBarThreshold
            // 
            this.hScrollBarThreshold.Location = new System.Drawing.Point(126, 52);
            this.hScrollBarThreshold.Maximum = 255;
            this.hScrollBarThreshold.Name = "hScrollBarThreshold";
            this.hScrollBarThreshold.Size = new System.Drawing.Size(314, 26);
            this.hScrollBarThreshold.TabIndex = 18;
            this.hScrollBarThreshold.Value = 128;
            this.hScrollBarThreshold.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarThreshold_Scroll);
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.BackColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel2.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel2.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel2.ForeColor = System.Drawing.Color.White;
            this.gradientLabel2.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel2.Location = new System.Drawing.Point(11, 52);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel2.TabIndex = 17;
            this.gradientLabel2.Text = "Threshold";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graLabelThresholdValue
            // 
            this.graLabelThresholdValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.graLabelThresholdValue.ColorBottom = System.Drawing.Color.Empty;
            this.graLabelThresholdValue.ColorTop = System.Drawing.Color.Empty;
            this.graLabelThresholdValue.ForeColor = System.Drawing.Color.White;
            this.graLabelThresholdValue.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.graLabelThresholdValue.Location = new System.Drawing.Point(436, 52);
            this.graLabelThresholdValue.Name = "graLabelThresholdValue";
            this.graLabelThresholdValue.Size = new System.Drawing.Size(39, 26);
            this.graLabelThresholdValue.TabIndex = 19;
            this.graLabelThresholdValue.Text = "128";
            this.graLabelThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graLabelForeground
            // 
            this.graLabelForeground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.graLabelForeground.ColorBottom = System.Drawing.Color.Empty;
            this.graLabelForeground.ColorTop = System.Drawing.Color.Empty;
            this.graLabelForeground.ForeColor = System.Drawing.Color.White;
            this.graLabelForeground.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.graLabelForeground.Location = new System.Drawing.Point(436, 23);
            this.graLabelForeground.Name = "graLabelForeground";
            this.graLabelForeground.Size = new System.Drawing.Size(39, 26);
            this.graLabelForeground.TabIndex = 55;
            this.graLabelForeground.Text = "0";
            this.graLabelForeground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.graLabelForeground.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(804, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Properties";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbBenchMarkGravityCenter);
            this.groupBox4.Controls.Add(this.textBoxBenchMarkPosition);
            this.groupBox4.Controls.Add(this.rbBenchMarkBottomRight);
            this.groupBox4.Controls.Add(this.rbBenchMarkBottomCenter);
            this.groupBox4.Controls.Add(this.rbBenchMarkBottomLeft);
            this.groupBox4.Controls.Add(this.rbBenchMarkMiddleRight);
            this.groupBox4.Controls.Add(this.rbBenchMarkMiddleCenter);
            this.groupBox4.Controls.Add(this.rbBenchMarkMiddleLeft);
            this.groupBox4.Controls.Add(this.rbBenchMarkTopCenter);
            this.groupBox4.Controls.Add(this.rbBenchMarkTopRight);
            this.groupBox4.Controls.Add(this.rbBenchMarkTopLeft);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(6, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(792, 175);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " BenchMark Position ";
            // 
            // rbBenchMarkGravityCenter
            // 
            this.rbBenchMarkGravityCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkGravityCenter.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkGravityCenter.Location = new System.Drawing.Point(144, 70);
            this.rbBenchMarkGravityCenter.Name = "rbBenchMarkGravityCenter";
            this.rbBenchMarkGravityCenter.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkGravityCenter.TabIndex = 32;
            this.rbBenchMarkGravityCenter.Tag = "9";
            this.rbBenchMarkGravityCenter.Text = "MC";
            this.rbBenchMarkGravityCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkGravityCenter.UseVisualStyleBackColor = true;
            // 
            // textBoxBenchMarkPosition
            // 
            this.textBoxBenchMarkPosition.Location = new System.Drawing.Point(209, 83);
            this.textBoxBenchMarkPosition.Name = "textBoxBenchMarkPosition";
            this.textBoxBenchMarkPosition.Size = new System.Drawing.Size(30, 21);
            this.textBoxBenchMarkPosition.TabIndex = 23;
            this.textBoxBenchMarkPosition.Text = "0";
            this.textBoxBenchMarkPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxBenchMarkPosition.Visible = false;
            // 
            // rbBenchMarkBottomRight
            // 
            this.rbBenchMarkBottomRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkBottomRight.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkBottomRight.Location = new System.Drawing.Point(98, 118);
            this.rbBenchMarkBottomRight.Name = "rbBenchMarkBottomRight";
            this.rbBenchMarkBottomRight.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkBottomRight.TabIndex = 31;
            this.rbBenchMarkBottomRight.Tag = "8";
            this.rbBenchMarkBottomRight.Text = "BR";
            this.rbBenchMarkBottomRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkBottomRight.UseVisualStyleBackColor = true;
            this.rbBenchMarkBottomRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkBottomCenter
            // 
            this.rbBenchMarkBottomCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkBottomCenter.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkBottomCenter.Location = new System.Drawing.Point(57, 118);
            this.rbBenchMarkBottomCenter.Name = "rbBenchMarkBottomCenter";
            this.rbBenchMarkBottomCenter.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkBottomCenter.TabIndex = 30;
            this.rbBenchMarkBottomCenter.Tag = "7";
            this.rbBenchMarkBottomCenter.Text = "BC";
            this.rbBenchMarkBottomCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkBottomCenter.UseVisualStyleBackColor = true;
            this.rbBenchMarkBottomCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkBottomLeft
            // 
            this.rbBenchMarkBottomLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkBottomLeft.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkBottomLeft.Location = new System.Drawing.Point(16, 118);
            this.rbBenchMarkBottomLeft.Name = "rbBenchMarkBottomLeft";
            this.rbBenchMarkBottomLeft.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkBottomLeft.TabIndex = 29;
            this.rbBenchMarkBottomLeft.Tag = "6";
            this.rbBenchMarkBottomLeft.Text = "BL";
            this.rbBenchMarkBottomLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkBottomLeft.UseVisualStyleBackColor = true;
            this.rbBenchMarkBottomLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkMiddleRight
            // 
            this.rbBenchMarkMiddleRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkMiddleRight.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkMiddleRight.Location = new System.Drawing.Point(98, 70);
            this.rbBenchMarkMiddleRight.Name = "rbBenchMarkMiddleRight";
            this.rbBenchMarkMiddleRight.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkMiddleRight.TabIndex = 28;
            this.rbBenchMarkMiddleRight.Tag = "5";
            this.rbBenchMarkMiddleRight.Text = "MR";
            this.rbBenchMarkMiddleRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkMiddleRight.UseVisualStyleBackColor = true;
            this.rbBenchMarkMiddleRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkMiddleCenter
            // 
            this.rbBenchMarkMiddleCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkMiddleCenter.Checked = true;
            this.rbBenchMarkMiddleCenter.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkMiddleCenter.Location = new System.Drawing.Point(57, 70);
            this.rbBenchMarkMiddleCenter.Name = "rbBenchMarkMiddleCenter";
            this.rbBenchMarkMiddleCenter.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkMiddleCenter.TabIndex = 27;
            this.rbBenchMarkMiddleCenter.TabStop = true;
            this.rbBenchMarkMiddleCenter.Tag = "4";
            this.rbBenchMarkMiddleCenter.Text = "MC";
            this.rbBenchMarkMiddleCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkMiddleCenter.UseVisualStyleBackColor = true;
            this.rbBenchMarkMiddleCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkMiddleLeft
            // 
            this.rbBenchMarkMiddleLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkMiddleLeft.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkMiddleLeft.Location = new System.Drawing.Point(16, 70);
            this.rbBenchMarkMiddleLeft.Name = "rbBenchMarkMiddleLeft";
            this.rbBenchMarkMiddleLeft.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkMiddleLeft.TabIndex = 26;
            this.rbBenchMarkMiddleLeft.Tag = "3";
            this.rbBenchMarkMiddleLeft.Text = "ML";
            this.rbBenchMarkMiddleLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkMiddleLeft.UseVisualStyleBackColor = true;
            this.rbBenchMarkMiddleLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkTopCenter
            // 
            this.rbBenchMarkTopCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkTopCenter.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkTopCenter.Location = new System.Drawing.Point(57, 22);
            this.rbBenchMarkTopCenter.Name = "rbBenchMarkTopCenter";
            this.rbBenchMarkTopCenter.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkTopCenter.TabIndex = 25;
            this.rbBenchMarkTopCenter.Tag = "1";
            this.rbBenchMarkTopCenter.Text = "TC";
            this.rbBenchMarkTopCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkTopCenter.UseVisualStyleBackColor = true;
            this.rbBenchMarkTopCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkTopRight
            // 
            this.rbBenchMarkTopRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkTopRight.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkTopRight.Location = new System.Drawing.Point(98, 22);
            this.rbBenchMarkTopRight.Name = "rbBenchMarkTopRight";
            this.rbBenchMarkTopRight.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkTopRight.TabIndex = 24;
            this.rbBenchMarkTopRight.Tag = "2";
            this.rbBenchMarkTopRight.Text = "TR";
            this.rbBenchMarkTopRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkTopRight.UseVisualStyleBackColor = true;
            this.rbBenchMarkTopRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
            // 
            // rbBenchMarkTopLeft
            // 
            this.rbBenchMarkTopLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBenchMarkTopLeft.ForeColor = System.Drawing.Color.Black;
            this.rbBenchMarkTopLeft.Location = new System.Drawing.Point(16, 22);
            this.rbBenchMarkTopLeft.Name = "rbBenchMarkTopLeft";
            this.rbBenchMarkTopLeft.Size = new System.Drawing.Size(40, 47);
            this.rbBenchMarkTopLeft.TabIndex = 23;
            this.rbBenchMarkTopLeft.Tag = "0";
            this.rbBenchMarkTopLeft.Text = "TL";
            this.rbBenchMarkTopLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBenchMarkTopLeft.UseVisualStyleBackColor = true;
            this.rbBenchMarkTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbBenchMarkPosition_MouseUp);
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
            this.gradientLabel7.Location = new System.Drawing.Point(11, 151);
            this.gradientLabel7.Name = "gradientLabel7";
            this.gradientLabel7.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel7.TabIndex = 50;
            this.gradientLabel7.Text = "Body Area";
            this.gradientLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckBodyArea
            // 
            this.ckBodyArea.AutoSize = true;
            this.ckBodyArea.BackColor = System.Drawing.Color.SteelBlue;
            this.ckBodyArea.Location = new System.Drawing.Point(16, 156);
            this.ckBodyArea.Name = "ckBodyArea";
            this.ckBodyArea.Size = new System.Drawing.Size(15, 14);
            this.ckBodyArea.TabIndex = 0;
            this.ckBodyArea.UseVisualStyleBackColor = false;
            this.ckBodyArea.CheckedChanged += new System.EventHandler(this.ckBodyArea_CheckedChanged);
            // 
            // ckBodyWidth
            // 
            this.ckBodyWidth.AutoSize = true;
            this.ckBodyWidth.BackColor = System.Drawing.Color.SteelBlue;
            this.ckBodyWidth.Location = new System.Drawing.Point(262, 157);
            this.ckBodyWidth.Name = "ckBodyWidth";
            this.ckBodyWidth.Size = new System.Drawing.Size(15, 14);
            this.ckBodyWidth.TabIndex = 55;
            this.ckBodyWidth.UseVisualStyleBackColor = false;
            this.ckBodyWidth.CheckedChanged += new System.EventHandler(this.ckBodyWidth_CheckedChanged);
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
            this.gradientLabel8.Location = new System.Drawing.Point(257, 152);
            this.gradientLabel8.Name = "gradientLabel8";
            this.gradientLabel8.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel8.TabIndex = 56;
            this.gradientLabel8.Text = "Body Width    ";
            this.gradientLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckBodyHeight
            // 
            this.ckBodyHeight.AutoSize = true;
            this.ckBodyHeight.BackColor = System.Drawing.Color.SteelBlue;
            this.ckBodyHeight.Location = new System.Drawing.Point(506, 156);
            this.ckBodyHeight.Name = "ckBodyHeight";
            this.ckBodyHeight.Size = new System.Drawing.Size(15, 14);
            this.ckBodyHeight.TabIndex = 57;
            this.ckBodyHeight.UseVisualStyleBackColor = false;
            this.ckBodyHeight.CheckedChanged += new System.EventHandler(this.ckBodyHeight_CheckedChanged);
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
            this.gradientLabel9.Location = new System.Drawing.Point(501, 151);
            this.gradientLabel9.Name = "gradientLabel9";
            this.gradientLabel9.Size = new System.Drawing.Size(108, 26);
            this.gradientLabel9.TabIndex = 58;
            this.gradientLabel9.Text = "Body Height    ";
            this.gradientLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numUpDownBodyArea
            // 
            this.numUpDownBodyArea.Location = new System.Drawing.Point(124, 154);
            this.numUpDownBodyArea.Name = "numUpDownBodyArea";
            this.numUpDownBodyArea.Size = new System.Drawing.Size(116, 21);
            this.numUpDownBodyArea.TabIndex = 59;
            this.numUpDownBodyArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gradientLabel10
            // 
            this.gradientLabel10.AutoSize = true;
            this.gradientLabel10.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel10.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel10.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel10.ForeColor = System.Drawing.Color.White;
            this.gradientLabel10.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel10.Location = new System.Drawing.Point(239, 157);
            this.gradientLabel10.Name = "gradientLabel10";
            this.gradientLabel10.Size = new System.Drawing.Size(18, 14);
            this.gradientLabel10.TabIndex = 46;
            this.gradientLabel10.Text = "%";
            // 
            // gradientLabel11
            // 
            this.gradientLabel11.AutoSize = true;
            this.gradientLabel11.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel11.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel11.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel11.ForeColor = System.Drawing.Color.White;
            this.gradientLabel11.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel11.Location = new System.Drawing.Point(485, 157);
            this.gradientLabel11.Name = "gradientLabel11";
            this.gradientLabel11.Size = new System.Drawing.Size(18, 14);
            this.gradientLabel11.TabIndex = 46;
            this.gradientLabel11.Text = "%";
            // 
            // numUpDownBodyWidth
            // 
            this.numUpDownBodyWidth.Location = new System.Drawing.Point(370, 154);
            this.numUpDownBodyWidth.Name = "numUpDownBodyWidth";
            this.numUpDownBodyWidth.Size = new System.Drawing.Size(115, 21);
            this.numUpDownBodyWidth.TabIndex = 59;
            this.numUpDownBodyWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gradientLabel12
            // 
            this.gradientLabel12.AutoSize = true;
            this.gradientLabel12.ColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel12.ColorTop = System.Drawing.Color.Empty;
            this.gradientLabel12.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel12.ForeColor = System.Drawing.Color.White;
            this.gradientLabel12.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel12.Location = new System.Drawing.Point(730, 158);
            this.gradientLabel12.Name = "gradientLabel12";
            this.gradientLabel12.Size = new System.Drawing.Size(18, 14);
            this.gradientLabel12.TabIndex = 46;
            this.gradientLabel12.Text = "%";
            // 
            // numUpDownBodyHeight
            // 
            this.numUpDownBodyHeight.Location = new System.Drawing.Point(615, 154);
            this.numUpDownBodyHeight.Name = "numUpDownBodyHeight";
            this.numUpDownBodyHeight.Size = new System.Drawing.Size(115, 21);
            this.numUpDownBodyHeight.TabIndex = 59;
            this.numUpDownBodyHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ucCogBlobReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelTitle);
            this.Name = "ucCogBlobReference";
            this.Size = new System.Drawing.Size(820, 388);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownBodyArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownBodyWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownBodyHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.GradientLabel labelTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomControl.GradientLabel gradientLabel1;
        private CustomControl.GradientLabel graLabelThresholdValue;
        private System.Windows.Forms.RadioButton rbRangeUpper;
        private System.Windows.Forms.HScrollBar hScrollBarThreshold;
        private CustomControl.GradientLabel gradientLabel2;
        private CustomControl.GradientLabel label19;
        private CustomControl.GradientLabel label20;
        private CustomControl.GradientLabel label21;
        private CustomControl.GradientLabel label18;
        private CustomControl.GradientLabel label17;
        private CustomControl.GradientLabel label16;
        private CustomControl.GradientLabel label14;
        private CustomControl.GradientLabel label13;
        private CustomControl.GradientLabel label11;
        private CustomControl.GradientLabel label4;
        private CustomControl.GradientLabel label5;
        private CustomControl.GradientLabel label6;
        private CustomControl.GradientLabel label7;
        private CustomControl.GradientLabel label8;
        private CustomControl.GradientLabel label9;
        private System.Windows.Forms.TextBox textBoxHeightSizeMax;
        private System.Windows.Forms.TextBox textBoxBlobAreaMin;
        private System.Windows.Forms.TextBox textBoxHeightSizeMin;
        private System.Windows.Forms.TextBox textBoxBlobAreaMax;
        private System.Windows.Forms.TextBox textBoxWidthSizeMax;
        private System.Windows.Forms.TextBox textBoxWidthSizeMin;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TextBox textBoxBodyHeight;
        private System.Windows.Forms.TextBox textBoxBodyWidth;
        private System.Windows.Forms.TextBox textBoxBodyArea;
        private CustomControl.GradientLabel gradientLabel5;
        private CustomControl.GradientLabel gradientLabel4;
        private CustomControl.GradientLabel gradientLabel3;
        private CustomControl.GradientLabel gradientLabel6;
        private System.Windows.Forms.RadioButton rbForegroundWhite;
        private System.Windows.Forms.RadioButton rbForegroundBlack;
        private CustomControl.GradientLabel graLabelForeground;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbBenchMarkGravityCenter;
        private System.Windows.Forms.TextBox textBoxBenchMarkPosition;
        private System.Windows.Forms.RadioButton rbBenchMarkBottomRight;
        private System.Windows.Forms.RadioButton rbBenchMarkBottomCenter;
        private System.Windows.Forms.RadioButton rbBenchMarkBottomLeft;
        private System.Windows.Forms.RadioButton rbBenchMarkMiddleRight;
        private System.Windows.Forms.RadioButton rbBenchMarkMiddleCenter;
        private System.Windows.Forms.RadioButton rbBenchMarkMiddleLeft;
        private System.Windows.Forms.RadioButton rbBenchMarkTopCenter;
        private System.Windows.Forms.RadioButton rbBenchMarkTopRight;
        private System.Windows.Forms.RadioButton rbBenchMarkTopLeft;
        private System.Windows.Forms.NumericUpDown numUpDownBodyHeight;
        private System.Windows.Forms.NumericUpDown numUpDownBodyWidth;
        private System.Windows.Forms.NumericUpDown numUpDownBodyArea;
        private System.Windows.Forms.CheckBox ckBodyHeight;
        private CustomControl.GradientLabel gradientLabel9;
        private System.Windows.Forms.CheckBox ckBodyWidth;
        private CustomControl.GradientLabel gradientLabel8;
        private System.Windows.Forms.CheckBox ckBodyArea;
        private CustomControl.GradientLabel gradientLabel7;
        private CustomControl.GradientLabel gradientLabel12;
        private CustomControl.GradientLabel gradientLabel11;
        private CustomControl.GradientLabel gradientLabel10;
    }
}
