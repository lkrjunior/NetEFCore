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
    public class PessoaJuridicaServiceInMemoryTest
    {
        private static IUnitOfWork GetUnitOfWork()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("UnitTest")
                .Options;
            var appDbContext = new AppDbContext(dbContextOptions);

            var pessoaFisicaRepository = new PessoaFisicaRepository(appDbContext);
            var pessoaJuridicaRepository = new PessoaJuridicaRepository(appDbContext);

            var unitOfWork = new UnitOfWork(appDbContext, pessoaFisicaRepository, pessoaJuridicaRepository);

            return unitOfWork;
        }

        [Fact]
        public async Task ShouldInsertPessoaJuridicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

            #endregion

            #region Act

            var result = await service.InsertAsync(entity);

            #endregion

            #region Assert

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.True(entity.Id > 0);
            Assert.Equal(entity.Name, result.Data?.Name);
            Assert.Equal(entity.Cnpj, result.Data?.Cnpj);
            Assert.Equal(entity.RegisterDate, result.Data?.RegisterDate);

            #endregion
        }

        [Fact]
        public async Task ShouldUpdatePessoaJuridicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var expectedCnpj = "123";

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

            #endregion

            #region Act

            await service.InsertAsync(entity);

            entity.Cnpj = expectedCnpj;

            var result = await service.UpdateAsync(entity);

            #endregion

            #region Assert

            Assert.False(result.HasError);
            Assert.Equal(StatusCodes.Status200OK, result.HttpStatusCode);
            Assert.True(entity.Id > 0);
            Assert.Equal(entity.Name, result.Data?.Name);
            Assert.Equal(expectedCnpj, result.Data?.Cnpj);
            Assert.Equal(entity.RegisterDate, result.Data?.RegisterDate);

            #endregion
        }

        [Fact]
        public async Task ShouldDontUpdatePessoaJuridicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

            #endregion

            #region Act

            var exception = await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await service.UpdateAsync(entity));

            #endregion

            #region Assert

            Assert.NotNull(exception.Message);

            #endregion
        }

        [Fact]
        public async Task ShouldDeletePessoaJuridicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

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
        public async Task ShouldDontDeletePessoaJuridicaWhenPessoaNotExists()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

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
        public async Task ShouldGetPessoaJuridicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

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
            Assert.Equal(entity.Cnpj, result.Data?.Cnpj);
            Assert.Equal(entity.RegisterDate, result.Data?.RegisterDate);

            #endregion
        }

        [Fact]
        public async Task ShouldDontGetPessoaJuridicaWhenPessoaNotExists()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

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
        public async Task ShouldListPessoaJuridicaWhenPayloadIsValid()
        {
            #region Arrange

            var entity = new PessoaJuridica()
            {
                Name = "Name",
                Cnpj = "1",
                RegisterDate = new DateTime(1980, 1, 1)
            };

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

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
        public async Task ShouldDontListPessoaJuridicaWhenPessoaIsEmpty()
        {
            #region Arrange

            var unitOfWork = GetUnitOfWork();

            var service = new PessoaJuridicaService(unitOfWork);

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