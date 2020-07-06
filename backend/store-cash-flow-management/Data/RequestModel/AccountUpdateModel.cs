using System;
using System.Collections.Generic;
using System.Text;

namespace Data.RequestModel
{
    public class AccountUpdateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int IdRole { get; set; }       
        public bool isActive { get; set; }

    }
}
