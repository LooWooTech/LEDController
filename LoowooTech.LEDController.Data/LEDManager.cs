using LoowooTech.LEDController.Data;
using LoowooTech.LEDController.LEDDriver;
using LoowooTech.LEDController.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDController.Data
{
    public class LEDManager
    {
        private static readonly LEDAdapter LEDAdapter = new LEDAdapter();

        private static readonly DataManager DataManager = DataManager.Instance;

        private LEDManager() { }

        public static readonly LEDManager Instance = new LEDManager();

        private ClientWindow GetWindow(string clientId)
        {
            var window = DataManager.GetClientWindow(clientId);
            if (window == null)
            {
                throw new Exception("没有找到窗口");
            }
            if (window.LEDVirtualID < 0)
            {
                CreateWindow(window);
            }
            return window;
        }

        public void OpenLEDScreens()
        {
            var list = DataManager.GetList<LEDScreen>();
            foreach (var led in list)
            {
                if (!led.HasOpen)
                {
                    var ret = LEDAdapter.Open(led.ID);
                }
            }
        }

        public void CreateWindow(ClientWindow model)
        {
            model.LEDVirtualID = LEDAdapter.CreateWindow(model.MarginLeft, model.MarginTop, model.Width, model.Height, model.LEDID);
        }

        public void CreateWindows()
        {
            var list = DataManager.GetList<ClientWindow>();
            LEDAdapter.RemoveAllWindows();
            foreach (var model in list)
            {
                CreateWindow(model);
            }
            DataManager.Save(list);
        }

        public void SendMessage(string clientId, string text)
        {
            var window = GetWindow(clientId);
            if (window == null)
            {
                throw new Exception("窗口不存在");
            }
            LEDAdapter.SetFont(new Font(window.FontFamily, window.FontSize), (ContentAlignment)window.TextAlignment, 0, window.LEDVirtualID);
            //持续时间、编号类型
            LEDAdapter.SendContent(text, (int)window.TextAnimation, 10, window.LEDVirtualID);
        }

        public void OpenWindow(string clientId)
        {
            var window = GetWindow(clientId);
            LEDAdapter.Open(window.LEDVirtualID);
        }

        public void ClearWindow(string clientId)
        {
            SendMessage(clientId, null);
        }

        public void CloseWindow(string clientId)
        {
            var window = GetWindow(clientId);
            LEDAdapter.Close(window.LEDVirtualID);
        }
    }

}