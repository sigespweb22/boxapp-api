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
            builder.ToTable("FornecedoresServicos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(1500);
            
            builder.Property(c => c.Valor)
                .HasDefaultValue(0)
                .HasColumnType("decimal(7,3)");
            
            builder.Property(c => c.TenantId)
                .HasDefaultValue(new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"))
                .IsRequired();
            
            builder.Property(c => c.FornecedorId)
                .IsRequired();
            
            builder
                .HasOne(c => c.Fornecedor)
                .WithMany(c => c.Servicos)
                .HasForeignKey(c => c.FornecedorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}