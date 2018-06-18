namespace KPVisionInspectionFramework
{
    partial class MainResultWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gradientLabelNeedleAlignY2 = new CustomControl.GradientLabel();
            this.gradientLabel8 = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignX2 = new CustomControl.GradientLabel();
            this.gradientLabel10 = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignY1 = new CustomControl.GradientLabel();
            this.gradientLabel6 = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignX1 = new CustomControl.GradientLabel();
            this.gradientLabel3 = new CustomControl.GradientLabel();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.gradientLabel1 = new CustomControl.GradientLabel();
            this.gradientLabelTeaching = new CustomControl.GradientLabel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(421, 30);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = " Result Window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitle_Paint);
            this.labelTitle.DoubleClick += new System.EventHandler(this.labelTitle_DoubleClick);
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignY2);
            this.panelMain.Controls.Add(this.gradientLabel8);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignX2);
            this.panelMain.Controls.Add(this.gradientLabel10);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignY1);
            this.panelMain.Controls.Add(this.gradientLabel6);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignX1);
            this.panelMain.Controls.Add(this.gradientLabel3);
            this.panelMain.Controls.Add(this.gradientLabel2);
            this.panelMain.Controls.Add(this.gradientLabel1);
            this.panelMain.Controls.Add(this.gradientLabelTeaching);
            this.panelMain.Location = new System.Drawing.Point(0, 33);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(421, 536);
            this.panelMain.TabIndex = 11;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            // 
            // gradientLabelNeedleAlignY2
            // 
            this.gradientLabelNeedleAlignY2.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignY2.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignY2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignY2.Location = new System.Drawing.Point(122, 188);
            this.gradientLabelNeedleAlignY2.Name = "gradientLabelNeedleAlignY2";
            this.gradientLabelNeedleAlignY2.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignY2.TabIndex = 27;
            this.gradientLabelNeedleAlignY2.Text = "0.0001";
            this.gradientLabelNeedleAlignY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel8
            // 
            this.gradientLabel8.BackColor = System.Drawing.Color.White;
            this.gradientLabel8.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel8.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel8.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel8.ForeColor = System.Drawing.Color.White;
            this.gradientLabel8.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel8.Location = new System.Drawing.Point(1, 188);
            this.gradientLabel8.Name = "gradientLabel8";
            this.gradientLabel8.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel8.TabIndex = 28;
            this.gradientLabel8.Text = "Align Data Y";
            this.gradientLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNeedleAlignX2
            // 
            this.gradientLabelNeedleAlignX2.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignX2.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignX2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignX2.Location = new System.Drawing.Point(122, 153);
            this.gradientLabelNeedleAlignX2.Name = "gradientLabelNeedleAlignX2";
            this.gradientLabelNeedleAlignX2.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignX2.TabIndex = 25;
            this.gradientLabelNeedleAlignX2.Text = "0.0001";
            this.gradientLabelNeedleAlignX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel10
            // 
            this.gradientLabel10.BackColor = System.Drawing.Color.White;
            this.gradientLabel10.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel10.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel10.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel10.ForeColor = System.Drawing.Color.White;
            this.gradientLabel10.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel10.Location = new System.Drawing.Point(1, 153);
            this.gradientLabel10.Name = "gradientLabel10";
            this.gradientLabel10.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel10.TabIndex = 26;
            this.gradientLabel10.Text = "Align Data X";
            this.gradientLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNeedleAlignY1
            // 
            this.gradientLabelNeedleAlignY1.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignY1.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignY1.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignY1.Location = new System.Drawing.Point(122, 68);
            this.gradientLabelNeedleAlignY1.Name = "gradientLabelNeedleAlignY1";
            this.gradientLabelNeedleAlignY1.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignY1.TabIndex = 23;
            this.gradientLabelNeedleAlignY1.Text = "0.0001";
            this.gradientLabelNeedleAlignY1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel6
            // 
            this.gradientLabel6.BackColor = System.Drawing.Color.White;
            this.gradientLabel6.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel6.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel6.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel6.ForeColor = System.Drawing.Color.White;
            this.gradientLabel6.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel6.Location = new System.Drawing.Point(1, 68);
            this.gradientLabel6.Name = "gradientLabel6";
            this.gradientLabel6.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel6.TabIndex = 24;
            this.gradientLabel6.Text = "Align Data Y";
            this.gradientLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNeedleAlignX1
            // 
            this.gradientLabelNeedleAlignX1.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX1.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignX1.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignX1.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignX1.Location = new System.Drawing.Point(122, 33);
            this.gradientLabelNeedleAlignX1.Name = "gradientLabelNeedleAlignX1";
            this.gradientLabelNeedleAlignX1.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignX1.TabIndex = 22;
            this.gradientLabelNeedleAlignX1.Text = "0.0001";
            this.gradientLabelNeedleAlignX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.BackColor = System.Drawing.Color.White;
            this.gradientLabel3.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel3.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel3.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel3.ForeColor = System.Drawing.Color.White;
            this.gradientLabel3.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel3.Location = new System.Drawing.Point(1, 33);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel3.TabIndex = 22;
            this.gradientLabel3.Text = "Align Data X";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.BackColor = System.Drawing.Color.White;
            this.gradientLabel2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel2.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel2.ForeColor = System.Drawing.Color.White;
            this.gradientLabel2.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel2.Location = new System.Drawing.Point(1, 240);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(418, 30);
            this.gradientLabel2.TabIndex = 21;
            this.gradientLabel2.Text = " Lead Inspection Result";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.BackColor = System.Drawing.Color.White;
            this.gradientLabel1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel1.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel1.ForeColor = System.Drawing.Color.White;
            this.gradientLabel1.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel1.Location = new System.Drawing.Point(0, 120);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(418, 30);
            this.gradientLabel1.TabIndex = 20;
            this.gradientLabel1.Text = " Needle Align2 Result";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabelTeaching
            // 
            this.gradientLabelTeaching.BackColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelTeaching.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabelTeaching.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelTeaching.ForeColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabelTeaching.Location = new System.Drawing.Point(1, 0);
            this.gradientLabelTeaching.Name = "gradientLabelTeaching";
            this.gradientLabelTeaching.Size = new System.Drawing.Size(418, 30);
            this.gradientLabelTeaching.TabIndex = 20;
            this.gradientLabelTeaching.Text = " Needle Align1 Result";
            this.gradientLabelTeaching.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(421, 571);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainResultWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainResultWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainResultWindow_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainResultWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainResultWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainResultWindow_MouseUp);
            this.Resize += new System.EventHandler(this.MainResultWindow_Resize);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private CustomControl.GradientLabel gradientLabel2;
        private CustomControl.GradientLabel gradientLabel1;
        private CustomControl.GradientLabel gradientLabelTeaching;
        private CustomControl.GradientLabel gradientLabel3;
        private CustomControl.GradientLabel gradientLabelNeedleAlignY2;
        private CustomControl.GradientLabel gradientLabel8;
        private CustomControl.GradientLabel gradientLabelNeedleAlignX2;
        private CustomControl.GradientLabel gradientLabel10;
        private CustomControl.GradientLabel gradientLabelNeedleAlignY1;
        private CustomControl.GradientLabel gradientLabel6;
        private CustomControl.GradientLabel gradientLabelNeedleAlignX1;
    }
}