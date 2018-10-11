﻿namespace KPVisionInspectionFramework
{
    partial class FolderPathWindow
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
            this.btnRecipeConfirm = new System.Windows.Forms.Button();
            this.textBoxInDataPath = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxOutDataPath = new System.Windows.Forms.TextBox();
            this.labelTrainImage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIndataPath = new System.Windows.Forms.Button();
            this.btnOutdataPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRecipeConfirm
            // 
            this.btnRecipeConfirm.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecipeConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeConfirm.Location = new System.Drawing.Point(503, 114);
            this.btnRecipeConfirm.Name = "btnRecipeConfirm";
            this.btnRecipeConfirm.Size = new System.Drawing.Size(111, 36);
            this.btnRecipeConfirm.TabIndex = 23;
            this.btnRecipeConfirm.Text = "Confirm";
            this.btnRecipeConfirm.UseVisualStyleBackColor = true;
            this.btnRecipeConfirm.Click += new System.EventHandler(this.btnRecipeConfirm_Click);
            // 
            // textBoxInDataPath
            // 
            this.textBoxInDataPath.Enabled = false;
            this.textBoxInDataPath.Font = new System.Drawing.Font("나눔바른고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxInDataPath.Location = new System.Drawing.Point(102, 40);
            this.textBoxInDataPath.Name = "textBoxInDataPath";
            this.textBoxInDataPath.Size = new System.Drawing.Size(484, 26);
            this.textBoxInDataPath.TabIndex = 21;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(620, 33);
            this.labelTitle.TabIndex = 20;
            this.labelTitle.Text = " New Name";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // textBoxOutDataPath
            // 
            this.textBoxOutDataPath.Font = new System.Drawing.Font("나눔바른고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxOutDataPath.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxOutDataPath.Location = new System.Drawing.Point(102, 77);
            this.textBoxOutDataPath.Name = "textBoxOutDataPath";
            this.textBoxOutDataPath.ReadOnly = true;
            this.textBoxOutDataPath.Size = new System.Drawing.Size(484, 26);
            this.textBoxOutDataPath.TabIndex = 21;
            // 
            // labelTrainImage
            // 
            this.labelTrainImage.BackColor = System.Drawing.Color.Black;
            this.labelTrainImage.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTrainImage.ForeColor = System.Drawing.Color.White;
            this.labelTrainImage.Location = new System.Drawing.Point(5, 40);
            this.labelTrainImage.Name = "labelTrainImage";
            this.labelTrainImage.Size = new System.Drawing.Size(92, 28);
            this.labelTrainImage.TabIndex = 24;
            this.labelTrainImage.Text = "In Data";
            this.labelTrainImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 28);
            this.label1.TabIndex = 24;
            this.label1.Text = "Out Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIndataPath
            // 
            this.btnIndataPath.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIndataPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIndataPath.Location = new System.Drawing.Point(587, 40);
            this.btnIndataPath.Name = "btnIndataPath";
            this.btnIndataPath.Size = new System.Drawing.Size(27, 26);
            this.btnIndataPath.TabIndex = 25;
            this.btnIndataPath.Tag = "0";
            this.btnIndataPath.Text = "...";
            this.btnIndataPath.UseVisualStyleBackColor = true;
            this.btnIndataPath.Click += new System.EventHandler(this.btnSearchDataPath_Click);
            // 
            // btnOutdataPath
            // 
            this.btnOutdataPath.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOutdataPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutdataPath.Location = new System.Drawing.Point(587, 77);
            this.btnOutdataPath.Name = "btnOutdataPath";
            this.btnOutdataPath.Size = new System.Drawing.Size(27, 26);
            this.btnOutdataPath.TabIndex = 26;
            this.btnOutdataPath.Tag = "1";
            this.btnOutdataPath.Text = "...";
            this.btnOutdataPath.UseVisualStyleBackColor = true;
            this.btnOutdataPath.Click += new System.EventHandler(this.btnSearchDataPath_Click);
            // 
            // FolderPathWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(620, 156);
            this.Controls.Add(this.btnOutdataPath);
            this.Controls.Add(this.btnIndataPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTrainImage);
            this.Controls.Add(this.btnRecipeConfirm);
            this.Controls.Add(this.textBoxOutDataPath);
            this.Controls.Add(this.textBoxInDataPath);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FolderPathWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecipeNewName";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRecipeConfirm;
        private System.Windows.Forms.TextBox textBoxInDataPath;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxOutDataPath;
        private System.Windows.Forms.Label labelTrainImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIndataPath;
        private System.Windows.Forms.Button btnOutdataPath;
    }
}