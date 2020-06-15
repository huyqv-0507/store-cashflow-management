using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IRoleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Role> getRoles()
        {
            return _repository.GetAll();
        }

        public void save()
        {
            _unitOfWork.Commit();
        }
    }
}
