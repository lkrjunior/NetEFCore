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
        public async Task ShouldCreatePessoaFisicaWhenPayloadIsValid()
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

            var result = await service.Insert(entity);

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.Equal(expectedEntity, entity);
        }
    }
}

