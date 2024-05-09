using ContatosApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Infra.Data.Mappings
{
    public class ContatosMap : IEntityTypeConfiguration<Contatos>
    {
        public void Configure(EntityTypeBuilder<Contatos> builder)
        {
            builder.ToTable("CONTATO");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("ID");

            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();

            builder.Property(c => c.Email).HasColumnName("EMAIL").HasMaxLength(50).IsRequired();
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Telefone).HasColumnName("TELEFONE").HasMaxLength(20).IsRequired();

            builder.HasIndex(c => c.Telefone).IsUnique();


        }

    }
}
