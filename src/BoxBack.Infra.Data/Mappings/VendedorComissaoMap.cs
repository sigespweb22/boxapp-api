using System.Collections.Immutable;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class VendedorComissaoMap : IEntityTypeConfiguration<VendedorComissao>
    {
        public void Configure(EntityTypeBuilder<VendedorComissao> builder)
        {
            builder.ToTable("VendedoresComissoes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.ValorComissao)
                .HasDefaultValue(0)
                .HasColumnType("decimal(7,3)");
            
            builder
                .HasOne(c => c.Vendedor)
                .WithMany(c => c.VendedorComissoes)
                .HasForeignKey(c => c.VendedorId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
               .HasOne(c => c.ClienteContrato)
               .WithMany(c => c.VendedoresComissoes)
               .HasForeignKey(c => c.ClienteContratoId)
               .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder
                .HasIndex(c => c.VendedorId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.ClienteContratoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }   
    }
}