using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Register
    {
        public Register()
        {
            RegisterCashTransaction = new HashSet<RegisterCashTransaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string Status { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<RegisterCashTransaction> RegisterCashTransaction { get; set; }
    }
}
