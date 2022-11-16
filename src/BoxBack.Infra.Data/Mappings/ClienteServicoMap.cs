using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ClienteServicoMap : IEntityTypeConfiguration<ClienteServico>
    {
        public void Configure(EntityTypeBuilder<ClienteServico> builder)
        {
            builder.ToTable("ClienteServicos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ValorVenda)
                .HasDefaultValue(0)
                .HasColumnType("decimal(7,3)");

            builder.Property(c => c.Caracteristicas)
                .IsRequired(false)
                .HasMaxLength(1500);

            builder
                .HasOne(c => c.Cliente)
                .WithMany(c => c.ClienteServicos)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            builder
                .HasOne(c => c.Servico)
                .WithMany(c => c.ClienteServicos)
                .HasForeignKey(c => c.ServicoId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(c => c.ClienteId)
                .IsRequired();
            
            builder.HasIndex(x => x.ClienteId)
                .IsUnique(false);

            builder.Property(c => c.ServicoId)
                .IsRequired();
            
            builder.HasIndex(x => x.ServicoId)
                .IsUnique(false);
        }
    }
}