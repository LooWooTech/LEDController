using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Server.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server.API
{
    public class APIService : IAPIService
    {
        private DataManager DataManager = DataManager.Instance;
        public bool ShowText(string clientId, string content)
        {
            Console.WriteLine(content);
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
