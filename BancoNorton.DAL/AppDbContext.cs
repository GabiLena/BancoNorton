using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BancoNorton.DAL;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<ContaFisica> ContasFisicas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public new async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default) => (await base.SaveChangesAsync(cancellationToken)) > 0;
}
