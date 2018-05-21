using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DIOControlManager
{
    public partial class DIOControlWindow : Form
    {
        public DIOControlWindow()
        {
            InitializeComponent();
        }

        #region Initialize & DeInitialize
        public bool Initialize()
        {
            bool _Result = false;

            do
            {

                _Result = true;
            } while (false);

            return _Result;
        }

        public void DeInitialize()
        {
            return;
        }
        #endregion Initialize & DeInitialize
    }
}
