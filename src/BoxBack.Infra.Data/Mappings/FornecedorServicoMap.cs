using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class FornecedorServicoMap : IEntityTypeConfiguration<FornecedorServico>
    {
        public void Configure(EntityTypeBuilder<FornecedorServico> builder)
        {
            builder.ToTable("FornecedorServicos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CodigoServico)
                .IsRequired(false)
                .HasMaxLength(50);
            
            builder.Property(c => c.Caracteristicas)
                .IsRequired(false);
            
            builder.Property(c => c.FornecedorId)
                .IsRequired();
            
            builder
                .HasOne(c => c.Fornecedor)
                .WithMany(c => c.FornecedorServicos)
                .HasForeignKey(c => c.FornecedorId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.Servicos)
                .WithOne(c => c.FornecedorServico)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}