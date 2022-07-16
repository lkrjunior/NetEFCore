using System;
using Microsoft.AspNetCore.Http;
using Moq;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;
using NetEFCore.Core.Service;

namespace NetEFCore.Test.Service
{
    public class PessoaJuridicaServiceTest
    {
        [Fact]
        public async Task ShouldInsertPessoaJuridicaWhenPayloadIsValid()
        {
            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };
            var expectedEntity = default(PessoaJuridica);

            var mockRepository = new Mock<IRepositoryBase<PessoaJuridica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.InsertAsync(It.IsAny<PessoaJuridica>())).Returns((PessoaJuridica entityToSave) =>
            {
                expectedEntity = entityToSave;

                return Task.CompletedTask;
            });

            mockUnitOfWork.Setup(x => x.PessoaJuridicaRepository).Returns(mockRepository.Object);

            var service = new PessoaJuridicaService(mockUnitOfWork.Object);

            var result = await service.InsertAsync(entity);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.Equal(expectedEntity, entity);
            mockRepository.Verify(x => x.InsertAsync(It.IsAny<PessoaJuridica>()), Times.Once);
        }

        [Fact]
        public async Task ShouldUpdatePessoaJuridicaWhenPayloadIsValid()
        {
            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaJuridica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.Update(It.IsAny<PessoaJuridica>())).Verifiable();

            mockUnitOfWork.Setup(x => x.PessoaJuridicaRepository).Returns(mockRepository.Object);

            var service = new PessoaJuridicaService(mockUnitOfWork.Object);

            var result = await service.UpdateAsync(entity);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            mockRepository.Verify(x => x.Update(It.IsAny<PessoaJuridica>()), Times.Once);
        }

        [Fact]
        public async Task ShouldGetPessoaJuridicaWhenPayloadIsValid()
        {
            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaJuridica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(entity);

            mockUnitOfWork.Setup(x => x.PessoaJuridicaRepository).Returns(mockRepository.Object);

            var service = new PessoaJuridicaService(mockUnitOfWork.Object);

            var result = await service.GetAsync(1);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.Equal(entity, result.Data);
            mockRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task ShouldListPessoaJuridicaWhenPayloadIsValid()
        {
            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaJuridica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.ListAsync()).ReturnsAsync(new List<PessoaJuridica>() { entity });

            mockUnitOfWork.Setup(x => x.PessoaJuridicaRepository).Returns(mockRepository.Object);

            var service = new PessoaJuridicaService(mockUnitOfWork.Object);

            var result = await service.ListAsync();

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.True(result.Data?.Count() >= 1);
            mockRepository.Verify(x => x.ListAsync(), Times.Once);
        }

        [Fact]
        public async Task ShouldDeletePessoaJuridicaWhenPayloadIsValid()
        {
            var entity = new PessoaJuridica()
            {
                Id = 1,
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaJuridica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.GetAsync(entity.Id)).ReturnsAsync(entity);
            mockRepository.Setup(x => x.Delete(It.IsAny<PessoaJuridica>())).Verifiable();

            mockUnitOfWork.Setup(x => x.PessoaJuridicaRepository).Returns(mockRepository.Object);

            var service = new PessoaJuridicaService(mockUnitOfWork.Object);

            var result = await service.DeleteAsync(1);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            mockRepository.Verify(x => x.GetAsync(entity.Id), Times.Once);
            mockRepository.Verify(x => x.Delete(It.IsAny<PessoaJuridica>()), Times.Once);
        }
    }
}

