using System;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;
using NetEFCore.Core.Models.Response;

namespace NetEFCore.Core.Service
{
    public class PessoaJuridicaService : IPessoaService<PessoaJuridica>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PessoaJuridicaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<PessoaJuridica>> DeleteAsync(int id)
        {
            var pessoa = await _unitOfWork.PessoaJuridicaRepository.GetAsync(id);
            if (pessoa == default)
            {
                return ServiceResponse<PessoaJuridica>.AsNotFound($"{nameof(id)}:{id} not found");
            }

            _unitOfWork.PessoaJuridicaRepository.Delete(pessoa);
            await _unitOfWork.SaveAsync();

            return ServiceResponse<PessoaJuridica>.AsOk(default);
        }

        public async Task<ServiceResponse<PessoaJuridica>> GetAsync(int id)
        {
            var pessoa = await _unitOfWork.PessoaJuridicaRepository.GetAsync(id);

            if (pessoa == default)
            {
                return ServiceResponse<PessoaJuridica>.AsNotFound($"{nameof(id)}:{id} not found");
            }

            return ServiceResponse<PessoaJuridica>.AsOk(pessoa);
        }

        public async Task<ServiceResponse<PessoaJuridica>> InsertAsync(PessoaJuridica entity)
        {
            await _unitOfWork.PessoaJuridicaRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();

            return ServiceResponse<PessoaJuridica>.AsOk(entity);
        }

        public async Task<ServiceResponse<IEnumerable<PessoaJuridica>>> ListAsync()
        {
            var pessoas = await _unitOfWork.PessoaJuridicaRepository.ListAsync();

            if (pessoas == default)
            {
                return ServiceResponse<IEnumerable<PessoaJuridica>>.AsNotFound("Empty list");
            }

            return ServiceResponse<IEnumerable<PessoaJuridica>>.AsOk(pessoas);
        }

        public async Task<ServiceResponse<PessoaJuridica>> UpdateAsync(PessoaJuridica entity)
        {
            _unitOfWork.PessoaJuridicaRepository.Update(entity);
            await _unitOfWork.SaveAsync();

            return ServiceResponse<PessoaJuridica>.AsOk(entity);
        }
    }
}

