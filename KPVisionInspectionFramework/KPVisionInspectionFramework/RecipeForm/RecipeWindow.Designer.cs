namespace KPVisionInspectionFramework
{
    partial class RecipeWindow
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
            this.btnRecipeAdd = new System.Windows.Forms.Button();
            this.btnRecipeDelete = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnRecipeCopy = new System.Windows.Forms.Button();
            this.btnRecipeChange = new System.Windows.Forms.Button();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.textBoxCurrentRecipe = new System.Windows.Forms.TextBox();
            this.gradientLabel1 = new CustomControl.GradientLabel();
            this.listBoxRecipe = new System.Windows.Forms.ListBox();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(640, 30);
            this.labelTitle.TabIndex = 12;
            this.labelTitle.Text = " Recipe Management";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitle_Paint);
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnRecipeAdd);
            this.panelMain.Controls.Add(this.btnRecipeDelete);
            this.panelMain.Controls.Add(this.btnOk);
            this.panelMain.Controls.Add(this.btnRecipeCopy);
            this.panelMain.Controls.Add(this.btnRecipeChange);
            this.panelMain.Controls.Add(this.gradientLabel2);
            this.panelMain.Controls.Add(this.textBoxCurrentRecipe);
            this.panelMain.Controls.Add(this.gradientLabel1);
            this.panelMain.Controls.Add(this.listBoxRecipe);
            this.panelMain.Location = new System.Drawing.Point(0, 33);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(640, 771);
            this.panelMain.TabIndex = 13;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // btnRecipeAdd
            // 
            this.btnRecipeAdd.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecipeAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeAdd.Location = new System.Drawing.Point(132, 714);
            this.btnRecipeAdd.Name = "btnRecipeAdd";
            this.btnRecipeAdd.Size = new System.Drawing.Size(120, 49);
            this.btnRecipeAdd.TabIndex = 305;
            this.btnRecipeAdd.Text = "New";
            this.btnRecipeAdd.UseVisualStyleBackColor = true;
            this.btnRecipeAdd.Click += new System.EventHandler(this.btnRecipeAdd_Click);
            // 
            // btnRecipeDelete
            // 
            this.btnRecipeDelete.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecipeDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeDelete.Location = new System.Drawing.Point(388, 714);
            this.btnRecipeDelete.Name = "btnRecipeDelete";
            this.btnRecipeDelete.Size = new System.Drawing.Size(120, 49);
            this.btnRecipeDelete.TabIndex = 306;
            this.btnRecipeDelete.Text = "Delete";
            this.btnRecipeDelete.UseVisualStyleBackColor = true;
            this.btnRecipeDelete.Click += new System.EventHandler(this.btnRecipeDelete_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(516, 714);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 49);
            this.btnOk.TabIndex = 304;
            this.btnOk.Text = "Confirm";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnRecipeCopy
            // 
            this.btnRecipeCopy.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecipeCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeCopy.Location = new System.Drawing.Point(260, 714);
            this.btnRecipeCopy.Name = "btnRecipeCopy";
            this.btnRecipeCopy.Size = new System.Drawing.Size(120, 49);
            this.btnRecipeCopy.TabIndex = 307;
            this.btnRecipeCopy.Text = "Copy";
            this.btnRecipeCopy.UseVisualStyleBackColor = true;
            this.btnRecipeCopy.Click += new System.EventHandler(this.btnRecipeCopy_Click);
            // 
            // btnRecipeChange
            // 
            this.btnRecipeChange.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecipeChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeChange.Location = new System.Drawing.Point(4, 714);
            this.btnRecipeChange.Name = "btnRecipeChange";
            this.btnRecipeChange.Size = new System.Drawing.Size(120, 49);
            this.btnRecipeChange.TabIndex = 308;
            this.btnRecipeChange.Text = "Change";
            this.btnRecipeChange.UseVisualStyleBackColor = true;
            this.btnRecipeChange.Click += new System.EventHandler(this.btnRecipeChange_Click);
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.gradientLabel2.ColorBottom = System.Drawing.Color.Gray;
            this.gradientLabel2.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gradientLabel2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel2.ForeColor = System.Drawing.Color.White;
            this.gradientLabel2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel2.Location = new System.Drawing.Point(3, 675);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(634, 35);
            this.gradientLabel2.TabIndex = 303;
            this.gradientLabel2.Text = "Recipe Management";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCurrentRecipe
            // 
            this.textBoxCurrentRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCurrentRecipe.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxCurrentRecipe.Location = new System.Drawing.Point(3, 639);
            this.textBoxCurrentRecipe.Multiline = true;
            this.textBoxCurrentRecipe.Name = "textBoxCurrentRecipe";
            this.textBoxCurrentRecipe.ReadOnly = true;
            this.textBoxCurrentRecipe.Size = new System.Drawing.Size(634, 29);
            this.textBoxCurrentRecipe.TabIndex = 302;
            this.textBoxCurrentRecipe.Text = "Recipe Name";
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.gradientLabel1.ColorBottom = System.Drawing.Color.Gray;
            this.gradientLabel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gradientLabel1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel1.ForeColor = System.Drawing.Color.White;
            this.gradientLabel1.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel1.Location = new System.Drawing.Point(3, 601);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(634, 35);
            this.gradientLabel1.TabIndex = 301;
            this.gradientLabel1.Text = "Current Recipe Name";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxRecipe
            // 
            this.listBoxRecipe.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBoxRecipe.FormattingEnabled = true;
            this.listBoxRecipe.ItemHeight = 14;
            this.listBoxRecipe.Items.AddRange(new object[] {
            "Recipe"});
            this.listBoxRecipe.Location = new System.Drawing.Point(1, 1);
            this.listBoxRecipe.Name = "listBoxRecipe";
            this.listBoxRecipe.Size = new System.Drawing.Size(638, 592);
            this.listBoxRecipe.TabIndex = 4;
            // 
            // RecipeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(640, 805);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "RecipeWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecipeWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecipeWindow_KeyDown);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ListBox listBoxRecipe;
        private System.Windows.Forms.Button btnRecipeAdd;
        private System.Windows.Forms.Button btnRecipeDelete;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnRecipeCopy;
        private System.Windows.Forms.Button btnRecipeChange;
        private CustomControl.GradientLabel gradientLabel2;
        private System.Windows.Forms.TextBox textBoxCurrentRecipe;
        private CustomControl.GradientLabel gradientLabel1;
    }
}