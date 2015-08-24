using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Model
{
    public class Command
    {
        public Command()
        {
            SendTime = DateTime.Now;
        }

        public string ClientId { get; set; }

        public string Path { get; set; }

        public string Body { get; set; }

        public DateTime SendTime { get; set; }
    }
}
