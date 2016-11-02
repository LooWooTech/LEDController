using LoowooTech.LEDController.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDController.Service
{
    public class NumberService : MarshalByRefObject
    {
        private LEDManager LEDManager = LEDManager.Instance;

        public void SendMessage(string clientId, string content)
        {
            LEDManager.SendMessage(clientId, content);
        }
    }
}
