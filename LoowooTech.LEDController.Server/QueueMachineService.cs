using LoowooTech.LEDController.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDController.Server
{
    public class QueueMachineService
    {
        private MessageServer _server;
        public QueueMachineService()
        {
            //排队机的监听服务
            var port = 0;
            if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["ServicePort2"], out port))
            {
                port = 8081;
            }
            var ipAddress = System.Configuration.ConfigurationManager.AppSettings["ServiceIP2"];

            _server = new MessageServer(ipAddress, port);

            _server.OnMessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            LEDManager.Instance.SendMessage(e.WinId, e.Text);
        }

        public void Start()
        {
            _server.Start();
        }

        public void Stop()
        {
            _server.Stop();
        }
    }
}