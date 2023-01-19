using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      
    }

    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Cliente>> GetAllAsync(int skip, int take);
    }
}
