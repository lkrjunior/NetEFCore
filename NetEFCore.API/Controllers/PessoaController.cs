using Microsoft.AspNetCore.Mvc;

namespace NetEFCore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    [HttpGet(Name = "Get")]
    public IActionResult Get()
    {
        return Ok();
    }
}

