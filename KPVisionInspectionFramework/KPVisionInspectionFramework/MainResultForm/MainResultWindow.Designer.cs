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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResultTest = new System.Windows.Forms.Button();
            this.QuickGridViewLeadResult = new CustomControl.QuickDataGridView();
            this.gridLeadNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadBent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadPitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientLabel13 = new CustomControl.GradientLabel();
            this.gradientLabel12 = new CustomControl.GradientLabel();
            this.gradientLabel11 = new CustomControl.GradientLabel();
            this.SevenSegTotal = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel9 = new CustomControl.GradientLabel();
            this.SevenSegYield = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel7 = new CustomControl.GradientLabel();
            this.SevenSegNg = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegGood = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.gradientLabelResult = new CustomControl.GradientLabel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.SevenSegCodeErr = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel14 = new CustomControl.GradientLabel();
            this.SevenSegBlankErr = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel15 = new CustomControl.GradientLabel();
            this.SevenSegMixErr = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel16 = new CustomControl.GradientLabel();
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
            this.panelMain.Controls.Add(this.gradientLabel13);
            this.panelMain.Controls.Add(this.gradientLabel12);
            this.panelMain.Controls.Add(this.gradientLabel16);
            this.panelMain.Controls.Add(this.gradientLabel15);
            this.panelMain.Controls.Add(this.gradientLabel14);
            this.panelMain.Controls.Add(this.gradientLabel11);
            this.panelMain.Controls.Add(this.SevenSegTotal);
            this.panelMain.Controls.Add(this.SevenSegMixErr);
            this.panelMain.Controls.Add(this.gradientLabel9);
            this.panelMain.Controls.Add(this.SevenSegBlankErr);
            this.panelMain.Controls.Add(this.SevenSegYield);
            this.panelMain.Controls.Add(this.SevenSegCodeErr);
            this.panelMain.Controls.Add(this.gradientLabel7);
            this.panelMain.Controls.Add(this.SevenSegNg);
            this.panelMain.Controls.Add(this.SevenSegGood);
            this.panelMain.Controls.Add(this.gradientLabel4);
            this.panelMain.Controls.Add(this.gradientLabelResult);
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
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Location = new System.Drawing.Point(0, 33);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(421, 917);
            this.panelMain.TabIndex = 11;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 858);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 34;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnResultTest
            // 
            this.btnResultTest.Location = new System.Drawing.Point(3, 858);
            this.btnResultTest.Name = "btnResultTest";
            this.btnResultTest.Size = new System.Drawing.Size(121, 43);
            this.btnResultTest.TabIndex = 33;
            this.btnResultTest.Text = "Test";
            this.btnResultTest.UseVisualStyleBackColor = true;
            this.btnResultTest.Visible = false;
            this.btnResultTest.Click += new System.EventHandler(this.btnResultTest_Click);
            // 
            // QuickGridViewLeadResult
            // 
            this.QuickGridViewLeadResult.AllowUserToAddRows = false;
            this.QuickGridViewLeadResult.AllowUserToDeleteRows = false;
            this.QuickGridViewLeadResult.AllowUserToResizeColumns = false;
            this.QuickGridViewLeadResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.QuickGridViewLeadResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.QuickGridViewLeadResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewLeadResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.QuickGridViewLeadResult.ColumnHeadersHeight = 22;
            this.QuickGridViewLeadResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridLeadNum,
            this.gridLeadBent,
            this.gridLeadWidth,
            this.gridLeadLength,
            this.gridLeadPitch});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.QuickGridViewLeadResult.DefaultCellStyle = dataGridViewCellStyle8;
            this.QuickGridViewLeadResult.EnableHeadersVisualStyles = false;
            this.QuickGridViewLeadResult.Location = new System.Drawing.Point(1, 778);
            this.QuickGridViewLeadResult.MultiSelect = false;
            this.QuickGridViewLeadResult.Name = "QuickGridViewLeadResult";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewLeadResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.QuickGridViewLeadResult.RowHeadersVisible = false;
            this.QuickGridViewLeadResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuickGridViewLeadResult.Size = new System.Drawing.Size(418, 74);
            this.QuickGridViewLeadResult.TabIndex = 32;
            this.QuickGridViewLeadResult.Tag = "Size : 418, 511";
            this.QuickGridViewLeadResult.Visible = false;
            // 
            // gridLeadNum
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadNum.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridLeadNum.HeaderText = "Num";
            this.gridLeadNum.Name = "gridLeadNum";
            this.gridLeadNum.ReadOnly = true;
            this.gridLeadNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadNum.Width = 35;
            // 
            // gridLeadBent
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadBent.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridLeadBent.HeaderText = "Lead Bent";
            this.gridLeadBent.Name = "gridLeadBent";
            this.gridLeadBent.ReadOnly = true;
            this.gridLeadBent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadBent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadBent.Width = 95;
            // 
            // gridLeadWidth
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadWidth.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridLeadWidth.HeaderText = "Lead Width";
            this.gridLeadWidth.Name = "gridLeadWidth";
            this.gridLeadWidth.ReadOnly = true;
            this.gridLeadWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadWidth.Width = 95;
            // 
            // gridLeadLength
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadLength.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridLeadLength.HeaderText = "Lead Length";
            this.gridLeadLength.Name = "gridLeadLength";
            this.gridLeadLength.ReadOnly = true;
            this.gridLeadLength.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadLength.Width = 95;
            // 
            // gridLeadPitch
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadPitch.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridLeadPitch.HeaderText = "Lead Pitch";
            this.gridLeadPitch.Name = "gridLeadPitch";
            this.gridLeadPitch.ReadOnly = true;
            this.gridLeadPitch.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadPitch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadPitch.Width = 95;
            // 
            // gradientLabel13
            // 
            this.gradientLabel13.BackColor = System.Drawing.Color.White;
            this.gradientLabel13.ColorBottom = System.Drawing.Color.LightGray;
            this.gradientLabel13.ColorTop = System.Drawing.Color.DimGray;
            this.gradientLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel13.ForeColor = System.Drawing.Color.White;
            this.gradientLabel13.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel13.Location = new System.Drawing.Point(1, 166);
            this.gradientLabel13.Name = "gradientLabel13";
            this.gradientLabel13.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel13.TabIndex = 31;
            this.gradientLabel13.Text = "Total";
            this.gradientLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel12
            // 
            this.gradientLabel12.BackColor = System.Drawing.Color.White;
            this.gradientLabel12.ColorBottom = System.Drawing.Color.LemonChiffon;
            this.gradientLabel12.ColorTop = System.Drawing.Color.Gold;
            this.gradientLabel12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel12.ForeColor = System.Drawing.Color.Black;
            this.gradientLabel12.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel12.Location = new System.Drawing.Point(1, 275);
            this.gradientLabel12.Name = "gradientLabel12";
            this.gradientLabel12.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel12.TabIndex = 31;
            this.gradientLabel12.Text = "Yield";
            this.gradientLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel11
            // 
            this.gradientLabel11.BackColor = System.Drawing.Color.White;
            this.gradientLabel11.ColorBottom = System.Drawing.Color.LightCoral;
            this.gradientLabel11.ColorTop = System.Drawing.Color.DarkRed;
            this.gradientLabel11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel11.ForeColor = System.Drawing.Color.White;
            this.gradientLabel11.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel11.Location = new System.Drawing.Point(1, 239);
            this.gradientLabel11.Name = "gradientLabel11";
            this.gradientLabel11.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel11.TabIndex = 31;
            this.gradientLabel11.Text = "NG";
            this.gradientLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenSegTotal
            // 
            this.SevenSegTotal.ArrayCount = 12;
            this.SevenSegTotal.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegTotal.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegTotal.ColorLight = System.Drawing.Color.White;
            this.SevenSegTotal.DecimalShow = true;
            this.SevenSegTotal.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegTotal.ElementWidth = 10;
            this.SevenSegTotal.ItalicFactor = -0.04F;
            this.SevenSegTotal.Location = new System.Drawing.Point(122, 164);
            this.SevenSegTotal.Name = "SevenSegTotal";
            this.SevenSegTotal.Size = new System.Drawing.Size(296, 30);
            this.SevenSegTotal.TabIndex = 30;
            this.SevenSegTotal.TabStop = false;
            this.SevenSegTotal.Value = "000000";
            // 
            // gradientLabel9
            // 
            this.gradientLabel9.BackColor = System.Drawing.Color.White;
            this.gradientLabel9.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel9.ColorTop = System.Drawing.Color.Green;
            this.gradientLabel9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel9.ForeColor = System.Drawing.Color.White;
            this.gradientLabel9.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel9.Location = new System.Drawing.Point(1, 203);
            this.gradientLabel9.Name = "gradientLabel9";
            this.gradientLabel9.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel9.TabIndex = 31;
            this.gradientLabel9.Text = "Good";
            this.gradientLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenSegYield
            // 
            this.SevenSegYield.ArrayCount = 11;
            this.SevenSegYield.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegYield.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegYield.ColorLight = System.Drawing.Color.Yellow;
            this.SevenSegYield.DecimalShow = true;
            this.SevenSegYield.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegYield.ElementWidth = 10;
            this.SevenSegYield.ItalicFactor = -0.04F;
            this.SevenSegYield.Location = new System.Drawing.Point(122, 275);
            this.SevenSegYield.Name = "SevenSegYield";
            this.SevenSegYield.Size = new System.Drawing.Size(272, 30);
            this.SevenSegYield.TabIndex = 30;
            this.SevenSegYield.TabStop = false;
            this.SevenSegYield.Value = "00000";
            // 
            // gradientLabel7
            // 
            this.gradientLabel7.BackColor = System.Drawing.Color.White;
            this.gradientLabel7.ColorBottom = System.Drawing.Color.LightBlue;
            this.gradientLabel7.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel7.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel7.ForeColor = System.Drawing.Color.White;
            this.gradientLabel7.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel7.Location = new System.Drawing.Point(1, 34);
            this.gradientLabel7.Name = "gradientLabel7";
            this.gradientLabel7.Size = new System.Drawing.Size(115, 69);
            this.gradientLabel7.TabIndex = 31;
            this.gradientLabel7.Text = "Result";
            this.gradientLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenSegNg
            // 
            this.SevenSegNg.ArrayCount = 12;
            this.SevenSegNg.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegNg.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegNg.ColorLight = System.Drawing.Color.Red;
            this.SevenSegNg.DecimalShow = true;
            this.SevenSegNg.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegNg.ElementWidth = 10;
            this.SevenSegNg.ItalicFactor = -0.04F;
            this.SevenSegNg.Location = new System.Drawing.Point(122, 239);
            this.SevenSegNg.Name = "SevenSegNg";
            this.SevenSegNg.Size = new System.Drawing.Size(296, 30);
            this.SevenSegNg.TabIndex = 30;
            this.SevenSegNg.TabStop = false;
            this.SevenSegNg.Value = "000000";
            // 
            // SevenSegGood
            // 
            this.SevenSegGood.ArrayCount = 12;
            this.SevenSegGood.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegGood.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegGood.ColorLight = System.Drawing.Color.Lime;
            this.SevenSegGood.DecimalShow = true;
            this.SevenSegGood.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegGood.ElementWidth = 10;
            this.SevenSegGood.ItalicFactor = -0.04F;
            this.SevenSegGood.Location = new System.Drawing.Point(122, 203);
            this.SevenSegGood.Name = "SevenSegGood";
            this.SevenSegGood.Size = new System.Drawing.Size(296, 30);
            this.SevenSegGood.TabIndex = 30;
            this.SevenSegGood.TabStop = false;
            this.SevenSegGood.Value = "000000";
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.BackColor = System.Drawing.Color.White;
            this.gradientLabel4.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel4.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel4.ForeColor = System.Drawing.Color.White;
            this.gradientLabel4.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel4.Location = new System.Drawing.Point(1, 0);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(418, 30);
            this.gradientLabel4.TabIndex = 29;
            this.gradientLabel4.Text = " Data Matrix Data";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabelResult
            // 
            this.gradientLabelResult.BackColor = System.Drawing.Color.DarkGreen;
            this.gradientLabelResult.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelResult.ColorTop = System.Drawing.Color.White;
            this.gradientLabelResult.Font = new System.Drawing.Font("HY견고딕", 36F, System.Drawing.FontStyle.Bold);
            this.gradientLabelResult.ForeColor = System.Drawing.Color.Lime;
            this.gradientLabelResult.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelResult.Location = new System.Drawing.Point(122, 34);
            this.gradientLabelResult.Name = "gradientLabelResult";
            this.gradientLabelResult.Size = new System.Drawing.Size(296, 69);
            this.gradientLabelResult.TabIndex = 27;
            this.gradientLabelResult.Text = "GOOD";
            this.gradientLabelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelDataMatrix
            // 
            this.gradientLabelDataMatrix.BackColor = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.ColorTop = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.Font = new System.Drawing.Font("HY견고딕", 20F);
            this.gradientLabelDataMatrix.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelDataMatrix.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelDataMatrix.Location = new System.Drawing.Point(122, 110);
            this.gradientLabelDataMatrix.Name = "gradientLabelDataMatrix";
            this.gradientLabelDataMatrix.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelDataMatrix.TabIndex = 27;
            this.gradientLabelDataMatrix.Text = "BARCODE";
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
            this.gradientLabelNeedleAlignY2.Location = new System.Drawing.Point(122, 698);
            this.gradientLabelNeedleAlignY2.Name = "gradientLabelNeedleAlignY2";
            this.gradientLabelNeedleAlignY2.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignY2.TabIndex = 27;
            this.gradientLabelNeedleAlignY2.Text = "0.0001";
            this.gradientLabelNeedleAlignY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabelNeedleAlignY2.Visible = false;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.BackColor = System.Drawing.Color.White;
            this.gradientLabel5.ColorBottom = System.Drawing.Color.LightBlue;
            this.gradientLabel5.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel5.ForeColor = System.Drawing.Color.White;
            this.gradientLabel5.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel5.Location = new System.Drawing.Point(1, 110);
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
            this.gradientLabel8.Location = new System.Drawing.Point(1, 698);
            this.gradientLabel8.Name = "gradientLabel8";
            this.gradientLabel8.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel8.TabIndex = 28;
            this.gradientLabel8.Text = "Align Data Y";
            this.gradientLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabel8.Visible = false;
            // 
            // gradientLabelNeedleAlignX2
            // 
            this.gradientLabelNeedleAlignX2.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignX2.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignX2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignX2.Location = new System.Drawing.Point(122, 663);
            this.gradientLabelNeedleAlignX2.Name = "gradientLabelNeedleAlignX2";
            this.gradientLabelNeedleAlignX2.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignX2.TabIndex = 25;
            this.gradientLabelNeedleAlignX2.Text = "0.0001";
            this.gradientLabelNeedleAlignX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabelNeedleAlignX2.Visible = false;
            // 
            // gradientLabel10
            // 
            this.gradientLabel10.BackColor = System.Drawing.Color.White;
            this.gradientLabel10.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel10.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel10.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel10.ForeColor = System.Drawing.Color.White;
            this.gradientLabel10.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel10.Location = new System.Drawing.Point(1, 663);
            this.gradientLabel10.Name = "gradientLabel10";
            this.gradientLabel10.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel10.TabIndex = 26;
            this.gradientLabel10.Text = "Align Data X";
            this.gradientLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabel10.Visible = false;
            // 
            // gradientLabelNeedleAlignY1
            // 
            this.gradientLabelNeedleAlignY1.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignY1.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignY1.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignY1.Location = new System.Drawing.Point(122, 583);
            this.gradientLabelNeedleAlignY1.Name = "gradientLabelNeedleAlignY1";
            this.gradientLabelNeedleAlignY1.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignY1.TabIndex = 23;
            this.gradientLabelNeedleAlignY1.Text = "0.0001";
            this.gradientLabelNeedleAlignY1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabelNeedleAlignY1.Visible = false;
            // 
            // gradientLabel6
            // 
            this.gradientLabel6.BackColor = System.Drawing.Color.White;
            this.gradientLabel6.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel6.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel6.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel6.ForeColor = System.Drawing.Color.White;
            this.gradientLabel6.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel6.Location = new System.Drawing.Point(1, 583);
            this.gradientLabel6.Name = "gradientLabel6";
            this.gradientLabel6.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel6.TabIndex = 24;
            this.gradientLabel6.Text = "Align Data Y";
            this.gradientLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabel6.Visible = false;
            // 
            // gradientLabelNeedleAlignX1
            // 
            this.gradientLabelNeedleAlignX1.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX1.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignX1.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignX1.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignX1.Location = new System.Drawing.Point(122, 548);
            this.gradientLabelNeedleAlignX1.Name = "gradientLabelNeedleAlignX1";
            this.gradientLabelNeedleAlignX1.Size = new System.Drawing.Size(296, 30);
            this.gradientLabelNeedleAlignX1.TabIndex = 22;
            this.gradientLabelNeedleAlignX1.Text = "0.0001";
            this.gradientLabelNeedleAlignX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabelNeedleAlignX1.Visible = false;
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.BackColor = System.Drawing.Color.White;
            this.gradientLabel3.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel3.ColorTop = System.Drawing.Color.DarkGreen;
            this.gradientLabel3.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel3.ForeColor = System.Drawing.Color.White;
            this.gradientLabel3.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel3.Location = new System.Drawing.Point(1, 548);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel3.TabIndex = 22;
            this.gradientLabel3.Text = "Align Data X";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabel3.Visible = false;
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.BackColor = System.Drawing.Color.White;
            this.gradientLabel2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel2.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel2.ForeColor = System.Drawing.Color.White;
            this.gradientLabel2.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel2.Location = new System.Drawing.Point(1, 745);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(418, 30);
            this.gradientLabel2.TabIndex = 21;
            this.gradientLabel2.Text = " Lead Inspection Result";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gradientLabel2.Visible = false;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.BackColor = System.Drawing.Color.White;
            this.gradientLabel1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel1.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel1.ForeColor = System.Drawing.Color.White;
            this.gradientLabel1.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel1.Location = new System.Drawing.Point(1, 630);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(418, 30);
            this.gradientLabel1.TabIndex = 20;
            this.gradientLabel1.Text = " Needle Align2 Result";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gradientLabel1.Visible = false;
            // 
            // gradientLabelTeaching
            // 
            this.gradientLabelTeaching.BackColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelTeaching.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabelTeaching.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelTeaching.ForeColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabelTeaching.Location = new System.Drawing.Point(1, 515);
            this.gradientLabelTeaching.Name = "gradientLabelTeaching";
            this.gradientLabelTeaching.Size = new System.Drawing.Size(418, 30);
            this.gradientLabelTeaching.TabIndex = 20;
            this.gradientLabelTeaching.Text = " Needle Align1 Result";
            this.gradientLabelTeaching.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gradientLabelTeaching.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(392, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 27);
            this.label1.TabIndex = 35;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SevenSegCodeErr
            // 
            this.SevenSegCodeErr.ArrayCount = 12;
            this.SevenSegCodeErr.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegCodeErr.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegCodeErr.ColorLight = System.Drawing.Color.Cyan;
            this.SevenSegCodeErr.DecimalShow = true;
            this.SevenSegCodeErr.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegCodeErr.ElementWidth = 10;
            this.SevenSegCodeErr.ItalicFactor = -0.04F;
            this.SevenSegCodeErr.Location = new System.Drawing.Point(122, 345);
            this.SevenSegCodeErr.Name = "SevenSegCodeErr";
            this.SevenSegCodeErr.Size = new System.Drawing.Size(296, 30);
            this.SevenSegCodeErr.TabIndex = 30;
            this.SevenSegCodeErr.TabStop = false;
            this.SevenSegCodeErr.Value = "000000";
            // 
            // gradientLabel14
            // 
            this.gradientLabel14.BackColor = System.Drawing.Color.White;
            this.gradientLabel14.ColorBottom = System.Drawing.Color.LightSeaGreen;
            this.gradientLabel14.ColorTop = System.Drawing.Color.DarkCyan;
            this.gradientLabel14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel14.ForeColor = System.Drawing.Color.White;
            this.gradientLabel14.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel14.Location = new System.Drawing.Point(1, 345);
            this.gradientLabel14.Name = "gradientLabel14";
            this.gradientLabel14.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel14.TabIndex = 31;
            this.gradientLabel14.Text = "      Code Err";
            this.gradientLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SevenSegBlankErr
            // 
            this.SevenSegBlankErr.ArrayCount = 12;
            this.SevenSegBlankErr.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegBlankErr.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegBlankErr.ColorLight = System.Drawing.Color.Cyan;
            this.SevenSegBlankErr.DecimalShow = true;
            this.SevenSegBlankErr.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegBlankErr.ElementWidth = 10;
            this.SevenSegBlankErr.ItalicFactor = -0.04F;
            this.SevenSegBlankErr.Location = new System.Drawing.Point(122, 381);
            this.SevenSegBlankErr.Name = "SevenSegBlankErr";
            this.SevenSegBlankErr.Size = new System.Drawing.Size(296, 30);
            this.SevenSegBlankErr.TabIndex = 30;
            this.SevenSegBlankErr.TabStop = false;
            this.SevenSegBlankErr.Value = "000000";
            // 
            // gradientLabel15
            // 
            this.gradientLabel15.BackColor = System.Drawing.Color.White;
            this.gradientLabel15.ColorBottom = System.Drawing.Color.LightSeaGreen;
            this.gradientLabel15.ColorTop = System.Drawing.Color.DarkCyan;
            this.gradientLabel15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel15.ForeColor = System.Drawing.Color.White;
            this.gradientLabel15.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel15.Location = new System.Drawing.Point(1, 381);
            this.gradientLabel15.Name = "gradientLabel15";
            this.gradientLabel15.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel15.TabIndex = 31;
            this.gradientLabel15.Text = "      Blank Err";
            this.gradientLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SevenSegMixErr
            // 
            this.SevenSegMixErr.ArrayCount = 12;
            this.SevenSegMixErr.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegMixErr.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegMixErr.ColorLight = System.Drawing.Color.Cyan;
            this.SevenSegMixErr.DecimalShow = true;
            this.SevenSegMixErr.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegMixErr.ElementWidth = 10;
            this.SevenSegMixErr.ItalicFactor = -0.04F;
            this.SevenSegMixErr.Location = new System.Drawing.Point(122, 417);
            this.SevenSegMixErr.Name = "SevenSegMixErr";
            this.SevenSegMixErr.Size = new System.Drawing.Size(296, 30);
            this.SevenSegMixErr.TabIndex = 30;
            this.SevenSegMixErr.TabStop = false;
            this.SevenSegMixErr.Value = "000000";
            // 
            // gradientLabel16
            // 
            this.gradientLabel16.BackColor = System.Drawing.Color.White;
            this.gradientLabel16.ColorBottom = System.Drawing.Color.LightSeaGreen;
            this.gradientLabel16.ColorTop = System.Drawing.Color.DarkCyan;
            this.gradientLabel16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel16.ForeColor = System.Drawing.Color.White;
            this.gradientLabel16.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel16.Location = new System.Drawing.Point(1, 417);
            this.gradientLabel16.Name = "gradientLabel16";
            this.gradientLabel16.Size = new System.Drawing.Size(115, 30);
            this.gradientLabel16.TabIndex = 31;
            this.gradientLabel16.Text = "      Mix Err";
            this.gradientLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
        private CustomControl.QuickDataGridView QuickGridViewLeadResult;
        private System.Windows.Forms.Button btnResultTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadBent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadPitch;
        private CustomControl.GradientLabel gradientLabel12;
        private CustomControl.GradientLabel gradientLabel11;
        private CustomControl.GradientLabel gradientLabel9;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegYield;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegNg;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegGood;
        private System.Windows.Forms.Label label1;
        private CustomControl.GradientLabel gradientLabel13;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegTotal;
        private CustomControl.GradientLabel gradientLabelResult;
        private CustomControl.GradientLabel gradientLabel16;
        private CustomControl.GradientLabel gradientLabel15;
        private CustomControl.GradientLabel gradientLabel14;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegMixErr;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegBlankErr;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegCodeErr;
    }
}