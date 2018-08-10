namespace KPVisionInspectionFramework
{
    partial class RecipeNewNameWindow
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
            this.btnRecipeCancel = new System.Windows.Forms.Button();
            this.btnRecipeConfirm = new System.Windows.Forms.Button();
            this.textBoxCurrentRecipe = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxNewRecipe = new System.Windows.Forms.TextBox();
            this.labelTrainImage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRecipeCancel
            // 
            this.btnRecipeCancel.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecipeCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeCancel.Location = new System.Drawing.Point(254, 108);
            this.btnRecipeCancel.Name = "btnRecipeCancel";
            this.btnRecipeCancel.Size = new System.Drawing.Size(129, 33);
            this.btnRecipeCancel.TabIndex = 22;
            this.btnRecipeCancel.Text = "Cancel";
            this.btnRecipeCancel.UseVisualStyleBackColor = true;
            this.btnRecipeCancel.Click += new System.EventHandler(this.btnRecipeCancel_Click);
            // 
            // btnRecipeConfirm
            // 
            this.btnRecipeConfirm.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecipeConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeConfirm.Location = new System.Drawing.Point(118, 108);
            this.btnRecipeConfirm.Name = "btnRecipeConfirm";
            this.btnRecipeConfirm.Size = new System.Drawing.Size(129, 33);
            this.btnRecipeConfirm.TabIndex = 23;
            this.btnRecipeConfirm.Text = "Confirm";
            this.btnRecipeConfirm.UseVisualStyleBackColor = true;
            this.btnRecipeConfirm.Click += new System.EventHandler(this.btnRecipeConfirm_Click);
            // 
            // textBoxCurrentRecipe
            // 
            this.textBoxCurrentRecipe.Enabled = false;
            this.textBoxCurrentRecipe.Font = new System.Drawing.Font("나눔바른고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxCurrentRecipe.Location = new System.Drawing.Point(119, 37);
            this.textBoxCurrentRecipe.Name = "textBoxCurrentRecipe";
            this.textBoxCurrentRecipe.Size = new System.Drawing.Size(264, 26);
            this.textBoxCurrentRecipe.TabIndex = 21;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(390, 30);
            this.labelTitle.TabIndex = 20;
            this.labelTitle.Text = " New Name";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // textBoxNewRecipe
            // 
            this.textBoxNewRecipe.Font = new System.Drawing.Font("나눔바른고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxNewRecipe.Location = new System.Drawing.Point(119, 69);
            this.textBoxNewRecipe.Name = "textBoxNewRecipe";
            this.textBoxNewRecipe.Size = new System.Drawing.Size(264, 26);
            this.textBoxNewRecipe.TabIndex = 21;
            // 
            // labelTrainImage
            // 
            this.labelTrainImage.BackColor = System.Drawing.Color.Black;
            this.labelTrainImage.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTrainImage.ForeColor = System.Drawing.Color.White;
            this.labelTrainImage.Location = new System.Drawing.Point(6, 37);
            this.labelTrainImage.Name = "labelTrainImage";
            this.labelTrainImage.Size = new System.Drawing.Size(107, 26);
            this.labelTrainImage.TabIndex = 24;
            this.labelTrainImage.Text = "Selected Recipe";
            this.labelTrainImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "New Recipe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecipeNewNameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(390, 151);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTrainImage);
            this.Controls.Add(this.btnRecipeCancel);
            this.Controls.Add(this.btnRecipeConfirm);
            this.Controls.Add(this.textBoxNewRecipe);
            this.Controls.Add(this.textBoxCurrentRecipe);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipeNewNameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecipeNewName";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecipeCancel;
        private System.Windows.Forms.Button btnRecipeConfirm;
        private System.Windows.Forms.TextBox textBoxCurrentRecipe;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxNewRecipe;
        private System.Windows.Forms.Label labelTrainImage;
        private System.Windows.Forms.Label label1;
    }
}