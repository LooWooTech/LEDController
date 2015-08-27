using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Server.Managers;
using System.Windows.Forms.VisualStyles;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class WindowContainerControl : UserControl, IContainerControl
    {
        private DataManager DataManager = new DataManager();
        
        public WindowContainerControl()
        {
            BindData();
        }

        private List<LEDScreen> Screens;
        public void BindData()
        {
            var data = DataManager.GetList<ClientWindow>();
            foreach (var item in data)
            {
                AddRow(item);
            }
            Screens =  DataManager.GetList<LEDScreen>();
            (dataGridView1.Columns["ScreenId"] as DataGridViewComboBoxColumn).DataSource = Screens;
            (dataGridView1.Columns["HorizonalAlignment"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(HorizontalAlignment));
            (dataGridView1.Columns["VerticalAlignment"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(VerticalAlignment));
            (dataGridView1.Columns["TextAnimation"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(TextAnimation));
        }

        private void AddRow(ClientWindow model)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];

            //((DataGridViewComboBoxCell)row.Cells["ScreenId"]).Value = model.ScreenId;

            row.Cells["ID"].Value = model.ID;
            row.Cells["ScreenId"].Value = model.ScreenId;
            row.Cells["Width"].Value = model.Width;
            row.Cells["Height"].Value = model.Height;
            row.Cells["HorizontalAlignment"].Value = model.HorizontalAlignment;
            row.Cells["VerticalAlignment"].Value = model.VerticalAlignment;
            row.Cells["TextAnimation"].Value = model.TextAnimation;
            row.Cells["FontFamily"].Value = model.FontFamily;
            row.Cells["FontSize"].Value = model.FontSize;
            row.Cells["MarginLeft"].Value = model.MarginLeft;
            row.Cells["MarginTop"].Value = model.MarginTop;

            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new ClientWindow());
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
            var list = new List<ClientWindow>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    var model = new ClientWindow();
                    model.ID = row.Cells["ID"].Value.ToString();

                    var width = 0;
                    int.TryParse(row.Cells["Width"].Value.ToString(), out width);
                    model.Width = width;

                    var height = 0;
                    int.TryParse(row.Cells["Height"].Value.ToString(), out height);
                    model.Height = height;

                    model.ScreenId = row.Cells["ScreenId"].Value.ToString();

                    int marginTop = 0;
                    int.TryParse(row.Cells["MarginTop"].Value.ToString(), out marginTop);
                    model.MarginTop = marginTop;

                    int marginLeft = 0;
                    int.TryParse(row.Cells["MarginLeft"].Value.ToString(), out marginLeft);
                    model.MarginLeft = marginLeft;

                    int fontSize = 0;
                    int.TryParse(row.Cells["FontSize"].Value.ToString(), out fontSize);
                    model.FontSize = fontSize;

                    model.FontFamily = row.Cells["FontFamily"].Value.ToString();

                    model.HorizontalAlignment = (System.Windows.Forms.HorizontalAlignment)Enum.Parse(model.VerticalAlignment.GetType(), row.Cells["HorizontalAlignment"].Value.ToString());
                    model.VerticalAlignment = (System.Windows.Forms.VisualStyles.VerticalAlignment)Enum.Parse(model.VerticalAlignment.GetType(), row.Cells["VerticalAlignment"].Value.ToString());
                    model.TextAnimation = (TextAnimation)Enum.Parse(model.TextAnimation.GetType(), row.Cells["TextAnimation"].Value.ToString());

                    list.Add(model);
                }
                catch { }
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
