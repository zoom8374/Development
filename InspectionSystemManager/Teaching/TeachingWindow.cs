using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InspectionSystemManager
{
    public partial class TeachingWindow : Form
    {
        private ContextMenu ContextMenuAlgo;

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


        #region Conext Menu Function
        private void PatternFindAlgorithm(object sender, EventArgs e)
        {
        }
        #endregion Conext Menu Function

        #region Button Event
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
    }
}
