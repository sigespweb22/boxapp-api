using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ClienteContratoMap : IEntityTypeConfiguration<ClienteContrato>
    {
        public void Configure(EntityTypeBuilder<ClienteContrato> builder)
        {
            builder.ToTable("ClienteContratos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ValorContrato)
                .HasDefaultValue(0)
                .HasColumnType("decimal(12,5)");

            builder
                .HasOne(c => c.Cliente)
                .WithMany(c => c.ClienteContratos)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.ClientesContratosFaturas)
                .WithOne(c => c.ClienteContrato)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}