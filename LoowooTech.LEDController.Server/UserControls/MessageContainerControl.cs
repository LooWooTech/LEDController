using System;
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
    public partial class MessageContainerControl : UserControl, IContainerControl
    {
        private DataManager DataManager = new DataManager();

        public MessageContainerControl()
        {
            InitializeComponent();
            BindData();
        }

        public void BindData()
        {
            var data = DataManager.GetList<Model.Message>();
            foreach (var msg in data)
            {
                AddRow(msg);
            }
        }

        private void AddRow(Model.Message msg)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];
            row.Cells["Content"].Value = msg.Content;
            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new Model.Message());
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
                var content = row.Cells["Content"];
                if (content.Value != null)
                {
                    var msg = new Model.Message { Content = content.Value.ToString() };
                    list.Add(msg);
                }
            }
            DataManager.Save(list);
            MessageBox.Show("保存成功");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
