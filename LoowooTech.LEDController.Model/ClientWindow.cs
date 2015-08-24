using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Models
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

        public int X { get; set; }

        public int Y { get; set; }

        public TextAnimation TextAnimation { get; set; }
    }
}
