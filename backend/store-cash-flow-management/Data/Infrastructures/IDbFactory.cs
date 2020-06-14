using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructures
{
    public interface IDbFactory
    {
        CashManageStoreContext Init();
    }
    public class DbFactory : Disposable, IDbFactory
    {
        CashManageStoreContext dbContext;
        public CashManageStoreContext Init()
        {
            return dbContext ?? (dbContext = new CashManageStoreContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
