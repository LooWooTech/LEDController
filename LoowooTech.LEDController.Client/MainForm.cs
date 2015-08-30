using LoowooTech.LEDController.Client.APIServiceReference;
using LoowooTech.LEDController.Model;
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
        private readonly string ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];

        private Thread _bindDataThread;
        private Thread _countdownThread;
        private Thread _offworkThread;

        private ClientButton _offworkButton;
        private ClientButton _countdownButton;
        private readonly int CountDownNumber = 10;

        public MainForm()
        {
            if (string.IsNullOrEmpty(ClientId))
            {
                MessageBox.Show("请在App.config里配置ClientId，再启动软件。");
                Application.Exit();
                return;
            }
            InitializeComponent();
            _bindDataThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        BindData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread.Sleep(1000 * 60);
                }

            });
            _bindDataThread.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _bindDataThread.Abort();

            if (_offworkThread != null)
            {
                _offworkThread.Abort();
            }
            if (_countdownThread != null)
            {
                _countdownThread.Abort();
            }
        }

        private void BindData()
        {
            var client = new APIServiceClient();
            var json = client.DownloadConfig(ClientId);
            var data = JsonConvert.DeserializeObject<JObject>(json);

            var messages = data["messages"].ToObject<List<Model.Message>>();
            var buttons = data["buttons"].ToObject<List<Model.ClientButton>>();
            var window = data["window"].ToObject<Model.ClientWindow>();
            var offworkTimes = data["offworktimes"].ToObject<List<Model.OffworkTime>>();

            _offworkButton = buttons.FirstOrDefault(e => e.Type == Model.ClientButtonType.下班);
            _countdownButton = buttons.FirstOrDefault(e => e.Type == Model.ClientButtonType.倒计时);

            this.BeginInvoke(new Action(() =>
            {
                //绑定消息下拉框
                cbxMessage.DataSource = messages.Select(e => e.Content).ToArray();
                //绑定下班时间下拉框
                cbxOffworkTime.DataSource = offworkTimes.Select(e => new TimeSpan(e.Hour, e.Minute, 0).ToString()).ToArray();
                //绑定文字窗口
                labMessage.TextAlign = (ContentAlignment)((int)window.TextAlignment);
                //判断下班、倒计时按钮是否可见
                offworkPanel.Visible = _offworkButton != null;
                btnCountDown.Visible = _countdownButton != null;
                //加载其他按钮
                foreach (var btn in buttons.Where(e => e.Type != ClientButtonType.倒计时 && e.Type != ClientButtonType.下班))
                {
                    var control = new Button()
                    {
                        Text = btn.Type.ToString(),
                        BackColor = Color.SteelBlue,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Width = 85,
                        Height = 32
                    };
                    //按钮点击事件
                    control.Click += (sender, e) => SendMessage(btn.Message);
                    buttonContainer.Controls.Add(control);
                }
            }));
            client.Close();
        }

        private void SendMessage(string msg)
        {
            var client = new APIServiceClient();
            labMessage.Text = msg;
            client.ShowText(ClientId, msg);
            client.Close();
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

        private void btnCountDown_Click(object sender, EventArgs e)
        {

        }
    }
}
