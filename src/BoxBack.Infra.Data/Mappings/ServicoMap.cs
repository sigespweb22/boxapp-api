using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servicos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            builder
                .HasIndex(c => c.Nome)
                .IsUnique();
            
            builder.Property(c => c.CodigoUnico)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder
                .HasIndex(c => c.CodigoUnico)
                .IsUnique();
            
            builder.Property(c => c.ValorCusto)
                .HasDefaultValue(0)
                .HasColumnType("decimal(7,3)");
            
            builder.Property(c => c.Caracteristicas)
                .IsRequired(false)
                .HasMaxLength(1500);
            
            builder.Property(c => c.TenantId)
                .HasDefaultValue(new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"))
                .IsRequired();
            
            builder.Property(c => c.FornecedorServicoId)
                .HasDefaultValue(Guid.Empty);
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Servicos)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.FornecedorServico)
                .WithMany(c => c.Servicos)
                .HasForeignKey(c => c.FornecedorServicoId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.ClienteServicos)
                .WithOne(c => c.Servico)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}