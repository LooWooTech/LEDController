using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDController.Data;
using LoowooTech.LEDController.Model;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class AdminContainerControl : UserControl, IContainerControl
    {

        private DataManager DataManager = DataManager.Instance;
        public AdminContainerControl()
        {
            InitializeComponent();
        }

        private bool _hasBind;
        public void BindData()
        {
            if (_hasBind) return;
            _hasBind = true;
            (dataGridView1.Columns["Role"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(Role));
            var data = DataManager.GetList<Admin>();
            foreach (var item in data)
            {
                AddRow(item);
            }
        }

        private void AddRow(Model.Admin model)
        {
            var rowIndex = dataGridView1.Rows.Add();

            var row = dataGridView1.Rows[rowIndex];
            row.Cells["Username"].Value = model.Username;
            row.Cells["Password"].Value = model.Password;
            row.Cells["Role"].Value = model.Role.ToString();

            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new Model.Admin());
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
            var list = new List<Model.Admin>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    list.Add(new Admin
                    {
                        Username = row.Cells["Username"].Value.ToString(),
                        Password = row.Cells["Password"].Value.ToString(),
                        Role = (Role)Enum.Parse(typeof(Role), row.Cells["Role"].Value.ToString())
                    });
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
    }
}
