using BancoNorton.Domain.Model;

namespace BancoNorton.Domain.Repository;

public interface IContaJuridicaRepository : IRepository<ContaJuridica>
{
    Task<string> ObterNumeroUltimaContaAsync();
}
