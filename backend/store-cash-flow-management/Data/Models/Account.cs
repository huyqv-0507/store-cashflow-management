using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Account
    {
        public Account()
        {
            StoreEmployee = new HashSet<StoreEmployee>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? TimeCreated { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<StoreEmployee> StoreEmployee { get; set; }
    }
}
