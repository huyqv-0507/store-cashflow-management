using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CashType
    {
        public CashType()
        {
            StoreCash = new HashSet<StoreCash>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StoreCash> StoreCash { get; set; }
    }
}
