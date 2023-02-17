using BancoNorton.Domain.Model;

namespace BancoNorton.Domain.Repository;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<List<Cliente>> GetAllAsync(int skip, int take);
    Task<bool> PossuiContaFisicaAsync(int idCliente, string numeroConta);
}
