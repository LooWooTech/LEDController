using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LoowooTech.LEDController.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var hasStarted = 0;
            Process proc = Process.GetCurrentProcess();
            foreach (var p in Process.GetProcesses())
            {
                if (p.ProcessName == proc.ProcessName)
                {
                    hasStarted++;
                }
            }
            if (hasStarted > 1)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();
            if (args.Length > 0)
            {
                mainForm.UserNo = args[0];
                if (args.Length > 1)
                {
                    mainForm.UserName = args[1];
                }
                StartChecker();
            }

            Application.Run(mainForm);
        }

        private static Process process;

        public static void StartChecker()
        {
            process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "ClientChecker.exe");
            var clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
            var serviceUrl = System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"];
            var appName = AppDomain.CurrentDomain.FriendlyName;
            psi.Arguments = string.Join(" ", new[] { clientId, appName, serviceUrl });
            //psi.CreateNoWindow = true;
            //psi.UseShellExecute = false;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo = psi;

            // run the process
            process.Start();
        }

        public static void StopChecker()
        {
            try
            {
                if (process != null)
                {
                    process.Kill();
                }
            }
            catch { }
        }
    }
}
