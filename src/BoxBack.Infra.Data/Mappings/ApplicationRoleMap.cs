using System;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Helpers;
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
            var roles = EnumHelper.GetNames<PermissionEnum>();
            foreach (var role in roles)
            {
                var tmp = new ApplicationRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = role,
                    NormalizedName = role.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Description = EnumHelper.Parse<PermissionEnum>(role).GetDescription()
                };
                builder.HasData(tmp);
            }
        }
    }
}