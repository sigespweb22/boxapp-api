using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class VerticalNavItemMap : IEntityTypeConfiguration<VerticalNavItem>
    {
        public void Configure(EntityTypeBuilder<VerticalNavItem> builder)
        {
            builder.ToTable("VerticalNavItems");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            

           builder.HasData();
        }
    }
}