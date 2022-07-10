using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NetEFCore.Core.Infrastructure.Data;
using NetEFCore.Core.Infrastructure.Repositories;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;

namespace NetEFCore.Test.Infrastructure.Repositories
{
    public class UnitOfWorkTest
    {
        private Mock<AppDbContext> _mockAppDbContext;
        private Mock<DbSet<PessoaFisica>> _mockPessoaFisicas;
        private Mock<DbSet<PessoaJuridica>> _mockPessoaJuridicas;
        private Mock<IRepositoryBase<PessoaFisica>> _mockPessoaFisicaRepository;
        private Mock<IRepositoryBase<PessoaJuridica>> _mockPessoaJuridicaRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        public UnitOfWorkTest()
        {
            _mockAppDbContext = new Mock<AppDbContext>();
            _mockPessoaFisicas = new Mock<DbSet<PessoaFisica>>();
            _mockPessoaJuridicas = new Mock<DbSet<PessoaJuridica>>();
            _mockPessoaFisicaRepository = new Mock<IRepositoryBase<PessoaFisica>>();
            _mockPessoaJuridicaRepository = new Mock<IRepositoryBase<PessoaJuridica>>();
        }

        [Fact]
        public async Task ShouldSavePessoaFisicaWhenPayloadIsValid()
        {
            var pessoa = new PessoaFisica()
            {
                Id = 1,
                Name = "Test",
                Cpf = "12345678901",
                BirthDate = new DateTime(1980,1,1)
            };

            _mockPessoaFisicaRepository.Setup(x => x.InsertAsync(It.IsAny<PessoaFisica>())).Returns(Task.CompletedTask);

            var unitOfWork = new UnitOfWork(_mockAppDbContext.Object, _mockPessoaFisicaRepository.Object, _mockPessoaJuridicaRepository.Object);

            await unitOfWork.PessoaFisicaRepository.InsertAsync(pessoa);
            await unitOfWork.SaveAsync();


        }
    }
}

