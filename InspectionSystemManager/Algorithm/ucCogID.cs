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
    public partial class ucCogID : UserControl
    {
        private CogBarCodeIDAlgo CogBarCodeIDAlgoRcp = new CogBarCodeIDAlgo();

        public delegate void ApplyBarCodeIDInspValueHandler(CogBarCodeIDAlgo _CogBarCodeIDAlgo, ref CogBarCodeIDResult _CogBarCodeIDResult);
        public event ApplyBarCodeIDInspValueHandler ApplyBarCodeIDInspValueEvent;

        public ucCogID()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

        }

        public void DeInitialize()
        {

        }

        public void SetAlgoRecipe(Object _Algorithm)
        {
            CogBarCodeIDAlgoRcp = _Algorithm as CogBarCodeIDAlgo;

            comboBoxSymbology.SelectedText = CogBarCodeIDAlgoRcp.Symbology;
            numUpDownNumtoFind.Value = CogBarCodeIDAlgoRcp.FindCount;
        }

        public void SaveAlgoRecipe()
        {
            CogBarCodeIDAlgoRcp.Symbology = comboBoxSymbology.Text;
            CogBarCodeIDAlgoRcp.FindCount = Convert.ToInt32(numUpDownNumtoFind.Value);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ApplySettingValue();
        }

        private void ApplySettingValue()
        {
            CogBarCodeIDResult _CogBarCodeIDResult = new CogBarCodeIDResult();
            CogBarCodeIDAlgo _CogBarCodeIDAlgoRcp = new CogBarCodeIDAlgo();
            _CogBarCodeIDAlgoRcp.Symbology = comboBoxSymbology.Text;
            _CogBarCodeIDAlgoRcp.FindCount = Convert.ToInt32(numUpDownNumtoFind.Value);

            var _ApplyBarCodeIDInspValueEvent = ApplyBarCodeIDInspValueEvent;
            if (_ApplyBarCodeIDInspValueEvent != null)
                _ApplyBarCodeIDInspValueEvent(_CogBarCodeIDAlgoRcp, ref _CogBarCodeIDResult);
        }
    }
}
