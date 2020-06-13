using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class RegisterCashTransactionRepository : RepositoryBase<RegisterCashTransaction>, IRegisterCashTransactionRepository
    {
        public RegisterCashTransactionRepository(IDbFactory dbFactory)
            : base (dbFactory)
        {

        }
    }
}
