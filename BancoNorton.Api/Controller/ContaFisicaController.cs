using BancoNorton.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace BancoNorton.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ContaFisicaController : ControllerBase
{
    private readonly IContaService _service;
    private readonly IClienteService _clienteService;

    public ContaFisicaController(IContaService service)
    {
        _service = service;
    }

}
