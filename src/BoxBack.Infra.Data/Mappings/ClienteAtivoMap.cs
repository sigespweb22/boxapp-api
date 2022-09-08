using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class ClienteAtivoMap : IEntityTypeConfiguration<ClienteAtivo>
    {
        public void Configure(EntityTypeBuilder<ClienteAtivo> builder)
        {
            builder.ToTable("ClientesAtivos");

            builder.HasKey(c => new { c.ClienteId, c.AtivoId });

            builder.Property(c => c.ValorCusto)
                .HasDefaultValue(0)
                .HasColumnType("decimal(7,3)");
            
            builder.Property(c => c.ValorVenda)
                .HasDefaultValue(0)
                .HasColumnType("decimal(7,3)");

            builder.Property(c => c.Caracteristica)
                .IsRequired(false)
                .HasMaxLength(1500);

            builder.Property(c => c.Observacao)
                .IsRequired(false)
                .HasMaxLength(255);

            builder
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Ativos)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            builder
                .HasOne(c => c.Ativo)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.AtivoId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}