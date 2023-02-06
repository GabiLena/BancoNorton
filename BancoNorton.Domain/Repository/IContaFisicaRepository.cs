using BancoNorton.Domain.Model;

namespace BancoNorton.Domain.Repository;

public interface IContaFisicaRepository : IRepository<ContaFisica>
{
    Task<string> ObterNumeroUltimaContaAsync();
}

