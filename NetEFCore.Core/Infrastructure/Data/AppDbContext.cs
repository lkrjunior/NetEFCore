using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetEFCore.Core.Models;

namespace NetEFCore.Core.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }

    }
}