using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class RotinaEventHistoryMap : IEntityTypeConfiguration<RotinaEventHistory>
    {
        public void Configure(EntityTypeBuilder<RotinaEventHistory> builder)
        {
            builder.ToTable("RotinaEventsHistories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            //Relationships
            builder
                .HasOne(c => c.Rotina)
                .WithMany(x => x.RotinasEventsHistories)
                .HasForeignKey(c => c.RotinaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}