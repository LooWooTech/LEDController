﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDController.Server.Managers;
using System.Threading;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class MessageControl : UserControl, IUserControl
    {
        public MessageControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];
            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        public void SaveData()
        {
            var list = new List<Model.Message>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var content = row.Cells[1];
                if (content != null && content.ToString().Length > 0)
                {
                    var msg = new Model.Message { Content = content.ToString() };
                    list.Add(msg);
                }
            }
            DataManager.Save(list);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
