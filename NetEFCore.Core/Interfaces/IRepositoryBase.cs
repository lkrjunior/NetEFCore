using System;
using System.Linq.Expressions;

namespace NetEFCore.Core.Interfaces
{
    public interface IRepositoryBase<T>
        where T : class
    {
        Task<T?> GetAsync(int id);
        Task<IList<T>> ListAsync();
        Task<IList<T>> ListAsync(Expression<Func<T, bool>> expression);
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

