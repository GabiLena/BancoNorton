using BancoNorton.Api.DTO;
using BancoNorton.Api.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BancoNorton.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaJuridicaController : ControllerBase
    {
        private readonly IContaService _service;

        public ContaJuridicaController(IContaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaContaJuridica([FromBody] ContaJuridicaDTO contaDTO)
        {
            var foiAdicionada = await _service.AdicionarContaJuridica(contaDTO);
            if (foiAdicionada) 
            {
                return Ok("Conta foi criada.");
            }
            return StatusCode(304);
        }

        //método que adiciona conta juridica em cliente

    }
}
