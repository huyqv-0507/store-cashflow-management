using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CashAccount
    {
        public long Id { get; set; }
        public decimal? TotalCashIncome { get; set; }
        public DateTime? Time { get; set; }
        public int? IdStore { get; set; }

        public virtual Store IdStoreNavigation { get; set; }
    }
}
