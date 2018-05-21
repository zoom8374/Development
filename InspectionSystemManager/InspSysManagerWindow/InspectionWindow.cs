using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;

namespace InspectionSystemManager
{
    public partial class InspectionWindow : Form
    {
        private string FormName;
        private bool ResizingFlag = false;
        private bool IsResizing = false;
        private Point LastPosition = new Point(0, 0);

        private int ImageSizeWidth = 0;
        private int ImageSizeHeight = 0;
        private bool IsCrossLine = false;

        private double DisplayZoomValue = 1;
        private double DisplayPanXValue = 0;
        private double DisplayPanYValue = 0;

        #region Initialize & DeInitialize
        public InspectionWindow()
        {
            InitializeComponent();

            #region Set Button Image Resource
            btnInspection.ButtonImage = InspectionSystemManager.Properties.Resources.Inspection;
            btnInspection.ButtonImageOver = InspectionSystemManager.Properties.Resources.InspectionOver;
            btnInspection.ButtonImageDown = InspectionSystemManager.Properties.Resources.InspectionOver;
            btnOneShot.ButtonImage = InspectionSystemManager.Properties.Resources.OneShot;
            btnOneShot.ButtonImageOver = InspectionSystemManager.Properties.Resources.OneShotOver;
            btnOneShot.ButtonImageDown = InspectionSystemManager.Properties.Resources.OneShotOver;
            btnRecipe.ButtonImage = InspectionSystemManager.Properties.Resources.Recipe;
            btnRecipe.ButtonImageOver = InspectionSystemManager.Properties.Resources.RecipeOver;
            btnRecipe.ButtonImageDown = InspectionSystemManager.Properties.Resources.RecipeOver;
            btnRecipeSave.ButtonImage = InspectionSystemManager.Properties.Resources.RecipeSave;
            btnRecipeSave.ButtonImageOver = InspectionSystemManager.Properties.Resources.RecipeSaveOver;
            btnRecipeSave.ButtonImageDown = InspectionSystemManager.Properties.Resources.RecipeSaveOver;
            btnLive.ButtonImage = InspectionSystemManager.Properties.Resources.Camera;
            btnLive.ButtonImageOver = InspectionSystemManager.Properties.Resources.CameraOver;
            btnLive.ButtonImageDown = InspectionSystemManager.Properties.Resources.CameraOver;
            btnImageSave.ButtonImage = InspectionSystemManager.Properties.Resources.ImageSave;
            btnImageSave.ButtonImageOver = InspectionSystemManager.Properties.Resources.ImageSaveOver;
            btnImageSave.ButtonImageDown = InspectionSystemManager.Properties.Resources.ImageSaveOver;
            btnImageLoad.ButtonImage = InspectionSystemManager.Properties.Resources.ImageLoad;
            btnImageLoad.ButtonImageOver = InspectionSystemManager.Properties.Resources.ImageLoadOver;
            btnImageLoad.ButtonImageDown = InspectionSystemManager.Properties.Resources.ImageLoadOver;

            #endregion Set Button Image Resource
        }

        public void Initialize(Object _OwnerForm, Object _OwnerClass, string _FormName)
        {
            //InspSysManager = (CInspectionSystemManager)_OwnerClass;
            labelTitle.Text = _FormName;
            this.Owner = (Form)_OwnerForm;
        }

        public void Deinitialize()
        {

        }

        public void SetLocation(int _StartX, int _StartY)
        {
            this.Location = new Point(_StartX, _StartY);
        }

        public void SetWindowSize(int _Width, int _Height)
        {
            this.Size = new Size(_Width, _Height);
        }

        public void SetWindowDisplayInfo(double _Zoom, double _PanX, double _PanY)
        {
            DisplayZoomValue = _Zoom;
            DisplayPanXValue = _PanX;
            DisplayPanYValue = _PanY;
        }

        public void GetWindowDisplayInfo(out double _Zoom, out double _PanX, out double _PanY)
        {
            _Zoom = DisplayZoomValue;
            _PanX = DisplayPanXValue;
            _PanY = DisplayPanYValue;
        }
        #endregion Initialize & DeInitialize

        #region Set Image Display Control
        public void SetDisplayImage(CogImage8Grey _DisplayImage)
        {
            if (_DisplayImage != null)
            {
                ImageSizeWidth = _DisplayImage.Width;
                ImageSizeHeight = _DisplayImage.Height;
            }
            kpCogDisplayMain.ClearDisplay();
            kpCogDisplayMain.SetDisplayImage(_DisplayImage);
            GC.Collect();
        }
        #endregion Set Image Display Control

        #region Control Default Event
        private void InspectionWindow_MouseMove(object sender, MouseEventArgs e)
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

        private void InspectionWindow_MouseDown(object sender, MouseEventArgs e)
        {
            this.IsResizing = true;
            this.LastPosition = e.Location;
        }

        private void InspectionWindow_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsResizing = false;
        }

        private void InspectionWindow_Resize(object sender, EventArgs e)
        {
            Size _TitleSize = new Size(this.Size.Width, labelTitle.Size.Height);
            Point _Location = panelMain.Location;

            labelTitle.Size = new Size(_TitleSize.Width - 6, _TitleSize.Height);
            labelTitle.Location = new Point(3, 2);

            panelMain.Size = new Size(_TitleSize.Width - 6, this.Size.Height - _TitleSize.Height - 6);
            panelMain.Location = new Point(3, _Location.Y);

            panelMenu.Size = new Size(panelMain.Width - 6, panelMenu.Height);
            panelMenu.Location = new Point(2, 2);

            Size _DisplayMain = kpCogDisplayMain.Size;
            kpCogDisplayMain.Size = new Size(panelMain.Width - 6, panelMain.Height - panelMenu.Height - 6);
            kpCogDisplayMain.Location = new Point(2, panelMenu.Height + 3);

            panelMain.Invalidate();
            labelTitle.Invalidate();
            panelMenu.Invalidate();
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

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMenu.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void labelTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.labelTitle.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void labelTitle_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void InspectionWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;
        }
        #endregion Control Default Event

        #region Control Event
        private void btnInspection_Click(object sender, EventArgs e)
        {

        }

        private void btnOneShot_Click(object sender, EventArgs e)
        {

        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {

        }

        private void btnRecipeSave_Click(object sender, EventArgs e)
        {

        }

        private void btnLive_Click(object sender, EventArgs e)
        {

        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            kpCogDisplayMain.ClearDisplay();
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {

        }
        #endregion Control Event

        public bool LoadCogImage()
        {
            bool _Result = false;

            return _Result;
        }

        public void SaveCogImage()
        {

        }
    }
}
