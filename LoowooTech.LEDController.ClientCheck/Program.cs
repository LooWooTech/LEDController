using LoowooTech.LEDController.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDController.ClientCheck
{
    public class Program
    {
        private static string _clientId;
        private static string _appName;
        private static string _serviceUrl;

        private static LEDService GetServiceClient()
        {
            return (LEDService)Activator.GetObject(typeof(LEDService), _serviceUrl);
        }

        static void Main(string[] args)
        {
            _clientId = args[0];
            _appName = args[1];
            _serviceUrl = args[2];

            while (true)
            {
                Thread.Sleep(1000);
                var apps = Process.GetProcessesByName(_appName);
                if (apps == null || apps.Length == 0)
                {
                    var client = GetServiceClient();
                    client.ClearWindow(_clientId);
                    break;
                }
            }
        }
    }
}
