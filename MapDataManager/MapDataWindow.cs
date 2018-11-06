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
        private MapDataParameter MapDataParamBackup;

        public delegate void MapDataParameterSaveHandler(MapDataParameter _MapDataParam, int _ID);
        public event MapDataParameterSaveHandler MapDataParameterSaveEvent;

        #region Initialize & DeInitialize
        public MapDataWindow()
        {
            InitializeComponent();
        }

        public void Initialize(MapDataParameter _MapDataParam)
        {
            SetMapDataParameter(_MapDataParam);
        }

        public void DeInitialize()
        {

        }

        private void SetMapDataParameter(MapDataParameter _MapDataParam)
        {
            MapDataParam = new MapDataParameter();
            MapDataParamBackup = new MapDataParameter();
            CParameterManager.RecipeCopy(_MapDataParam, ref MapDataParam);
            CParameterManager.RecipeCopy(_MapDataParam, ref MapDataParamBackup);
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

        private void btnUnitPatternAreaShow_Click(object sender, EventArgs e)
        {
            btnUnitPatternSearchAreaShow.Enabled = false;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternSearchAreaCancel.Enabled = false;
            btnUnitPatternAreaShow.Enabled = false;
            btnUnitPatternAreaSet.Enabled = true;
            btnUnitPatternAreaCancel.Enabled = true;

            CogRectangle _PatternRegion = new CogRectangle();
            CogRectangle _PatternSearchRegion = new CogRectangle();
            _PatternRegion.SetCenterWidthHeight(MapDataParam.UnitPatternAreaCenterX, MapDataParam.UnitPatternAreaCenterY, MapDataParam.UnitPatternAreaWidth, MapDataParam.UnitPatternAreaHeight);
            _PatternSearchRegion.SetCenterWidthHeight(MapDataParam.UnitSearchAreaCenterX, MapDataParam.UnitSearchAreaCenterY, MapDataParam.UnitSearchAreaWidth, MapDataParam.UnitSearchAreaHeight);

            kpTeachDisplay.ClearDisplay();
            kpTeachDisplay.DrawInterActiveShape(_PatternRegion, "PatternRegion", CogColorConstants.Green);
            kpTeachDisplay.DrawStaticShape(_PatternSearchRegion, "PatternSearchRegion", CogColorConstants.Orange, 2, CogGraphicLineStyleConstants.Dash);
        }

        private void btnUnitPatternAreaSet_Click(object sender, EventArgs e)
        {
            btnUnitPatternSearchAreaShow.Enabled = true;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternSearchAreaCancel.Enabled = false;
            btnUnitPatternAreaShow.Enabled = true;
            btnUnitPatternAreaSet.Enabled = false;
            btnUnitPatternAreaCancel.Enabled = false;

            double _CenterX, _CenterY, _Width, _Height;
            CogRectangle _PatternRegion = kpTeachDisplay.GetInterActiveRectangle();
            _PatternRegion.GetCenterWidthHeight(out _CenterX, out _CenterY, out _Width, out _Height);

            kpTeachDisplay.ClearDisplay("PatternRegion");
            kpTeachDisplay.DrawStaticShape(_PatternRegion, "PatternRegion", CogColorConstants.Green, 2, CogGraphicLineStyleConstants.Dash);

            MapDataParam.UnitPatternAreaCenterX = _CenterX;
            MapDataParam.UnitPatternAreaCenterY = _CenterY;
            MapDataParam.UnitPatternAreaWidth = _Width;
            MapDataParam.UnitPatternAreaHeight = _Height;
        }

        private void btnUnitPatternSearchAreaCancel_Click(object sender, EventArgs e)
        {
            btnUnitPatternSearchAreaShow.Enabled = true;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternSearchAreaCancel.Enabled = false;
            btnUnitPatternAreaShow.Enabled = true;
            btnUnitPatternAreaSet.Enabled = false;
            btnUnitPatternAreaCancel.Enabled = false;

            kpTeachDisplay.ClearDisplay();
        }

        private void btnUnitPatternSearchAreaShow_Click(object sender, EventArgs e)
        {
            btnUnitPatternSearchAreaShow.Enabled = false;
            btnUnitPatternSearchAreaSet.Enabled = true;
            btnUnitPatternSearchAreaCancel.Enabled = true;
            btnUnitPatternAreaShow.Enabled = false;
            btnUnitPatternAreaSet.Enabled = false;
            btnUnitPatternAreaCancel.Enabled = false;

            CogRectangle _PatternRegion = new CogRectangle();
            CogRectangle _PatternSearchRegion = new CogRectangle();
            _PatternRegion.SetCenterWidthHeight(MapDataParam.UnitPatternAreaCenterX, MapDataParam.UnitPatternAreaCenterY, MapDataParam.UnitPatternAreaWidth, MapDataParam.UnitPatternAreaHeight);
            _PatternSearchRegion.SetCenterWidthHeight(MapDataParam.UnitSearchAreaCenterX, MapDataParam.UnitSearchAreaCenterY, MapDataParam.UnitSearchAreaWidth, MapDataParam.UnitSearchAreaHeight);

            kpTeachDisplay.ClearDisplay();
            kpTeachDisplay.DrawInterActiveShape(_PatternSearchRegion, "PatternSearchRegion", CogColorConstants.Orange);
            kpTeachDisplay.DrawStaticShape(_PatternRegion, "PatternRegion", CogColorConstants.Green, 2, CogGraphicLineStyleConstants.Dash);
        }

        private void btnUnitPatternSearchAreaSet_Click(object sender, EventArgs e)
        {
            btnUnitPatternSearchAreaShow.Enabled = true;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternSearchAreaCancel.Enabled = false;
            btnUnitPatternAreaShow.Enabled = true;
            btnUnitPatternAreaSet.Enabled = false;
            btnUnitPatternAreaCancel.Enabled = false;

            double _CenterX, _CenterY, _Width, _Height;
            CogRectangle _PatternSearchRegion = kpTeachDisplay.GetInterActiveRectangle();

            _PatternSearchRegion.GetCenterWidthHeight(out _CenterX, out _CenterY, out _Width, out _Height);

            kpTeachDisplay.ClearDisplay("PatternSearchRegion");
            kpTeachDisplay.DrawStaticShape(_PatternSearchRegion, "PatternSearchRegion", CogColorConstants.Orange, 2, CogGraphicLineStyleConstants.Dash);

            MapDataParam.UnitSearchAreaCenterX = _CenterX;
            MapDataParam.UnitSearchAreaCenterY = _CenterY;
            MapDataParam.UnitSearchAreaWidth = _Width;
            MapDataParam.UnitSearchAreaHeight = _Height;
        }

        private void btnUnitPatternAreaCancel_Click(object sender, EventArgs e)
        {
            btnUnitPatternSearchAreaShow.Enabled = true;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternSearchAreaCancel.Enabled = false;
            btnUnitPatternAreaShow.Enabled = true;
            btnUnitPatternAreaSet.Enabled = false;
            btnUnitPatternAreaCancel.Enabled = false;

            kpTeachDisplay.ClearDisplay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _ID = 0; //ID 확인 UI 추가 필요

            var _MapDataParameterSaveEvent = MapDataParameterSaveEvent;
            MapDataParameterSaveEvent?.Invoke(MapDataParam, _ID);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion Control Event
    }
}
