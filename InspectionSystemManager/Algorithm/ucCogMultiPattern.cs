using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ParameterManager;
using LogMessageManager;

using Cognex.VisionPro;

namespace InspectionSystemManager
{
    public partial class ucCogMultiPattern : UserControl
    {
        private CogMultiPatternAlgo CogMultiPatternAlgoRcp = new CogMultiPatternAlgo();
        private References ReferenceBackup = new References();

        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;
        private double BenchMarkOffsetX = 0;
        private double BenchMarkOffsetY = 0;

        Button[] btnNewArea;
        Button[] btnAdd;
        Button[] btnModify;
        Button[] btnFind;

        private int SelectedPattern = 0;

        public delegate void DrawReferRegionHandler(CogRectangle _Region, double _OriginX, double _OriginY, CogColorConstants _Color);
        public event DrawReferRegionHandler DrawReferRegionEvent;

        public delegate void ReferenceActionHandler(eReferAction _ReferAction, int _Index = 0);
        public event ReferenceActionHandler ReferenceActionEvent;

        public ucCogMultiPattern()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            btnNewArea = new Button[2] { btnShowAreaTop, btnShowAreaBottom };
            btnAdd = new Button[2] { btnPatternAddTop, btnPatternAddBottom };
            btnModify = new Button[2] { btnPatternModifyTop, btnPatternModifyBottom };
            btnFind = new Button[2] { btnFindTop, btnFindBottom };
        }

        public void SetAlgoRecipe(Object _Algorithm, double _BenchMarkOffsetX, double _BenchMarkOffsetY, double _ResolutionX, double _ResolutionY)
        {
            if (null == _Algorithm) return;

            CogMultiPatternAlgoRcp = _Algorithm as CogMultiPatternAlgo;
            ReferenceBackup.Clear();
            for (int iLoopCount = 0; iLoopCount < CogMultiPatternAlgoRcp.ReferenceInfoList.Count; ++iLoopCount)
            {
                ReferenceInformation _ReferInfo = CogMultiPatternAlgoRcp.ReferenceInfoList[iLoopCount];
                ReferenceBackup.Add(_ReferInfo);
            }

            ResolutionX = _ResolutionX;
            ResolutionY = _ResolutionY;
            BenchMarkOffsetX = _BenchMarkOffsetX;
            BenchMarkOffsetY = _BenchMarkOffsetY;

            numericUpDownFindScore.Value = Convert.ToDecimal(CogMultiPatternAlgoRcp.MatchingScore);
            numericUpDownFindCount.Value = Convert.ToDecimal(CogMultiPatternAlgoRcp.MatchingCount);
            numericUpDownAngleLimit.Value = Convert.ToDecimal(CogMultiPatternAlgoRcp.MatchingAngle);

            if (CogMultiPatternAlgoRcp.ReferenceInfoList.Count > 0)
            {
                ShowPatternImageArea(SelectedPattern + 1);
                ShowPatternImage(SelectedPattern + 1);
            }
        }

        #region Control Event
        private void btnShowArea_Click(object sender, EventArgs e)
        {
            int Num = Convert.ToInt32(((Button)sender).Tag);

            CogRectangle _Region = new CogRectangle();
            _Region.SetCenterWidthHeight(200, 200, 200, 200);

            var _DrawReferRegionEvent = DrawReferRegionEvent;
            _DrawReferRegionEvent?.Invoke(_Region, _Region.CenterX, _Region.CenterY, CogColorConstants.Cyan);
        }

        private void btnPatternAdd_Click(object sender, EventArgs e)
        {
            int Num = Convert.ToInt32(((Button)sender).Tag);

            var _ReferenceActionEvent = ReferenceActionEvent;
            _ReferenceActionEvent?.Invoke(eReferAction.ADD);

            SelectedPattern = Num;
            ShowPatternImage(Num + 1);
            ShowPatternImageArea(Num + 1);
        }

        private void btnPatternModify_Click(object sender, EventArgs e)
        {
            int Num = Convert.ToInt32(((Button)sender).Tag);
            SelectedPattern = Num;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int Num = Convert.ToInt32(((Button)sender).Tag);
            SelectedPattern = Num;

        }
        #endregion Control Event

        public void SaveAlgoRecipe()
        {

        }

        private void ShowPatternImageArea(int _PatternNumber)
        {
            if (_PatternNumber <= 0) return;
            if (_PatternNumber > CogMultiPatternAlgoRcp.ReferenceInfoList.Count || CogMultiPatternAlgoRcp.ReferenceInfoList.Count == 0) return;

            _PatternNumber = _PatternNumber - 1;
            CogRectangle _Region = new CogRectangle();
            _Region.SetCenterWidthHeight(CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].CenterX, CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].CenterY, CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].Width, CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].Height);
            var _DrawReferRegionEvent = DrawReferRegionEvent;
            _DrawReferRegionEvent.Invoke(_Region,
                                        CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].CenterX - CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].OriginPointOffsetX,
                                        CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].CenterY - CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].OriginPointOffsetY, CogColorConstants.Yellow);
        }

        private void ShowPatternImage(int _PatternNumber)
        {
            if (_PatternNumber <= 0) { kpPatternDisplay.SetDisplayImage(null); return; }
            if (_PatternNumber > CogMultiPatternAlgoRcp.ReferenceInfoList.Count || CogMultiPatternAlgoRcp.ReferenceInfoList.Count == 0) return;

            _PatternNumber = _PatternNumber - 1;
            kpPatternDisplay.SetDisplayImage((CogImage8Grey)CogMultiPatternAlgoRcp.ReferenceInfoList[_PatternNumber].Reference.GetTrainedPatternImage());
        }

    }
}
