using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList.Core;
using Data.EditModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Services.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        public StoreService(IStoreRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public bool createStore(StoreUpdateModel store)
        {
            if(store != null)
            {
                var tmp = new Store();
                tmp.Name = store.Name;
                tmp.Address = store.Address;
                tmp.Phone = store.Phone;
                tmp.TimeCreated = DateTime.Now;
                _repo.Add(tmp);
                this.save();
                return true;
            }
            return false;                
        }

        public bool deleteStore(int id)
        {
            if(id != null && id > 0)
            {
                var store = _repo.GetById(id);
                if(store != null)
                {
                    _repo.Delete(store);
                    this.save();
                    return true;
                }                             
            }
            return false;
        }

        public Store getStoreById(int id)
        {
            return _repo.GetById(id);
        }
      


        public IQueryable<Store> getStores()
        {
            return _repo.GetAll();
        }
        
        
        public  void save()
        {
            _unitOfWork.Commit();
        }

        public bool updateStore(StoreUpdateModel store)
        {
            if(store != null)
            {
                var tmp = _repo.GetById(store.Id);
                if (!store.Name.Equals(tmp.Name) && !store.Name.Equals("string"))
                {
                    tmp.Name = store.Name;
                }
                if (!store.Address.Equals(tmp.Address) && !store.Address.Equals("string"))
                {
                    tmp.Address = store.Address;
                }
                if (!store.Phone.Equals(tmp.Phone) && !store.Phone.Equals("string"))
                {
                    tmp.Phone = store.Phone;
                }
                _repo.Update(tmp);
                this.save();
                return true;
            }
            return false;
        }

        
    }
}


