using Microsoft.AspNetCore.Mvc;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;

namespace NetEFCore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService<PessoaJuridica> _pessoaJuridicaService;
    private readonly IPessoaService<PessoaFisica> _pessoaFisicaService;

    public PessoaController(IPessoaService<PessoaFisica> pessoaFisicaService, IPessoaService<PessoaJuridica> pessoaJuridicaService)
    {
        _pessoaFisicaService = pessoaFisicaService;
        _pessoaJuridicaService = pessoaJuridicaService;
    }

    [HttpGet("GetPessoaFisica")]
    public async Task<IActionResult> GetPessoaFisica(int id)
    {
        var result = await _pessoaFisicaService.GetAsync(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpGet("ListPessoaFisica")]
    public async Task<IActionResult> ListPessoaFisica()
    {
        var result = await _pessoaFisicaService.ListAsync();

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpDelete("DeletePessoaFisica")]
    public async Task<IActionResult> DeletePessoaFisica(int id)
    {
        var result = await _pessoaFisicaService.DeleteAsync(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("InsertPessoaFisica")]
    public async Task<IActionResult> InsertPessoaFisica(PessoaFisica pessoa)
    {
        var result = await _pessoaFisicaService.InsertAsync(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("UpdatePessoaFisica")]
    public async Task<IActionResult> UpdatePessoaFisica(PessoaFisica pessoa)
    {
        var result = await _pessoaFisicaService.UpdateAsync(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }


    [HttpGet("GetPessoaJuridica")]
    public async Task<IActionResult> GetPessoaJuridica(int id)
    {
        var result = await _pessoaJuridicaService.GetAsync(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpGet("ListPessoaJuridica")]
    public async Task<IActionResult> ListPessoaJuridica()
    {
        var result = await _pessoaJuridicaService.ListAsync();

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpDelete("DeletePessoaJuridica")]
    public async Task<IActionResult> DeletePessoaJuridica(int id)
    {
        var result = await _pessoaJuridicaService.DeleteAsync(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("InsertPessoaJuridica")]
    public async Task<IActionResult> InsertPessoaJuridica(PessoaJuridica pessoa)
    {
        var result = await _pessoaJuridicaService.InsertAsync(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("UpdatePessoaJuridica")]
    public async Task<IActionResult> UpdatePessoaJuridica(PessoaJuridica pessoa)
    {
        var result = await _pessoaJuridicaService.UpdateAsync(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }
}