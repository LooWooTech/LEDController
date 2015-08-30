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
    public partial class OffworkTimeContainerControl : UserControl, IContainerControl
    {
        public OffworkTimeContainerControl()
        {
            InitializeComponent();
        }

        private DataManager DataManager = DataManager.Instance;

        private bool _hasBind;
        public void BindData()
        {
            if (_hasBind) return;
            _hasBind = true;

            var data = DataManager.GetList<Model.OffworkTime>();
            foreach (var item in data)
            {
                AddRow(item);
            }
        }

        private void AddRow(Model.OffworkTime model)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];

            row.Cells["Hour"].Value = (model.Hour < 10 ? "0" : "") + model.Hour.ToString();
            row.Cells["Minute"].Value = (model.Minute < 10 ? "0" : "") + model.Minute.ToString();

            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new Model.OffworkTime());
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
            var list = new List<Model.OffworkTime>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var model = new Model.OffworkTime
                {
                    Hour = int.Parse(row.Cells["Hour"].Value.ToString()),
                    Minute = int.Parse(row.Cells["Minute"].Value.ToString())
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
