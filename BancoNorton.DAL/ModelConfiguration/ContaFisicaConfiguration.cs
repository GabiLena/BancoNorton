using BancoNorton.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoNorton.DAL.ModelConfiguration
{
    public class ContaFisicaConfiguration : IEntityTypeConfiguration<ContaFisica>
    {
        public void Configure(EntityTypeBuilder<ContaFisica> builder)
        {
            builder.HasData(new ContaFisica("002", int.MaxValue, 1) { Id = 1, DataCriacao = new DateTimeOffset(new DateTime(2023, 01, 01)) });
        }
    }
}
