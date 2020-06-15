using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.IServices
{
    public interface IRoleService
    {
        IQueryable<Role> getRoles();
        void save();
    }
}
