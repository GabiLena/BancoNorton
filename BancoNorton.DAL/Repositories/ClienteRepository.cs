using BancoNorton.Domain.Model;
using BancoNorton.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace BancoNorton.DAL.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync(int skip, int take)
        {
            return await _context.Clientes
                .Include(cliente => cliente.ContasJuridicas)
                .Include(cliente => cliente.ContasFisicas)
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<bool> PossuiContaFisicaAsync(int idCliente, string numeroConta)
        {
            var cliente = await _context.Clientes 
                .Include(_cliente => _cliente.ContasFisicas)
                .FirstOrDefaultAsync(c => c.Id == idCliente && c.ContasFisicas.Any(cf => cf.NumeroConta == numeroConta));
            return cliente != null;
        }
    }
}
