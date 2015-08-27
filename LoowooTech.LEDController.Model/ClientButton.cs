using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Model
{
    public enum ClientButtonType
    {
        [Description("开始")]
        Start,
        [Description("暂停")]
        Pause,
        [Description("下班")]
        //GetOffWork,
        //[Description("倒计时")]
        Countdown,
        [Description("故障")]
        Error,
    }

    public class ClientButton
    {
        [Newtonsoft.Json.JsonIgnore]
        public string Name
        {
            get
            {
                var field = typeof(ClientButtonType).GetField(Type.ToString());
                var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                return attr == null ? Type.ToString() : attr.Description;
            }
        }

        public ClientButtonType Type { get; set; }

        public string ContentFormat { get; set; }
    }
}
