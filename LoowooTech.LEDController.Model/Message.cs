using System;
using System.Collections.Generic;

using System.Text;

namespace LoowooTech.LEDController.Model
{
    public class Message
    {
        public string Content { get; set; }
        
        public bool AutoSend { get; set; }

        public SendTime? SendTime { get; set; }
    }

    public enum SendTime
    { 
        无 = 0,
        启动 = 1,
        退出 = 2
    }
}
