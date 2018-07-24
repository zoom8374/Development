using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomControl;
using ParameterManager;

namespace KPVisionInspectionFramework
{
    public partial class ucMainResultLead : UserControl
    {
        #region Initialize & DeInitialize
        public ucMainResultLead()
        {
            InitializeComponent();
            InitializeControl();
            this.Location = new Point(1, 1);
        }

        private void InitializeControl()
        {
            for (int iLoopCount = 0; iLoopCount < 22; ++iLoopCount)
            {
                DataGridViewRow _GridRow = new DataGridViewRow();
                DataGridViewCell[] _GridCell = new DataGridViewCell[5];
                _GridCell[0] = gridLeadNum.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[1] = gridLeadBent.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[2] = gridLeadWidth.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[3] = gridLeadLength.CellTemplate.Clone() as DataGridViewCell;
                _GridCell[4] = gridLeadPitch.CellTemplate.Clone() as DataGridViewCell;

                _GridCell[0].Value = (iLoopCount + 1);
                _GridCell[0].Style.BackColor = Color.DarkGreen;
                _GridCell[0].Style.ForeColor = Color.White;
                //_GridCell[1].Style.BackColor = Color.PowderBluePowderBlue;
                //_GridCell[2].Style.BackColor = Color.PowderBlue;
                //_GridCell[3].Style.BackColor = Color.PowderBlue;
                //_GridCell[4].Style.BackColor = Color.PowderBlue;
                //
                _GridRow.Cells.AddRange(_GridCell);
                QuickGridViewLeadResult.Rows.Add(_GridRow);
            }
            QuickGridViewLeadResult.ClearSelection();
        }

        public void DeInitialize()
        {
            
        }
        #endregion Initialize & DeInitialize

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.panelMain.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        public void SetNeedleResultData(SendResultParameter _ResultParam)
        {
            if (_ResultParam.ID == 0)   //Needle Align Vision1
            {
                var _Result = _ResultParam.SendResult as SendNeedleAlignResult;
                if (_Result != null)
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, _Result.AlignX.ToString("F3"));
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, _Result.AlignY.ToString("F3"));
                }
                else
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX1, "-");
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY1, "-");
                }

                if (_ResultParam.IsGood)
                {
                    ControlInvoke.GradientLabelText(gradientLabelResult, "GOOD", Color.Lime);
                }

                else
                {
                    if (eNgType.NDL_FIND == _ResultParam.NgType)
                    {
                        ControlInvoke.GradientLabelText(gradientLabelResult, "Not Found", Color.Red);
                    }

                    else if (eNgType.NDL_CENTER == _ResultParam.NgType)
                    {
                        ControlInvoke.GradientLabelText(gradientLabelResult, "Not Found", Color.Red);
                    }
                }
            }

            else if (_ResultParam.ID == 1)   //Needle Align Vision2
            {
                var _Result = _ResultParam.SendResult as SendNeedleAlignResult;
                if (_Result != null)
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX2, _Result.AlignX.ToString("F3"));
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY2, _Result.AlignY.ToString("F3"));
                }
                else
                {
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignX2, "-");
                    ControlInvoke.GradientLabelText(gradientLabelNeedleAlignY2, "-");
                }

                if (_ResultParam.IsGood)
                {
                    ControlInvoke.GradientLabelText(gradientLabelResult, "GOOD", Color.Lime);
                }

                else
                {
                    if (eNgType.NDL_FIND == _ResultParam.NgType)
                    {
                        ControlInvoke.GradientLabelText(gradientLabelResult, "Not Found", Color.Red);
                    }

                    else if (eNgType.NDL_CENTER == _ResultParam.NgType)
                    {
                        ControlInvoke.GradientLabelText(gradientLabelResult, "Not Found", Color.Red);
                    }
                }
            }

            else
            {
                //LOG
            }
        }

        public void SetLeadResultData(SendResultParameter _ResultParam)
        {
            var _Result = _ResultParam.SendResult as SendLeadResult;
            if (_Result != null)
            {
                for (int iLoopCount = 0; iLoopCount < _Result.LeadCount; ++iLoopCount)
                {
                    double _Angle = _Result.LeadAngle[iLoopCount] * 180 / Math.PI;
                    if (_Angle > 0) _Angle = 90 - (_Result.LeadAngle[iLoopCount] * 180 / Math.PI);
                    else _Angle = -(90 + (_Result.LeadAngle[iLoopCount] * 180 / Math.PI));

                    QuickGridViewLeadResult[1, iLoopCount].Value = _Angle.ToString("F3");
                    QuickGridViewLeadResult[2, iLoopCount].Value = _Result.LeadWidth[iLoopCount].ToString("F3");
                    QuickGridViewLeadResult[3, iLoopCount].Value = _Result.LeadLength[iLoopCount].ToString("F3");

                    if (_Result.IsLeadBendGood[iLoopCount] && iLoopCount % 2 == 0) QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.PowderBlue;
                    else if (_Result.IsLeadBendGood[iLoopCount] && iLoopCount % 2 == 1) QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.White;
                    else QuickGridViewLeadResult[1, iLoopCount].Style.BackColor = Color.Red;
                }

                if (_ResultParam.IsGood)
                {
                    ControlInvoke.GradientLabelText(gradientLabelResult, "GOOD", Color.Lime);
                }

                else
                {
                    if (eNgType.LEAD_BENT == _ResultParam.NgType)
                    {
                        ControlInvoke.GradientLabelText(gradientLabelResult, "LEAD BENT", Color.Red);
                    }
                }
            }
            QuickGridViewLeadResult.ClearSelection();
        }
    }
}
