using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .HasMany(c => c.ApplicationUserRoles)
                .WithOne(d => d.ApplicationRole)
                .HasForeignKey(c => c.RoleId)
                .IsRequired();

            //Initial seed
            builder.HasData(
                new ApplicationRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", ConcurrencyStamp = "da8e4f70-8be9-4d8f-a684-5b97f19d252c", Name = "Master", NormalizedName = "MASTER".ToUpper() 
                }
            );
        }
    }
}