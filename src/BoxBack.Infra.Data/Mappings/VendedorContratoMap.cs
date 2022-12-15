using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class VendedorContratoMap : IEntityTypeConfiguration<VendedorContrato>
    {
        public void Configure(EntityTypeBuilder<VendedorContrato> builder)
        {
            builder.ToTable("VendedoresContratos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder
                .HasOne(c => c.Vendedor)
                .WithMany(c => c.VendedorContratos)
                .HasForeignKey(c => c.VendedorId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
               .HasOne(c => c.ClienteContrato)
               .WithMany(c => c.VendedoresContratos)
               .HasForeignKey(c => c.ClienteContratoId)
               .OnDelete(DeleteBehavior.NoAction);
        }   
    }
}