using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
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
        //private Mock<IMemoryCache> _mockMemoryCache;
        private Mock<IRepositoryBase<PessoaFisica>> _mockPessoaFisicaRepository;
        private Mock<IRepositoryBase<PessoaJuridica>> _mockPessoaJuridicaRepository;
        
        public UnitOfWorkTest()
        {
            //_mockMemoryCache = new Mock<IMemoryCache>();
            //var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseMemoryCache(_mockMemoryCache.Object)
            //    .Options;

            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("UnitTest")
                .Options;

            _mockAppDbContext = new Mock<AppDbContext>(dbContextOptions);
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

            _mockPessoaFisicaRepository.Verify(x => x.InsertAsync(It.IsAny<PessoaFisica>()), Times.Once);
        }
    }
}

