using System;
namespace NetEFCore.Core.Interfaces
{
    public interface IRepository<T>
        where T : IEntity
    {
    }
}

