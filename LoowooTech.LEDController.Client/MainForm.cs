using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDController.Client
{
    public partial class MainForm : Form
    {
        private string clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
        public MainForm()
        {
            if (string.IsNullOrEmpty(clientId))
            {
                MessageBox.Show("请在App.config里配置ClientId，再启动软件。");
                Application.Exit();
                return;
            }
            InitializeComponent();
            new Thread(() =>
            {
                BindData();

            }).Start();
        }

        private void BindData()
        {

            var client = new Client.APIServiceReference.APIServiceClient();
            var json = client.DownloadConfig(clientId);
            var data = JsonConvert.DeserializeObject<JObject>(json);

            var messages = data["messages"].ToObject<List<Model.Message>>();
            var buttons = data["buttons"].ToObject<List<Model.ClientButton>>();
            var window = data["window"].ToObject<Model.ClientWindow>();
            var offworkTimes = data["offworktimes"].ToObject<List<Model.OffworkTime>>();

            this.BeginInvoke(new Action(() =>
            {
                cbxMessage.DataSource = messages.Select(e => e.Content).ToArray();
                cbxOffworkTime.DataSource = offworkTimes.Select(e => new TimeSpan(e.Hour, e.Minute, 0).ToString()).ToArray();

                foreach (var btn in buttons)
                {

                }
            }));
        }

        private void SendMessage(string msg)
        {
            labMessage.Text = msg;
        }

        private void labTitle_DoubleClick(object sender, EventArgs e)
        {
            var historyForm = new HistoryForm();
            historyForm.Show();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxMessage.Text))
            {
                MessageBox.Show("请先选择或填写好内容，再点击发送按钮");
                return;
            }
            SendMessage(cbxMessage.Text);
        }

        private void btnOffwork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxOffworkTime.SelectedText))
            {
                MessageBox.Show("没有选择下班时间");
                return;
            }

            var arr = cbxOffworkTime.SelectedText.Split(':');
            var hour = int.Parse(arr[0]);
            var minute = int.Parse(arr[1]);

            var offworkTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hour, minute, 0);

            var lastMinutes = (DateTime.Now - offworkTime).TotalMinutes;

            SendMessage("离下班时间还剩" + lastMinutes + "分钟");
        }

        private int CountDownNumber = 10;

        private void btnCountDown_Click(object sender, EventArgs e)
        {
            CountDownThread = new Thread(() =>
            {

            });
        }

        private Thread CountDownThread;
    }
}
