using LoowooTech.LEDController.Server.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDController.Server
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var host = new ServiceHost(typeof(APIService));
            host.Open();

            new Thread(() =>
            {
                Managers.LEDAdapterManager.Instance.OpenLEDScreens();
                Managers.LEDAdapterManager.Instance.CreateWindows();
            }).Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
