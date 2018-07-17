using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CustomControl;
using ParameterManager;

namespace KPVisionInspectionFramework
{
    public partial class MainResultWindow : Form
    {
        private eProjectType ProjectType;

        private bool ResizingFlag = false;
        private bool IsResizing = false;
        private Point LastPosition = new Point(0, 0);

        #region Initialize & DeInitialize
        public MainResultWindow()
        {
            InitializeComponent();
        }

        public void Initialize(Object _OwnerForm, int _ProjectType)
        {
            this.Owner = (Form)_OwnerForm;
            ProjectType = (eProjectType)_ProjectType;

            SetControls();
            SetWindowLocation(1482, 148);

            for (int iLoopCount = 0; iLoopCount < 22; ++iLoopCount)
            {
                DataGridViewRow _GridRow = new DataGridViewRow();
                DataGridViewCell[] _GridCell = new DataGridViewCell[5];
                _GridCell[0] = gridLeadNum.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[1] = gridLeadBent.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[2] = gridLeadWidth.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[3] = gridLeadLength.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[4] = gridLeadPitch.CellTemplate.Clone() as DataGridViewCell;

                _GridCell[0].Value = (iLoopCount + 1);
                _GridCell[0].Style.BackColor = Color.DarkGreen;
                _GridCell[0].Style.ForeColor = Color.White;
                //_GridCell[1].Style.BackColor = Color.PowderBluePowderBlue;
                //_GridCell[2].Style.BackColor = Color.PowderBlue;
                //_GridCell[3].Style.BackColor = Color.PowderBlue;
                //_GridCell[4].Style.BackColor = Color.PowderBlue;
                //
                _GridRow.Cells.AddRange(_GridCell);
                QuickGridViewLeadResult.Rows.Add(_GridRow);
            }
            QuickGridViewLeadResult.ClearSelection();
        }

        public void DeInitialize()
        {

        }

        public void SetWindowLocation(int _StartX, int _StartY)
        {
            this.Location = new Point(_StartX, _StartY);
        }

        public void SetWindowSize(int _Width, int _Height)
        {
            this.Size = new Size(_Width, _Height);
        }

        public void SetControls()
        {

        }
        #endregion Initialize & DeInitialize

        #region Control Default Event
        private void MainResultWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            if (!IsResizing) // handle cursor type
            {
                bool resize_x = e.X > (this.Width - 8);
                bool resize_y = e.Y > (this.Height - 8);

                if (resize_x && resize_y) this.Cursor = Cursors.SizeNWSE;
                else if (resize_x) this.Cursor = Cursors.SizeWE;
                else if (resize_y) this.Cursor = Cursors.SizeNS;
                else this.Cursor = Cursors.Default;
            }
            else // handle resize
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Right) return;

                int w = this.Size.Width;
                int h = this.Size.Height;

                if (this.Cursor.Equals(Cursors.SizeNWSE)) this.Size = new Size(w + (e.Location.X - this.LastPosition.X), h + (e.Location.Y - this.LastPosition.Y));
                else if (this.Cursor.Equals(Cursors.SizeWE)) this.Size = new Size(w + (e.Location.X - this.LastPosition.X), h);
                else if (this.Cursor.Equals(Cursors.SizeNS)) this.Size = new Size(w, h + (e.Location.Y - this.LastPosition.Y));

