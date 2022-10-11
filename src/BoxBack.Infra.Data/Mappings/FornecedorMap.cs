using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedores");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(20);
            
            builder
                .HasIndex(c => c.Cnpj)
                .IsUnique();
            
            builder.Property(c => c.TelefonePrincipal)
                .IsRequired(false)
                .HasMaxLength(14);
            
            builder.Property(c => c.Observacao)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.Cidade)
                .IsRequired(false)
                .HasDefaultValue(255);
            
            builder.Property(c => c.Estado)
                .IsRequired(false)
                .HasDefaultValue(4);

            builder.Property(c => c.TenantId)
                .HasDefaultValue(new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"))
                .IsRequired();
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Fornecedores)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.FornecedorServicos)
                .WithOne(c => c.Fornecedor)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}