using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoowooTech.LEDController.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void labTitle_DoubleClick(object sender, EventArgs e)
        {
            var historyForm = new HistoryForm();
            historyForm.Show();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnOffwork_Click(object sender, EventArgs e)
        {

        }

        private void btnCountDown_Click(object sender, EventArgs e)
        {

        }
    }
}
