using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace LoowooTech.LEDController.Server.Managers
{
    [Table("History")]
    public class History
    {
        public History()
        {
            CreateTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public string ClientId { get; set; }
    }
}
