using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Server.Managers;
using LoowooTech.LEDController.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace LoowooTech.LEDController.Server.API
{
    public class APIService : IAPIService
    {
        private DataManager DataManager = DataManager.Instance;
        private HistoryManager HistoryManager = HistoryManager.Instance;
        public bool ShowText(string clientId, string content)
        {
            var client = DataManager.GetList<ClientWindow>().FirstOrDefault(e => e.ID == clientId);
            LEDAdapterManager.LEDAdapter.SetFont(new Font(client.FontFamily, client.FontSize), (ContentAlignment)client.TextAlignment, 0, client.LEDVirtualID);
            //持续时间、编号类型
            LEDAdapterManager.LEDAdapter.SendContent(content, (int)client.TextAnimation, 10, client.LEDVirtualID);

            Console.WriteLine(content);
            HistoryManager.Add(new History
            {
                ClientId = clientId,
                Content = content
            });
            return true;
        }

        public string DownloadConfig(string clientId)
        {
            var messages = DataManager.GetList<Message>();
            var buttons = DataManager.GetList<ClientButton>();
            var window = DataManager.GetList<ClientWindow>().FirstOrDefault(e => e.ID == clientId);
            var offworktimes = DataManager.GetList<OffworkTime>();
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                messages,
                buttons,
                window,
                offworktimes
            });
        }
    }
}
