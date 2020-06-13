using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CashTransaction
    {
        public CashTransaction()
        {
            Invoice = new HashSet<Invoice>();
        }

        public long Id { get; set; }
        public decimal? Cash { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? TransactionTypeId { get; set; }
        public long? RegisterCashTransactionId { get; set; }

        public virtual RegisterCashTransaction RegisterCashTransaction { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