                this.LastPosition = e.Location;
            }
        }

        static int count = 1;
        private void btnResultTest_Click(object sender, EventArgs e)
        {
            DataGridViewCell[] _GridCell = new DataGridViewCell[5];
            _GridCell[0] = gridLeadNum.CellTemplate.Clone() as DataGridViewCell;
            _GridCell[1] = gridLeadBent.CellTemplate.Clone() as DataGridViewCell;
            _GridCell[2] = gridLeadWidth.CellTemplate.Clone() as DataGridViewCell;
            _GridCell[3] = gridLeadLength.CellTemplate.Clone() as DataGridViewCell;
            _GridCell[4] = gridLeadPitch.CellTemplate.Clone() as DataGridViewCell;

            _GridCell[0].Value = count;
            _GridCell[0].Style.BackColor = Color.DarkGreen;
            _GridCell[0].Style.ForeColor = Color.White;
            
            _GridCell[1].Value = 0.00;
            _GridCell[1].Style.BackColor = Color.PowderBlue;

            _GridCell[2].Value = 0.00;
            _GridCell[2].Style.BackColor = Color.PowderBlue;

            _GridCell[3].Value = 0.00;
            _GridCell[3].Style.BackColor = Color.PowderBlue;

            _GridCell[4].Value = 0.00;
            _GridCell[4].Style.BackColor = Color.PowderBlue;

            DataGridViewRow _GridRow = new DataGridViewRow();
            _GridRow.Cells.AddRange(_GridCell);
            QuickGridViewLeadResult.Rows.Add(_GridRow);
            QuickGridViewLeadResult.ClearSelection();
            count++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //QuickGridViewLeadResult[2, 3].Style.BackColor = Color.Red;
            //QuickGridViewLeadResult[2, 3].Style.ForeColor = Color.White;

            for (int iLoopCount = 0; iLoopCount < 22; ++iLoopCount)
            {
                QuickGridViewLeadResult[1, iLoopCount].Value = 0;
                QuickGridViewLeadResult[2, iLoopCount].Value = 0;
                QuickGridViewLeadResult[3, iLoopCount].Value = 0;
            }
            QuickGridViewLeadResult.ClearSelection();
        }

        private void MainResultWindow_MouseDown(object sender, MouseEventArgs e)
        {
            this.IsResizing = true;
            this.LastPosition = e.Location;
        }

        private void MainResultWindow_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsResizing = false;
        }

        private void MainResultWindow_Resize(object sender, EventArgs e)
        {
            Size _TitleSize = new Size(this.Size.Width, labelTitle.Size.Height);
            Point _Location = panelMain.Location;

            labelTitle.Size = new Size(_TitleSize.Width - 6, _TitleSize.Height);
            labelTitle.Location = new Point(3, 2);

            panelMain.Size = new Size(_TitleSize.Width - 6, this.Size.Height - _TitleSize.Height - 6);
            panelMain.Location = new Point(3, _Location.Y);

            panelMain.Invalidate();
            labelTitle.Invalidate();
        }

        private void MainResultWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;
        }

        private void labelTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.labelTitle.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void labelTitle_DoubleClick(object sender, EventArgs e)
        {
            ResizingFlag = !ResizingFlag;
            if (true == ResizingFlag) labelTitle.ForeColor = Color.Chocolate;
            else labelTitle.ForeColor = Color.WhiteSmoke;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            var s = sender as Label;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);

            this.Cursor = Cursors.Default;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            s.Tag = new Point(e.X, e.Y);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void panelMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            this.Cursor = Cursors.Default;
        }
        #endregion Control Default Event

        #region 프로젝트 별 Result Data Setting
        public void SetResultData(SendResultParameter _ResultParam)
        {
            if (_ResultParam.ProjectItem == eProjectItem.NEEDLE_ALIGN)   SetNeedleAlignResultData(_ResultParam);
            else if (_ResultParam.ProjectItem == eProjectItem.LEAD_INSP) SetLeadInspectionResultData(_ResultParam);
            else if (_ResultParam.ProjectItem == eProjectItem.ID_INSP)   SetIDInspectionResultData(_ResultParam);
        }

        private void SetNeedleAlignResultData(SendResultParameter _ResultParam)
        {
            if (_ResultParam.ID == 0)   //Needle Align Vision1
            {
                var _Result = _ResultParam.SendResult as SendNeedleAlignResult;
                if (_Result != null)
                {
                    //gradientLabelNeedleAlignX1.Text = _Result.AlignX.ToString("F3");
                    //gradientLabelNeedleAlignY1.Text = _Result.AlignY.ToString("F3");
                    //SevenSegArr.Value = _Result.AlignX.ToString("F3");
                    //
                    //string _AlignValueX = _Result.AlignX.ToString("F3");
                    //SevenSegArr.Value = _AlignValueX;

                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, _Result.AlignX.ToString("F3"));
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, _Result.AlignY.ToString("F3"));
                }
                else
                {
                    //gradientLabelNeedleAlignX1.Text = "-";
                    //gradientLabelNeedleAlignY1.Text = "-";
                    SevenSegArr.Value = "0";

                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, "-");
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, "-");
                }
            }

            else if (_ResultParam.ID == 1)   //Needle Align Vision2
            {
                //gradientLabelNeedleAlignX2.Text = _ResultParam.AlignX.ToString("F3");
                //gradientLabelNeedleAlignY2.Text = _ResultParam.AlignY.ToString("F3");
            }

            else
            {
                //LOG
            }
        }

        private void SetLeadInspectionResultData(SendResultParameter _ResultParam)
        {
            var _Result = _ResultParam.SendResult as SendLeadResult;
            if (_Result != null)
            {
                for (int iLoopCount = 0; iLoopCount < _Result.LeadCount; ++iLoopCount)
                {
                    double _Angle = _Result.LeadAngle[iLoopCount] * 180 / Math.PI;
                    if (_Angle > 0) _Angle = 90 - (_Result.LeadAngle[iLoopCount] * 180 / Math.PI);
                    else            _Angle = -(90 + (_Result.LeadAngle[iLoopCount] * 180 / Math.PI));

                    QuickGridViewLeadResult[1, iLoopCount].Value = _Angle.ToString("F3");
                    QuickGridViewLeadResult[2, iLoopCount].Value = _Result.LeadWidth[iLoopCount].ToString("F3");
                    QuickGridViewLeadResult[3, iLoopCount].Value = _Result.LeadLength[iLoopCount].ToString("F3");

                    //QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = (_Result.IsLeadBendGood[iLoopCount] == true) ? Color.PowderBlue : Color.Red;

                    if (_Result.IsLeadBendGood[iLoopCount] && iLoopCount % 2 == 0)      QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.PowderBlue;
                    else if (_Result.IsLeadBendGood[iLoopCount] && iLoopCount % 2 == 1) QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.White;
                    else                                                                QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.Red;
                }
            }
            QuickGridViewLeadResult.ClearSelection();
        }

        private void SetIDInspectionResultData(SendResultParameter _ResultParam)
        {
            var _Result = _ResultParam.SendResult as SendIDResult;

            if (_Result != null) gradientLabelDataMatrix.Text = (_ResultParam.IsGood == true) ? _Result.ReadCode : "-----";
            else                 gradientLabelDataMatrix.Text = "-";
        }
        # endregion 프로젝트 별 Result Data Setting
    }
}
