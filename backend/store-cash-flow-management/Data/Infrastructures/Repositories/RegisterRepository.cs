using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class RegisterRepository : RepositoryBase<Register>, IRegisterRepository
    {
        public RegisterRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
