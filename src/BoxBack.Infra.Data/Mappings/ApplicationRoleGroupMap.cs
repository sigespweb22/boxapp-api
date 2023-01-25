using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationRoleGroupMap : IEntityTypeConfiguration<ApplicationRoleGroup>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleGroup> builder)
        {
            builder.ToTable("AspNetRoleGroups");

            builder.HasKey(c => new { c.RoleId, c.GroupId });

            builder
                .HasOne(c => c.ApplicationRole)
                .WithMany(c => c.ApplicationRoleGroups)
                .HasForeignKey(c => c.RoleId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            builder
                .HasOne(c => c.ApplicationGroup)
                .WithMany(c => c.ApplicationRoleGroups)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            // Initial seed
            // builder.HasData(
            //     new ApplicationRoleGroup
            //     {
            //         RoleId = "b0f96d85-3647-4651-9f78-b7529b577ec0", // primary key
            //         GroupId = Guid.Parse("23e63d9c-283b-496b-b7d8-7dac2ef7a822") // primary key
            //     }
            // );
        }
    }
}