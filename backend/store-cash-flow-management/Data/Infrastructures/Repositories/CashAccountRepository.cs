using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class CashAccountRepository : RepositoryBase<CashAccount>, ICashAccountRepository
    {
        public CashAccountRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
