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
                if (!role.Equals("Master"))
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
                } else {
                    builder.HasData(new ApplicationRole()
                    {
                        Id = "b0f96d85-3647-4651-9f78-b7529b577ec0",
                        Name = "Master",
                        NormalizedName = "MASTER",
                        ConcurrencyStamp = "4629cea3-3b65-43b9-9c4e-7cc68fe4e4e4",
                        Description = "Pode realizar todas as ações/operações, bem como ter acesso a todos os dados e funcionalidades"
                    });
                }
            }
        }
    }
}