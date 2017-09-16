using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories
{
    public interface IRepository<T> where T:class
    {
        // CRUD
        bool Delete(T entity);
        bool Update(T entity);
        int Insert(T entity);
        IEnumerable<T> GetList();
        T GetById(int id);
    }
}
