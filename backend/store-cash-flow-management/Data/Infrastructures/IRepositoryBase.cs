using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Infrastructures
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(object id);
        IQueryable<T> GetAll();
        List<T> GetPaged(int page, int pageSize);
    }
}
