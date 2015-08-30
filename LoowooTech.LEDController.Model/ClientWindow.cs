using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Model
{
    public class ClientWindow
    {
        public ClientWindow()
        {
            FontSize = 4;
            FontFamily = "宋体";
            TextAlignment = Model.TextAlignment.中;
            TextAnimation = Model.TextAnimation.A;
        }

        public string ID { get; set; }

        public string ScreenId { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MarginLeft { get; set; }

        public int MarginTop { get; set; }

        public TextAlignment TextAlignment { get; set; }

        public TextAnimation TextAnimation { get; set; }

        public string FontFamily { get; set; }

        public int FontSize { get; set; }
    }

    public enum TextAlignment
    {
        左上 = 1,
        上 = 2,
        右上 = 4,

        左 = 16,
        中 = 32,
        右 = 64,

        左下 = 128,
        下 = 512,
        右下 = 1024
    }
}
