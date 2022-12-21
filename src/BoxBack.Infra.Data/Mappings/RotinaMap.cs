using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class RotinaMap : IEntityTypeConfiguration<Rotina>
    {
        public void Configure(EntityTypeBuilder<Rotina> builder)
        {
            builder.ToTable("Rotinas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(2500);

            //Relationships
            
            builder
                .HasMany(c => c.RotinasEventsHistories)
                .WithOne(x => x.Rotina)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Rotinas)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}