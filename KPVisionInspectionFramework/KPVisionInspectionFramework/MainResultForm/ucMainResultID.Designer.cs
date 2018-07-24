namespace KPVisionInspectionFramework
{
    partial class ucMainResultID
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
            this.label1 = new System.Windows.Forms.Label();
            this.gradientLabel5 = new CustomControl.GradientLabel();
            this.gradientLabelDataMatrix = new CustomControl.GradientLabel();
            this.gradientLabelResult = new CustomControl.GradientLabel();
            this.gradientLabel4 = new CustomControl.GradientLabel();
            this.SevenSegGood = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegNg = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel7 = new CustomControl.GradientLabel();
            this.SevenSegCodeErr = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegYield = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegBlankErr = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel9 = new CustomControl.GradientLabel();
            this.SevenSegMixErr = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.SevenSegTotal = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.gradientLabel11 = new CustomControl.GradientLabel();
            this.gradientLabel14 = new CustomControl.GradientLabel();
            this.gradientLabel15 = new CustomControl.GradientLabel();
            this.gradientLabel16 = new CustomControl.GradientLabel();
            this.gradientLabel12 = new CustomControl.GradientLabel();
            this.gradientLabel13 = new CustomControl.GradientLabel();
            this.btnResultTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(392, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 27);
            this.label1.TabIndex = 35;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.BackColor = System.Drawing.Color.White;
            this.gradientLabel5.ColorBottom = System.Drawing.Color.LightBlue;
            this.gradientLabel5.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel5.ForeColor = System.Drawing.Color.White;
            this.gradientLabel5.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel5.Location = new System.Drawing.Point(3, 110);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel5.TabIndex = 28;
            this.gradientLabel5.Text = "Data";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelDataMatrix
            // 
            this.gradientLabelDataMatrix.BackColor = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.ColorTop = System.Drawing.Color.White;
            this.gradientLabelDataMatrix.Font = new System.Drawing.Font("HY견고딕", 20F);
            this.gradientLabelDataMatrix.ForeColor = System.Drawing.Color.Black;
            this.gradientLabelDataMatrix.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelDataMatrix.Location = new System.Drawing.Point(117, 110);
            this.gradientLabelDataMatrix.Name = "gradientLabelDataMatrix";
            this.gradientLabelDataMatrix.Size = new System.Drawing.Size(302, 30);
            this.gradientLabelDataMatrix.TabIndex = 27;
            this.gradientLabelDataMatrix.Text = "BARCODE";
            this.gradientLabelDataMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabelResult
            // 
            this.gradientLabelResult.BackColor = System.Drawing.Color.DarkGreen;
            this.gradientLabelResult.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelResult.ColorTop = System.Drawing.Color.White;
            this.gradientLabelResult.Font = new System.Drawing.Font("HY견고딕", 36F, System.Drawing.FontStyle.Bold);
            this.gradientLabelResult.ForeColor = System.Drawing.Color.Lime;
            this.gradientLabelResult.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabelResult.Location = new System.Drawing.Point(117, 34);
            this.gradientLabelResult.Name = "gradientLabelResult";
            this.gradientLabelResult.Size = new System.Drawing.Size(302, 69);
            this.gradientLabelResult.TabIndex = 27;
            this.gradientLabelResult.Text = "GOOD";
            this.gradientLabelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gradientLabel4.Size = new System.Drawing.Size(417, 30);
            this.gradientLabel4.TabIndex = 29;
            this.gradientLabel4.Text = " Data Matrix Data";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.SevenSegGood.Location = new System.Drawing.Point(117, 203);
            this.SevenSegGood.Name = "SevenSegGood";
            this.SevenSegGood.Size = new System.Drawing.Size(302, 30);
            this.SevenSegGood.TabIndex = 30;
            this.SevenSegGood.TabStop = false;
            this.SevenSegGood.Value = "000000";
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
            this.SevenSegNg.Location = new System.Drawing.Point(117, 239);
            this.SevenSegNg.Name = "SevenSegNg";
            this.SevenSegNg.Size = new System.Drawing.Size(302, 30);
            this.SevenSegNg.TabIndex = 30;
            this.SevenSegNg.TabStop = false;
            this.SevenSegNg.Value = "000000";
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
            this.gradientLabel7.Size = new System.Drawing.Size(110, 69);
            this.gradientLabel7.TabIndex = 31;
            this.gradientLabel7.Text = "Result";
            this.gradientLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.SevenSegCodeErr.Location = new System.Drawing.Point(117, 345);
            this.SevenSegCodeErr.Name = "SevenSegCodeErr";
            this.SevenSegCodeErr.Size = new System.Drawing.Size(302, 30);
            this.SevenSegCodeErr.TabIndex = 30;
            this.SevenSegCodeErr.TabStop = false;
            this.SevenSegCodeErr.Value = "000000";
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
            this.SevenSegYield.Location = new System.Drawing.Point(117, 275);
            this.SevenSegYield.Name = "SevenSegYield";
            this.SevenSegYield.Size = new System.Drawing.Size(278, 30);
            this.SevenSegYield.TabIndex = 30;
            this.SevenSegYield.TabStop = false;
            this.SevenSegYield.Value = "00000";
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
            this.SevenSegBlankErr.Location = new System.Drawing.Point(117, 381);
            this.SevenSegBlankErr.Name = "SevenSegBlankErr";
            this.SevenSegBlankErr.Size = new System.Drawing.Size(302, 30);
            this.SevenSegBlankErr.TabIndex = 30;
            this.SevenSegBlankErr.TabStop = false;
            this.SevenSegBlankErr.Value = "000000";
            // 
            // gradientLabel9
            // 
            this.gradientLabel9.BackColor = System.Drawing.Color.White;
            this.gradientLabel9.ColorBottom = System.Drawing.Color.LightGreen;
            this.gradientLabel9.ColorTop = System.Drawing.Color.Green;
            this.gradientLabel9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel9.ForeColor = System.Drawing.Color.White;
            this.gradientLabel9.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel9.Location = new System.Drawing.Point(3, 203);
            this.gradientLabel9.Name = "gradientLabel9";
            this.gradientLabel9.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel9.TabIndex = 31;
            this.gradientLabel9.Text = "Good";
            this.gradientLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.SevenSegMixErr.Location = new System.Drawing.Point(117, 417);
            this.SevenSegMixErr.Name = "SevenSegMixErr";
            this.SevenSegMixErr.Size = new System.Drawing.Size(302, 30);
            this.SevenSegMixErr.TabIndex = 30;
            this.SevenSegMixErr.TabStop = false;
            this.SevenSegMixErr.Value = "000000";
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
            this.SevenSegTotal.Location = new System.Drawing.Point(117, 164);
            this.SevenSegTotal.Name = "SevenSegTotal";
            this.SevenSegTotal.Size = new System.Drawing.Size(302, 30);
            this.SevenSegTotal.TabIndex = 30;
            this.SevenSegTotal.TabStop = false;
            this.SevenSegTotal.Value = "000000";
            // 
            // gradientLabel11
            // 
            this.gradientLabel11.BackColor = System.Drawing.Color.White;
            this.gradientLabel11.ColorBottom = System.Drawing.Color.LightCoral;
            this.gradientLabel11.ColorTop = System.Drawing.Color.DarkRed;
            this.gradientLabel11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel11.ForeColor = System.Drawing.Color.White;
            this.gradientLabel11.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel11.Location = new System.Drawing.Point(3, 239);
            this.gradientLabel11.Name = "gradientLabel11";
            this.gradientLabel11.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel11.TabIndex = 31;
            this.gradientLabel11.Text = "NG";
            this.gradientLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel14
            // 
            this.gradientLabel14.BackColor = System.Drawing.Color.White;
            this.gradientLabel14.ColorBottom = System.Drawing.Color.LightSeaGreen;
            this.gradientLabel14.ColorTop = System.Drawing.Color.DarkCyan;
            this.gradientLabel14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel14.ForeColor = System.Drawing.Color.White;
            this.gradientLabel14.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel14.Location = new System.Drawing.Point(3, 345);
            this.gradientLabel14.Name = "gradientLabel14";
            this.gradientLabel14.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel14.TabIndex = 31;
            this.gradientLabel14.Text = "      Code Err";
            this.gradientLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel15
            // 
            this.gradientLabel15.BackColor = System.Drawing.Color.White;
            this.gradientLabel15.ColorBottom = System.Drawing.Color.LightSeaGreen;
            this.gradientLabel15.ColorTop = System.Drawing.Color.DarkCyan;
            this.gradientLabel15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel15.ForeColor = System.Drawing.Color.White;
            this.gradientLabel15.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel15.Location = new System.Drawing.Point(3, 381);
            this.gradientLabel15.Name = "gradientLabel15";
            this.gradientLabel15.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel15.TabIndex = 31;
            this.gradientLabel15.Text = "      Blank Err";
            this.gradientLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel16
            // 
            this.gradientLabel16.BackColor = System.Drawing.Color.White;
            this.gradientLabel16.ColorBottom = System.Drawing.Color.LightSeaGreen;
            this.gradientLabel16.ColorTop = System.Drawing.Color.DarkCyan;
            this.gradientLabel16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel16.ForeColor = System.Drawing.Color.White;
            this.gradientLabel16.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel16.Location = new System.Drawing.Point(3, 417);
            this.gradientLabel16.Name = "gradientLabel16";
            this.gradientLabel16.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel16.TabIndex = 31;
            this.gradientLabel16.Text = "      Mix Err";
            this.gradientLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel12
            // 
            this.gradientLabel12.BackColor = System.Drawing.Color.White;
            this.gradientLabel12.ColorBottom = System.Drawing.Color.LemonChiffon;
            this.gradientLabel12.ColorTop = System.Drawing.Color.Gold;
            this.gradientLabel12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel12.ForeColor = System.Drawing.Color.Black;
            this.gradientLabel12.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel12.Location = new System.Drawing.Point(3, 275);
            this.gradientLabel12.Name = "gradientLabel12";
            this.gradientLabel12.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel12.TabIndex = 31;
            this.gradientLabel12.Text = "Yield";
            this.gradientLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel13
            // 
            this.gradientLabel13.BackColor = System.Drawing.Color.White;
            this.gradientLabel13.ColorBottom = System.Drawing.Color.LightGray;
            this.gradientLabel13.ColorTop = System.Drawing.Color.DimGray;
            this.gradientLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel13.ForeColor = System.Drawing.Color.White;
            this.gradientLabel13.GradientDirection = CustomControl.GradientLabel.Direction.Horizon;
            this.gradientLabel13.Location = new System.Drawing.Point(3, 166);
            this.gradientLabel13.Name = "gradientLabel13";
            this.gradientLabel13.Size = new System.Drawing.Size(110, 30);
            this.gradientLabel13.TabIndex = 31;
            this.gradientLabel13.Text = "Total";
            this.gradientLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResultTest
            // 
            this.btnResultTest.Location = new System.Drawing.Point(2, 488);
            this.btnResultTest.Name = "btnResultTest";
            this.btnResultTest.Size = new System.Drawing.Size(121, 43);
            this.btnResultTest.TabIndex = 33;
            this.btnResultTest.Text = "Test";
            this.btnResultTest.UseVisualStyleBackColor = true;
            this.btnResultTest.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 34;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.btnResultTest);
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
            this.panelMain.Controls.Add(this.gradientLabel5);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(421, 733);
            this.panelMain.TabIndex = 13;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // ucMainResultID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.249999F);
            this.Name = "ucMainResultID";
            this.Size = new System.Drawing.Size(421, 738);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomControl.GradientLabel gradientLabel5;
        private CustomControl.GradientLabel gradientLabelDataMatrix;
        private CustomControl.GradientLabel gradientLabelResult;
        private CustomControl.GradientLabel gradientLabel4;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegGood;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegNg;
        private CustomControl.GradientLabel gradientLabel7;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegCodeErr;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegYield;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegBlankErr;
        private CustomControl.GradientLabel gradientLabel9;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegMixErr;
        private DmitryBrant.CustomControls.SevenSegmentArray SevenSegTotal;
        private CustomControl.GradientLabel gradientLabel11;
        private CustomControl.GradientLabel gradientLabel14;
        private CustomControl.GradientLabel gradientLabel15;
        private CustomControl.GradientLabel gradientLabel16;
        private CustomControl.GradientLabel gradientLabel12;
        private CustomControl.GradientLabel gradientLabel13;
        private System.Windows.Forms.Button btnResultTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelMain;
    }
}
