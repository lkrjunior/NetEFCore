using System;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;
using NetEFCore.Core.Models.Response;

namespace NetEFCore.Core.Service
{
    public class PessoaFisicaService : IPessoaService<PessoaFisica>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PessoaFisicaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<PessoaFisica>> DeleteAsync(int id)
        {
            var pessoa = await _unitOfWork.PessoaFisicaRepository.GetAsync(id);
            if (pessoa == default)
            {
                return ServiceResponse<PessoaFisica>.AsNotFound($"{nameof(id)}:{id} not found");
            }

            _unitOfWork.PessoaFisicaRepository.Delete(pessoa);
            await _unitOfWork.SaveAsync();

            return ServiceResponse<PessoaFisica>.AsOk(default);
        }

        public async Task<ServiceResponse<PessoaFisica>> GetAsync(int id)
        {
            var pessoa = await _unitOfWork.PessoaFisicaRepository.GetAsync(id);

            if (pessoa == default)
            {
                return ServiceResponse<PessoaFisica>.AsNotFound($"{nameof(id)}:{id} not found");
            }

            return ServiceResponse<PessoaFisica>.AsOk(pessoa);
        }

        public async Task<ServiceResponse<PessoaFisica>> InsertAsync(PessoaFisica entity)
        {
            await _unitOfWork.PessoaFisicaRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();

            return ServiceResponse<PessoaFisica>.AsOk(entity);
        }

        public async Task<ServiceResponse<IEnumerable<PessoaFisica>>> ListAsync()
        {
            var pessoas = await _unitOfWork.PessoaFisicaRepository.ListAsync();

            if (!pessoas.Any())
            {
                return ServiceResponse<IEnumerable<PessoaFisica>>.AsNotFound("Empty list");
            }

            return ServiceResponse<IEnumerable<PessoaFisica>>.AsOk(pessoas);
        }

        public async Task<ServiceResponse<PessoaFisica>> UpdateAsync(PessoaFisica entity)
        {
            _unitOfWork.PessoaFisicaRepository.Update(entity);
            await _unitOfWork.SaveAsync();

            return ServiceResponse<PessoaFisica>.AsOk(entity);
        }
    }
}

