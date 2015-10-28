using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDController.Data;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class ConfigContainerControl : UserControl, IContainerControl
    {
        public ConfigContainerControl()
        {
            InitializeComponent();
        }

        private DataManager DataManager = DataManager.Instance;

        private bool _hasBind;
        public void BindData()
        {
            if (_hasBind) return;
            _hasBind = true;
        }

        public void SaveData()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

    }
}
