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

        private CogImage8Grey OriginImage;
        private InspectionPattern InspPattern;

        private CogRectangle SelectingRect;
        private CogRectangle SelectedRect;
        private string SelectingRectName;
        private string SelectedRectName;
        private bool IsDrawPatterns;

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
            InspPattern = new InspectionPattern();

            SelectingRect = null;
            SelectedRect = null;
            kpTeachDisplay.MousePointEvent += new KPDisplay.KPCogDisplayControl.MousePointHandler(TeachDisplayDownEventFunction);
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

            numUpDownUnitRowCount.Value = Convert.ToDecimal(MapDataParam.UnitRowCount);
            numUpDownUnitColumnCount.Value = Convert.ToDecimal(MapDataParam.UnitColumnCount);
            numUpDownSectionRowCount.Value = Convert.ToDecimal(MapDataParam.SectionRowCount);
            numUpDownSectionColumnCount.Value = Convert.ToDecimal(MapDataParam.SectionColumnCount);
            numericUpDownFindCount.Value = Convert.ToDecimal(MapDataParam.FindCount);
            numericUpDownFindScore.Value = Convert.ToDecimal(MapDataParam.FindScore);
            numericUpDownAngleLimit.Value = Convert.ToDecimal(MapDataParam.AngleLimit);

            chAreaAutoSearch.Checked    = Convert.ToBoolean(MapDataParam.MapDataTeachingMode);
            chAreaManualSearch.Checked  = !Convert.ToBoolean(MapDataParam.MapDataTeachingMode);

            if (true == MapDataParam.UnitPattern.Trained)
                kpPatternDisplay.SetDisplayImage((CogImage8Grey)MapDataParam.UnitPattern.GetTrainedPatternImage());
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
            OriginImage = _OriginImage;
            kpTeachDisplay.SetDisplayImage(_OriginImage);
        }

        private void btnUnitPatternAreaShow_Click(object sender, EventArgs e)
        {
            #region Button Status
            btnUnitPatternSearchAreaShow.Enabled = false;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternOriginCenterSet.Enabled = true;
            btnUnitPatternAreaShow.Enabled = false;
            btnUnitPatternAreaSet.Enabled = true;
            //btnUnitPatternAreaCancel.Enabled = true;
            #endregion Button Status

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
            #region Button Status
            btnUnitPatternSearchAreaShow.Enabled = true;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternOriginCenterSet.Enabled = false;
            btnUnitPatternAreaShow.Enabled = true;
            btnUnitPatternAreaSet.Enabled = false;
            //btnUnitPatternAreaCancel.Enabled = false;
            #endregion Button Status

            CogRectangle _PatternRegion = kpTeachDisplay.GetInterActiveRectangle();
            CogPointMarker _PatternOrigin = new CogPointMarker();
            _PatternOrigin.SetCenterRotationSize(_PatternRegion.CenterX, _PatternRegion.CenterY, 0, 2);

            kpTeachDisplay.ClearDisplay("PatternRegion");
            kpTeachDisplay.ClearDisplay("PatternOriginPoint");
            kpTeachDisplay.DrawStaticShape(_PatternRegion, "PatternRegion", CogColorConstants.Green, 2, CogGraphicLineStyleConstants.Dash);
            kpTeachDisplay.DrawStaticShape(_PatternOrigin, "PatternOriginPoint", CogColorConstants.Green, 14);

            MapDataParam.UnitPatternAreaCenterX = _PatternRegion.CenterX;
            MapDataParam.UnitPatternAreaCenterY = _PatternRegion.CenterY;
            MapDataParam.UnitPatternAreaWidth = _PatternRegion.Width;
            MapDataParam.UnitPatternAreaHeight = _PatternRegion.Height;
            MapDataParam.UnitPatternAreaOriginX = _PatternOrigin.X;
            MapDataParam.UnitPatternAreaOriginY = _PatternOrigin.Y;

            //Pattern 등록
            CogPMAlignPattern _Pattern = InspPattern.GetPatternReference(OriginImage, _PatternRegion, _PatternOrigin.X, _PatternOrigin.Y);
            kpPatternDisplay.SetDisplayImage((CogImage8Grey)_Pattern.GetTrainedPatternImage());
            MapDataParam.UnitPattern = _Pattern;

            SelectingRectName = SelectedRectName = "";
            IsDrawPatterns = false;
        }

        private void btnUnitPatternOriginCenterSet_Click(object sender, EventArgs e)
        {
            CogRectangle _PatternRegion = kpTeachDisplay.GetInterActiveRectangle();
            CogPointMarker _PatternOrigin = new CogPointMarker();
            _PatternOrigin.SetCenterRotationSize(_PatternRegion.CenterX, _PatternRegion.CenterY, 0, 2);

            kpTeachDisplay.ClearDisplay("PatternOriginPoint");
            kpTeachDisplay.DrawInterActiveShape(_PatternOrigin, "PatternOriginPoint", CogColorConstants.Green, 14);
        }

        private void btnUnitPatternSearchAreaShow_Click(object sender, EventArgs e)
        {
            #region Button Status
            btnUnitPatternSearchAreaShow.Enabled = false;
            btnUnitPatternSearchAreaSet.Enabled = true;
            btnUnitPatternOriginCenterSet.Enabled = false;
            btnUnitPatternAreaShow.Enabled = false;
            btnUnitPatternAreaSet.Enabled = false;
            //btnUnitPatternAreaCancel.Enabled = false;
            #endregion Button Status

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
            #region Button Status
            btnUnitPatternSearchAreaShow.Enabled = true;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternOriginCenterSet.Enabled = false;
            btnUnitPatternAreaShow.Enabled = true;
            btnUnitPatternAreaSet.Enabled = false;
            //btnUnitPatternAreaCancel.Enabled = false;
            #endregion Button Status

            CogRectangle _PatternSearchRegion = kpTeachDisplay.GetInterActiveRectangle();
            kpTeachDisplay.ClearDisplay("PatternSearchRegion");
            kpTeachDisplay.DrawStaticShape(_PatternSearchRegion, "PatternSearchRegion", CogColorConstants.Orange, 2, CogGraphicLineStyleConstants.Dash);
            MapDataParam.UnitSearchAreaCenterX = _PatternSearchRegion.CenterX;
            MapDataParam.UnitSearchAreaCenterY = _PatternSearchRegion.CenterY;
            MapDataParam.UnitSearchAreaWidth = _PatternSearchRegion.Width;
            MapDataParam.UnitSearchAreaHeight = _PatternSearchRegion.Height;

            SelectingRectName = SelectedRectName = "";
            IsDrawPatterns = false;
        }

        private void btnUnitPatternAreaCancel_Click(object sender, EventArgs e)
        {
            #region Button Status
            btnUnitPatternSearchAreaShow.Enabled = true;
            btnUnitPatternSearchAreaSet.Enabled = false;
            btnUnitPatternOriginCenterSet.Enabled = false;
            btnUnitPatternAreaShow.Enabled = true;
            btnUnitPatternAreaSet.Enabled = false;
            //btnUnitPatternAreaCancel.Enabled = false;
            #endregion Button Status

            kpTeachDisplay.ClearDisplay();
            SelectingRectName = SelectedRectName = "";
            IsDrawPatterns = false;
        }

        private void btnFindSearchArea_Click(object sender, EventArgs e)
        {
            double _OffsetX = MapDataParam.UnitPatternAreaOriginX - MapDataParam.UnitPatternAreaCenterX;
            double _OffsetY = MapDataParam.UnitPatternAreaOriginY - MapDataParam.UnitPatternAreaCenterY;

            InspPattern.SetPatternReference(MapDataParam.UnitPattern);
            InspPattern.SetMatchingParameter(MapDataParam.FindCount, MapDataParam.FindScore);

            if (false == InspPattern.Run(OriginImage)) { MessageBox.Show("Pattern Not Found"); return; }

            CogPMAlignResults _PatternResult = InspPattern.GetResults();
            MapDataParam.UnitListCenterX.Clear();
            MapDataParam.UnitListCenterY.Clear();
            MapDataParam.UnitListWidth.Clear();
            MapDataParam.UnitListHeight.Clear();
            if (_PatternResult.Count > 0)
            {
                double[] _OriginX, _OriginY, _CenterX, _CenterY, _Width, _Height;
                _OriginX = new double[_PatternResult.Count];
                _OriginY = new double[_PatternResult.Count];
                _CenterX = new double[_PatternResult.Count];
                _CenterY = new double[_PatternResult.Count];
                _Width   = new double[_PatternResult.Count];
                _Height  = new double[_PatternResult.Count];

                for (int iLoopCount = 0; iLoopCount < _PatternResult.Count; ++iLoopCount)
                {
                    _OriginX[iLoopCount] = _PatternResult[iLoopCount].GetPose().TranslationX;
                    _OriginY[iLoopCount] = _PatternResult[iLoopCount].GetPose().TranslationY;
                    _CenterX[iLoopCount] = _PatternResult[iLoopCount].GetPose().TranslationX - _OffsetX;
                    _CenterY[iLoopCount] = _PatternResult[iLoopCount].GetPose().TranslationY - _OffsetY;
                    _Width[iLoopCount]  = _PatternResult.GetTrainArea().Width;
                    _Height[iLoopCount] = _PatternResult.GetTrainArea().Height;

                    CogRectangle _FindPattern = new CogRectangle();
                    _FindPattern.SetCenterWidthHeight(_CenterX[iLoopCount], _CenterY[iLoopCount], MapDataParam.UnitSearchAreaWidth, MapDataParam.UnitSearchAreaHeight);
                    kpTeachDisplay.DrawStaticShape(_FindPattern, "SearchArea" + (iLoopCount + 1));

                    CogPointMarker _OriginPoint = new CogPointMarker();
                    _OriginPoint.SetCenterRotationSize(_OriginX[iLoopCount], _OriginY[iLoopCount], 0, 2);
                    kpTeachDisplay.DrawStaticShape(_OriginPoint, "PatternOrigin" + (iLoopCount + 1), CogColorConstants.Green, 12);

                    MapDataParam.UnitListCenterX.Add(_CenterX[iLoopCount]);
                    MapDataParam.UnitListCenterY.Add(_CenterY[iLoopCount]);
                    MapDataParam.UnitListWidth.Add(_Width[iLoopCount]);
                    MapDataParam.UnitListHeight.Add(_Height[iLoopCount]);
                }
            }

            SelectingRectName = SelectedRectName = "";
            IsDrawPatterns = true;
            MessageBox.Show("Pattern Find Complete");
        }

        private void btnShowSearchArea_Click(object sender, EventArgs e)
        {
            if (MapDataParam.UnitListCenterX == null || MapDataParam.UnitListCenterY == null) return;
            if (MapDataParam.UnitListCenterX.Count == 0 || MapDataParam.UnitListCenterY.Count == 0) return;
            if (MapDataParam.UnitListCenterX.Count != MapDataParam.UnitListCenterY.Count) return;

            kpTeachDisplay.ClearDisplay();
            for (int iLoopCount = 0; iLoopCount < MapDataParam.UnitListCenterX.Count; ++iLoopCount)
            {
                CogRectangle _FindPattern = new CogRectangle();
                _FindPattern.SetCenterWidthHeight(MapDataParam.UnitListCenterX[iLoopCount], MapDataParam.UnitListCenterY[iLoopCount], 
                                                  MapDataParam.UnitListWidth[iLoopCount], MapDataParam.UnitListHeight[iLoopCount]);
                kpTeachDisplay.DrawStaticShape(_FindPattern, "SearchArea" + (iLoopCount + 1));

                CogPointMarker _OriginPoint = new CogPointMarker();
                _OriginPoint.SetCenterRotationSize(MapDataParam.UnitListCenterX[iLoopCount], MapDataParam.UnitListCenterY[iLoopCount], 0, 2);
                kpTeachDisplay.DrawStaticShape(_OriginPoint, "PatternOrigin" + (iLoopCount + 1), CogColorConstants.Green, 12);
            }

            SelectingRectName = SelectedRectName = "";
            IsDrawPatterns = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _ID = 0; //ID 확인 UI 추가 필요

            MapDataParam.UnitRowCount = Convert.ToUInt32(numUpDownUnitRowCount.Value);
            MapDataParam.UnitColumnCount = Convert.ToUInt32(numUpDownUnitColumnCount.Value);
            MapDataParam.SectionRowCount = Convert.ToUInt32(numUpDownSectionRowCount.Value);
            MapDataParam.SectionColumnCount = Convert.ToUInt32(numUpDownSectionColumnCount.Value);
            MapDataParam.FindCount = Convert.ToUInt32(numericUpDownFindCount.Value);
            MapDataParam.FindScore = Convert.ToDouble(numericUpDownFindScore.Value);
            MapDataParam.AngleLimit = Convert.ToDouble(numericUpDownAngleLimit.Value);
            MapDataParam.UnitTotalCount = Convert.ToUInt32(txtUnitTotalCount.Text);
            MapDataParam.MapDataTeachingMode = Convert.ToInt32(chAreaAutoSearch.Checked);

            var _MapDataParameterSaveEvent = MapDataParameterSaveEvent;
            _MapDataParameterSaveEvent?.Invoke(MapDataParam, _ID);
        }

        private void btnManualSearchArea_Click(object sender, EventArgs e)
        {
            CogRectangle _WholePatternRegion = new CogRectangle();
            _WholePatternRegion.SetCenterWidthHeight(MapDataParam.WholeSearchAreaCenterX, MapDataParam.WholeSearchAreaCenterY,
                                                     MapDataParam.WholeSearchAreaWidth, MapDataParam.WholeSearchAreaHeight);

            kpTeachDisplay.ClearDisplay();
            kpTeachDisplay.DrawInterActiveShape(_WholePatternRegion, "WholePatternRegion", CogColorConstants.Orange);
        }

        private void btnManualSearchAreaSet_Click(object sender, EventArgs e)
        {
            uint _RowCount = Convert.ToUInt32(numUpDownUnitRowCount.Value);
            uint _ColCount = Convert.ToUInt32(numUpDownUnitColumnCount.Value);

            CogRectangle _WholePatternRegion = kpTeachDisplay.GetInterActiveRectangle();
            MapDataParam.WholeSearchAreaCenterX = _WholePatternRegion.CenterX;
            MapDataParam.WholeSearchAreaCenterY = _WholePatternRegion.CenterY;
            MapDataParam.WholeSearchAreaWidth = _WholePatternRegion.Width;
            MapDataParam.WholeSearchAreaHeight = _WholePatternRegion.Height;

            double _Width, _Height;
            _Width = _WholePatternRegion.Width / _ColCount;
            _Height = _WholePatternRegion.Height / _RowCount;

            double _StartCenterPointX, _StartCenterPointY, _CenterPointX, _CenterPointY;
            _StartCenterPointX = _WholePatternRegion.X + _Width / 2;
            _StartCenterPointY = _WholePatternRegion.Y + _Height / 2;

            kpTeachDisplay.ClearDisplay();
            MapDataParam.UnitListCenterX.Clear();
            MapDataParam.UnitListCenterY.Clear();
            MapDataParam.UnitListWidth.Clear();
            MapDataParam.UnitListHeight.Clear();
            CogRectangle[,] _PatternRegions = new CogRectangle[_RowCount, _ColCount];
            for (int iLoopCount = 0; iLoopCount < _RowCount; ++iLoopCount)
            {
                _CenterPointY = _StartCenterPointY + (_Height * iLoopCount);
                for (int jLoopCount = 0; jLoopCount < _ColCount; ++jLoopCount)
                {
                    _CenterPointX = _StartCenterPointX + (_Width * jLoopCount);

                    _PatternRegions[iLoopCount, jLoopCount] = new CogRectangle();
                    _PatternRegions[iLoopCount, jLoopCount].SetCenterWidthHeight(_CenterPointX, _CenterPointY, _Width, _Height);

                    MapDataParam.UnitListCenterX.Add(_PatternRegions[iLoopCount, jLoopCount].CenterX);
                    MapDataParam.UnitListCenterY.Add(_PatternRegions[iLoopCount, jLoopCount].CenterY);
                    MapDataParam.UnitListWidth.Add(_PatternRegions[iLoopCount, jLoopCount].Width);
                    MapDataParam.UnitListHeight.Add(_PatternRegions[iLoopCount, jLoopCount].Height);

                    //kpTeachDisplay.DrawStaticShape(_PatternRegions[iLoopCount, jLoopCount], "SearchArea" + (iLoopCount + 1) + (jLoopCount + 1));
                }
            }

            btnShowSearchArea_Click(null, null);
        }

        private void numUpDownUnitRowCount_ValueChanged(object sender, EventArgs e)
        {
            txtUnitTotalCount.Text = (Convert.ToInt32(numUpDownUnitRowCount.Value) * Convert.ToInt32(numUpDownUnitColumnCount.Value)).ToString();
        }

        private void numUpDownUnitColumnCount_ValueChanged(object sender, EventArgs e)
        {
            txtUnitTotalCount.Text = (Convert.ToInt32(numUpDownUnitRowCount.Value) * Convert.ToInt32(numUpDownUnitColumnCount.Value)).ToString();
        }

        private void chAreaAutoSearch_CheckedChanged(object sender, EventArgs e)
        {
            chAreaManualSearch.Checked = !chAreaAutoSearch.Checked;

            if (true == chAreaAutoSearch.Checked)
            {
                //panel2.Visible = true;
                //panel3.Visible = false;
                //panel2.Location = new Point(639, 404);
            }
        }

        private void chAreaManualSearch_CheckedChanged(object sender, EventArgs e)
        {
            chAreaAutoSearch.Checked = !chAreaManualSearch.Checked;

            if (true == chAreaManualSearch.Checked)
            {
                //panel2.Visible = false;
                //panel3.Visible = true;
                //panel3.Location = new Point(639, 404);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CParameterManager.RecipeCopy(MapDataParamBackup, ref MapDataParam);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion Control Event

        private void TeachDisplayDownEventFunction(Point _MousePoint)
        {
            if (false == IsDrawPatterns) return;
            if (MapDataParam.UnitListCenterX == null || MapDataParam.UnitListCenterY == null) return;
            if (MapDataParam.UnitListCenterX.Count == 0 || MapDataParam.UnitListCenterY.Count == 0) return;
            if (MapDataParam.UnitListCenterX.Count != MapDataParam.UnitListCenterY.Count) return;

            for (int iLoopCount = 0; iLoopCount < MapDataParam.UnitListCenterX.Count; ++iLoopCount)
            {
                Rectangle _Rect = new Rectangle((int)MapDataParam.UnitListCenterX[iLoopCount] - (int)(MapDataParam.UnitSearchAreaWidth / 2), (int)(MapDataParam.UnitListCenterY[iLoopCount] - MapDataParam.UnitSearchAreaHeight / 2), 
                                                (int)MapDataParam.UnitListWidth[iLoopCount], (int)MapDataParam.UnitListHeight[iLoopCount]);
                if (true == _Rect.Contains(_MousePoint.X, _MousePoint.Y))
                {
                    //현재 클릭한 Rect 정보
                    SelectingRect = new CogRectangle();
                    SelectingRect.SetCenterWidthHeight(MapDataParam.UnitListCenterX[iLoopCount], MapDataParam.UnitListCenterY[iLoopCount], 
                                                       MapDataParam.UnitListWidth[iLoopCount], MapDataParam.UnitListHeight[iLoopCount]);
                    SelectingRectName = "SearchArea" + (iLoopCount + 1);

                    if (SelectingRectName != SelectedRectName)
                    {
                        kpTeachDisplay.DrawStaticShape(SelectingRect, SelectingRectName, CogColorConstants.Orange);

                        if (SelectedRectName != "" && SelectedRectName != null)
                            kpTeachDisplay.DrawStaticShape(SelectedRect, SelectedRectName, CogColorConstants.Green);

                        SelectedRect = new CogRectangle(SelectingRect);
                        SelectedRectName = SelectingRectName;
                    }
                }
            }
        }
    }
}
