using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Text;

namespace LoowooTech.LEDController.Model
{
    public enum ClientButtonType
    {
        普通,
        开始,
        暂停,
        故障,
        下班,
        倒计数
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
