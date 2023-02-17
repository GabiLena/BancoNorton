using BancoNorton.Api.DTO;
using BancoNorton.Api.Service;
using BancoNorton.Domain.Model;
using BancoNorton.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BancoNorton.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _service;
    private readonly IClienteRepository _repository;
    private readonly IContaService _serviceConta;

    public ClienteController(IClienteService service, IClienteRepository repository, IContaService contaService)
    {
        _service = service;
        _repository = repository;
        _serviceConta = contaService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionaClienteAsync([FromBody] ClienteDTO clienteDTO)
    {
        var adicionado = await _service.AdicionaCliente(clienteDTO);
        if (adicionado)
            return Ok("Cliente foi adicionado");
        return StatusCode(304);
    }

    [HttpGet]
    public async Task<ActionResult<List<ClienteDTO>>> RecuperaClientesAsync([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var clientes = await _service.RecuperaClientes(skip, take);// no service tem contas, mas aqui fica null

        if (clientes is null)
            return StatusCode(500, "Lista é nula");

        if (!clientes.Any())
            return NotFound();

        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDTO>> RecuperaClientesPeloIdAsync(int id)
    {
        var clienteAchado = await _service.RecuperaClientePeloIdAsync(id);
        if (clienteAchado is null)
            return StatusCode(500, "Cliente não existe");

        return Ok(clienteAchado);
    }

    [HttpPatch]
    public async Task<IActionResult> AtualizaCliente([FromBody] ClienteDTO clienteDTO)
    {
        var clienteFoiAtualizado = await _service.AtualizaDadosDeCliente(clienteDTO);
        if (!clienteFoiAtualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaCliente(int id)
    {
        var clienteDeletado = await _repository.DeleteAsync(id);
        return Ok("Cliente foi deletado com sucesso.");
    }

}
