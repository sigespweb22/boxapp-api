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