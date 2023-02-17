using BancoNorton.Api.DTO;
using BancoNorton.Api.Service;
using BancoNorton.Domain.Model;
using BancoNorton.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BancoNorton.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ContaFisicaController : ControllerBase
{
    private readonly IContaService _service;
    private readonly IClienteService _clienteService;
    private readonly IClienteRepository _repository;

    public ContaFisicaController(IContaService service, IClienteService clienteService, IClienteRepository repository)
    {
        _service = service;
        _clienteService = clienteService;
        _repository = repository;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AdicionaContaFisica([FromBody] ContaFisicaDTO contaDto, int id)
    {
        var cliente = await _clienteService.RecuperaClientePeloIdAsync(id);
        if (cliente is not Cliente clienteValido)
            return NotFound("Cliente não encontrado.");

        var numeroConta = await _service.GeraNumeroContaFisicaAsync(contaDto);
        var jaPossuiConta = await _repository.PossuiContaFisicaAsync(id, numeroConta);
        if (jaPossuiConta)
            return StatusCode(304, $"Cliente já possui conta com número: '{contaDto.NumeroConta}'.");

        clienteValido.ContasFisicas.Add(new(numeroConta, contaDto.Saldo, clienteValido.Id));
        var foiAtualizado = await _repository.UpdateAsync(clienteValido);

        return foiAtualizado ? Ok("Conta adicionada com sucesso!") : StatusCode(304, $"Ocorreu um erro ao tentar adicionar a conta física no cliente com id: '{cliente.Id}'.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperaContaPeloIdAsync(int id)
    {
        var contaRecuperada = await _service.RecuperaContaFisicaPorIdAsync(id);
        if (contaRecuperada is null)
            return StatusCode(500, "Conta não existe");
        return Ok(contaRecuperada);
    }

    [HttpPost()]
    public async Task<IActionResult> TransfereSaldoEntreContasAsync([FromBody]TansferenciaDTO tansferenciaDTO)
    {
        var transferenciaDeContas = await _service.TranfereSaldoEntreContasAsync(tansferenciaDTO);
        if (transferenciaDeContas is false)
            return BadRequest();

        return Ok($"Valor: " + tansferenciaDTO.Valor + " transferido com sucesso para conta de id: " + tansferenciaDTO.IdContaDestino);
    }

}
