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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnResultTest = new System.Windows.Forms.Button();
            this.QuickGridViewLeadResult = new CustomControl.QuickDataGridView();
            this.gradientLabel7 = new CustomControl.GradientLabel();
            this.SevenSegArr = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.gradientLabelDataMatrix = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignY2 = new CustomControl.GradientLabel();
            this.gradientLabel5 = new CustomControl.GradientLabel();
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
            this.button1 = new System.Windows.Forms.Button();
            this.gridLeadNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadBent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadPitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuickGridViewLeadResult)).BeginInit();
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
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.btnResultTest);
            this.panelMain.Controls.Add(this.QuickGridViewLeadResult);
            this.panelMain.Controls.Add(this.gradientLabel7);
            this.panelMain.Controls.Add(this.SevenSegArr);
            this.panelMain.Controls.Add(this.gradientLabel4);
            this.panelMain.Controls.Add(this.gradientLabelDataMatrix);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignY2);
            this.panelMain.Controls.Add(this.gradientLabel5);
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
            this.panelMain.Size = new System.Drawing.Size(421, 917);
            this.panelMain.TabIndex = 11;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            // 
            // btnResultTest
            // 
            this.btnResultTest.Location = new System.Drawing.Point(0, 892);
            this.btnResultTest.Name = "btnResultTest";
            this.btnResultTest.Size = new System.Drawing.Size(121, 43);
            this.btnResultTest.TabIndex = 33;
            this.btnResultTest.Text = "Test";
            this.btnResultTest.UseVisualStyleBackColor = true;
            this.btnResultTest.Click += new System.EventHandler(this.btnResultTest_Click);
            // 
            // QuickGridViewLeadResult
            // 
            this.QuickGridViewLeadResult.AllowUserToAddRows = false;
            this.QuickGridViewLeadResult.AllowUserToDeleteRows = false;
            this.QuickGridViewLeadResult.AllowUserToResizeColumns = false;
            this.QuickGridViewLeadResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.QuickGridViewLeadResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.QuickGridViewLeadResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewLeadResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.QuickGridViewLeadResult.ColumnHeadersHeight = 22;
            this.QuickGridViewLeadResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridLeadNum,
            this.gridLeadBent,
            this.gridLeadWidth,
            this.gridLeadLength,
            this.gridLeadPitch});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle17.NullValue = "0";
            dataGridViewCellStyle17.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.QuickGridViewLeadResult.DefaultCellStyle = dataGridViewCellStyle17;
            this.QuickGridViewLeadResult.EnableHeadersVisualStyles = false;
            this.QuickGridViewLeadResult.Location = new System.Drawing.Point(1, 263);
            this.QuickGridViewLeadResult.MultiSelect = false;
            this.QuickGridViewLeadResult.Name = "QuickGridViewLeadResult";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewLeadResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.QuickGridViewLeadResult.RowHeadersVisible = false;
            this.QuickGridViewLeadResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuickGridViewLeadResult.Size = new System.Drawing.Size(418, 511);
            this.QuickGridViewLeadResult.TabIndex = 32;
            // 
            // gradientLabel7
            // 
            this.gradientLabel7.BackColor = System.Drawing.Color.White;
            this.gradientLabel7.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel7.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel7.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel7.ForeColor = System.Drawing.Color.White;
            this.gradientLabel7.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel7.Location = new System.Drawing.Point(1, 855);
            this.gradientLabel7.Name = "gradientLabel7";
            this.gradientLabel7.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel7.TabIndex = 31;
            this.gradientLabel7.Text = "Data";
            this.gradientLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenSegArr
            // 
            this.SevenSegArr.ArrayCount = 10;
            this.SevenSegArr.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegArr.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegArr.ColorLight = System.Drawing.Color.Lime;
            this.SevenSegArr.DecimalShow = true;
            this.SevenSegArr.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegArr.ElementWidth = 10;
            this.SevenSegArr.ItalicFactor = -0.04F;
            this.SevenSegArr.Location = new System.Drawing.Point(122, 855);
            this.SevenSegArr.Name = "SevenSegArr";
            this.SevenSegArr.Size = new System.Drawing.Size(296, 35);
            this.SevenSegArr.TabIndex = 30;
            this.SevenSegArr.TabStop = false;
            this.SevenSegArr.Value = "0000000000";
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.BackColor = System.Drawing.Color.White;
            this.gradientLabel4.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel4.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel4.ForeColor = System.Drawing.Color.White;
            this.gradientLabel4.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel4.Location = new System.Drawing.Point(1, 786);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(418, 30);
            this.gradientLabel4.TabIndex = 29;
            this.gradientLabel4.Text = " Data Matrix Data";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabelDataMatrix
            // 
            this.gradientLabelDataMatrix.BackColor = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.ColorTop = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelDataMatrix.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelDataMatrix.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelDataMatrix.Location = new System.Drawing.Point(122, 819);
            this.gradientLabelDataMatrix.Name = "gradientLabelDataMatrix";
            this.gradientLabelDataMatrix.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelDataMatrix.TabIndex = 27;
            this.gradientLabelDataMatrix.Text = "-----";
            this.gradientLabelDataMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNeedleAlignY2
            // 
            this.gradientLabelNeedleAlignY2.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignY2.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignY2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignY2.Location = new System.Drawing.Point(122, 183);
            this.gradientLabelNeedleAlignY2.Name = "gradientLabelNeedleAlignY2";
            this.gradientLabelNeedleAlignY2.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignY2.TabIndex = 27;
            this.gradientLabelNeedleAlignY2.Text = "0.0001";
            this.gradientLabelNeedleAlignY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.BackColor = System.Drawing.Color.White;
            this.gradientLabel5.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel5.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel5.ForeColor = System.Drawing.Color.White;
            this.gradientLabel5.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel5.Location = new System.Drawing.Point(1, 819);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel5.TabIndex = 28;
            this.gradientLabel5.Text = "Data";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel8
            // 
            this.gradientLabel8.BackColor = System.Drawing.Color.White;
            this.gradientLabel8.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel8.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel8.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel8.ForeColor = System.Drawing.Color.White;
            this.gradientLabel8.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel8.Location = new System.Drawing.Point(1, 183);
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
            this.gradientLabelNeedleAlignX2.Location = new System.Drawing.Point(122, 148);
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
            this.gradientLabel10.Location = new System.Drawing.Point(1, 148);
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
            this.gradientLabel2.Location = new System.Drawing.Point(1, 230);
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
            this.gradientLabel1.Location = new System.Drawing.Point(1, 115);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 892);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 34;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridLeadNum
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadNum.DefaultCellStyle = dataGridViewCellStyle12;
            this.gridLeadNum.HeaderText = "Num";
            this.gridLeadNum.Name = "gridLeadNum";
            this.gridLeadNum.ReadOnly = true;
            this.gridLeadNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadNum.Width = 35;
            // 
            // gridLeadBent
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadBent.DefaultCellStyle = dataGridViewCellStyle13;
            this.gridLeadBent.HeaderText = "Lead Bent";
            this.gridLeadBent.Name = "gridLeadBent";
            this.gridLeadBent.ReadOnly = true;
            this.gridLeadBent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadBent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadBent.Width = 95;
            // 
            // gridLeadWidth
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadWidth.DefaultCellStyle = dataGridViewCellStyle14;
            this.gridLeadWidth.HeaderText = "Lead Width";
            this.gridLeadWidth.Name = "gridLeadWidth";
            this.gridLeadWidth.ReadOnly = true;
            this.gridLeadWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadWidth.Width = 95;
            // 
            // gridLeadLength
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadLength.DefaultCellStyle = dataGridViewCellStyle15;
            this.gridLeadLength.HeaderText = "Lead Length";
            this.gridLeadLength.Name = "gridLeadLength";
            this.gridLeadLength.ReadOnly = true;
            this.gridLeadLength.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadLength.Width = 95;
            // 
            // gridLeadPitch
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadPitch.DefaultCellStyle = dataGridViewCellStyle16;
            this.gridLeadPitch.HeaderText = "Lead Pitch";
            this.gridLeadPitch.Name = "gridLeadPitch";
            this.gridLeadPitch.ReadOnly = true;
            this.gridLeadPitch.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadPitch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadPitch.Width = 95;
            // 
            // MainResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(421, 951);
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
            ((System.ComponentModel.ISupportInitialize)(this.QuickGridViewLeadResult)).EndInit();
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
        private CustomControl.GradientLabel gradientLabel4;
        private CustomControl.GradientLabel gradientLabelDataMatrix;
        private CustomControl.GradientLabel gradientLabel5;
        private CustomControl.GradientLabel gradientLabel7;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegArr;
        private CustomControl.QuickDataGridView QuickGridViewLeadResult;
        private System.Windows.Forms.Button btnResultTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadBent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadPitch;
    }
}