﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ParameterManager;

namespace DIOControlManager
{
    public partial class DIOControlWindow : Form
    {

        public bool IsShowWindow = false;

        public delegate void InputChangedHandler(short _BitNum, bool _Signal);
        public event InputChangedHandler InputChangedEvent;

        public DIOControlWindow()
        {
            InitializeComponent();
        }

        #region Initialize & DeInitialize
        public bool Initialize()
        {
            bool _Result = true;

            return _Result;
        }

        public void DeInitialize()
        {

        }
        #endregion Initialize & DeInitialize

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            InputChangedEvent(DIOMAP.IN_TRG1, true);
        }


        public void ShowDIOWindow()
        {
            IsShowWindow = true;
            this.Show();
        }
    }
}
