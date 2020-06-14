using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class StoreEmployeeRepository : RepositoryBase<StoreEmployee>, IStoreEmployeeRepository
    {
        public StoreEmployeeRepository(IDbFactory dbFactory)
            : base (dbFactory)
        {

        }
    }
}
