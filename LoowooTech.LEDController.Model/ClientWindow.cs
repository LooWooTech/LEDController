using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Model
{
    public class ClientWindow
    {
        public ClientWindow()
        {
            ClientId = Guid.NewGuid().ToString();
        }

        public string ClientId { get; set; }

        public string ScreenId { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MarginLeft { get; set; }

        public int MarginTop { get; set; }

        public HorizontalAlignment HorizonalAlignment { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }

        public TextAnimation TextAnimation { get; set; }

        public string FontFamily { get; set; }

        public string FontSize { get; set; }
    }
}
