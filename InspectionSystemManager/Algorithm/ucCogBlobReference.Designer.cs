namespace InspectionSystemManager
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
            this.gradientLabel1 = new CustomControl.GradientLabel();
            this.graLabelThresholdValue = new CustomControl.GradientLabel();
            this.rbRangeUpper = new System.Windows.Forms.RadioButton();
            this.hScrollBarThreshold = new System.Windows.Forms.HScrollBar();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.labelTitle.Size = new System.Drawing.Size(950, 30);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = " Body Reference Teaching Window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
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
            this.groupBox2.Controls.Add(this.btnSetting);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ColorBottom = System.Drawing.Color.Empty;
            this.label19.ColorTop = System.Drawing.Color.Empty;
            this.label19.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.label19.Location = new System.Drawing.Point(456, 85);
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
            this.label20.Location = new System.Drawing.Point(456, 54);
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
            this.label18.Location = new System.Drawing.Point(211, 85);
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
            this.label17.Location = new System.Drawing.Point(211, 55);
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
            this.label14.Location = new System.Drawing.Point(240, 86);
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
            this.label13.Location = new System.Drawing.Point(240, 54);
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
            this.label6.Location = new System.Drawing.Point(11, 48);
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
            this.label7.Location = new System.Drawing.Point(257, 48);
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
            this.label8.Location = new System.Drawing.Point(11, 79);
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
            this.label9.Location = new System.Drawing.Point(257, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 26);
            this.label9.TabIndex = 40;
            this.label9.Text = "Height Max";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxHeightSizeMax
            // 
            this.textBoxHeightSizeMax.Location = new System.Drawing.Point(371, 82);
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
            this.textBoxBlobAreaMin.Text = "0";
            this.textBoxBlobAreaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxHeightSizeMin
            // 
            this.textBoxHeightSizeMin.Location = new System.Drawing.Point(125, 81);
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
            this.textBoxBlobAreaMax.Text = "0";
            this.textBoxBlobAreaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxWidthSizeMax
            // 
            this.textBoxWidthSizeMax.Location = new System.Drawing.Point(371, 50);
            this.textBoxWidthSizeMax.Name = "textBoxWidthSizeMax";
            this.textBoxWidthSizeMax.Size = new System.Drawing.Size(84, 21);
            this.textBoxWidthSizeMax.TabIndex = 32;
            this.textBoxWidthSizeMax.Text = "0";
            this.textBoxWidthSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxWidthSizeMin
            // 
            this.textBoxWidthSizeMin.Location = new System.Drawing.Point(125, 51);
            this.textBoxWidthSizeMin.Name = "textBoxWidthSizeMin";
            this.textBoxWidthSizeMin.Size = new System.Drawing.Size(84, 21);
            this.textBoxWidthSizeMin.TabIndex = 31;
            this.textBoxWidthSizeMin.Text = "0";
            this.textBoxWidthSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradientLabel1);
            this.groupBox1.Controls.Add(this.graLabelThresholdValue);
            this.groupBox1.Controls.Add(this.rbRangeUpper);
            this.groupBox1.Controls.Add(this.hScrollBarThreshold);
            this.groupBox1.Controls.Add(this.gradientLabel2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 92);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Threshold Condition ";
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
            // graLabelThresholdValue
            // 
            this.graLabelThresholdValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.graLabelThresholdValue.ColorBottom = System.Drawing.Color.Empty;
            this.graLabelThresholdValue.ColorTop = System.Drawing.Color.Empty;
            this.graLabelThresholdValue.ForeColor = System.Drawing.Color.White;
            this.graLabelThresholdValue.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.graLabelThresholdValue.Location = new System.Drawing.Point(343, 52);
            this.graLabelThresholdValue.Name = "graLabelThresholdValue";
            this.graLabelThresholdValue.Size = new System.Drawing.Size(39, 26);
            this.graLabelThresholdValue.TabIndex = 19;
            this.graLabelThresholdValue.Text = "128";
            this.graLabelThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbRangeUpper
            // 
            this.rbRangeUpper.Appearance = System.Windows.Forms.Appearance.Button;
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
            this.hScrollBarThreshold.Size = new System.Drawing.Size(214, 26);
            this.hScrollBarThreshold.TabIndex = 18;
            this.hScrollBarThreshold.Value = 128;
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
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetting.ForeColor = System.Drawing.Color.Black;
            this.btnSetting.Location = new System.Drawing.Point(686, 163);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(100, 37);
            this.btnSetting.TabIndex = 50;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
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
    }
}
