using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Server.Managers;
using LooWooTech.LEDController.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server.API
{
    public class APIService : IAPIService
    {
        private ILEDAdapter _ledAdapter;
        private DataManager DataManager = DataManager.Instance;
        private HistoryManager HistoryManager = HistoryManager.Instance;
        public bool ShowText(string clientId, string content)
        {
            var client = DataManager.GetList<ClientWindow>().FirstOrDefault(e=>e.ID == clientId);

            //持续时间、编号类型
            //_ledAdapter.SendContent(content, (int)client.TextAnimation, 10, client.ID);

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
