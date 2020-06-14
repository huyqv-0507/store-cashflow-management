using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class StoreCash
    {
        public int Id { get; set; }
        public int? StoreId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public int? CashTypeId { get; set; }
        public decimal? CashAccount { get; set; }

        public virtual CashType CashType { get; set; }
        public virtual Store Store { get; set; }
    }
}
