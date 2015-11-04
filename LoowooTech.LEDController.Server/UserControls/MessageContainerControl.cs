using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDController.Data;
using System.Threading;
using LoowooTech.LEDController.Model;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class MessageContainerControl : UserControl, IContainerControl
    {
        private DataManager DataManager = DataManager.Instance;

        public MessageContainerControl()
        {
            InitializeComponent();
        }

        private bool _hasBind;
        public void BindData()
        {
            if (_hasBind) return;
            _hasBind = true;

            //(dataGridView1.Columns["SendTime"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(SendTime));

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
            row.Cells["AutoSend"].Value = msg.AutoSend;
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
                var autoSend = row.Cells["AutoSend"] as DataGridViewCheckBoxCell;
                if (content.Value != null)
                {
                    var msg = new Model.Message
                    {
                        Content = content.Value.ToString(),
                        AutoSend = autoSend.Value.ToString() == "True",
                    };
                    if (msg.AutoSend)
                    {
                        msg.SendTime = SendTime.启动;//目前只支持启动
                    }
                    list.Add(msg);
                }
            }
            DataManager.Save(list);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("保存成功");
        }
    }
}
