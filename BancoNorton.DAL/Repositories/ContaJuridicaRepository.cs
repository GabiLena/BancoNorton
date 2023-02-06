using BancoNorton.Domain.Model;
using BancoNorton.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace BancoNorton.DAL.Repositories
{
    public class ContaJuridicaRepository : Repository<ContaJuridica>, IContaJuridicaRepository
    {
        private readonly AppDbContext _context;

        public ContaJuridicaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> ObterNumeroUltimaContaAsync()
        {
            var conta = await _context.ContasJuridicas.OrderByDescending(c => c.DataCriacao).FirstOrDefaultAsync();
            return conta.NumeroConta;
        }
    }
}
