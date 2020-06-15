using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Store
    {
        public Store()
        {
            Register = new HashSet<Register>();
            StoreCash = new HashSet<StoreCash>();
            StoreEmployee = new HashSet<StoreEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? TimeCreated { get; set; }

        public virtual ICollection<Register> Register { get; set; }
        public virtual ICollection<StoreCash> StoreCash { get; set; }
        public virtual ICollection<StoreEmployee> StoreEmployee { get; set; }
    }
}
