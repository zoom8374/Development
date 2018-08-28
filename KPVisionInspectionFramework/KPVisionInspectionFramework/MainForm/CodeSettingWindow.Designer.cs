namespace KPVisionInspectionFramework
{
    partial class CodeSettingWindow
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
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(306, 30);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "  Code Setting Window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitle_Paint);
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.textBoxBarcode);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Location = new System.Drawing.Point(0, 33);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(297, 40);
            this.panelMain.TabIndex = 11;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Font = new System.Drawing.Font("나눔바른고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxBarcode.Location = new System.Drawing.Point(95, 7);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(193, 26);
            this.textBoxBarcode.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 34;
            this.label1.Text = "Barcode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Font = new System.Drawing.Font("나눔바른고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(270, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 28);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CodeSettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(300, 75);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "CodeSettingWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeSettingWindow_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CodeSettingWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CodeSettingWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CodeSettingWindow_MouseUp);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBarcode;
    }
}