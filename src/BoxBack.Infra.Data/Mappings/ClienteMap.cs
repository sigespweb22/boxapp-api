using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

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
            
            builder.Property(c => c.InscricaoEstadual)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.CNPJ)
                .IsRequired(false)
                .HasDefaultValue(null)
                .HasMaxLength(20);
            
            builder.Property(c => c.Cpf)
                .IsRequired(false)
                .HasDefaultValue(null)
                .HasMaxLength(20);
            
            builder
                .HasIndex(c => c.CNPJ)
                .IsUnique();
            
            builder
                .HasIndex(c => c.Cpf)
                .IsUnique();
            
            builder.Property(c => c.TelefonePrincipal)
                .IsRequired(false)
                .HasMaxLength(20);
            
            builder.Property(c => c.Observacao)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.Rua)
                .IsRequired(false)
                .HasDefaultValue(500);
            
            builder.Property(c => c.Numero)
                .IsRequired(false)
                .HasDefaultValue(5);
            
            builder.Property(c => c.Complemento)
                .IsRequired(false)
                .HasDefaultValue(50);
            
            builder.Property(c => c.Cidade)
                .IsRequired(false)
                .HasDefaultValue(255);
            
            builder.Property(c => c.Estado)
                .IsRequired(false)
                .HasDefaultValue(4);
            
            builder.Property(c => c.Cep)
                .IsRequired(false)
                .HasDefaultValue(20);

            builder.Property(c => c.TenantId)
                .HasDefaultValue(new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"))
                .IsRequired();
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.ClienteServicos)
                .WithOne(c => c.Cliente)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
               .HasMany(c => c.ClienteContratos)
               .WithOne(c => c.Cliente)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}