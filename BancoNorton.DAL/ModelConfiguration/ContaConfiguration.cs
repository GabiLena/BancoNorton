using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoNorton.DAL.ModelConfiguration;
public class ContaConfiguration : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder
            .HasOne(c => c.Cliente)
            .WithOne(cliente => cliente.Conta)
            .HasForeignKey<Conta>(c => c.ClienteId);
    }
}
