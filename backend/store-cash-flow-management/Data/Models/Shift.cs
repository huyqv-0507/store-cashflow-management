using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Shift
    {
        public Shift()
        {
            RegisterCashTransaction = new HashSet<RegisterCashTransaction>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RegisterCashTransaction> RegisterCashTransaction { get; set; }
    }
}
