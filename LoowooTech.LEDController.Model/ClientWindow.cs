using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LoowooTech.LEDController.Model
{
    public class ClientWindow
    {
        public string ID { get; set; }

        public string ScreenId { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MarginLeft { get; set; }

        public int MarginTop { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }

        public TextAnimation TextAnimation { get; set; }

        public string FontFamily { get; set; }

        public int FontSize { get; set; }
    }
}
