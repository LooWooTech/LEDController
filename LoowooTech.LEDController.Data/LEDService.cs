using LoowooTech.LEDController.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDController.Data
{
    public class LEDService : MarshalByRefObject
    {
        private LEDManager LEDManager = LEDManager.Instance;

        public bool ShowText(string clientId, string content)
        {
            LEDManager.SendMessage(clientId, content);
            return true;
        }
        public void ClearWindow(string clientId)
        {
            ShowText(clientId, null);
        }

        public void OpenWindow(string clientId)
        {
            LEDManager.OpenWindow(clientId);
        }

        public void CloseWindow(string clientId)
        {
            LEDManager.CloseWindow(clientId);
        }

        private DataManager DataManager = DataManager.Instance;
        public string DownloadConfig(string clientId)
        {
            var messages = DataManager.GetList<Message>();
            var buttons = DataManager.GetList<ClientButton>();
            var window = DataManager.GetClientWindow(clientId);
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