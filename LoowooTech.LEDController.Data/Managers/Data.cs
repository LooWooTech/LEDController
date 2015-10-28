using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDController.Data
{
    public class Data
    {
        public Data()
        {
            CreateTime = DateTime.Now;
        }

        public int ID { get; set; }

        public DataType Type { get; set; }

        public DateTime CreateTime { get; set; }

        public string DataJson { get; set; }

        private object _data;

        public T GetObject<T>()
        {
            try
            {
                if (_data == null)
                {
                    _data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(DataJson);
                }
            }
            catch { }
            return (T)_data;
        }

        public void SetObject(Object obj)
        {
            _data = obj;
            if (obj == null)
            {
                DataJson = null;
            }
            else
            {
                DataJson = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
        }

    }

    public enum DataType
    {
        Message = 1,
        ClientButton,
        ClientWindow,
        LEDScreen,
        Admin,
        OffworkTime,
        SystemConfig
    }
}
