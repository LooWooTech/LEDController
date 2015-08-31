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
using LoowooTech.LEDController.Server;

namespace LoowooTech.LEDController.Server.UserControls
{
    public partial class WindowContainerControl : UserControl, IContainerControl
    {
        private DataManager DataManager = DataManager.Instance;
        private ILEDAdapter LEDAdapter;

        public WindowContainerControl()
        {
            InitializeComponent();
        }

        private bool _hasBind;
        public void BindData()
        {
            if (_hasBind) return;
            _hasBind = true;

            //(dataGridView1.Columns["LEDID"] as DataGridViewComboBoxColumn).DataSource = DataManager.GetList<LEDScreen>().Select(e => e.ID).ToArray();
            (dataGridView1.Columns["TextAlignment"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(TextAlignment));
            (dataGridView1.Columns["TextAnimation"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(TextAnimation));


            var data = DataManager.GetList<ClientWindow>();
            foreach (var item in data)
            {
                AddRow(item);
            }
        }

        private void AddRow(ClientWindow model)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];

            row.Cells["ID"].Value = model.ID;
            row.Cells["LEDID"].Value = model.LEDID;
            row.Cells["Width"].Value = model.Width;
            row.Cells["Height"].Value = model.Height.ToString();
            row.Cells["TextAlignment"].Value = model.TextAlignment.ToString();
            row.Cells["TextAnimation"].Value = model.TextAnimation.ToString();
            row.Cells["FontFamily"].Value = model.FontFamily;
            row.Cells["FontSize"].Value = model.FontSize.ToString();
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

                    var ledId = 0;
                    int.TryParse(row.Cells["LEDID"].Value.ToString(), out ledId);
                    model.LEDID = ledId;

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

                    model.TextAlignment = (TextAlignment)Enum.Parse(model.TextAlignment.GetType(), row.Cells["TextAlignment"].Value.ToString());
                    model.TextAnimation = (TextAnimation)Enum.Parse(model.TextAnimation.GetType(), row.Cells["TextAnimation"].Value.ToString());

                    //if (!model.HasCreated)
                    //{
                    //    //创建虚拟窗口，返回窗口虚拟ID
                    //    model.LEDVirtualID = LEDAdapter.CreateWindow(model.MarginLeft, model.MarginTop, model.Width, model.Height);
                    //}

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

        private void btnCreateWindow_Click(object sender, EventArgs e)
        {
            LEDAdapterManager.Instance.CreateWindows();
        }
    }
}
