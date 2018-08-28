using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using LogMessageManager;

namespace KPVisionInspectionFramework
{
    public partial class CodeSettingWindow : Form
    {
        private bool ResizingFlag = false;
        private bool IsResizing = false;
        private Point LastPosition = new Point(0, 0);

        public delegate void BarcodeReaderHandler(string ReadCode);
        public event BarcodeReaderHandler BarcodeReaderEvent;

        public CodeSettingWindow()
        {
            InitializeComponent();
            LastPosition.X = this.Location.X;
            LastPosition.Y = this.Location.Y;

            textBoxBarcode.Clear();
        }

        #region Control Default Event
        private void CodeSettingWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;
        }

        private void CodeSettingWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            if (!IsResizing) // handle cursor type
            {
                bool resize_x = e.X > (this.Width - 8);
                bool resize_y = e.Y > (this.Height - 8);

                //if (e.X > 0 && e.X < 2) resize_x = true;
                //if (e.Y > 0 && e.Y < 2) resize_y = true;

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

        private void CodeSettingWindow_MouseDown(object sender, MouseEventArgs e)
        {
            this.IsResizing = true;
            this.LastPosition = e.Location;
        }

        private void CodeSettingWindow_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsResizing = false;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            //if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            var s = sender as Label;
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);

            this.Cursor = Cursors.Default;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            s.Tag = new Point(e.X, e.Y);
        }

        private void labelTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.labelTitle.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void panelMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == ResizingFlag) { this.Cursor = Cursors.Default; return; }

            this.Cursor = Cursors.Default;
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        #endregion Control Default Event

        #region Control Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            BarcodeReaderEvent(textBoxBarcode.Text);

            CLogManager.AddSystemLog(CLogManager.LOG_TYPE.INFO, "CodeSettingWindow - BarcodeReaderEvent Complete", CLogManager.LOG_LEVEL.MID);

            this.Hide();
        }
        #endregion Control Event
    }
}
