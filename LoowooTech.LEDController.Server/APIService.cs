using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server.API
{
    public class APIService
    {
        public bool ShowText(string clientId, string content)
        {
            Console.WriteLine(content);
            return true;
        }

        public string DownloadConfig(string clientId)
        {
            return "hello world!";
        }
    }
}
