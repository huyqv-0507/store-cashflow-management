using Data.RequestModel;
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

        bool createStore(StoreUpdateModel store);
        bool updateStore(StoreUpdateModel store);
        bool deleteStore(int id);
    }   
}
