using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class TransactionTypeRepository : RepositoryBase<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
