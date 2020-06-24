using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.RequestModel
{
    public class AccountLoginModel
    {
        [Required]
        public string Username;
        [Required]
        public string Password;
    }
}
