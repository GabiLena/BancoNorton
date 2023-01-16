using BancoNorton.DAL.ModelConfiguration;
using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BancoNorton.DAL;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<ContaJuridica> ContasJuridicas { get; set; }
    public DbSet<ContaFisica> ContasFisicas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new ContaJuridicaConfiguration());

        base.OnModelCreating(modelBuilder);
    }
    public new async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default) => (await base.SaveChangesAsync(cancellationToken)) > 0;
}
