using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Model
{
    public class Admin
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin1,
        Admin2,
        Admin3,
    }
}
