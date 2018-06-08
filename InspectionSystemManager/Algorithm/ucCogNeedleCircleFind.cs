﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ParameterManager;

namespace InspectionSystemManager
{
    public partial class ucCogNeedleCircleFind : UserControl
    {
        private CogNeedleFindAlgo CogNeedleFindAlgoRcp = new CogNeedleFindAlgo();

        private double OriginX = 0;
        private double OriginY = 0;
        private double ResolutionX = 0.005;
        private double ResolutionY = 0.005;

        private bool AlgoInitFlag = false;

        public delegate void ApplyNeedleCircleFindValueHandler(CogNeedleFindAlgo _CogNeedleFindAlgo, ref CogNeedleFindResult _CogNeedleFindResult);
        public event ApplyNeedleCircleFindValueHandler ApplyNeedleCircleFindValueEvent;

        public delegate void DrawNeedleCircleFindCaliperHandler(CogNeedleFindAlgo _CogNeedleFindAlgo);
        public event DrawNeedleCircleFindCaliperHandler DrawNeedleCircleFindCaliperEvent;

        #region Initialize & DeInitialize
        public ucCogNeedleCircleFind()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

        }

        private void InitializeControl()
        {

        }

        public void DeInitialize()
        {

        }
        #endregion Initialize & DeInitialize

        #region Control Event
        private void btnSetting_Click(object sender, EventArgs e)
        {
            ApplySettingValue();
        }

        private void btnDrawCaliper_Click(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void rbSearchDirection_MouseUp(object sender, MouseEventArgs e)
        {
            RadioButton _RadioDirection = (RadioButton)sender;
            int _Direction = Convert.ToInt32(_RadioDirection.Tag);
            SetSearchDirection(_Direction);
            graLabelSearchDirection.Text = _Direction.ToString();
            //ApplySettingValue();
            DrawCircleFindCapliper();
        }

        private void numUpDownCaliperNumber_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void numUpDownSearchLength_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void numUpDownProjectionLength_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void numUpDownArcCenterX_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void numUpDownArcCenterY_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void numUpDownArcRadius_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void numUpDownAngleStart_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }

        private void numUpDownAngleSpan_ValueChanged(object sender, EventArgs e)
        {
            DrawCircleFindCapliper();
        }
        #endregion Control Event

        public void SetAlgoRecipe(Object _Algorithm, double _ResolutionX, double _ResolutionY)
        {
            AlgoInitFlag = false;

            CogNeedleFindAlgoRcp = _Algorithm as CogNeedleFindAlgo;

            ResolutionX                     = _ResolutionX;
            ResolutionY                     = _ResolutionY;
            numUpDownCaliperNumber.Value    = Convert.ToDecimal(CogNeedleFindAlgoRcp.CaliperNumber);
            numUpDownSearchLength.Value     = Convert.ToDecimal(CogNeedleFindAlgoRcp.CaliperSearchLength);
            numUpDownProjectionLength.Value = Convert.ToDecimal(CogNeedleFindAlgoRcp.CaliperProjectionLength);
            numUpDownArcCenterX.Value       = Convert.ToDecimal(CogNeedleFindAlgoRcp.ArcCenterX);
            numUpDownArcCenterY.Value       = Convert.ToDecimal(CogNeedleFindAlgoRcp.ArcCenterY);
            numUpDownArcRadius.Value        = Convert.ToDecimal(CogNeedleFindAlgoRcp.ArcRadius);
            numUpDownAngleStart.Value       = Convert.ToDecimal(CogNeedleFindAlgoRcp.ArcAngleStart);
            numUpDownAngleSpan.Value        = Convert.ToDecimal(CogNeedleFindAlgoRcp.ArcAngleSpan);
            textBoxCenterX.Text             = CogNeedleFindAlgoRcp.OriginX.ToString("F3");
            textBoxCenterY.Text             = CogNeedleFindAlgoRcp.OriginY.ToString("F3");
            textBoxRadius.Text              = CogNeedleFindAlgoRcp.OriginRadius.ToString("F3");

            SetSearchDirection(CogNeedleFindAlgoRcp.CaliperSearchDirection);
            
            AlgoInitFlag = true;
        }

        public void SaveAlgoRecipe()
        {
            CogNeedleFindAlgoRcp.CaliperNumber           = Convert.ToInt32(numUpDownCaliperNumber.Value);
            CogNeedleFindAlgoRcp.CaliperSearchLength     = Convert.ToDouble(numUpDownSearchLength.Value);
            CogNeedleFindAlgoRcp.CaliperProjectionLength = Convert.ToDouble(numUpDownProjectionLength.Value);
            CogNeedleFindAlgoRcp.CaliperSearchDirection  = Convert.ToInt32(graLabelSearchDirection.Text);
            CogNeedleFindAlgoRcp.ArcCenterX     = Convert.ToDouble(numUpDownArcCenterX.Value);
            CogNeedleFindAlgoRcp.ArcCenterY     = Convert.ToDouble(numUpDownArcCenterY.Value);
            CogNeedleFindAlgoRcp.ArcRadius      = Convert.ToDouble(numUpDownArcRadius.Value);
            CogNeedleFindAlgoRcp.ArcAngleStart  = Convert.ToDouble(numUpDownAngleStart.Value);
            CogNeedleFindAlgoRcp.ArcAngleSpan   = Convert.ToDouble(numUpDownAngleSpan.Value);
            CogNeedleFindAlgoRcp.OriginX        = Convert.ToDouble(textBoxCenterX.Text);
            CogNeedleFindAlgoRcp.OriginY        = Convert.ToDouble(textBoxCenterY.Text);
            CogNeedleFindAlgoRcp.OriginRadius   = Convert.ToDouble(textBoxRadius.Text);
        }

