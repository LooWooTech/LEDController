using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server.Managers
{
    [Table("Data")]
    public class Data
    {
        public Data()
        {
            CreateTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DataType Type { get; set; }

        public DateTime CreateTime { get; set; }

        [Column("Data")]
        public byte[] DataBytes { get; set; }

        private object _data;

        public T GetObject<T>()
        {
            try
            {
                if (_data == null)
                {
                    var json = Encoding.UTF8.GetString(DataBytes);
                    _data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
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
                DataBytes = null;
            }
            else
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                DataBytes = Encoding.UTF8.GetBytes(json);
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
