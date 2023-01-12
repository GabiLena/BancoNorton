using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoNorton.DAL.ModelConfiguration;
public class ContaConfiguration : IEntityTypeConfiguration<ContaJuridica>
{
    public void Configure(EntityTypeBuilder<ContaJuridica> builder)
    {
        builder.HasData(new ContaJuridica("001", int.MaxValue, 1) { Id = 1, DataCriacao = new DateTimeOffset(new DateTime(2023,01,01)) });    
    }
}
