namespace InspectionSystemManager
{
    partial class InspectionWindow
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.imageButton2 = new CustomControl.ImageButton();
            this.imageButton1 = new CustomControl.ImageButton();
            this.btnInspection = new CustomControl.ImageButton();
            this.btnLive = new CustomControl.ImageButton();
            this.imageButton3 = new CustomControl.ImageButton();
            this.kpCogDisplayMain = new KPDisplay.KPCogDisplayControl();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.kpCogDisplayMain);
            this.panelMain.Controls.Add(this.panelMenu);
            this.panelMain.Location = new System.Drawing.Point(0, 33);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(624, 590);
            this.panelMain.TabIndex = 2;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.imageButton3);
            this.panelMenu.Controls.Add(this.imageButton2);
            this.panelMenu.Controls.Add(this.imageButton1);
            this.panelMenu.Controls.Add(this.btnInspection);
            this.panelMenu.Controls.Add(this.btnLive);
            this.panelMenu.Location = new System.Drawing.Point(3, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(616, 38);
            this.panelMenu.TabIndex = 0;
            // 
            // imageButton2
            // 
            this.imageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton2.BackgroundImage = global::InspectionSystemManager.Properties.Resources.Recipe;
            this.imageButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton2.ForeColor = System.Drawing.Color.White;
            this.imageButton2.Location = new System.Drawing.Point(68, 1);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.Size = new System.Drawing.Size(34, 34);
            this.imageButton2.TabIndex = 10;
            this.imageButton2.UseVisualStyleBackColor = false;
            // 
            // imageButton1
            // 
            this.imageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton1.BackgroundImage = global::InspectionSystemManager.Properties.Resources.OneShot;
            this.imageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton1.ForeColor = System.Drawing.Color.White;
            this.imageButton1.Location = new System.Drawing.Point(35, 1);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.Size = new System.Drawing.Size(34, 34);
            this.imageButton1.TabIndex = 9;
            this.imageButton1.UseVisualStyleBackColor = false;
            // 
            // btnInspection
            // 
            this.btnInspection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnInspection.BackgroundImage = global::InspectionSystemManager.Properties.Resources.Inspection;
            this.btnInspection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInspection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnInspection.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnInspection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnInspection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnInspection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInspection.ForeColor = System.Drawing.Color.White;
            this.btnInspection.Location = new System.Drawing.Point(1, 1);
            this.btnInspection.Name = "btnInspection";
            this.btnInspection.Size = new System.Drawing.Size(34, 34);
            this.btnInspection.TabIndex = 8;
            this.btnInspection.UseVisualStyleBackColor = false;
            // 
            // btnLive
            // 
            this.btnLive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnLive.BackgroundImage = global::InspectionSystemManager.Properties.Resources.Camera;
            this.btnLive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnLive.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnLive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnLive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLive.ForeColor = System.Drawing.Color.White;
            this.btnLive.Location = new System.Drawing.Point(162, 1);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(34, 34);
            this.btnLive.TabIndex = 7;
            this.btnLive.UseVisualStyleBackColor = false;
            // 
            // imageButton3
            // 
            this.imageButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton3.BackgroundImage = global::InspectionSystemManager.Properties.Resources.Save;
            this.imageButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.imageButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton3.ForeColor = System.Drawing.Color.White;
            this.imageButton3.Location = new System.Drawing.Point(102, 1);
            this.imageButton3.Name = "imageButton3";
            this.imageButton3.Size = new System.Drawing.Size(34, 34);
            this.imageButton3.TabIndex = 11;
            this.imageButton3.UseVisualStyleBackColor = false;
            // 
            // kpCogDisplayMain
            // 
            this.kpCogDisplayMain.BackColor = System.Drawing.SystemColors.Control;
            this.kpCogDisplayMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpCogDisplayMain.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kpCogDisplayMain.Location = new System.Drawing.Point(3, 47);
            this.kpCogDisplayMain.Name = "kpCogDisplayMain";
            this.kpCogDisplayMain.Size = new System.Drawing.Size(621, 540);
            this.kpCogDisplayMain.TabIndex = 1;
            this.kpCogDisplayMain.UseStatusBar = true;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(624, 30);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = " Inspection window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitle_Paint);
            this.labelTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDoubleClick);
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // InspectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(624, 623);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InspectionWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InspectionWindow_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InspectionWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InspectionWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InspectionWindow_MouseUp);
            this.Resize += new System.EventHandler(this.InspectionWindow_Resize);
            this.panelMain.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMenu;
        private KPDisplay.KPCogDisplayControl kpCogDisplayMain;
        private CustomControl.ImageButton btnInspection;
        private CustomControl.ImageButton btnLive;
        private CustomControl.ImageButton imageButton2;
        private CustomControl.ImageButton imageButton1;
        private CustomControl.ImageButton imageButton3;
        private System.Windows.Forms.Label labelTitle;
    }
}