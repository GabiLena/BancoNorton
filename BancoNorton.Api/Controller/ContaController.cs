using BancoNorton.Api.DTO;
using BancoNorton.Api.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BancoNorton.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _service;

        public ContaController(IContaService service)
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

        // GET api/<ContaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<ContaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
