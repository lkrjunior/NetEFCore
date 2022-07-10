using System;
using NetEFCore.Core.Infrastructure.Data;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;

namespace NetEFCore.Core.Infrastructure.Repositories
{
    public class PessoaJuridicaRepository : RepositoryBase<PessoaJuridica>, IRepositoryBase<PessoaJuridica>
    {
        public PessoaJuridicaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}