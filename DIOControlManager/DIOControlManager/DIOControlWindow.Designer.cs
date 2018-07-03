namespace DIOControlManager
{
    partial class DIOControlWindow
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
            this.btnTrigger = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnInput4 = new System.Windows.Forms.Button();
            this.btnInput3 = new System.Windows.Forms.Button();
            this.btnInput2 = new System.Windows.Forms.Button();
            this.btnInput1 = new System.Windows.Forms.Button();
            this.btnInput0 = new System.Windows.Forms.Button();
            this.btnInput5 = new System.Windows.Forms.Button();
            this.btnInput7 = new System.Windows.Forms.Button();
            this.btnInput6 = new System.Windows.Forms.Button();
            this.btnOutput7 = new System.Windows.Forms.Button();
            this.btnOutput6 = new System.Windows.Forms.Button();
            this.btnOutput5 = new System.Windows.Forms.Button();
            this.btnOutput4 = new System.Windows.Forms.Button();
            this.btnOutput3 = new System.Windows.Forms.Button();
            this.btnOutput2 = new System.Windows.Forms.Button();
            this.btnOutput1 = new System.Windows.Forms.Button();
            this.btnOutput0 = new System.Windows.Forms.Button();
            this.labelExit = new System.Windows.Forms.Label();
            this.btnOutput15 = new System.Windows.Forms.Button();
            this.btnOutput14 = new System.Windows.Forms.Button();
            this.btnOutput13 = new System.Windows.Forms.Button();
            this.btnOutput12 = new System.Windows.Forms.Button();
            this.btnOutput11 = new System.Windows.Forms.Button();
            this.btnOutput10 = new System.Windows.Forms.Button();
            this.btnOutput9 = new System.Windows.Forms.Button();
            this.btnOutput8 = new System.Windows.Forms.Button();
            this.btnInput15 = new System.Windows.Forms.Button();
            this.btnInput14 = new System.Windows.Forms.Button();
            this.btnInput13 = new System.Windows.Forms.Button();
            this.btnInput12 = new System.Windows.Forms.Button();
            this.btnInput11 = new System.Windows.Forms.Button();
            this.btnInput10 = new System.Windows.Forms.Button();
            this.btnInput9 = new System.Windows.Forms.Button();
            this.btnInput8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTrigger
            // 
            this.btnTrigger.Location = new System.Drawing.Point(4, 361);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(87, 25);
            this.btnTrigger.TabIndex = 0;
            this.btnTrigger.Text = "Trigger";
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(722, 30);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = " DIO Window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitle_Paint);
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // btnInput4
            // 
            this.btnInput4.BackColor = System.Drawing.Color.Maroon;
            this.btnInput4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput4.ForeColor = System.Drawing.Color.White;
            this.btnInput4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput4.Location = new System.Drawing.Point(4, 211);
            this.btnInput4.Name = "btnInput4";
            this.btnInput4.Size = new System.Drawing.Size(173, 32);
            this.btnInput4.TabIndex = 266;
            this.btnInput4.Tag = "4";
            this.btnInput4.Text = "DI4";
            this.btnInput4.UseVisualStyleBackColor = false;
            // 
            // btnInput3
            // 
            this.btnInput3.BackColor = System.Drawing.Color.Maroon;
            this.btnInput3.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput3.ForeColor = System.Drawing.Color.White;
            this.btnInput3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput3.Location = new System.Drawing.Point(4, 175);
            this.btnInput3.Name = "btnInput3";
            this.btnInput3.Size = new System.Drawing.Size(173, 32);
            this.btnInput3.TabIndex = 265;
            this.btnInput3.Tag = "3";
            this.btnInput3.Text = "DI3";
            this.btnInput3.UseVisualStyleBackColor = false;
            // 
            // btnInput2
            // 
            this.btnInput2.BackColor = System.Drawing.Color.Maroon;
            this.btnInput2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput2.ForeColor = System.Drawing.Color.White;
            this.btnInput2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput2.Location = new System.Drawing.Point(4, 139);
            this.btnInput2.Name = "btnInput2";
            this.btnInput2.Size = new System.Drawing.Size(173, 32);
            this.btnInput2.TabIndex = 264;
            this.btnInput2.Tag = "2";
            this.btnInput2.Text = "DI2";
            this.btnInput2.UseVisualStyleBackColor = false;
            // 
            // btnInput1
            // 
            this.btnInput1.BackColor = System.Drawing.Color.Maroon;
            this.btnInput1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput1.ForeColor = System.Drawing.Color.White;
            this.btnInput1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput1.Location = new System.Drawing.Point(4, 103);
            this.btnInput1.Name = "btnInput1";
            this.btnInput1.Size = new System.Drawing.Size(173, 32);
            this.btnInput1.TabIndex = 263;
            this.btnInput1.Tag = "1";
            this.btnInput1.Text = "DI1";
            this.btnInput1.UseVisualStyleBackColor = false;
            // 
            // btnInput0
            // 
            this.btnInput0.BackColor = System.Drawing.Color.Maroon;
            this.btnInput0.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput0.ForeColor = System.Drawing.Color.White;
            this.btnInput0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput0.Location = new System.Drawing.Point(4, 67);
            this.btnInput0.Name = "btnInput0";
            this.btnInput0.Size = new System.Drawing.Size(173, 32);
            this.btnInput0.TabIndex = 262;
            this.btnInput0.Tag = "0";
            this.btnInput0.Text = "DI0";
            this.btnInput0.UseVisualStyleBackColor = false;
            // 
            // btnInput5
            // 
            this.btnInput5.BackColor = System.Drawing.Color.Maroon;
            this.btnInput5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput5.ForeColor = System.Drawing.Color.White;
            this.btnInput5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput5.Location = new System.Drawing.Point(4, 247);
            this.btnInput5.Name = "btnInput5";
            this.btnInput5.Size = new System.Drawing.Size(173, 32);
            this.btnInput5.TabIndex = 272;
            this.btnInput5.Tag = "6";
            this.btnInput5.Text = "DI5";
            this.btnInput5.UseVisualStyleBackColor = false;
            // 
            // btnInput7
            // 
            this.btnInput7.BackColor = System.Drawing.Color.Maroon;
            this.btnInput7.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput7.ForeColor = System.Drawing.Color.White;
            this.btnInput7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput7.Location = new System.Drawing.Point(4, 319);
            this.btnInput7.Name = "btnInput7";
            this.btnInput7.Size = new System.Drawing.Size(173, 32);
            this.btnInput7.TabIndex = 274;
            this.btnInput7.Tag = "4";
            this.btnInput7.Text = "DI7";
            this.btnInput7.UseVisualStyleBackColor = false;
            // 
            // btnInput6
            // 
            this.btnInput6.BackColor = System.Drawing.Color.Maroon;
            this.btnInput6.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput6.ForeColor = System.Drawing.Color.White;
            this.btnInput6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput6.Location = new System.Drawing.Point(4, 283);
            this.btnInput6.Name = "btnInput6";
            this.btnInput6.Size = new System.Drawing.Size(173, 32);
            this.btnInput6.TabIndex = 273;
            this.btnInput6.Tag = "4";
            this.btnInput6.Text = "DI6";
            this.btnInput6.UseVisualStyleBackColor = false;
            // 
            // btnOutput7
            // 
            this.btnOutput7.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput7.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput7.ForeColor = System.Drawing.Color.White;
            this.btnOutput7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput7.Location = new System.Drawing.Point(367, 319);
            this.btnOutput7.Name = "btnOutput7";
            this.btnOutput7.Size = new System.Drawing.Size(173, 32);
            this.btnOutput7.TabIndex = 282;
            this.btnOutput7.Tag = "7";
            this.btnOutput7.Text = "DO7";
            this.btnOutput7.UseVisualStyleBackColor = false;
            this.btnOutput7.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput6
            // 
            this.btnOutput6.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput6.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput6.ForeColor = System.Drawing.Color.White;
            this.btnOutput6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput6.Location = new System.Drawing.Point(367, 283);
            this.btnOutput6.Name = "btnOutput6";
            this.btnOutput6.Size = new System.Drawing.Size(173, 32);
            this.btnOutput6.TabIndex = 281;
            this.btnOutput6.Tag = "6";
            this.btnOutput6.Text = "DO6";
            this.btnOutput6.UseVisualStyleBackColor = false;
            this.btnOutput6.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput5
            // 
            this.btnOutput5.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput5.ForeColor = System.Drawing.Color.White;
            this.btnOutput5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput5.Location = new System.Drawing.Point(367, 247);
            this.btnOutput5.Name = "btnOutput5";
            this.btnOutput5.Size = new System.Drawing.Size(173, 32);
            this.btnOutput5.TabIndex = 280;
            this.btnOutput5.Tag = "5";
            this.btnOutput5.Text = "DO5";
            this.btnOutput5.UseVisualStyleBackColor = false;
            this.btnOutput5.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput4
            // 
            this.btnOutput4.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput4.ForeColor = System.Drawing.Color.White;
            this.btnOutput4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput4.Location = new System.Drawing.Point(367, 211);
            this.btnOutput4.Name = "btnOutput4";
            this.btnOutput4.Size = new System.Drawing.Size(173, 32);
            this.btnOutput4.TabIndex = 279;
            this.btnOutput4.Tag = "4";
            this.btnOutput4.Text = "DO4";
            this.btnOutput4.UseVisualStyleBackColor = false;
            this.btnOutput4.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput3
            // 
            this.btnOutput3.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput3.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput3.ForeColor = System.Drawing.Color.White;
            this.btnOutput3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput3.Location = new System.Drawing.Point(367, 175);
            this.btnOutput3.Name = "btnOutput3";
            this.btnOutput3.Size = new System.Drawing.Size(173, 32);
            this.btnOutput3.TabIndex = 278;
            this.btnOutput3.Tag = "3";
            this.btnOutput3.Text = "DO3";
            this.btnOutput3.UseVisualStyleBackColor = false;
            this.btnOutput3.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput2
            // 
            this.btnOutput2.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput2.ForeColor = System.Drawing.Color.White;
            this.btnOutput2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput2.Location = new System.Drawing.Point(367, 139);
            this.btnOutput2.Name = "btnOutput2";
            this.btnOutput2.Size = new System.Drawing.Size(173, 32);
            this.btnOutput2.TabIndex = 277;
            this.btnOutput2.Tag = "2";
            this.btnOutput2.Text = "DO2";
            this.btnOutput2.UseVisualStyleBackColor = false;
            this.btnOutput2.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput1
            // 
            this.btnOutput1.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput1.ForeColor = System.Drawing.Color.White;
            this.btnOutput1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput1.Location = new System.Drawing.Point(367, 103);
            this.btnOutput1.Name = "btnOutput1";
            this.btnOutput1.Size = new System.Drawing.Size(173, 32);
            this.btnOutput1.TabIndex = 276;
            this.btnOutput1.Tag = "1";
            this.btnOutput1.Text = "DO1";
            this.btnOutput1.UseVisualStyleBackColor = false;
            this.btnOutput1.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput0
            // 
            this.btnOutput0.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput0.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput0.ForeColor = System.Drawing.Color.White;
            this.btnOutput0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput0.Location = new System.Drawing.Point(367, 67);
            this.btnOutput0.Name = "btnOutput0";
            this.btnOutput0.Size = new System.Drawing.Size(173, 32);
            this.btnOutput0.TabIndex = 275;
            this.btnOutput0.Tag = "0";
            this.btnOutput0.Text = "DO0";
            this.btnOutput0.UseVisualStyleBackColor = false;
            this.btnOutput0.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // labelExit
            // 
            this.labelExit.Font = new System.Drawing.Font("나눔바른고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelExit.ForeColor = System.Drawing.Color.White;
            this.labelExit.Location = new System.Drawing.Point(694, 3);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(25, 24);
            this.labelExit.TabIndex = 283;
            this.labelExit.Text = "X";
            this.labelExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOutput15
            // 
            this.btnOutput15.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput15.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput15.ForeColor = System.Drawing.Color.White;
            this.btnOutput15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput15.Location = new System.Drawing.Point(546, 319);
            this.btnOutput15.Name = "btnOutput15";
            this.btnOutput15.Size = new System.Drawing.Size(173, 32);
            this.btnOutput15.TabIndex = 291;
            this.btnOutput15.Tag = "15";
            this.btnOutput15.Text = "DO15";
            this.btnOutput15.UseVisualStyleBackColor = false;
            this.btnOutput15.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput14
            // 
            this.btnOutput14.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput14.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput14.ForeColor = System.Drawing.Color.White;
            this.btnOutput14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput14.Location = new System.Drawing.Point(546, 283);
            this.btnOutput14.Name = "btnOutput14";
            this.btnOutput14.Size = new System.Drawing.Size(173, 32);
            this.btnOutput14.TabIndex = 290;
            this.btnOutput14.Tag = "14";
            this.btnOutput14.Text = "DO14";
            this.btnOutput14.UseVisualStyleBackColor = false;
            this.btnOutput14.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput13
            // 
            this.btnOutput13.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput13.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput13.ForeColor = System.Drawing.Color.White;
            this.btnOutput13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput13.Location = new System.Drawing.Point(546, 247);
            this.btnOutput13.Name = "btnOutput13";
            this.btnOutput13.Size = new System.Drawing.Size(173, 32);
            this.btnOutput13.TabIndex = 289;
            this.btnOutput13.Tag = "13";
            this.btnOutput13.Text = "DO13";
            this.btnOutput13.UseVisualStyleBackColor = false;
            this.btnOutput13.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput12
            // 
            this.btnOutput12.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput12.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput12.ForeColor = System.Drawing.Color.White;
            this.btnOutput12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput12.Location = new System.Drawing.Point(546, 211);
            this.btnOutput12.Name = "btnOutput12";
            this.btnOutput12.Size = new System.Drawing.Size(173, 32);
            this.btnOutput12.TabIndex = 288;
            this.btnOutput12.Tag = "12";
            this.btnOutput12.Text = "DO12";
            this.btnOutput12.UseVisualStyleBackColor = false;
            this.btnOutput12.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput11
            // 
            this.btnOutput11.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput11.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput11.ForeColor = System.Drawing.Color.White;
            this.btnOutput11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput11.Location = new System.Drawing.Point(546, 175);
            this.btnOutput11.Name = "btnOutput11";
            this.btnOutput11.Size = new System.Drawing.Size(173, 32);
            this.btnOutput11.TabIndex = 287;
            this.btnOutput11.Tag = "11";
            this.btnOutput11.Text = "DO11";
            this.btnOutput11.UseVisualStyleBackColor = false;
            this.btnOutput11.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput10
            // 
            this.btnOutput10.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput10.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput10.ForeColor = System.Drawing.Color.White;
            this.btnOutput10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput10.Location = new System.Drawing.Point(546, 139);
            this.btnOutput10.Name = "btnOutput10";
            this.btnOutput10.Size = new System.Drawing.Size(173, 32);
            this.btnOutput10.TabIndex = 286;
            this.btnOutput10.Tag = "10";
            this.btnOutput10.Text = "DO10";
            this.btnOutput10.UseVisualStyleBackColor = false;
            this.btnOutput10.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput9
            // 
            this.btnOutput9.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput9.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput9.ForeColor = System.Drawing.Color.White;
            this.btnOutput9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput9.Location = new System.Drawing.Point(546, 103);
            this.btnOutput9.Name = "btnOutput9";
            this.btnOutput9.Size = new System.Drawing.Size(173, 32);
            this.btnOutput9.TabIndex = 285;
            this.btnOutput9.Tag = "9";
            this.btnOutput9.Text = "DO9";
            this.btnOutput9.UseVisualStyleBackColor = false;
            this.btnOutput9.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOutput8
            // 
            this.btnOutput8.BackColor = System.Drawing.Color.Maroon;
            this.btnOutput8.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnOutput8.ForeColor = System.Drawing.Color.White;
            this.btnOutput8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOutput8.Location = new System.Drawing.Point(546, 67);
            this.btnOutput8.Name = "btnOutput8";
            this.btnOutput8.Size = new System.Drawing.Size(173, 32);
            this.btnOutput8.TabIndex = 284;
            this.btnOutput8.Tag = "8";
            this.btnOutput8.Text = "DO8";
            this.btnOutput8.UseVisualStyleBackColor = false;
            this.btnOutput8.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnInput15
            // 
            this.btnInput15.BackColor = System.Drawing.Color.Maroon;
            this.btnInput15.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput15.ForeColor = System.Drawing.Color.White;
            this.btnInput15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput15.Location = new System.Drawing.Point(183, 319);
            this.btnInput15.Name = "btnInput15";
            this.btnInput15.Size = new System.Drawing.Size(173, 32);
            this.btnInput15.TabIndex = 299;
            this.btnInput15.Tag = "4";
            this.btnInput15.Text = "DI15";
            this.btnInput15.UseVisualStyleBackColor = false;
            // 
            // btnInput14
            // 
            this.btnInput14.BackColor = System.Drawing.Color.Maroon;
            this.btnInput14.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput14.ForeColor = System.Drawing.Color.White;
            this.btnInput14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput14.Location = new System.Drawing.Point(183, 283);
            this.btnInput14.Name = "btnInput14";
            this.btnInput14.Size = new System.Drawing.Size(173, 32);
            this.btnInput14.TabIndex = 298;
            this.btnInput14.Tag = "4";
            this.btnInput14.Text = "DI14";
            this.btnInput14.UseVisualStyleBackColor = false;
            // 
            // btnInput13
            // 
            this.btnInput13.BackColor = System.Drawing.Color.Maroon;
            this.btnInput13.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput13.ForeColor = System.Drawing.Color.White;
            this.btnInput13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput13.Location = new System.Drawing.Point(183, 247);
            this.btnInput13.Name = "btnInput13";
            this.btnInput13.Size = new System.Drawing.Size(173, 32);
            this.btnInput13.TabIndex = 297;
            this.btnInput13.Tag = "6";
            this.btnInput13.Text = "DI13";
            this.btnInput13.UseVisualStyleBackColor = false;
            // 
            // btnInput12
            // 
            this.btnInput12.BackColor = System.Drawing.Color.Maroon;
            this.btnInput12.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput12.ForeColor = System.Drawing.Color.White;
            this.btnInput12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput12.Location = new System.Drawing.Point(183, 211);
            this.btnInput12.Name = "btnInput12";
            this.btnInput12.Size = new System.Drawing.Size(173, 32);
            this.btnInput12.TabIndex = 296;
            this.btnInput12.Tag = "4";
            this.btnInput12.Text = "DI12";
            this.btnInput12.UseVisualStyleBackColor = false;
            // 
            // btnInput11
            // 
            this.btnInput11.BackColor = System.Drawing.Color.Maroon;
            this.btnInput11.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput11.ForeColor = System.Drawing.Color.White;
            this.btnInput11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput11.Location = new System.Drawing.Point(183, 175);
            this.btnInput11.Name = "btnInput11";
            this.btnInput11.Size = new System.Drawing.Size(173, 32);
            this.btnInput11.TabIndex = 295;
            this.btnInput11.Tag = "3";
            this.btnInput11.Text = "DI11";
            this.btnInput11.UseVisualStyleBackColor = false;
            // 
            // btnInput10
            // 
            this.btnInput10.BackColor = System.Drawing.Color.Maroon;
            this.btnInput10.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput10.ForeColor = System.Drawing.Color.White;
            this.btnInput10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput10.Location = new System.Drawing.Point(183, 139);
            this.btnInput10.Name = "btnInput10";
            this.btnInput10.Size = new System.Drawing.Size(173, 32);
            this.btnInput10.TabIndex = 294;
            this.btnInput10.Tag = "2";
            this.btnInput10.Text = "DI10";
            this.btnInput10.UseVisualStyleBackColor = false;
            // 
            // btnInput9
            // 
            this.btnInput9.BackColor = System.Drawing.Color.Maroon;
            this.btnInput9.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput9.ForeColor = System.Drawing.Color.White;
            this.btnInput9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput9.Location = new System.Drawing.Point(183, 103);
            this.btnInput9.Name = "btnInput9";
            this.btnInput9.Size = new System.Drawing.Size(173, 32);
            this.btnInput9.TabIndex = 293;
            this.btnInput9.Tag = "1";
            this.btnInput9.Text = "DI9";
            this.btnInput9.UseVisualStyleBackColor = false;
            // 
            // btnInput8
            // 
            this.btnInput8.BackColor = System.Drawing.Color.Maroon;
            this.btnInput8.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInput8.ForeColor = System.Drawing.Color.White;
            this.btnInput8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInput8.Location = new System.Drawing.Point(183, 67);
            this.btnInput8.Name = "btnInput8";
            this.btnInput8.Size = new System.Drawing.Size(173, 32);
            this.btnInput8.TabIndex = 292;
            this.btnInput8.Tag = "0";
            this.btnInput8.Text = "DI8";
            this.btnInput8.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 30);
            this.label1.TabIndex = 300;
            this.label1.Text = " Input I/O Signal (VISION -> PLC)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSlateGray;
            this.label2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(366, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 30);
            this.label2.TabIndex = 301;
            this.label2.Text = " Output I/O Signal (PLC -> VISION)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DIOControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(722, 391);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInput15);
            this.Controls.Add(this.btnInput14);
            this.Controls.Add(this.btnInput13);
            this.Controls.Add(this.btnInput12);
            this.Controls.Add(this.btnInput11);
            this.Controls.Add(this.btnInput10);
            this.Controls.Add(this.btnInput9);
            this.Controls.Add(this.btnInput8);
            this.Controls.Add(this.btnOutput15);
            this.Controls.Add(this.btnOutput14);
            this.Controls.Add(this.btnOutput13);
            this.Controls.Add(this.btnOutput12);
            this.Controls.Add(this.btnOutput11);
            this.Controls.Add(this.btnOutput10);
            this.Controls.Add(this.btnOutput9);
            this.Controls.Add(this.btnOutput8);
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.btnOutput7);
            this.Controls.Add(this.btnOutput6);
            this.Controls.Add(this.btnOutput5);
            this.Controls.Add(this.btnOutput4);
            this.Controls.Add(this.btnOutput3);
            this.Controls.Add(this.btnOutput2);
            this.Controls.Add(this.btnOutput1);
            this.Controls.Add(this.btnOutput0);
            this.Controls.Add(this.btnInput7);
            this.Controls.Add(this.btnInput6);
            this.Controls.Add(this.btnInput5);
            this.Controls.Add(this.btnInput4);
            this.Controls.Add(this.btnInput3);
            this.Controls.Add(this.btnInput2);
            this.Controls.Add(this.btnInput1);
            this.Controls.Add(this.btnInput0);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnTrigger);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DIOControlWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DIOControlWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnInput4;
        private System.Windows.Forms.Button btnInput3;
        private System.Windows.Forms.Button btnInput2;
        private System.Windows.Forms.Button btnInput1;
        private System.Windows.Forms.Button btnInput0;
        private System.Windows.Forms.Button btnInput5;
        private System.Windows.Forms.Button btnInput7;
        private System.Windows.Forms.Button btnInput6;
        private System.Windows.Forms.Button btnOutput7;
        private System.Windows.Forms.Button btnOutput6;
        private System.Windows.Forms.Button btnOutput5;
        private System.Windows.Forms.Button btnOutput4;
        private System.Windows.Forms.Button btnOutput3;
        private System.Windows.Forms.Button btnOutput2;
        private System.Windows.Forms.Button btnOutput1;
        private System.Windows.Forms.Button btnOutput0;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Button btnOutput15;
        private System.Windows.Forms.Button btnOutput14;
        private System.Windows.Forms.Button btnOutput13;
        private System.Windows.Forms.Button btnOutput12;
        private System.Windows.Forms.Button btnOutput11;
        private System.Windows.Forms.Button btnOutput10;
        private System.Windows.Forms.Button btnOutput9;
        private System.Windows.Forms.Button btnOutput8;
        private System.Windows.Forms.Button btnInput15;
        private System.Windows.Forms.Button btnInput14;
        private System.Windows.Forms.Button btnInput13;
        private System.Windows.Forms.Button btnInput12;
        private System.Windows.Forms.Button btnInput11;
        private System.Windows.Forms.Button btnInput10;
        private System.Windows.Forms.Button btnInput9;
        private System.Windows.Forms.Button btnInput8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

