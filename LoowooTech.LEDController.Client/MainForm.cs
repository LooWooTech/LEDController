using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDController.Client
{
    public partial class MainForm : Form
    {
        private readonly string ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];

        private delegate void Action();

        private Thread _bindDataThread;

        public string UserNo { get; set; }

        public string UserName { get; set; }

        private ClientButton _offworkButton;
        private ClientButton _countdownButton;
        private int _countDownNumber = 10;
        private bool _hasSendMessageOnStart;

        public MainForm()
        {
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!string.IsNullOrEmpty(UserNo))
            {
                labInfo.Text = "工号：" + UserNo;
                if (!string.IsNullOrEmpty(UserName))
                {
                    labInfo.Text += " 姓名：" + UserName;
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                var client = GetServiceClient();
                client.ClearWindow(ClientId);
            }
            catch
            {
            }
            _bindDataThread.Abort();
            Program.StopChecker();
            base.OnClosed(e);
        }

        private LEDService GetServiceClient()
        {
            return (LEDService)Activator.GetObject(typeof(LEDService), System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"]);
        }

        private void BindData()
        {
            var client = GetServiceClient();
            var json = client.DownloadConfig(ClientId);
            var data = JsonConvert.DeserializeObject<JObject>(json);
            var window = data["window"].ToObject<Model.ClientWindow>();
            if (window == null)
            {
                MessageBox.Show("没有在Config文件里配置ClientId，或者服务器不存在此窗口。");
                return;
            }

            var messages = data["messages"].ToObject<List<Model.Message>>();
            var buttons = data["buttons"].ToObject<List<Model.ClientButton>>();
            var offworkTimes = data["offworktimes"].ToObject<List<Model.OffworkTime>>();

            foreach (var btn in buttons)
            {
                if (btn.Type == ClientButtonType.下班)
                {
                    _offworkButton = btn;
                }
                if (btn.Type == ClientButtonType.倒计数)
                {
                    _countdownButton = btn;
                }
            }

            this.BeginInvoke(new Action(() =>
            {
                //绑定消息下拉框
                var msgDatasource = new List<string>();
                foreach (var msg in messages)
                {
                    if (!string.IsNullOrEmpty(msg.Content))
                    {
                        var content = msg.Content.Replace("{工号}", UserNo);
                        msgDatasource.Add(content);
                        //发送启动消息
                        if (!_hasSendMessageOnStart)
                        {
                            if (msg.AutoSend && msg.SendTime == SendTime.启动)
                            {
                                SendMessage(content);
                            }
                        }
                    }
                }
                _hasSendMessageOnStart = true;

                cbxMessage.DataSource = msgDatasource;
                //绑定下班时间下拉框
                var workTimeDatasource = new List<string>();
                foreach (var time in offworkTimes)
                {
                    workTimeDatasource.Add(new TimeSpan(time.Hour, time.Minute, 0).ToString());
                }
                cbxOffworkTime.DataSource = workTimeDatasource;
                //绑定文字窗口
                //ledPanel1.ChangeLedSize(300, 128);
                ledPanel1.Height = window.Height + 10;
                ledPanel1.Width = window.Width + 10;
                ledPanel1.TextAlign = (ContentAlignment)window.TextAlignment;
                ledPanel1.Font = new Font(window.FontFamily, window.FontSize);
                //判断下班按钮是否可见
                offworkPanel.Visible = _offworkButton != null;
                //加载其他按钮
                buttonContainer.Controls.Clear();
                foreach (var btn in buttons)
                {
                    if (btn.Type == ClientButtonType.下班) continue;

                    var control = new Button()
                    {
                        Text = btn.Type.ToString(),
                        BackColor = Color.SteelBlue,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Width = 85,
                        Height = 32
                    };
                    switch (btn.Type)
                    {
                        case ClientButtonType.故障:
                            control.BackColor = Color.Red;
                            break;
                        case ClientButtonType.倒计数:
                            control.BackColor = Color.Peru;
                            break;
                    }
                    //按钮点击事件
                    control.Click += (sender, e) =>
                    {
                        if (btn.Type == ClientButtonType.倒计数)
                        {
                            btnCountDown_Click(sender, e);
                        }
                        else
                        {
                            SendMessage(btn.Message);
                        }
                    };
                    buttonContainer.Controls.Add(control);
                }
            }));
        }

        private void SendMessage(string msg)
        {
            ledPanel1.Text = "发送中";
            new Thread(() =>
            {
                try
                {
                    var client = GetServiceClient();
                    client.ShowText(ClientId, msg);
                    ledPanel1.Invoke(new Action(() =>
                    {
                        ledPanel1.Text = msg;
                    }));
                }
                catch (Exception ex)
                {
                    ledPanel1.Invoke(new Action(() =>
                    {
                        ledPanel1.Text = "发送失败";
                    }));
                    MessageBox.Show("出错了\n" + ex.Message);
                }
            }).Start();
        }

        private void labTitle_DoubleClick(object sender, EventArgs e)
        {
            BindData();
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
            if (string.IsNullOrEmpty(cbxOffworkTime.Text))
            {
                MessageBox.Show("没有选择下班时间");
                return;
            }

            var arr = cbxOffworkTime.Text.Split(':');
            var hour = int.Parse(arr[0]);
            var minute = int.Parse(arr[1]);

            var offworkTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hour, minute, 0);
            if (offworkTime < DateTime.Now)
            {
                MessageBox.Show("已经下班");
                return;
            }
            var lastMinutes = (int)((offworkTime - DateTime.Now).TotalMinutes);
            var lastHour = lastMinutes / 60;
            SendMessage(_offworkButton.Message.Replace("{剩余分钟}", lastMinutes.ToString()));
        }

        private void btnCountDown_Click(object sender, EventArgs e)
        {
            SendMessage(_countdownButton.Message.Replace("{剩余人数}", _countDownNumber.ToString()));
            _countDownNumber--;
        }
    }
}
