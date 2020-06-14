using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class CashTransactionRepository : RepositoryBase<CashTransaction>, ICashTransactionRepository
    {
        public CashTransactionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
