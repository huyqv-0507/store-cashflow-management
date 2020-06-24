using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class RegisterCashTransaction
    {
        public RegisterCashTransaction()
        {
            CashTransaction = new HashSet<CashTransaction>();
        }

        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public string Note { get; set; }
        public int? ShiftId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? RegisterId { get; set; }

        public virtual Register Register { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual ICollection<CashTransaction> CashTransaction { get; set; }
    }
}
