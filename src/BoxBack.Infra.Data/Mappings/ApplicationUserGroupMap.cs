using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationUserGroupMap : IEntityTypeConfiguration<ApplicationUserGroup>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserGroup> builder)
        {
            builder.ToTable("AspNetUserGroups");

            builder.HasKey(c => new { c.UserId, c.GroupId });

            builder
                .HasOne(c => c.ApplicationUser)
                .WithMany(c => c.ApplicationUserGroups)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            builder
                .HasOne(c => c.ApplicationGroup)
                .WithMany(c => c.ApplicationUserGroups)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            // initial seed
            builder.HasData(
                new ApplicationUserGroup
                {
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    GroupId = Guid.Parse("23e63d9c-283b-496b-b7d8-7dac2ef7a822") // primary key
                }
            );
        }
    }
}