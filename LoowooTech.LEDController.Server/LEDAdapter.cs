using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server
{
    public class LEDAdapter : ILEDAdapter
    {
        public bool Open(int ledIndex)
        {
            throw new NotImplementedException();
        }

        public void Close(int ledIndex)
        {
            throw new NotImplementedException();
        }

        public int CreateWindow(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void RemoveWindow(int windowId)
        {
            throw new NotImplementedException();
        }

        public void SetFont(System.Drawing.Font font, System.Drawing.ContentAlignment alignment, int rowSpace, int windowId)
        {
            throw new NotImplementedException();
        }

        public void SendContent(string content, int animationType, int holdTime, int windowId)
        {
            throw new NotImplementedException();
        }
    }
}
