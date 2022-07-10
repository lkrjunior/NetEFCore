using System;
using NetEFCore.Core.Models;

namespace NetEFCore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryBase<PessoaFisica> PessoaFisicaRepository { get; }
        IRepositoryBase<PessoaJuridica> PessoaJuridicaRepository { get; }
        Task SaveAsync();
    }
}

