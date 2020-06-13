using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            CashTransaction = new HashSet<CashTransaction>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CashTransaction> CashTransaction { get; set; }
    }
}
