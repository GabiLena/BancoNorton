using BancoNorton.Domain.Model;
using BancoNorton.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace BancoNorton.DAL.Repositories
{
    public class ContaFisicaRepository : Repository<ContaFisica>, IContaFisicaRepository
    {

        private readonly AppDbContext _context;

        public ContaFisicaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> ObterNumeroUltimaContaAsync()
        {
            var conta = await _context.ContasFisicas.OrderByDescending(c => c.DataCriacao).FirstOrDefaultAsync();
            if (conta != null)
                return conta.NumeroConta;
            else
                return "1458";
        }
    }
}

