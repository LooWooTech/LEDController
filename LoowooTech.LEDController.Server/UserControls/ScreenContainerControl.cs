using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDController.Data;
using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Server;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class ScreenContainerControl : UserControl, IContainerControl
    {
        private DataManager DataManager = DataManager.Instance;

        public ScreenContainerControl()
        {
            InitializeComponent();
        }

        private bool _hasBind;
        public void BindData()
        {
            if (_hasBind) return;
            _hasBind = true;
            var data = DataManager.GetList<LEDScreen>();
            foreach (var item in data)
            {
                AddRow(item);
            }
        }

        private void AddRow(LEDScreen model)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];

            row.Cells["ID"].Value = model.ID;
            row.Cells["Width"].Value = model.Width;
            row.Cells["Height"].Value = model.Height;

            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new LEDScreen());
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
            var list = new List<LEDScreen>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    var model = new LEDScreen();

                    var id = 0;
                    int.TryParse(row.Cells["ID"].Value.ToString(), out id);
                    model.ID = id;

                    var width = 0;
                    int.TryParse(row.Cells["Width"].Value.ToString(), out width);
                    model.Width = width;

                    var height = 0;
                    int.TryParse(row.Cells["Height"].Value.ToString(), out height);
                    model.Height = height;

                    list.Add(model);
                }
                catch { }
            }
            DataManager.Save(list);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("保存成功");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            LEDAdapterManager.Instance.OpenLEDScreens();
        }
    }
}
