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
        var result = await _pessoaFisicaService.Get(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpGet("ListPessoaFisica")]
    public async Task<IActionResult> ListPessoaFisica()
    {
        var result = await _pessoaFisicaService.List();

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpDelete("DeletePessoaFisica")]
    public async Task<IActionResult> DeletePessoaFisica(int id)
    {
        var result = await _pessoaFisicaService.Delete(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("InsertPessoaFisica")]
    public async Task<IActionResult> InsertPessoaFisica(PessoaFisica pessoa)
    {
        var result = await _pessoaFisicaService.Insert(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("UpdatePessoaFisica")]
    public async Task<IActionResult> UpdatePessoaFisica(PessoaFisica pessoa)
    {
        var result = await _pessoaFisicaService.Update(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }


    [HttpGet("GetPessoaJuridica")]
    public async Task<IActionResult> GetPessoaJuridica(int id)
    {
        var result = await _pessoaJuridicaService.Get(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpGet("ListPessoaJuridica")]
    public async Task<IActionResult> ListPessoaJuridica()
    {
        var result = await _pessoaJuridicaService.List();

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpDelete("DeletePessoaJuridica")]
    public async Task<IActionResult> DeletePessoaJuridica(int id)
    {
        var result = await _pessoaJuridicaService.Delete(id);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("InsertPessoaJuridica")]
    public async Task<IActionResult> InsertPessoaJuridica(PessoaJuridica pessoa)
    {
        var result = await _pessoaJuridicaService.Insert(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }

    [HttpPost("UpdatePessoaJuridica")]
    public async Task<IActionResult> UpdatePessoaJuridica(PessoaJuridica pessoa)
    {
        var result = await _pessoaJuridicaService.Update(pessoa);

        if (result.HasError)
        {
            return Problem(result.ErrorMessage, HttpContext.Request.Path, result.HttpStatusCode, result.ErrorTitle);
        }

        return Ok(result.Data ?? default);
    }
}