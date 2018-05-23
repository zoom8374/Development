namespace InspectionSystemManager
{
    partial class TeachingWindow
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
            this.kpTeachDisplay = new KPDisplay.KPCogDisplayControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panelTeaching = new CustomControl.PanelDoubleBuffer();
            this.labelTeaching = new System.Windows.Forms.Label();
            this.panelTeaching.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1900, 30);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = " Recipe Teaching window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpTeachDisplay
            // 
            this.kpTeachDisplay.BackColor = System.Drawing.Color.White;
            this.kpTeachDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpTeachDisplay.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kpTeachDisplay.Location = new System.Drawing.Point(1, 31);
            this.kpTeachDisplay.Name = "kpTeachDisplay";
            this.kpTeachDisplay.Size = new System.Drawing.Size(940, 882);
            this.kpTeachDisplay.TabIndex = 9;
            this.kpTeachDisplay.UseStatusBar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(1736, 871);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(154, 35);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.Location = new System.Drawing.Point(1576, 871);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(154, 35);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panelTeaching
            // 
            this.panelTeaching.BackColor = System.Drawing.Color.LightGray;
            this.panelTeaching.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTeaching.Controls.Add(this.labelTeaching);
            this.panelTeaching.Location = new System.Drawing.Point(947, 33);
            this.panelTeaching.Name = "panelTeaching";
            this.panelTeaching.Size = new System.Drawing.Size(953, 832);
            this.panelTeaching.TabIndex = 15;
            // 
            // labelTeaching
            // 
            this.labelTeaching.BackColor = System.Drawing.Color.White;
            this.labelTeaching.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTeaching.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTeaching.ForeColor = System.Drawing.Color.Black;
            this.labelTeaching.Location = new System.Drawing.Point(0, 0);
            this.labelTeaching.Name = "labelTeaching";
            this.labelTeaching.Size = new System.Drawing.Size(951, 30);
            this.labelTeaching.TabIndex = 10;
            this.labelTeaching.Text = " Teaching Window";
            this.labelTeaching.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TeachingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(1900, 918);
            this.ControlBox = false;
            this.Controls.Add(this.panelTeaching);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.kpTeachDisplay);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 149);
            this.Name = "TeachingWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TeachingWindow";
            this.panelTeaching.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private KPDisplay.KPCogDisplayControl kpTeachDisplay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private CustomControl.PanelDoubleBuffer panelTeaching;
        private System.Windows.Forms.Label labelTeaching;
    }
}