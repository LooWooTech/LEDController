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


        public bool ShowText(string clientId, string content)
        {
            var client = DataManager.GetClientWindow(clientId);
            LEDAdapterManager.LEDAdapter.SetFont(new Font(client.FontFamily, client.FontSize), (ContentAlignment)client.TextAlignment, 0, client.LEDVirtualID);
            //持续时间、编号类型
            LEDAdapterManager.LEDAdapter.SendContent(content, (int)client.TextAnimation, 10, client.LEDVirtualID);

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
    }
}
