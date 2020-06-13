using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class StoreCashRepository : RepositoryBase<StoreCash>, IStoreCashRepository
    {
        public StoreCashRepository(IDbFactory dbFactory)
            : base (dbFactory)
        {

        }
    }
}
