using LoowooTech.LEDController.LEDDriver;
using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server.Managers
{
    public class LEDAdapterManager
    {
        private LEDAdapterManager()
        { }

        public static readonly LEDAdapterManager Instance = new LEDAdapterManager();
        private DataManager DataManager = DataManager.Instance;

        public static readonly LEDAdapter LEDAdapter = new LEDAdapter();


        public void OpenLEDScreens()
        {
            var list = DataManager.GetList<LEDScreen>();
            foreach (var led in list)
            {
                if (!led.HasOpen)
                {
                    LEDAdapter.Open(led.ID);
                }
            }
        }

        public void CreateWindows()
        {
            var list = DataManager.GetList<ClientWindow>();
            LEDAdapter.RemoveAllWindows();
            foreach (var model in list)
            {
                model.LEDVirtualID = LEDAdapter.CreateWindow(model.MarginLeft, model.MarginTop, model.Width, model.Height, model.LEDID);
            }
            DataManager.Save(list);
        }
    }
}
