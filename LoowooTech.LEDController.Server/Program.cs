using LoowooTech.LEDController.Server.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;

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
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            var host = new ServiceHost(typeof(APIService));
            host.Open();

            Managers.LEDAdapterManager.Instance.OpenLEDScreens();
            Managers.LEDAdapterManager.Instance.CreateWindows();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            var content = new StringBuilder();
            content.AppendLine(ex.Message);
            content.AppendLine(ex.StackTrace);
            File.WriteAllText(Path.Combine(logPath, ex.GetType().Name + DateTime.Now.Ticks.ToString() + ".txt"), content.ToString());
        }
    }
}
