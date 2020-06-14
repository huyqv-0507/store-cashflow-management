using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cash { get; set; }
        public string CreateTime { get; set; }
        public long? CashTransactionId { get; set; }

        public virtual CashTransaction CashTransaction { get; set; }
    }
}
