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
    public partial class HistoryContainerControl : UserControl, IContainerControl
    {
        private HistoryManager HistoryManager = HistoryManager.Instance;
        private DataManager DataManager = DataManager.Instance;

        public HistoryContainerControl()
        {
            InitializeComponent();
        }

        private int _pageCount;
        private int _pageIndex;
        private int _pageSize = 20;

        private void BindPageData(int pageIndex = 1)
        {
            var clientId = cbxClientId.Text;
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            var data = HistoryManager.GetList(clientId, pageIndex, _pageSize, out _pageCount);

            if (pageIndex > _pageCount)
            {
                pageIndex = _pageCount;
            }

            _pageIndex = pageIndex;

            dataGridView1.DataSource = data;
        }

        public void BindData()
        {
            var clients = DataManager.GetList<ClientWindow>().Select(e => e.ID).ToArray();
            cbxClientId.Items.AddRange(clients);

            BindPageData();

        }

        public void SaveData()
        {
        }

        private void txtPage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnGo_Click(null, null);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var page = 0;
            if (int.TryParse(txtPage.Text, out page))
            {
                if (page <= 0) return;

                BindPageData(page);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            BindPageData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            BindPageData(_pageIndex - 1);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            BindPageData(_pageCount);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BindPageData(_pageIndex + 1);
        }
    }
}