        public void SetCaliper(int _CaliperNumber, double _SearchLength, double _ProjectionLength, eSearchDirection _eSearchDir)
        {
            numUpDownCaliperNumber.Value = Convert.ToDecimal(_CaliperNumber);
            numUpDownSearchLength.Value = Convert.ToDecimal(_SearchLength);
            numUpDownProjectionLength.Value = Convert.ToDecimal(_ProjectionLength);
            SetSearchDirection(Convert.ToInt32(_eSearchDir));
        }

        public void SetCircularArc(double _CenterX, double _CenterY, double _Radius, double _AngleStart, double _AngleSpan)
        {
            numUpDownArcCenterX.Value = Convert.ToDecimal(_CenterX);
            numUpDownArcCenterY.Value = Convert.ToDecimal(_CenterY);
            numUpDownArcRadius.Value = Convert.ToDecimal(_Radius);
            numUpDownAngleStart.Value = Convert.ToDecimal(_AngleStart);
            numUpDownAngleSpan.Value = Convert.ToDecimal(_AngleSpan);
        }

        private void SetSearchDirection(int _Direction)
        {
            rbSearchDirectionIn.Checked = false;
            rbSearchDirectionOut.Checked = false;

            switch ((eSearchDirection)_Direction)
            {
                case eSearchDirection.IN_WARD:  rbSearchDirectionIn.Checked = true;     break;
                case eSearchDirection.OUT_WARD: rbSearchDirectionOut.Checked = true;    break;
            }
        }
        
        private void ApplySettingValue()
        {
            CogNeedleFindResult _CogNeedleFindResult = new CogNeedleFindResult();
            CogNeedleFindAlgo _CogNeedleFindAlgoRcp = new CogNeedleFindAlgo();
            _CogNeedleFindAlgoRcp.CaliperNumber           = Convert.ToInt32(numUpDownCaliperNumber.Value);
            _CogNeedleFindAlgoRcp.CaliperSearchLength     = Convert.ToDouble(numUpDownSearchLength.Value);
            _CogNeedleFindAlgoRcp.CaliperProjectionLength = Convert.ToDouble(numUpDownProjectionLength.Value);
            _CogNeedleFindAlgoRcp.CaliperSearchDirection  = Convert.ToInt32(graLabelSearchDirection.Text);
            _CogNeedleFindAlgoRcp.ArcCenterX     = Convert.ToDouble(numUpDownArcCenterX.Value);
            _CogNeedleFindAlgoRcp.ArcCenterY     = Convert.ToDouble(numUpDownArcCenterY.Value);
            _CogNeedleFindAlgoRcp.ArcRadius      = Convert.ToDouble(numUpDownArcRadius.Value);
            _CogNeedleFindAlgoRcp.ArcAngleStart  = Convert.ToDouble(numUpDownAngleStart.Value);
            _CogNeedleFindAlgoRcp.ArcAngleSpan   = Convert.ToDouble(numUpDownAngleSpan.Value);

            var _ApplyNeedleCircleFindValueEvent = ApplyNeedleCircleFindValueEvent;
            if (_ApplyNeedleCircleFindValueEvent != null)
                _ApplyNeedleCircleFindValueEvent(_CogNeedleFindAlgoRcp, ref _CogNeedleFindResult);

            if (_CogNeedleFindResult.IsGood)
            {
                textBoxCenterX.Text = (_CogNeedleFindResult.CenterX * ResolutionX).ToString("F3");
                textBoxCenterY.Text = (_CogNeedleFindResult.CenterY * ResolutionY).ToString("F3");
                textBoxRadius.Text = (_CogNeedleFindResult.Radius * ResolutionX).ToString("F3");
            }
        }

        private void DrawCircleFindCapliper()
        {
            if (!AlgoInitFlag) return;

            CogNeedleFindAlgo _CogNeedleFindAlgoRcp = new CogNeedleFindAlgo();
            _CogNeedleFindAlgoRcp.CaliperNumber = Convert.ToInt32(numUpDownCaliperNumber.Value);
            _CogNeedleFindAlgoRcp.CaliperSearchLength = Convert.ToDouble(numUpDownSearchLength.Value);
            _CogNeedleFindAlgoRcp.CaliperProjectionLength = Convert.ToDouble(numUpDownProjectionLength.Value);
            _CogNeedleFindAlgoRcp.CaliperSearchDirection = Convert.ToInt32(graLabelSearchDirection.Text);
            _CogNeedleFindAlgoRcp.ArcCenterX = Convert.ToDouble(numUpDownArcCenterX.Value);
            _CogNeedleFindAlgoRcp.ArcCenterY = Convert.ToDouble(numUpDownArcCenterY.Value);
            _CogNeedleFindAlgoRcp.ArcRadius = Convert.ToDouble(numUpDownArcRadius.Value);
            _CogNeedleFindAlgoRcp.ArcAngleStart = Convert.ToDouble(numUpDownAngleStart.Value);
            _CogNeedleFindAlgoRcp.ArcAngleSpan = Convert.ToDouble(numUpDownAngleSpan.Value);

            var _DrawNeedleCircleFindCaliperEvent = DrawNeedleCircleFindCaliperEvent;
            if (_DrawNeedleCircleFindCaliperEvent != null)
                _DrawNeedleCircleFindCaliperEvent(_CogNeedleFindAlgoRcp);
        }
    }
}
