using AutoMapper;
using BancoNorton.Api.DTO;
using BancoNorton.Api.Validator;
using BancoNorton.DAL.Repositories;
using BancoNorton.Domain.Model;
using BancoNorton.Domain.Repository;

namespace BancoNorton.Api.Service;

public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly IClienteRepository _repository;
    private readonly ClienteDTOValidator _validator;

    public ClienteService(IMapper mapper, IClienteRepository repository, ClienteDTOValidator validator)
    {
        _mapper = mapper;
        _repository = repository;
        _validator = validator;
    }

    public async Task<bool> AdicionaCliente(ClienteDTO clienteDTO)
    {
        var result = _validator.Validate(clienteDTO);
        if (!result.IsValid)
            throw new Exception(string.Join("|", result.Errors.Select(x => x.ErrorMessage)));

        var novoCliente = _mapper.Map<Cliente>(clienteDTO);
        return await _repository.AddAsync(novoCliente);
    }

    public async Task<List<ClienteDTO>> RecuperaClientes(int skip, int take)
    {
        var clientes = await _repository.GetAllAsync(skip, take);
        return _mapper.Map<List<Cliente>, List<ClienteDTO>>(clientes);//para cada cliente, mapeia para dto
    }

    public async Task<bool> AtualizaDadosDeCliente(ClienteDTO clienteDTO)
    {
        var cliente = _mapper.Map<Cliente>(clienteDTO);
        var clienteAtualizado = await _repository.UpdateAsync(cliente);
        return clienteAtualizado;
    }

    public async Task<Cliente?> RecuperaClientePeloIdAsync(int id)
    {
        var clienteAchado = await _repository.FindByIdAsync(id);
        if (clienteAchado is null)
            return null;

        //var clienteDto = _mapper.Map<ClienteDTO>(clienteAchado);
        return clienteAchado;
    }
}

public interface IClienteService
{
    Task<bool> AdicionaCliente(ClienteDTO clienteDTO);
    Task<bool> AtualizaDadosDeCliente(ClienteDTO clienteDTO);
    Task<Cliente?> RecuperaClientePeloIdAsync(int id);
    Task<List<ClienteDTO>> RecuperaClientes(int skip, int take);
}
