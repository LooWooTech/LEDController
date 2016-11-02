using LoowooTech.LEDController.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
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
            if (args == null || args.Length != 3)
            {
                Console.WriteLine("参数不正确");
                Console.Read();
                return;
            }
            Console.WriteLine(string.Join("\n", args));
            _clientId = args[0];
            _appName = args[1];
            _serviceUrl = args[2];

            ChannelServices.RegisterChannel(new TcpClientChannel(), true);

            while (true)
            {
                Thread.Sleep(1000);
                var app = GetApp(_appName);
                if (app == null)
                {
                    Console.WriteLine("Doctor已被结束");
                    try
                    {
                        var client = GetServiceClient();
                        client.ShowText(_clientId, null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("清屏失败");
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
            }
        }

        private static Process GetApp(string appName)
        {
            var apps = Process.GetProcesses();
            foreach (var app in apps)
            {
                try
                {
                    if (app.MainModule.ModuleName == _appName)
                    {
                        return app;
                    }
                }
                catch { }
            }
            return null;
        }
    }
}
