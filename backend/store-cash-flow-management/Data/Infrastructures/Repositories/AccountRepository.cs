using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory)
            :base(dbFactory)
        {

        }
    }
}
