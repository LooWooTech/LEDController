using LoowooTech.LEDController.Data;
using System;
using System.Collections.Generic;

using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

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

            OpenService();

            LEDManager.Instance.OpenLEDScreens();
            LEDManager.Instance.CreateWindows();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        private static void OpenService()
        {
            var servicePort = 0;
            if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["ServicePort"], out servicePort))
            {
                servicePort = 8080;
            }
            var channel = new TcpServerChannel(servicePort);
            ChannelServices.RegisterChannel(channel, true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LEDService), "LEDService", WellKnownObjectMode.SingleCall);

            //排队机的监听服务
            var service2 = new QueueMachineService();
            service2.Start();
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
