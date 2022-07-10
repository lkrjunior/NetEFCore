using System;
using NetEFCore.Core.Infrastructure.Data;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;

namespace NetEFCore.Core.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IRepositoryBase<PessoaFisica> PessoaFisicaRepository { get; private set; }
        public IRepositoryBase<PessoaJuridica> PessoaJuridicaRepository { get; private set; }

        public UnitOfWork(AppDbContext appDbContext, IRepositoryBase<PessoaFisica> pessoaFisicaRepository, IRepositoryBase<PessoaJuridica> pessoaJuridicaRepository)
        {
            _appDbContext = appDbContext;
            PessoaFisicaRepository = pessoaFisicaRepository;
            PessoaJuridicaRepository = pessoaJuridicaRepository;
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}