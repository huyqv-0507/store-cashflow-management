using Data.Infrastructures.IRepositories;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures.Repositories
{
    public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
