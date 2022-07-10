using Microsoft.AspNetCore.Mvc;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;

namespace NetEFCore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PessoaController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("GetPessoaFisica")]
    public async Task<IActionResult> GetPessoaFisica(int id)
    {
        var pessoa = await _unitOfWork.PessoaFisicaRepository.GetAsync(id);

        if (pessoa == default)
        {
            NotFound();
        }

        return Ok(pessoa);
    }

    [HttpGet("ListPessoaFisica")]
    public async Task<IActionResult> ListPessoaFisica()
    {
        var pessoas = await _unitOfWork.PessoaFisicaRepository.ListAsync();

        if (pessoas == default)
        {
            NotFound();
        }

        return Ok(pessoas);
    }

    [HttpDelete("DeletePessoaFisica")]
    public async Task<IActionResult> DeletePessoaFisica(int id)
    {
        var pessoa = await _unitOfWork.PessoaFisicaRepository.GetAsync(id);
        if (pessoa == default)
        {
            return NotFound();
        }

        _unitOfWork.PessoaFisicaRepository.Delete(pessoa);
        await _unitOfWork.SaveAsync();

        return Ok();
    }

    [HttpPost("InsertPessoaFisica")]
    public async Task<IActionResult> InsertPessoaFisica(PessoaFisica pessoa)
    {
        await _unitOfWork.PessoaFisicaRepository.InsertAsync(pessoa);
        await _unitOfWork.SaveAsync();

        return Ok(pessoa);
    }

    [HttpPost("UpdatePessoaFisica")]
    public async Task<IActionResult> UpdatePessoaFisica(PessoaFisica pessoa)
    {
        _unitOfWork.PessoaFisicaRepository.Update(pessoa);
        await _unitOfWork.SaveAsync();

        return Ok(pessoa);
    }

    [HttpGet("GetPessoaJuridica")]
    public async Task<IActionResult> GetPessoaJuridica(int id)
    {
        var pessoa = await _unitOfWork.PessoaJuridicaRepository.GetAsync(id);

        if (pessoa == default)
        {
            return NotFound();
        }

        return Ok(pessoa);
    }

    [HttpGet("ListPessoaJuridica")]
    public async Task<IActionResult> ListPessoaJuridica()
    {
        var pessoas = await _unitOfWork.PessoaJuridicaRepository.ListAsync();

        if (pessoas == default)
        {
            NotFound();
        }

        return Ok(pessoas);
    }

    [HttpDelete("DeletePessoaJuridica")]
    public async Task<IActionResult> DeletePessoaJuridica(int id)
    {
        var pessoa = await _unitOfWork.PessoaJuridicaRepository.GetAsync(id);
        if (pessoa == null)
        {
            NotFound();
        }

        _unitOfWork.PessoaJuridicaRepository.Delete(pessoa);
        await _unitOfWork.SaveAsync();

        return Ok();
    }

    [HttpPost("InsertPessoaJuridica")]
    public async Task<IActionResult> InsertPessoaJuridica(PessoaJuridica pessoa)
    {
        await _unitOfWork.PessoaJuridicaRepository.InsertAsync(pessoa);
        await _unitOfWork.SaveAsync();

        return Ok(pessoa);
    }

    [HttpPost("UpdatePessoaJuridica")]
    public async Task<IActionResult> UpdatePessoaJuridica(PessoaJuridica pessoa)
    {
        _unitOfWork.PessoaJuridicaRepository.Update(pessoa);
        await _unitOfWork.SaveAsync();

        return Ok(pessoa);
    }

}

