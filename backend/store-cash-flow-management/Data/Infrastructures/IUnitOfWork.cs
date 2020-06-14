using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures
{
    public interface IUnitOfWork
    {
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private CashManageStoreContext _dbContext;
        private readonly IDbFactory _dbFactory;
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public CashManageStoreContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
