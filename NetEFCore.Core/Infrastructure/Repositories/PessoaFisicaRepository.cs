using System;
using NetEFCore.Core.Infrastructure.Data;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;

namespace NetEFCore.Core.Infrastructure.Repositories
{
    public class PessoaFisicaRepository : RepositoryBase<PessoaFisica>, IRepositoryBase<PessoaFisica>
    {
        public PessoaFisicaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

