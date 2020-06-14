using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class CashTypeRepository : RepositoryBase<CashType>, ICashTypeRepository
    {
        public CashTypeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
