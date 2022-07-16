using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetEFCore.Core.Infrastructure.Data;
using NetEFCore.Core.Infrastructure.Repositories;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;
using NetEFCore.Core.Service;

namespace NetEFCore.Test.Service
{
    public class PessoaFisicaServiceInMemoryTest
    {
        private static IUnitOfWork GetUnitOfWork()
        {
            var dbName = Guid.NewGuid().ToString();
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            var appDbContext = new AppDbContext(dbContextOptions);

            var pessoaFisicaRepository = new PessoaFisicaRepository(appDbContext);
            var pessoaJuridicaRepository = new PessoaJuridicaRepository(appDbContext);

            var unitOfWork = new UnitOfWork(appDbContext, pessoaFisicaRepository, pessoaJuridicaRepository);

            return unitOfWork;
        }

        [Fact]
        public async Task ShouldInsertPessoaFisicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            var result = await service.InsertAsync(entity);

            #endregion

            #region Assert

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.True(entity.Id > 0);
            Assert.Equal(entity.Name, result.Data?.Name);
            Assert.Equal(entity.Cpf, result.Data?.Cpf);
            Assert.Equal(entity.BirthDate, result.Data?.BirthDate);

            #endregion
        }

        [Fact]
        public async Task ShouldUpdatePessoaFisicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var expectedCpf = "123";

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            await service.InsertAsync(entity);

            entity.Cpf = expectedCpf;

            var result = await service.UpdateAsync(entity);

            #endregion

            #region Assert

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.True(entity.Id > 0);
            Assert.Equal(entity.Name, result.Data?.Name);
            Assert.Equal(expectedCpf, result.Data?.Cpf);
            Assert.Equal(entity.BirthDate, result.Data?.BirthDate);

            #endregion
        }

        [Fact]
        public async Task ShouldDontUpdatePessoaFisicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            var exception = await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await service.UpdateAsync(entity));

            #endregion

            #region Assert

            Assert.NotNull(exception.Message);

            #endregion
        }

        [Fact]
        public async Task ShouldDeletePessoaFisicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            await service.InsertAsync(entity);

            var result = await service.DeleteAsync(entity.Id);

            #endregion

            #region Assert

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.Null(result.Data);

            #endregion
        }

        [Fact]
        public async Task ShouldDontDeletePessoaFisicaWhenPessoaNotExists()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            var result = await service.DeleteAsync(entity.Id);

            #endregion

            #region Assert

            Assert.True(result.HasError);
            Assert.Equal(StatusCodes.Status404NotFound, result.HttpStatusCode);
            Assert.NotNull(result.ErrorMessage);

            #endregion
        }

        [Fact]
        public async Task ShouldGetPessoaFisicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            await service.InsertAsync(entity);

            var result = await service.GetAsync(entity.Id);

            #endregion

            #region Assert

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.True(entity.Id > 0);
            Assert.Equal(entity.Name, result.Data?.Name);
            Assert.Equal(entity.Cpf, result.Data?.Cpf);
            Assert.Equal(entity.BirthDate, result.Data?.BirthDate);

            #endregion
        }

        [Fact]
        public async Task ShouldDontGetPessoaFisicaWhenPessoaNotExists()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            var result = await service.GetAsync(entity.Id);

            #endregion

            #region Assert

            Assert.True(result.HasError);
            Assert.Equal(StatusCodes.Status404NotFound, result.HttpStatusCode);
            Assert.NotNull(result.ErrorMessage);

            #endregion
        }

        [Fact]
        public async Task ShouldListPessoaFisicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaFisica()
            {
                Name = "Name",
                Cpf = "1",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            await service.InsertAsync(entity);

            entity.Id = 0;

            await service.InsertAsync(entity);

            var result = await service.ListAsync();

            #endregion

            #region Assert

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.Equal(2, result.Data?.Count());
            
            #endregion
        }

        [Fact]
        public async Task ShouldDontListPessoaFisicaWhenPessoaIsEmpty()
        {
            #region Arrange

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaFisicaService(unitOfWork);

            #endregion

            #region Act

            var result = await service.ListAsync();

            #endregion

            #region Assert

            Assert.True(result.HasError);
            Assert.Equal(StatusCodes.Status404NotFound, result.HttpStatusCode);
            Assert.NotNull(result.ErrorMessage);

            #endregion
        }
    }
}