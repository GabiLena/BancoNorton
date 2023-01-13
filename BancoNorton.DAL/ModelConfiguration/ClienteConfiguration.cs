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
            .HasMany(cliente => cliente.ContasJuridicas)
            .WithOne(conta => conta.Cliente)
            .HasForeignKey(conta => conta.ClienteId);
        //.OnDelete(DeleteBehavior.Cascade); definição de ação quando houver deleção de dados;

        builder
            .HasMany(cliente => cliente.ContasFisicas)
            .WithOne(conta => conta.Cliente)
            .HasForeignKey(conta => conta.ClienteId);


        builder.HasData(new Cliente("012.345.678-90", "Fulano Detal") { Id = 1 });
        builder.HasData(new Cliente("456.890.158-81", "Gabriela Lena") { Id = 2 });

    }
}
