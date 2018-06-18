using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public void SetResultData(SendResultParameter _ResultParam)
        {
            if (_ResultParam.ProjectItem == eProjectItem.NEEDLE_ALIGN)   SetNeedleAlignResultData(_ResultParam);
            else if (_ResultParam.ProjectItem == eProjectItem.LEAD_INSP) SetLeadInspectionResultData(_ResultParam);
        }

        private void SetNeedleAlignResultData(SendResultParameter _ResultParam)
        {
            if (_ResultParam.ID == 0)   //Needle Align Vision1
            {
                gradientLabelNeedleAlignX1.Text = _ResultParam.AlignX.ToString("F3");
                gradientLabelNeedleAlignY1.Text = _ResultParam.AlignY.ToString("F3");
            }

            else if (_ResultParam.ID == 1)   //Needle Align Vision2
            {
                gradientLabelNeedleAlignX2.Text = _ResultParam.AlignX.ToString("F3");
                gradientLabelNeedleAlignY2.Text = _ResultParam.AlignY.ToString("F3");
            }

            else
            {
                //LOG
            }
        }

        private void SetLeadInspectionResultData(SendResultParameter _ResultParam)
        {

        }
    }
}
