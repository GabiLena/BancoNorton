using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoNorton.DAL.ModelConfiguration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
            // relacionamento one to many
        builder
            .HasMany(cliente => cliente.Contas)
            .WithOne(conta => conta.Cliente)
            .HasForeignKey(conta => conta.ClienteId);
            //.OnDelete(DeleteBehavior.Cascade); definição de ação quando houver deleção de dados;
    }
}
