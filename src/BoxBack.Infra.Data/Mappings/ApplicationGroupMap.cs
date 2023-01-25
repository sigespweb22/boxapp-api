using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationGroupMap : IEntityTypeConfiguration<ApplicationGroup>
    {
        public void Configure(EntityTypeBuilder<ApplicationGroup> builder)
        {
            builder.ToTable("AspNetGroups");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(c => c.UniqueKey)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(c => c.TenantId)
                .HasDefaultValue(new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"))
                .IsRequired();
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.ApplicationGroups)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
            
            // builder.HasData(
            //     new ApplicationGroup
            //     {
            //         Id = Guid.Parse("23e63d9c-283b-496b-b7d8-7dac2ef7a822"), // primary key
            //         IsDeleted = false,
            //         CreatedAt = DateTimeOffset.Now,
            //         CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //         UpdatedAt = DateTimeOffset.Now,
            //         UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //         Name = "Master",
            //         UniqueKey = "ors0eAr4DPkvrwhy5gVnQAqRDnJUO43j9HzbkPyZ/7Q=", // generated with secre from name
            //         TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            //     }
            // );
        }

        private string ExtractEntityNameFromRoleName(string roleName)
        {
            return string.Empty;
        }

        private string ExtractActionNameFromRoleName(string roleName)
        {
            return string.Empty;
        }
    }
}