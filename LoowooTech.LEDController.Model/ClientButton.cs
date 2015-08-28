using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Model
{
    public enum ClientButtonType
    {
        普通,
        开始,
        暂停,
        下班,
        故障,
        倒计时
    }

    public class ClientButton
    {
        public ClientButton()
        {
            Type = ClientButtonType.普通;
        }

        public ClientButtonType Type { get; set; }

        public string Message { get; set; }
    }
}
