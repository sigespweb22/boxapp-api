using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedores");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.ComissaoReais)
                .IsRequired(false)
                .HasDefaultValue(null)
                .HasColumnType("decimal(7,3)");
            
            builder.Property(c => c.ComissaoPercentual)
                .IsRequired(false)
                .HasDefaultValue(null);
            
            builder
                .HasOne(c => c.ApplicationUser)
                .WithOne(c => c.Vendedor)
                .HasForeignKey<Vendedor>(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
               .HasMany(c => c.VendedorComissoes)
               .WithOne(c => c.Vendedor)
               .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.VendedorContratos)
                .WithOne(c => c.Vendedor)
                .OnDelete(DeleteBehavior.NoAction);
        }   
    }
}