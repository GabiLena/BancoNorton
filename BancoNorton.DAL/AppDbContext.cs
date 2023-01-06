using BancoNorton.DAL.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BancoNorton.DAL;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new ContaConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
