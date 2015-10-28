using System;
using System.Collections.Generic;

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
        前台管理员,
        后台管理员,
        系统管理员,
    }
}
