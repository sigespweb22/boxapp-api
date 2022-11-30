using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class FornecedorProdutoMap : IEntityTypeConfiguration<FornecedorProduto>
    {
        public void Configure(EntityTypeBuilder<FornecedorProduto> builder)
        {
            builder.ToTable("FornecedorProdutos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CodigoProduto)
                .IsRequired(false)
                .HasMaxLength(50);
            
            builder.Property(c => c.Caracteristicas)
                .IsRequired(false);
            
            builder.Property(c => c.FornecedorId)
                .IsRequired();
            
            builder
                .HasOne(c => c.Fornecedor)
                .WithMany(c => c.FornecedorProdutos)
                .HasForeignKey(c => c.FornecedorId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.Produtos)
                .WithOne(c => c.FornecedorProduto)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}