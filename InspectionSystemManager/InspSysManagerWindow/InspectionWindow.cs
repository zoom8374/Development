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
using Cognex.VisionPro.ImageFile;

using LogMessageManager;
using ParameterManager;

namespace InspectionSystemManager
{
    public partial class InspectionWindow : Form
    {
        private TeachingWindow TeachWnd;
        private InspectionParameter InspParam = new InspectionParameter();

        private int ID;
        private eProjectType ProjectType;
        private eProjectItem ProjectItem;
        private string FormName;
        private bool ResizingFlag = false;
        private bool IsResizing = false;
        private Point LastPosition = new Point(0, 0);

        private CogImageFileTool OriginImageFileTool = new CogImageFileTool();
        private CogImage8Grey    OriginImage = new CogImage8Grey();

        private int ImageSizeWidth = 0;
        private int ImageSizeHeight = 0;
        private bool IsCrossLine = false;

        private double DisplayZoomValue = 1;
        private double DisplayPanXValue = 0;
        private double DisplayPanYValue = 0;

        public bool IsInspectionComplete = false;


        public delegate void InspectionWindowHandler(eIWCMD _Command, object _Value = null);
        public event InspectionWindowHandler InspectionWindowEvent;


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

        public void Initialize(Object _OwnerForm, int _ID, InspectionParameter _InspParam, eProjectItem _ProjectItem, string _FormName)
        {
            ID = _ID;
            ProjectItem = _ProjectItem;
            FormName = _FormName;
            
            this.labelTitle.Text = _FormName;
            this.Owner = (Form)_OwnerForm;

            TeachWnd = new TeachingWindow();
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
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM{0} Inspection Run", ID + 1));
        }

        private void btnOneShot_Click(object sender, EventArgs e)
        {
            CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM{0} One-Shot Inspection Run", ID + 1));
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            InspectionWindowEvent(eIWCMD.TEACHING, true);
            Teaching();
            InspectionWindowEvent(eIWCMD.TEACHING, false);
        }

        private void btnRecipeSave_Click(object sender, EventArgs e)
        {
            InspectionWindowEvent(eIWCMD.TEACH_SAVE);
        }

        private void btnLive_Click(object sender, EventArgs e)
        {

        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            LoadCogImage();
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {
            SaveCogImage();
        }
        #endregion Control Event

        private string LoadCogImage()
        {
            string _ImageFileName = "";
            string _ImageFilePath = "";

            OpenFileDialog _OpenDialog = new OpenFileDialog();
            _OpenDialog.InitialDirectory = @"D:\VisionInspectionData";
            _OpenDialog.Filter = "BmpFile (*.bmp)|*.bmp";

            try
            {
                if (_OpenDialog.ShowDialog() == DialogResult.OK)
                {
                    _ImageFileName = _OpenDialog.SafeFileName;
                    _ImageFilePath = _OpenDialog.FileName;
                    OriginImageFileTool.Operator.Open(_ImageFilePath, CogImageFileModeConstants.Read);
                    OriginImageFileTool.Run();
                    OriginImage = (CogImage8Grey)OriginImageFileTool.OutputImage;

                    SetDisplayImage(OriginImage);
                } 
            }

            catch
            {
                MessageBox.Show(new Form { TopMost = true }, "Could not open image file.");
            }

            return _ImageFileName;
        }

        private void SaveCogImage(string _SaveDirectory = null)
        {
            if (_SaveDirectory == null) _SaveDirectory = @"D:\VisionInspectionData\" + FormName;
            kpCogDisplayMain.SaveDisplayImage(_SaveDirectory);
        }

        private void Teaching()
        {
            TeachWnd = new TeachingWindow();
            TeachWnd.Initialize(ID, InspParam, ProjectItem);

            TeachWnd.SetTeachingImage(OriginImage, OriginImage.Width, OriginImage.Height);
            TeachWnd.ShowDialog();
            
            if (DialogResult.OK == TeachWnd.DialogResult)
            {
                //Teaching 한 Recipe Update
                InspectionWindowEvent(eIWCMD.TEACH_OK, TeachWnd.GetInspectionParameter());
            }
            TeachWnd.DeInitialize();
            TeachWnd.Dispose();
            GC.Collect();
        }

        private bool Inspection()
        {
            bool _Result = false;

            IsInspectionComplete = false;

            do
            {
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - Inspection Start", ID));
                if (false == InspectionResultClear()) break;
                if (false == InspectionProcess()) break;
                if (false == InspectionResultDsiplay()) break;

                _Result = true;
                CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - Inspection End", ID));
            } while (false);

            GC.Collect();

            //CLogManager.AddInspectionLog(CLogManager.LOG_TYPE.INFO, String.Format("ISM {0} - Inspection Result : {1}", ID, ));
            return _Result;
        }

        private bool InspectionResultClear()
        {
            bool _Result = true;

            return _Result;
        }

        private bool InspectionProcess()
        {
            bool _Result = true;

            return _Result;
        }

        private bool InspectionResultDsiplay()
        {
            bool _Result = true;

            return _Result;
        }
    }
}
