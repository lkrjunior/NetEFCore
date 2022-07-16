using System;
using Microsoft.AspNetCore.Http;
using Moq;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;
using NetEFCore.Core.Service;

namespace NetEFCore.Test.Service
{
    public class PessoaFisicaServiceTest
    {
        [Fact]
        public async Task ShouldInsertPessoaFisicaWhenPayloadIsValid()
        {
            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };
            var expectedEntity = default(PessoaFisica);

            var mockRepository = new Mock<IRepositoryBase<PessoaFisica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.InsertAsync(It.IsAny<PessoaFisica>())).Returns((PessoaFisica entityToSave) =>
            {
                expectedEntity = entityToSave;

                return Task.CompletedTask;
            });

            mockUnitOfWork.Setup(x => x.PessoaFisicaRepository).Returns(mockRepository.Object);

            var service = new PessoaFisicaService(mockUnitOfWork.Object);

            var result = await service.InsertAsync(entity);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.Equal(expectedEntity, entity);
            mockRepository.Verify(x => x.InsertAsync(It.IsAny<PessoaFisica>()), Times.Once);
        }

        [Fact]
        public async Task ShouldUpdatePessoaFisicaWhenPayloadIsValid()
        {
            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaFisica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.Update(It.IsAny<PessoaFisica>())).Verifiable();

            mockUnitOfWork.Setup(x => x.PessoaFisicaRepository).Returns(mockRepository.Object);

            var service = new PessoaFisicaService(mockUnitOfWork.Object);

            var result = await service.UpdateAsync(entity);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            mockRepository.Verify(x => x.Update(It.IsAny<PessoaFisica>()), Times.Once);
        }

        [Fact]
        public async Task ShouldGetPessoaFisicaWhenPayloadIsValid()
        {
            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaFisica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(entity);

            mockUnitOfWork.Setup(x => x.PessoaFisicaRepository).Returns(mockRepository.Object);

            var service = new PessoaFisicaService(mockUnitOfWork.Object);

            var result = await service.GetAsync(1);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.Equal(entity, result.Data);
            mockRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task ShouldListPessoaFisicaWhenPayloadIsValid()
        {
            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaFisica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.ListAsync()).ReturnsAsync(new List<PessoaFisica>() { entity });

            mockUnitOfWork.Setup(x => x.PessoaFisicaRepository).Returns(mockRepository.Object);

            var service = new PessoaFisicaService(mockUnitOfWork.Object);

            var result = await service.ListAsync();

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.True(result.Data?.Count() >= 1);
            mockRepository.Verify(x => x.ListAsync(), Times.Once);
        }

        [Fact]
        public async Task ShouldDeletePessoaFisicaWhenPayloadIsValid()
        {
            var entity = new PessoaFisica()
            {
                Id = 1,
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var mockRepository = new Mock<IRepositoryBase<PessoaFisica>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRepository.Setup(x => x.GetAsync(entity.Id)).ReturnsAsync(entity);
            mockRepository.Setup(x => x.Delete(It.IsAny<PessoaFisica>())).Verifiable();

            mockUnitOfWork.Setup(x => x.PessoaFisicaRepository).Returns(mockRepository.Object);

            var service = new PessoaFisicaService(mockUnitOfWork.Object);

            var result = await service.DeleteAsync(1);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            mockRepository.Verify(x => x.GetAsync(entity.Id), Times.Once);
            mockRepository.Verify(x => x.Delete(It.IsAny<PessoaFisica>()), Times.Once);
        }
    }
}

