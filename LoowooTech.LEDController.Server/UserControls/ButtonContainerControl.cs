using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDController.Server.Managers;
using LoowooTech.LEDController.Model;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class ButtonContainerControl : UserControl, IContainerControl
    {
        private DataManager DataManager = DataManager.Instance;

        public ButtonContainerControl()
        {
            InitializeComponent();
        }

        private bool _hasBind;
        public void BindData()
        {
            if (_hasBind) return;
            _hasBind = true;

            (dataGridView1.Columns["Type"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(ClientButtonType));

            var data = DataManager.GetList<Model.ClientButton>();
            foreach (var item in data)
            {
                AddRow(item);
            }
        }

        private void AddRow(Model.ClientButton model)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];

            row.Cells["Type"].Value = model.Type.ToString();
            row.Cells["Message"].Value = model.Message;

            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new Model.ClientButton());
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
            var list = new List<Model.ClientButton>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var model = new Model.ClientButton
                {
                    Type = (ClientButtonType)Enum.Parse(typeof(ClientButtonType), row.Cells["Type"].Value.ToString()),
                    Message = row.Cells["Message"].Value.ToString()
                };
                list.Add(model);
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
