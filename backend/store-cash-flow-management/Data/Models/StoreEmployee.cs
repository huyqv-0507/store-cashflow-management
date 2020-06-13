using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class StoreEmployee
    {
        public long Id { get; set; }
        public int? IdStore { get; set; }
        public long? IdAccount { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
        public virtual Store IdStoreNavigation { get; set; }
    }
}
