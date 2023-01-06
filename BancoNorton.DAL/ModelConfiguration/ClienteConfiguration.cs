using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoNorton.DAL.ModelConfiguration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder
            .HasOne(c => c.Conta)
            .WithOne(conta => conta.Cliente)
            .HasForeignKey<Cliente>(c => c.ContaId);
    }
}
