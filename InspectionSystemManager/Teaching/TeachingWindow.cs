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
        private enum eAreaList  { ID = 0, NAME, BENCHMARK, ENABLE, NGNUMBER };
        private enum eAlgoList  { ID = 0, NAME, BENCHMARK, ENABLE };
        private enum eTeachStep { AREA_SELECT = 0, AREA_SET, AREA_CLEAR, ALGO_SELECT, ALGO_SET, ALGO_CLEAR };

        private CogImage8Grey InspectionImage = new CogImage8Grey();
        private int InspectionImageWidth = 0;
        private int InspectionImageHeight = 0;
        private double InspectionAreaWidth;
        private double InspectionAreaHeight;

        private ContextMenu     ContextMenuAlgo;
        private eTeachStep      CurrentTeachStep;
        private eProjectItem    ProjectItem;

        private InspectionParameter InspParam;
        private int InspAreaSelected = -1;
        private int InspAlgoSelected = -1;

        private AreaResultParameterList AreaResParamList;   //검사 결과를 Teaching시에 적용하기 위해
        private AlgoResultParameterList AlgoResParamList;   //검사 결과를 Teaching시에 적용하기 위해
        private double AreaOffsetX;
        private double AreaOffsetY;
        private double AlgoOffsetX;
        private double AlgoOffsetY;

        private double ResolutionX;
        private double ResolutionY;

        #region Initialize & DeInitialize
        public TeachingWindow()
        {
            InitializeComponent();
            InitializeContextMenu();
        }

        public void Initialize(int _ID = 0, InspectionParameter _InspParam = null, eProjectItem _ProjectItem = eProjectItem.NEEDLE_ALIGN)
        {
            string _WindowTextName = String.Format(" Vision{0} - Teaching Window", (_ID + 1));
            this.labelTitle.Text = _WindowTextName;
            this.labelStatus.Text = "";

            ProjectItem = _ProjectItem;

            SetInspectionParameter(_InspParam);
            SetResolution();

            InspAreaSelected = -1;
            InspAlgoSelected = -1;

            foreach (DataGridViewColumn _dataGridView in gridViewArea.Columns)
                _dataGridView.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataGridViewColumn _dataGridView in gridViewAlgo.Columns)
                _dataGridView.SortMode = DataGridViewColumnSortMode.NotSortable;

            InitializeEvent();
            GridViewAreaAndAlgoClear();
            UpdateInspectionAreaList();

            InitializeContextMenu();

            gridViewArea.ShowCellToolTips = false;
            gridViewAlgo.ShowCellToolTips = false;
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

        private void SetInspectionParameter(InspectionParameter _InspParam = null)
        {
            InspParam = new InspectionParameter();
            CParameterManager.RecipeCopy(_InspParam, ref InspParam);

            //Reference File Copy
        }

        private void SetResolution()
        {
            ResolutionX = InspParam.ResolutionX;
            ResolutionY = InspParam.ResolutionY;
        }

        public InspectionParameter GetInspectionParameter()
        {
            return InspParam;
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
            kpTeachDisplay.ClearDisplay();
            panelTeaching.Controls.Clear();
            panelTeaching.Controls.Add(labelTeaching);

            InspectionAreaParameter _InspAreaParam = new InspectionAreaParameter();
            InspParam.InspAreaParam.Add(_InspAreaParam);

            GridViewAreaAndAlgoClear();
            UpdateInspectionAreaList(InspParam.InspAreaParam.Count - 1);

            UpdateTeachingStatus(eTeachStep.AREA_CLEAR);
            gridViewAlgo.ClearSelection();
            gridViewAlgo.Rows.Clear();
        }

        private void btnInspectionAreaDel_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAreaCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnInspectionAreaSet_Click(object sender, EventArgs e)
        {
            if (gridViewArea.SelectedRows.Count == 0) { MessageBox.Show("Not selected inspection area."); return; }
            int _SelectedAreaNum = Convert.ToInt32(gridViewArea.SelectedRows[0].Cells[(int)eAreaList.ID].Value) - 1;
            if (_SelectedAreaNum < 0) { MessageBox.Show("Not selected inspection area."); return; }
            if (InspectionImageWidth == 0 || InspectionImageHeight == 0) return;

            InspAreaSelected = _SelectedAreaNum;
            
            //BenchMark Setting
            DataGridViewComboBoxCell _ComboCell = (DataGridViewComboBoxCell)gridViewArea[Convert.ToInt32(eAreaList.BENCHMARK), InspAreaSelected];
            InspParam.InspAreaParam[InspAreaSelected].AreaBenchMark = _ComboCell.Items.IndexOf(_ComboCell.Value);

            _ComboCell = (DataGridViewComboBoxCell)gridViewArea[Convert.ToInt32(eAreaList.NGNUMBER), InspAreaSelected];
            InspParam.InspAreaParam[InspAreaSelected].NgAreaNumber = _ComboCell.Items.IndexOf(_ComboCell.Value) + 1;

            DataGridViewCheckBoxCell _CheckCell = (DataGridViewCheckBoxCell)gridViewArea[Convert.ToInt32(eAreaList.ENABLE), InspAreaSelected];
            InspParam.InspAreaParam[InspAreaSelected].Enable = Convert.ToBoolean(_CheckCell.Value);

            CogRectangle _InspRegion = new CogRectangle();
            CogRectangle _Boundary = new CogRectangle();
            _Boundary.SetXYWidthHeight(0, 0, InspectionImageWidth, InspectionImageHeight);
            if (false == GetCorrectionRectangle(kpTeachDisplay, _Boundary, ref _InspRegion)) { MessageBox.Show("The rectangle is outside the inspection area."); return; }
            InspectionAreaWidth = Convert.ToInt32(_InspRegion.Width);
            InspectionAreaHeight = Convert.ToInt32(_InspRegion.Height);

            //Area 영역 설정 시 Area Offset 값 얻어오기
            GetAreaResultDataOffset(InspAreaSelected);

            kpTeachDisplay.ClearDisplay();
            kpTeachDisplay.DrawStaticShape(_InspRegion, "InspRegion", CogColorConstants.Green);
            panelTeaching.Controls.Clear();
            panelTeaching.Controls.Add(labelTeaching);

            //Area Setting
            InspParam.InspAreaParam[InspAreaSelected].AreaRegionCenterX = _InspRegion.CenterX - AreaOffsetX;
            InspParam.InspAreaParam[InspAreaSelected].AreaRegionCenterY = _InspRegion.CenterY - AreaOffsetY;
            InspParam.InspAreaParam[InspAreaSelected].AreaRegionWidth   = _InspRegion.Width;
            InspParam.InspAreaParam[InspAreaSelected].AreaRegionHeight  = _InspRegion.Height;

            UpdateInspectionAreaList(InspAreaSelected);
            gridViewArea.Rows[InspAreaSelected].Selected = true;

            UpdateInspectionAlgoList(InspAreaSelected);
            UpdateTeachingStatus(eTeachStep.AREA_SET);
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

        #region Inspection Area & Algorithm Gridview Update
        private void GridViewAreaAndAlgoClear()
        {
            gridViewArea.Rows.Clear();
            gridViewAlgo.Rows.Clear();
        }

        private void UpdateInspectionAreaList(int _Selected = -1, bool _IsNew = false)
        {
            gridViewArea.Rows.Clear();

            for (int iLoopCount = 0; iLoopCount < InspParam.InspAreaParam.Count; ++iLoopCount)
            {
                string _Index = (iLoopCount + 1).ToString();
                string _Name = "Area" + _Index;
                bool _Enable = InspParam.InspAreaParam[iLoopCount].Enable;

                AddInspectionArea(_Index, _Name, _Enable);
                gridViewArea.Rows[iLoopCount].Selected = false;
            }

            if (_Selected != -1)
            {
                gridViewArea.CurrentCell = gridViewArea.Rows[_Selected].Cells[0];
                gridViewArea.Rows[_Selected].Selected = true;

                UpdateInspectionAlgoList(_Selected, true);
                InspAreaSelected = _Selected;
            }
        }

        private void AddInspectionArea(string _Index, string _Name, bool _Enable)
        {
            DataGridViewCell[] _GridCell = new DataGridViewCell[5];
            _GridCell[0] = (DataGridViewCell)this.gridAreaID.CellTemplate.Clone();
            _GridCell[1] = (DataGridViewCell)this.gridAreaName.CellTemplate.Clone();
            _GridCell[2] = (DataGridViewCell)this.gridAreaBenchMark.CellTemplate.Clone();
            _GridCell[3] = (DataGridViewCell)this.gridAreaEnable.CellTemplate.Clone();
            _GridCell[4] = (DataGridViewCell)this.gridAreaNgNum.CellTemplate.Clone();

            //BenchMark ComboBox Setting
            DataGridViewComboBoxCell _DataGridComboCell = new DataGridViewComboBoxCell();
            _DataGridComboCell = (DataGridViewComboBoxCell)this.gridAreaBenchMark.CellTemplate.Clone();
            _DataGridComboCell.Items.Add("None");
            
            for (int iLoopCount = 0; iLoopCount < Convert.ToInt32(_Index) - 1; ++iLoopCount)
            {
                string _ItemName = String.Format("Area{0}", iLoopCount + 1);
                _DataGridComboCell.Items.Add(_ItemName);
            }
            _GridCell[2] = _DataGridComboCell;

            _GridCell[0].Value = _Index;
            _GridCell[1].Value = _Name;
            _GridCell[2].Value = "Area" + InspParam.InspAreaParam[Convert.ToInt32(_Index) - 1].AreaBenchMark;
            if (InspParam.InspAreaParam[Convert.ToInt32(_Index) - 1].AreaBenchMark == 0) _GridCell[2].Value = "None";
            _GridCell[3].Value = _Enable;
            _GridCell[4].Value = InspParam.InspAreaParam[Convert.ToInt32(_Index) - 1].NgAreaNumber.ToString();
            if (InspParam.InspAreaParam[Convert.ToInt32(_Index) - 1].NgAreaNumber == 0) _GridCell[4].Value = "1";

            DataGridViewRow _GridRow = new DataGridViewRow();
            _GridRow.Cells.AddRange(_GridCell);
            gridViewArea.Rows.Add(_GridRow);
        }

        private void UpdateInspectionAlgoList(int _ID, bool _IsNew = false)
        {
            InspAreaSelected = _ID;
            gridViewAlgo.Rows.Clear();

            for (int iLoopCount = 0; iLoopCount < InspParam.InspAreaParam[_ID].InspAlgoParam.Count; ++iLoopCount)
            {
                string _Index = (iLoopCount + 1).ToString();
                string _Name = "Algo" + _Index;
                bool _Enable = InspParam.InspAreaParam[_ID].InspAlgoParam[iLoopCount].AlgoEnable;

                if (InspParam.InspAreaParam[_ID].InspAlgoParam[iLoopCount].AlgoType == (int)eAlgoType.C_PATTERN)    _Name = "Search a reference";   //"Pattern - Reference"
                else if (InspParam.InspAreaParam[_ID].InspAlgoParam[iLoopCount].AlgoType == (int)eAlgoType.C_BLOB)  _Name = "Defect detection";     //"Blob - Defect"

                AddInspectionAlgo(_Index, _Name, _Enable);
            }
            gridViewAlgo.ClearSelection();
        }

        private void AddInspectionAlgo(string _Index, string _Name, bool _Enable)
        {
            DataGridViewCell[] _GridCell = new DataGridViewCell[4];
            _GridCell[0] = (DataGridViewCell)this.gridAlgoID.CellTemplate.Clone();
            _GridCell[1] = (DataGridViewCell)this.gridAlgoName.CellTemplate.Clone();
            _GridCell[2] = (DataGridViewCell)this.gridAlgoBenchMark.CellTemplate.Clone();
            _GridCell[3] = (DataGridViewCell)this.gridAlgoEnable.CellTemplate.Clone();

            //BenchMark ComboBox Setting
            DataGridViewComboBoxCell _DataGridComboCell = new DataGridViewComboBoxCell();
            _DataGridComboCell = (DataGridViewComboBoxCell)this.gridAlgoBenchMark.CellTemplate.Clone();
            _DataGridComboCell.Items.Add("None");

            for (int iLoopCount = 0; iLoopCount < Convert.ToInt32(_Index) - 1; ++iLoopCount)
            {
                string _ItemName = String.Format("Area{0}", iLoopCount + 1);
                _DataGridComboCell.Items.Add(_ItemName);
            }
            _GridCell[2] = _DataGridComboCell;

            //GridView Setting
            _GridCell[0].Value = _Index;
            _GridCell[1].Value = _Name;
            _GridCell[2].Value = "Area" + InspParam.InspAreaParam[InspAreaSelected].InspAlgoParam[Convert.ToInt32(_Index) - 1].AlgoBenchMark;
            if (InspParam.InspAreaParam[InspAreaSelected].InspAlgoParam[Convert.ToInt32(_Index) - 1].AlgoBenchMark == 0) _GridCell[2].Value = "None";
            _GridCell[3].Value = _Enable;

            DataGridViewRow _GridRow = new DataGridViewRow();
            _GridRow.Cells.AddRange(_GridCell);
            gridViewAlgo.Rows.Add(_GridRow);
        }
        #endregion Inspection Area & Algorithm Gridview Update

        #region Teaching Parameter Set & UI Setting
        private bool GetCorrectionRectangle(KPDisplay.KPCogDisplayControl _DisplayCtrl, CogRectangle _Boundary, ref CogRectangle _ResultRegion)
        {
            bool _Result = true;

            double _StartX, _StartY, _EndX, _EndY, _Width, _Height;
            CogRectangle _CurrentRegion = _DisplayCtrl.GetInterActiveRectangle();
            _CurrentRegion.GetXYWidthHeight(out _StartX, out _StartY, out _Width, out _Height);
            _EndX = _StartX + _Width;
            _EndY = _StartY + _Height;

            //영역이 Boundary를 완전히 벗어난 경우는 Fail
            if ((_EndX < _Boundary.X) || (_StartX > _Boundary.X + _Boundary.Width) || (_EndY < _Boundary.Y) || (_StartY > _Boundary.Y + _Boundary.Height)) return false;

            //Boundary 밖으로 벗어난 경우 Boundary 끝으로 변경
            if (_StartX < _Boundary.X) { _Width = (_Width + (_StartX - _Boundary.X)); _StartX = _Boundary.X; }
            if (_StartY < _Boundary.Y) { _Height = (_Height + (_StartY - _Boundary.Y)); _StartY = _Boundary.Y; }
            if (_EndX > (_Boundary.X + _Boundary.Width)) { _Width = _Width - (_EndX - (_Boundary.X + _Boundary.Width)); }
            if (_EndY > (_Boundary.Y + _Boundary.Height)) { _Height = _Height - (_EndY - (_Boundary.Y + _Boundary.Height)); }

            _ResultRegion.SetXYWidthHeight(_StartX, _StartY, _Width, _Height);

            return _Result;
        }

        private void GetAreaResultDataOffset(int _Area)
        {
            AreaOffsetX = AreaOffsetY;

            int _BenchmarkIndex = InspParam.InspAreaParam[_Area].AreaBenchMark - 1;

            //BenchMark가 있는 경우
            if (_BenchmarkIndex >= 0 && AreaResParamList.Count > _BenchmarkIndex)
            {
                AreaOffsetX = AreaResParamList[_BenchmarkIndex].OffsetX;
                AreaOffsetY = AreaResParamList[_BenchmarkIndex].OffsetY;
            }
        }

        private void GetAlgoResultDataOffset(int _Area, int _Algo)
        {
            AlgoOffsetX = AlgoOffsetY = 0;

            int _BenchmarkIndex = InspParam.InspAreaParam[_Area].InspAlgoParam[_Algo].AlgoBenchMark;

            int _ResultIndex = 0;

            for (int iLoopCount = 0; iLoopCount < _Area; ++iLoopCount)
            {
                if (InspParam.InspAreaParam[iLoopCount].Enable == true)
                {
                    for (int jLoopCount = 0; jLoopCount < InspParam.InspAreaParam[iLoopCount].InspAlgoParam.Count; ++jLoopCount)
                    {
                        if (InspParam.InspAreaParam[iLoopCount].InspAlgoParam[jLoopCount].AlgoEnable == true)
                            _ResultIndex++;
                    }
                }
            }

            //BenchMark가 있는 경우
            if (_BenchmarkIndex > 0)
            {
                _ResultIndex = _ResultIndex + (_BenchmarkIndex - 1);
                if (AlgoResParamList.Count > _ResultIndex && _ResultIndex >= 0)
                {
                    AlgoOffsetX = AlgoResParamList[_ResultIndex].OffsetX;
                    AlgoOffsetY = AlgoResParamList[_ResultIndex].OffsetY;
                }
            }
        }

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

        private void UpdateInspectionArea(int _ID)
        {
            double _CenterX = InspParam.InspAreaParam[_ID].AreaRegionCenterX + AreaOffsetX;
            double _CenterY = InspParam.InspAreaParam[_ID].AreaRegionCenterY + AreaOffsetY;
            double _Width = InspParam.InspAreaParam[_ID].AreaRegionWidth;
            double _Height = InspParam.InspAreaParam[_ID].AreaRegionHeight;

            CogRectangle _InspRegion = new CogRectangle();
            _InspRegion.SetCenterWidthHeight(_CenterX, _CenterY, _Width, _Height);

            kpTeachDisplay.ClearDisplay();
            kpTeachDisplay.DrawInterActiveShape(_InspRegion, "InspRegion", CogColorConstants.Green);
        }
        #endregion Teaching Parameter Set & UI Setting

        private void gridViewArea_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int _Index = (int)eAreaList.ENABLE;
                bool _Flag = Convert.ToBoolean(gridViewArea.SelectedRows[0].Cells[_Index].Value);
                gridViewArea.SelectedRows[0].Cells[_Index].Value = !_Flag;
            }
        }

        private void gridViewArea_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridViewArea.RowCount <= 0) return;
            if (gridViewArea.SelectedRows.Count == 0) return;

            gridViewArea.SelectedRows[0].Selected = true;
            int _ID = Convert.ToInt32(gridViewArea.SelectedRows[0].Cells[(int)eAreaList.ID].Value) - 1;

            kpTeachDisplay.ClearDisplay();
            panelTeaching.Controls.Clear();
            panelTeaching.Controls.Add(labelTeaching);
            gridViewAlgo.Rows.Clear();

            GetAreaResultDataOffset(_ID);
            UpdateInspectionArea(_ID);

            gridViewAlgo.ClearSelection();
            InspAreaSelected = _ID;

            UpdateTeachingStatus(eTeachStep.AREA_SELECT);
        }
    }
}
