﻿namespace KPVisionInspectionFramework
{
    partial class ucMainResultVoid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.QuickGridViewResult = new CustomControl.QuickDataGridView();
            this.gridLeadNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDefectWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDefectHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDefectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientLabel2 = new CustomControl.GradientLabel();
            this.gradientLabelTotalCount = new CustomControl.GradientLabel();
            this.gradientLabelYield = new CustomControl.GradientLabel();
            this.gradientLabelNgCount = new CustomControl.GradientLabel();
            this.SevenSegTotal = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabelGoodCount = new CustomControl.GradientLabel();
            this.SevenSegYield = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegNg = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegGood = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResultTest = new System.Windows.Forms.Button();
            this.gradientLabel7 = new CustomControl.GradientLabel();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.gradientLabelResult = new CustomControl.GradientLabel();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuickGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.QuickGridViewResult);
            this.panelMain.Controls.Add(this.gradientLabel2);
            this.panelMain.Controls.Add(this.gradientLabelTotalCount);
            this.panelMain.Controls.Add(this.gradientLabelYield);
            this.panelMain.Controls.Add(this.gradientLabelNgCount);
            this.panelMain.Controls.Add(this.SevenSegTotal);
            this.panelMain.Controls.Add(this.gradientLabelGoodCount);
            this.panelMain.Controls.Add(this.SevenSegYield);
            this.panelMain.Controls.Add(this.SevenSegNg);
            this.panelMain.Controls.Add(this.SevenSegGood);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.btnResultTest);
            this.panelMain.Controls.Add(this.gradientLabel7);
            this.panelMain.Controls.Add(this.gradientLabel4);
            this.panelMain.Controls.Add(this.gradientLabelResult);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(377, 830);
            this.panelMain.TabIndex = 15;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // QuickGridViewResult
            // 
            this.QuickGridViewResult.AllowUserToAddRows = false;
            this.QuickGridViewResult.AllowUserToDeleteRows = false;
            this.QuickGridViewResult.AllowUserToResizeColumns = false;
            this.QuickGridViewResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.QuickGridViewResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.QuickGridViewResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.QuickGridViewResult.ColumnHeadersHeight = 22;
            this.QuickGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.QuickGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridLeadNum,
            this.gridDefectWidth,
            this.gridDefectHeight,
            this.gridDefectType});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.QuickGridViewResult.DefaultCellStyle = dataGridViewCellStyle7;
            this.QuickGridViewResult.EnableHeadersVisualStyles = false;
            this.QuickGridViewResult.Location = new System.Drawing.Point(-1, 239);
            this.QuickGridViewResult.MultiSelect = false;
            this.QuickGridViewResult.Name = "QuickGridViewResult";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuickGridViewResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.QuickGridViewResult.RowHeadersVisible = false;
            this.QuickGridViewResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QuickGridViewResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QuickGridViewResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuickGridViewResult.Size = new System.Drawing.Size(378, 245);
            this.QuickGridViewResult.TabIndex = 46;
            this.QuickGridViewResult.Tag = "Size : 418, 511";
            // 
            // gridLeadNum
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridLeadNum.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridLeadNum.Frozen = true;
            this.gridLeadNum.HeaderText = "Num";
            this.gridLeadNum.Name = "gridLeadNum";
            this.gridLeadNum.ReadOnly = true;
            this.gridLeadNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLeadNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridLeadNum.Width = 34;
            // 
            // gridDefectWidth
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridDefectWidth.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridDefectWidth.Frozen = true;
            this.gridDefectWidth.HeaderText = "Width";
            this.gridDefectWidth.Name = "gridDefectWidth";
            this.gridDefectWidth.ReadOnly = true;
            this.gridDefectWidth.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDefectWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridDefectWidth.Width = 135;
            // 
            // gridDefectHeight
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridDefectHeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridDefectHeight.Frozen = true;
            this.gridDefectHeight.HeaderText = "Height";
            this.gridDefectHeight.Name = "gridDefectHeight";
            this.gridDefectHeight.ReadOnly = true;
            this.gridDefectHeight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDefectHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridDefectHeight.Width = 135;
            // 
            // gridDefectType
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridDefectType.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridDefectType.Frozen = true;
            this.gridDefectType.HeaderText = "Ng Type";
            this.gridDefectType.Name = "gridDefectType";
            this.gridDefectType.ReadOnly = true;
            this.gridDefectType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDefectType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridDefectType.Width = 70;
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.BackColor = System.Drawing.Color.White;
            this.gradientLabel2.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel2.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel2.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel2.ForeColor = System.Drawing.Color.White;
            this.gradientLabel2.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel2.Location = new System.Drawing.Point(0, 207);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(375, 30);
            this.gradientLabel2.TabIndex = 45;
            this.gradientLabel2.Text = " Void Defect Result List";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.gradientLabel4.Text = " Result Window";
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
            // ucMainResultVoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F, System.Drawing.FontStyle.Bold);
            this.Name = "ucMainResultVoid";
            this.Size = new System.Drawing.Size(378, 830);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuickGridViewResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private CustomControl.GradientLabel gradientLabelTotalCount;
        private CustomControl.GradientLabel gradientLabelYield;
        private CustomControl.GradientLabel gradientLabelNgCount;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegTotal;
        private CustomControl.GradientLabel gradientLabelGoodCount;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegYield;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegNg;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegGood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnResultTest;
        private CustomControl.GradientLabel gradientLabel7;
        private CustomControl.GradientLabel gradientLabel4;
        private CustomControl.GradientLabel gradientLabelResult;
        private CustomControl.QuickDataGridView QuickGridViewResult;
        private CustomControl.GradientLabel gradientLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeadNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDefectWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDefectHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDefectType;
    }
}
