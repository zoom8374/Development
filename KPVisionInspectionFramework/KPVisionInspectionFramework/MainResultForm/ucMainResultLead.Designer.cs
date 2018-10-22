namespace KPVisionInspectionFramework
{
    partial class ucMainResultLead
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.gradientLabelTotalCount = new CustomControl.GradientLabel();
            this.gradientLabelYield = new CustomControl.GradientLabel();
            this.gradientLabelNgCount = new CustomControl.GradientLabel();
            this.SevenSegTotal = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabelGoodCount = new CustomControl.GradientLabel();
            this.SevenSegYield = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegNg = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegGood = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.label1 = new System.Windows.Forms.Label();
            this.QuickGridViewLeadResult = new CustomControl.QuickDataGridView();
            this.gridLeadNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadBent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeadPitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResultTest = new System.Windows.Forms.Button();
            this.gradientLabel7 = new CustomControl.GradientLabel();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.gradientLabelResult = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignY2 = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignX2 = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignY1 = new CustomControl.GradientLabel();
            this.gradientLabel6 = new CustomControl.GradientLabel();
            this.gradientLabelNeedleAlignX1 = new CustomControl.GradientLabel();
            this.gradientLabel3 = new CustomControl.GradientLabel();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.gradientLabel5 = new CustomControl.GradientLabel();
            this.gradientLabelTeaching = new CustomControl.GradientLabel();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuickGridViewLeadResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.gradientLabelTotalCount);
            this.panelMain.Controls.Add(this.gradientLabelYield);
            this.panelMain.Controls.Add(this.gradientLabelNgCount);
            this.panelMain.Controls.Add(this.SevenSegTotal);
            this.panelMain.Controls.Add(this.gradientLabelGoodCount);
            this.panelMain.Controls.Add(this.SevenSegYield);
            this.panelMain.Controls.Add(this.SevenSegNg);
            this.panelMain.Controls.Add(this.SevenSegGood);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.QuickGridViewLeadResult);
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.btnResultTest);
            this.panelMain.Controls.Add(this.gradientLabel7);
            this.panelMain.Controls.Add(this.gradientLabel4);
            this.panelMain.Controls.Add(this.gradientLabelResult);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignY2);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignX2);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignY1);
            this.panelMain.Controls.Add(this.gradientLabel6);
            this.panelMain.Controls.Add(this.gradientLabelNeedleAlignX1);
            this.panelMain.Controls.Add(this.gradientLabel3);
            this.panelMain.Controls.Add(this.gradientLabel2);
            this.panelMain.Controls.Add(this.gradientLabel5);
            this.panelMain.Controls.Add(this.gradientLabelTeaching);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(377, 830);
            this.panelMain.TabIndex = 14;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // gradientLabelTotalCount
            // 
            this.gradientLabelTotalCount.BackColor = System.Drawing.Color.White;
            this.gradientLabelTotalCount.ColorBottom = System.Drawing.Color.LightGray;
            this.gradientLabelTotalCount.ColorTop = System.Drawing.Color.DimGray;
            this.gradientLabelTotalCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gradientLabelTotalCount.ForeColor = System.Drawing.Color.White;
            this.gradientLabelTotalCount.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelTotalCount.Location = new System.Drawing.Point(3, 90);
            this.gradientLabelTotalCount.Name = "gradientLabelTotalCount";
            this.gradientLabelTotalCount.Size = new System.Drawing.Size(94, 24);
            this.gradientLabelTotalCount.TabIndex = 40;
            this.gradientLabelTotalCount.Text = "Total";
            this.gradientLabelTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabelTotalCount.DoubleClick += new System.EventHandler(this.gradientLabelTotalCount_DoubleClick);
            // 
            // gradientLabelYield
            // 
            this.gradientLabelYield.BackColor = System.Drawing.Color.White;
            this.gradientLabelYield.ColorBottom = System.Drawing.Color.LemonChiffon;
            this.gradientLabelYield.ColorTop = System.Drawing.Color.Gold;
            this.gradientLabelYield.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gradientLabelYield.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelYield.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelYield.Location = new System.Drawing.Point(3, 171);
            this.gradientLabelYield.Name = "gradientLabelYield";
            this.gradientLabelYield.Size = new System.Drawing.Size(94, 24);
            this.gradientLabelYield.TabIndex = 41;
            this.gradientLabelYield.Text = "Yield";
            this.gradientLabelYield.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNgCount
            // 
            this.gradientLabelNgCount.BackColor = System.Drawing.Color.White;
            this.gradientLabelNgCount.ColorBottom = System.Drawing.Color.LightCoral;
            this.gradientLabelNgCount.ColorTop = System.Drawing.Color.DarkRed;
            this.gradientLabelNgCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gradientLabelNgCount.ForeColor = System.Drawing.Color.White;
            this.gradientLabelNgCount.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNgCount.Location = new System.Drawing.Point(3, 144);
            this.gradientLabelNgCount.Name = "gradientLabelNgCount";
            this.gradientLabelNgCount.Size = new System.Drawing.Size(94, 24);
            this.gradientLabelNgCount.TabIndex = 42;
            this.gradientLabelNgCount.Text = "NG";
            this.gradientLabelNgCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabelNgCount.DoubleClick += new System.EventHandler(this.gradientLabelNgCount_DoubleClick);
            // 
            // SevenSegTotal
            // 
            this.SevenSegTotal.ArrayCount = 13;
            this.SevenSegTotal.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegTotal.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegTotal.ColorLight = System.Drawing.Color.White;
            this.SevenSegTotal.DecimalShow = true;
            this.SevenSegTotal.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegTotal.ElementWidth = 10;
            this.SevenSegTotal.ItalicFactor = -0.04F;
            this.SevenSegTotal.Location = new System.Drawing.Point(103, 88);
            this.SevenSegTotal.Name = "SevenSegTotal";
            this.SevenSegTotal.Size = new System.Drawing.Size(275, 24);
            this.SevenSegTotal.TabIndex = 36;
            this.SevenSegTotal.TabStop = false;
            this.SevenSegTotal.Value = "000000";
            // 
            // gradientLabelGoodCount
            // 
            this.gradientLabelGoodCount.BackColor = System.Drawing.Color.White;
            this.gradientLabelGoodCount.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabelGoodCount.ColorTop = System.Drawing.Color.Green;
            this.gradientLabelGoodCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gradientLabelGoodCount.ForeColor = System.Drawing.Color.White;
            this.gradientLabelGoodCount.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelGoodCount.Location = new System.Drawing.Point(3, 117);
            this.gradientLabelGoodCount.Name = "gradientLabelGoodCount";
            this.gradientLabelGoodCount.Size = new System.Drawing.Size(94, 24);
            this.gradientLabelGoodCount.TabIndex = 43;
            this.gradientLabelGoodCount.Text = "Good";
            this.gradientLabelGoodCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gradientLabelGoodCount.DoubleClick += new System.EventHandler(this.gradientLabelGoodCount_DoubleClick);
            // 
            // SevenSegYield
            // 
            this.SevenSegYield.ArrayCount = 12;
            this.SevenSegYield.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegYield.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegYield.ColorLight = System.Drawing.Color.Yellow;
            this.SevenSegYield.DecimalShow = true;
            this.SevenSegYield.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegYield.ElementWidth = 10;
            this.SevenSegYield.ItalicFactor = -0.04F;
            this.SevenSegYield.Location = new System.Drawing.Point(104, 171);
            this.SevenSegYield.Name = "SevenSegYield";
            this.SevenSegYield.Size = new System.Drawing.Size(252, 24);
            this.SevenSegYield.TabIndex = 37;
            this.SevenSegYield.TabStop = false;
            this.SevenSegYield.Value = "00000";
            // 
            // SevenSegNg
            // 
            this.SevenSegNg.ArrayCount = 13;
            this.SevenSegNg.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegNg.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegNg.ColorLight = System.Drawing.Color.Red;
            this.SevenSegNg.DecimalShow = true;
            this.SevenSegNg.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegNg.ElementWidth = 10;
            this.SevenSegNg.ItalicFactor = -0.04F;
            this.SevenSegNg.Location = new System.Drawing.Point(103, 144);
            this.SevenSegNg.Name = "SevenSegNg";
            this.SevenSegNg.Size = new System.Drawing.Size(275, 24);
            this.SevenSegNg.TabIndex = 38;
            this.SevenSegNg.TabStop = false;
            this.SevenSegNg.Value = "000000";
            // 
            // SevenSegGood
            // 
            this.SevenSegGood.ArrayCount = 13;
            this.SevenSegGood.ColorBackground = System.Drawing.Color.DimGray;
            this.SevenSegGood.ColorDark = System.Drawing.Color.Gray;
            this.SevenSegGood.ColorLight = System.Drawing.Color.Lime;
            this.SevenSegGood.DecimalShow = true;
            this.SevenSegGood.ElementPadding = new System.Windows.Forms.Padding(2);
            this.SevenSegGood.ElementWidth = 10;
            this.SevenSegGood.ItalicFactor = -0.04F;
            this.SevenSegGood.Location = new System.Drawing.Point(103, 117);
            this.SevenSegGood.Name = "SevenSegGood";
            this.SevenSegGood.Size = new System.Drawing.Size(275, 24);
            this.SevenSegGood.TabIndex = 39;
            this.SevenSegGood.TabStop = false;
            this.SevenSegGood.Value = "000000";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(350, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 24);
            this.label1.TabIndex = 44;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewLeadResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.QuickGridViewLeadResult.ColumnHeadersHeight = 22;
            this.QuickGridViewLeadResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.QuickGridViewLeadResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridLeadNum,
            this.gridLeadBent,
            this.gridLeadWidth,
            this.gridLeadLength,
            this.gridLeadPitch});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.QuickGridViewLeadResult.DefaultCellStyle = dataGridViewCellStyle8;
            this.QuickGridViewLeadResult.EnableHeadersVisualStyles = false;
            this.QuickGridViewLeadResult.Location = new System.Drawing.Point(2, 319);
            this.QuickGridViewLeadResult.MultiSelect = false;
            this.QuickGridViewLeadResult.Name = "QuickGridViewLeadResult";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewLeadResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.QuickGridViewLeadResult.RowHeadersVisible = false;
            this.QuickGridViewLeadResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QuickGridViewLeadResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QuickGridViewLeadResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuickGridViewLeadResult.Size = new System.Drawing.Size(378, 510);
            this.QuickGridViewLeadResult.TabIndex = 32;
            this.QuickGridViewLeadResult.Tag = "Size : 418, 511";
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
            this.gridLeadNum.Width = 34;
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
            this.gridLeadBent.Width = 85;
            // 
            // gridLeadWidth
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadWidth.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridLeadWidth.HeaderText = "Lead Width";
            this.gridLeadWidth.Name = "gridLeadWidth";
            this.gridLeadWidth.ReadOnly = true;
            this.gridLeadWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadWidth.Width = 85;
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
            this.gridLeadLength.Width = 85;
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
            this.gridLeadPitch.Width = 85;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 830);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 34;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnResultTest
            // 
            this.btnResultTest.Location = new System.Drawing.Point(0, 830);
            this.btnResultTest.Name = "btnResultTest";
            this.btnResultTest.Size = new System.Drawing.Size(121, 43);
            this.btnResultTest.TabIndex = 33;
            this.btnResultTest.Text = "Test";
            this.btnResultTest.UseVisualStyleBackColor = true;
            // 
            // gradientLabel7
            // 
            this.gradientLabel7.BackColor = System.Drawing.Color.White;
            this.gradientLabel7.ColorBottom = System.Drawing.Color.LightBlue;
            this.gradientLabel7.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel7.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel7.ForeColor = System.Drawing.Color.White;
            this.gradientLabel7.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel7.Location = new System.Drawing.Point(3, 34);
            this.gradientLabel7.Name = "gradientLabel7";
            this.gradientLabel7.Size = new System.Drawing.Size(94, 51);
            this.gradientLabel7.TabIndex = 31;
            this.gradientLabel7.Text = "Result";
            this.gradientLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.BackColor = System.Drawing.Color.White;
            this.gradientLabel4.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel4.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel4.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel4.ForeColor = System.Drawing.Color.White;
            this.gradientLabel4.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel4.Location = new System.Drawing.Point(2, 1);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(376, 30);
            this.gradientLabel4.TabIndex = 29;
            this.gradientLabel4.Text = " Data Matrix Data";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabelResult
            // 
            this.gradientLabelResult.BackColor = System.Drawing.Color.DarkGreen;
            this.gradientLabelResult.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelResult.ColorTop = System.Drawing.Color.White;
            this.gradientLabelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.gradientLabelResult.ForeColor = System.Drawing.Color.Lime;
            this.gradientLabelResult.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelResult.Location = new System.Drawing.Point(103, 34);
            this.gradientLabelResult.Name = "gradientLabelResult";
            this.gradientLabelResult.Size = new System.Drawing.Size(275, 51);
            this.gradientLabelResult.TabIndex = 27;
            this.gradientLabelResult.Text = "-";
            this.gradientLabelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNeedleAlignY2
            // 
            this.gradientLabelNeedleAlignY2.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignY2.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignY2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignY2.Location = new System.Drawing.Point(242, 256);
            this.gradientLabelNeedleAlignY2.Name = "gradientLabelNeedleAlignY2";
            this.gradientLabelNeedleAlignY2.Size = new System.Drawing.Size(136, 24);
            this.gradientLabelNeedleAlignY2.TabIndex = 27;
            this.gradientLabelNeedleAlignY2.Text = "0.0001";
            this.gradientLabelNeedleAlignY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNeedleAlignX2
            // 
            this.gradientLabelNeedleAlignX2.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignX2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignX2.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignX2.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignX2.Location = new System.Drawing.Point(242, 228);
            this.gradientLabelNeedleAlignX2.Name = "gradientLabelNeedleAlignX2";
            this.gradientLabelNeedleAlignX2.Size = new System.Drawing.Size(136, 24);
            this.gradientLabelNeedleAlignX2.TabIndex = 25;
            this.gradientLabelNeedleAlignX2.Text = "0.0001";
            this.gradientLabelNeedleAlignX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelNeedleAlignY1
            // 
            this.gradientLabelNeedleAlignY1.BackColor = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.ColorTop = System.Drawing.Color.White;
            this.gradientLabelNeedleAlignY1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelNeedleAlignY1.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelNeedleAlignY1.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelNeedleAlignY1.Location = new System.Drawing.Point(101, 256);
            this.gradientLabelNeedleAlignY1.Name = "gradientLabelNeedleAlignY1";
            this.gradientLabelNeedleAlignY1.Size = new System.Drawing.Size(136, 24);
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
            this.gradientLabel6.Location = new System.Drawing.Point(3, 256);
            this.gradientLabel6.Name = "gradientLabel6";
            this.gradientLabel6.Size = new System.Drawing.Size(94, 24);
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
            this.gradientLabelNeedleAlignX1.Location = new System.Drawing.Point(101, 228);
            this.gradientLabelNeedleAlignX1.Name = "gradientLabelNeedleAlignX1";
            this.gradientLabelNeedleAlignX1.Size = new System.Drawing.Size(136, 24);
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
            this.gradientLabel3.Location = new System.Drawing.Point(3, 228);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(94, 24);
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
            this.gradientLabel2.Location = new System.Drawing.Point(3, 287);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(375, 30);
            this.gradientLabel2.TabIndex = 21;
            this.gradientLabel2.Text = " Lead Inspection Result";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.BackColor = System.Drawing.Color.White;
            this.gradientLabel5.ColorBottom = System.Drawing.Color.WhiteSmoke;
            this.gradientLabel5.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel5.ForeColor = System.Drawing.Color.White;
            this.gradientLabel5.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel5.Location = new System.Drawing.Point(242, 201);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Size = new System.Drawing.Size(136, 24);
            this.gradientLabel5.TabIndex = 20;
            this.gradientLabel5.Text = " Needle Align2 Result";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabelTeaching
            // 
            this.gradientLabelTeaching.BackColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.ColorBottom = System.Drawing.Color.WhiteSmoke;
            this.gradientLabelTeaching.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabelTeaching.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelTeaching.ForeColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabelTeaching.Location = new System.Drawing.Point(101, 201);
            this.gradientLabelTeaching.Name = "gradientLabelTeaching";
            this.gradientLabelTeaching.Size = new System.Drawing.Size(136, 24);
            this.gradientLabelTeaching.TabIndex = 20;
            this.gradientLabelTeaching.Text = " Needle Align1 Result";
            this.gradientLabelTeaching.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucMainResultLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            this.Name = "ucMainResultLead";
            this.Size = new System.Drawing.Size(378, 830);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuickGridViewLeadResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnResultTest;
        private CustomControl.QuickDataGridView QuickGridViewLeadResult;
        private CustomControl.GradientLabel gradientLabel7;
        private CustomControl.GradientLabel gradientLabel4;
        private CustomControl.GradientLabel gradientLabelResult;
        private CustomControl.GradientLabel gradientLabelNeedleAlignY2;
        private CustomControl.GradientLabel gradientLabelNeedleAlignX2;
        private CustomControl.GradientLabel gradientLabelNeedleAlignY1;
        private CustomControl.GradientLabel gradientLabel6;
        private CustomControl.GradientLabel gradientLabelNeedleAlignX1;
        private CustomControl.GradientLabel gradientLabel3;
        private CustomControl.GradientLabel gradientLabel2;
        private CustomControl.GradientLabel gradientLabelTeaching;
        private CustomControl.GradientLabel gradientLabel5;
        private CustomControl.GradientLabel gradientLabelTotalCount;
        private CustomControl.GradientLabel gradientLabelYield;
        private CustomControl.GradientLabel gradientLabelNgCount;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegTotal;
        private CustomControl.GradientLabel gradientLabelGoodCount;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegYield;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegNg;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegGood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadBent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadPitch;
    }
}
