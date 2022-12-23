using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ClienteContratoFaturaMap : IEntityTypeConfiguration<ClienteContratoFatura>
    {
        public void Configure(EntityTypeBuilder<ClienteContratoFatura> builder)
        {
            builder.ToTable("ClientesContratosFaturas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Valor)
                .HasDefaultValue(0)
                .HasColumnType("decimal(12,5)");
            
            builder.Property(c => c.Desconto)
                .HasDefaultValue(0)
                .HasColumnType("decimal(12,5)");
            
            builder.Property(c => c.NumeroParcela)
                .HasDefaultValue(0);
            
            builder.Property(c => c.Quitado)
                .HasDefaultValue(false);

            builder
                .HasOne(x => x.ClienteContrato)
                .WithMany(x => x.ClientesContratosFaturas)
                .HasForeignKey(x => x.ClienteContratoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}