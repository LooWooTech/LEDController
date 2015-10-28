using System;
using System.Collections.Generic;

using System.Text;

namespace LoowooTech.LEDController.Model
{
    public class LEDScreen
    {
        public LEDScreen()
        {
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public bool HasOpen { get; set; }
    }

}
