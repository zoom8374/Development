using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;

using ParameterManager;

namespace InspectionSystemManager
{
    public partial class TeachingWindow : Form
    {
        private CogImage8Grey InspectionImage = new CogImage8Grey();
        private int InspectionImageWidth = 0;
        private int InspectionImageHeight = 0;

        private ContextMenu ContextMenuAlgo;

        private eTeachStep CurrentTeachStep;

        private int InspAreaSelected = -1;
        private int InspAlgoSelected = -1;

        #region Initialize & DeInitialize
        public TeachingWindow()
        {
            InitializeComponent();
            InitializeContextMenu();
        }

        public void Initialize()
        {

        }

        public void DeInitialize()
        {

        }

        private void InitializeContextMenu()
        {
            ContextMenuAlgo = new ContextMenu();
            ContextMenuAlgo.MenuItems.Clear();

            ContextMenuAlgo.MenuItems.Add("Search a reference", new EventHandler(PatternFindAlgorithm));
        }
        #endregion Initialize & DeInitialize

        #region Conext Menu Function
        private void PatternFindAlgorithm(object sender, EventArgs e)
        {
        }
        #endregion Conext Menu Function

        #region Button Event
        private void btnInspectionAreaAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAreaDel_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAreaCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAreaSet_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAlgoAdd_MouseUp(object sender, MouseEventArgs e)
        {
            Point _Position = new Point(e.X, e.Y);

            if (labelStatus.Text.Contains("Area Set") == false) { MessageBox.Show("Not set inspection area."); return; }

            ContextMenuAlgo.Show(btnInspectionAlgoAdd, _Position);

            UpdateTeachingStatus(eTeachStep.ALGO_CLEAR);
        }

        private void btnInspectionAlgoDel_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAlgoCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAlgoSet_Click(object sender, EventArgs e)
        {

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
        #endregion Button Event


        #region Teaching Parameter Set & UI Setting
        public void SetTeachingImage(CogImage8Grey _InspectionImage, int _Width, int _Height)
        {
            InspectionImage = _InspectionImage;
            InspectionImageWidth = _Width;
            InspectionImageHeight = _Height;

            kpTeachDisplay.SetDisplayImage(InspectionImage);
        }


        private void UpdateTeachingStatus(eTeachStep _TeachStep)
        {
            string _AreaSelectMsg = String.Format("Area{0} Select", InspAreaSelected + 1);
            string _AreaSetMsg = String.Format(" >> Area Set");
            string _AlgoSelectMsg = String.Format(" >> Algo{0} Select", InspAlgoSelected + 1);
            string _AlgoSetMsg = String.Format(" >> Algo Set");

            switch (_TeachStep)
            {
                case eTeachStep.AREA_CLEAR:     labelStatus.Text = ""; break;
                case eTeachStep.AREA_SELECT:    labelStatus.Text = _AreaSelectMsg; break;
                case eTeachStep.AREA_SET:       labelStatus.Text = _AreaSelectMsg + _AreaSetMsg; break;
                case eTeachStep.ALGO_CLEAR:     labelStatus.Text = _AreaSelectMsg + _AreaSetMsg; break;
                case eTeachStep.ALGO_SELECT:    labelStatus.Text = _AreaSelectMsg + _AreaSetMsg + _AlgoSelectMsg; break;
                case eTeachStep.ALGO_SET:       labelStatus.Text = _AreaSelectMsg + _AreaSetMsg + _AlgoSelectMsg + _AlgoSetMsg; break;
            }

            CurrentTeachStep = _TeachStep;
        }
        #endregion Teaching Parameter Set & UI Setting
    }
}
