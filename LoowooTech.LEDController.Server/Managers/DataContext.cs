using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server.Managers
{
    public class DataContext : DbContext
    {
        public DataContext(string conn = "DbConnection")
            : base(conn)
        {
            Database.SetInitializer<DataContext>(null);
        }
        
        public DbSet<Data> Datas { get; set; }

        public DbSet<History> Histories { get; set; }
    }
}
