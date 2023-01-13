using BancoNorton.Api.DTO;
using BancoNorton.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace BancoNorton.Api.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContaFisicaController : ControllerBase
    {
        private readonly IContaService _service;

        public ContaFisicaController(IContaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaContaFisica([FromBody] ContaFisicaDTO contaDTO)
        {
            var adicionado = await _service.AdicionarContaFisica(contaDTO);
            if (adicionado)
            {
                return Ok("Conta foi criada.");
            }
            return StatusCode(304);
        }

    }
}
