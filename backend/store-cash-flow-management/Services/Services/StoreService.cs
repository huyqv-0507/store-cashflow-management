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

        public Store getStoreById(int id)
        {
            return _repo.GetById(id);
        }

        public IPagedList<Store> getStoreByPage(int? page,int? pageSize)
        {
            int pageNumber = (page ?? 1);
            int size = (pageSize ?? 3);
            return _repo.GetAll().ToPagedList(pageNumber,size);
        }


        public IQueryable<Store> getStores()
        {
            return _repo.GetAll();
        }
        
        
        public void save()
        {
            _unitOfWork.Commit();
        }
    }
}


