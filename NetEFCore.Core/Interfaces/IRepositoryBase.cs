using System;
using System.Linq.Expressions;

namespace NetEFCore.Core.Interfaces
{
    public interface IRepositoryBase<T>
        where T : class
    {
        Task<T?> Get(int id);
        Task<IList<T>> List();
        Task<IList<T>> List(Expression<Func<T, bool>> expression);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

