using Data.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IStoreService
    {
        IQueryable<Store> getStores();
        Store getStoreById(int id);

        IPagedList<Store> getStoreByPage(int? page, int? pageSize);

    }
}
