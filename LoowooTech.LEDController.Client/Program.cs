using System;
using System.Collections.Generic;
using System.Linq;
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
            }
            Application.Run(mainForm);
        }
    }
}
