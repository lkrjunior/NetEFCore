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

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> Get()
    {
        var pessoa = new PessoaFisica()
        {
            Name = "Luciano",
            Cpf = "123",
            BirthDate = new DateTime(1986, 8, 11)
        };

        await _unitOfWork.PessoaFisicaRepository.InsertAsync(pessoa);
        await _unitOfWork.SaveAsync();

        return Ok(pessoa);
    }
}

