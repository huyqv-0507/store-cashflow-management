using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Order
    {
        public long Id { get; set; }
        public long? IdEmployeeCategory { get; set; }
        public decimal? Cash { get; set; }
        public DateTime? TimeCreated { get; set; }
        public int? IdPayment { get; set; }
    }
}
