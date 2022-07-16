using System;
using NetEFCore.Core.Models;
using NetEFCore.Core.Models.Response;

namespace NetEFCore.Core.Interfaces
{
    public interface IPessoaService<T>
        where T : PessoaBase
    {
        Task<ServiceResponse<T>> GetAsync(int id);
        Task<ServiceResponse<IEnumerable<T>>> ListAsync();
        Task<ServiceResponse<T>> DeleteAsync(int id);
        Task<ServiceResponse<T>> InsertAsync(T entity);
        Task<ServiceResponse<T>> UpdateAsync(T entity);
    }
}

