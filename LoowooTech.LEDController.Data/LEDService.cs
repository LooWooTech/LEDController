using LoowooTech.LEDController.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LoowooTech.LEDController.Data
{
    public class LEDService : MarshalByRefObject
    {
        private DataManager DataManager = DataManager.Instance;

        private ClientWindow GetWindow(string clientId)
        {
            var window = DataManager.GetClientWindow(clientId);
            if (window.LEDVirtualID < 0)
            {
                LEDAdapterManager.Instance.CreateWindow(window);
            }
            return window;
        }

        public bool ShowText(string clientId, string content)
        {
            var window = GetWindow(clientId);
            LEDAdapterManager.LEDAdapter.SetFont(new Font(window.FontFamily, window.FontSize), (ContentAlignment)window.TextAlignment, 0, window.LEDVirtualID);
            //持续时间、编号类型
            LEDAdapterManager.LEDAdapter.SendContent(content, (int)window.TextAnimation, 10, window.LEDVirtualID);

            return true;
        }

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

        public void ClearWindow(string clientId)
        {
            ShowText(clientId, null);
        }

        public void OpenWindow(string clientId)
        {
            var window = GetWindow(clientId);
            LEDAdapterManager.LEDAdapter.Open(window.LEDVirtualID);
        }

        public void CloseWindow(string clientId)
        {
            var window = GetWindow(clientId);
            LEDAdapterManager.LEDAdapter.Close(window.LEDVirtualID);
        }
    }
}
