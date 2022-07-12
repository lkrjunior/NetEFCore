using System;
using NetEFCore.Core.Models;
using NetEFCore.Core.Models.Response;

namespace NetEFCore.Core.Interfaces
{
    public interface IPessoaService<T>
        where T : PessoaBase
    {
        Task<ServiceResponse<T>> Get(int id);
        Task<ServiceResponse<IEnumerable<T>>> List();
        Task<ServiceResponse<T>> Delete(int id);
        Task<ServiceResponse<T>> Insert(T entity);
        Task<ServiceResponse<T>> Update(T entity);
    }
}

