using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KPVisionInspectionFramework
{
    public partial class FolderPathWindow : Form
    {
        public delegate void SetDataPathHandler(string[] _DataPath);
        public event SetDataPathHandler SetDataPathEvent;

        public delegate bool LOTChangeHandler(object _LOTNum);
        public event LOTChangeHandler LOTChangeEvent;

        public FolderPathWindow(bool _SimulationModeFlag)
        {
            InitializeComponent();

            //LDHM 2018.11.21, Test용 LOT Change/END 기능
            if(_SimulationModeFlag)
            {
                labelLOTNum.Visible = true;
                txtBoxLOTNum.Visible = true;
                btnLOTEnd.Visible = true;
                btnLotChange.Visible = true;
            }
        }

        public void SetCurrentDataPath(string[] _CurrentDataPath)
        {
            textBoxInDataPath.Clear();
            textBoxOutDataPath.Clear();

            textBoxInDataPath.Text = _CurrentDataPath[0];
            textBoxOutDataPath.Text = _CurrentDataPath[1];
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxInDataPath.Text == null || textBoxInDataPath.Text == "") { MessageBox.Show("In Data 폴더 경로가 없습니다."); return; }
            if (textBoxOutDataPath.Text == null || textBoxOutDataPath.Text == "") { MessageBox.Show("Out Data 폴더 경로가 없습니다."); return; }

            string[] DataPath = new string[2];
            DataPath[0] = textBoxInDataPath.Text;
            DataPath[1] = textBoxOutDataPath.Text;

            var _RecipeCopyEvent = SetDataPathEvent;
            _RecipeCopyEvent?.Invoke(DataPath);

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);

            this.Cursor = Cursors.Default;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Label;
            s.Tag = new Point(e.X, e.Y);
        }
        
        private void btnSearchDataPath_Click(object sender, EventArgs e)
        {  
            FolderBrowserDialog FolderDialog = new FolderBrowserDialog();
            if (DialogResult.OK == FolderDialog.ShowDialog())
            {
                Button btnSearch = (Button)sender;
                switch (Convert.ToInt32(btnSearch.Tag))
                {
                    case 0: textBoxInDataPath.Text = FolderDialog.SelectedPath; break;
                    case 1: textBoxOutDataPath.Text = FolderDialog.SelectedPath; break;
                }
            }
        }

        private void btnLotChange_Click(object sender, EventArgs e)
        {
            if (txtBoxLOTNum.Text == "") { MessageBox.Show("LOTNum을 입력하세요."); return; }

            LOTChangeEvent("@N,B84060800," + txtBoxLOTNum.Text + ",AAA,AAA,BBB,25");
        }

        private void btnLOTEnd_Click(object sender, EventArgs e)
        {
            LOTChangeEvent("@E,LotEnd,");
        }
    }
}
