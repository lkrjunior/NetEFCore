using Microsoft.EntityFrameworkCore;
using NetEFCore.Core.Models;

namespace NetEFCore.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}