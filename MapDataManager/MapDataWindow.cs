using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;

using ParameterManager;

namespace MapDataManager
{
    public partial class MapDataWindow : Form
    {
        private MapDataParameter MapDataParam;

        #region Initialize & DeInitialize
        public MapDataWindow()
        {
            InitializeComponent();
        }

        public void Initialize(MapDataParameter _MapDataParam)
        {
            MapDataParam = new MapDataParameter();
        }

        public void DeInitialize()
        {

        }
        #endregion Initialize & DeInitialize

        #region Control Default Event

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            s.Tag = new Point(e.X, e.Y);
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);

            this.Cursor = Cursors.Default;
        }

        private void labelTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.labelTitle.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        #endregion Control Default Event

        #region Control Event
        public void SetMapDataImage(CogImage8Grey _OriginImage)
        {
            kpTeachDisplay.SetDisplayImage(_OriginImage);
        }

        private void btnUnitPatternShow_Click(object sender, EventArgs e)
        {

        }

        private void btnUnitPatternSet_Click(object sender, EventArgs e)
        {

        }

        private void btnUnitPatternAreaShow_Click(object sender, EventArgs e)
        {

        }

        private void btnUnitPatternAreaSet_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion Control Event

    }
}
