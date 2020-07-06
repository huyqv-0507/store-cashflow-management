using System;
using System.Collections.Generic;
using System.Text;

namespace Data.RequestModel
{
    public class CreateAccountModel
    {
        public string Usernanme { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
        public string Name { get; set; }

    }
}
