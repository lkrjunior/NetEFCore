using Microsoft.AspNetCore.Mvc;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;

namespace NetEFCore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPessoaService<PessoaFisica> _pessoaService;

    public PessoaController(IUnitOfWork unitOfWork, IPessoaService<PessoaFisica> pessoaService)
    {
        _unitOfWork = unitOfWork;
        _pessoaService = pessoaService;
    }

    [HttpGet("GetPessoaFisica")]
    public async Task<IActionResult> GetPessoaFisica(int id)
    {
        var result = await _pessoaService.Get(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpGet("ListPessoaFisica")]
    public async Task<IActionResult> ListPessoaFisica()
    {
        var result = await _pessoaService.List();

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpDelete("DeletePessoaFisica")]
    public async Task<IActionResult> DeletePessoaFisica(int id)
    {
        var result = await _pessoaService.Delete(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("InsertPessoaFisica")]
    public async Task<IActionResult> InsertPessoaFisica(PessoaFisica pessoa)
    {
        var result = await _pessoaService.Insert(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("UpdatePessoaFisica")]
    public async Task<IActionResult> UpdatePessoaFisica(PessoaFisica pessoa)
    {
        var result = await _pessoaService.Update(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
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
            return NotFound();
        }

        return Ok(pessoas);
    }

    [HttpDelete("DeletePessoaJuridica")]
    public async Task<IActionResult> DeletePessoaJuridica(int id)
    {
        var pessoa = await _unitOfWork.PessoaJuridicaRepository.GetAsync(id);
        if (pessoa == null)
        {
            return NotFound();
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

