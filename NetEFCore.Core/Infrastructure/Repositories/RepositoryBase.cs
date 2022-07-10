using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NetEFCore.Core.Infrastructure.Data;
using NetEFCore.Core.Interfaces;

namespace NetEFCore.Core.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        private readonly AppDbContext _appDbContext;

        protected RepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public virtual async Task<T?> Get(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task Insert(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
        }

        public virtual async Task<IList<T>> List()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IList<T>> List(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public virtual void Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}