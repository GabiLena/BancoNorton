using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var conta = await _context.Contas.OrderByDescending(c => c.DataCriacao).FirstOrDefaultAsync();
            return conta.NumeroConta;
        }
    }
    public interface IContaFisicaRepository : IRepository<ContaFisica>
    {
        Task<string> ObterNumeroUltimaContaAsync();
    }
}

