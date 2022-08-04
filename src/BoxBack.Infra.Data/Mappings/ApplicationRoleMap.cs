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

            //Seeding a  'Administrator' role to AspNetRoles table
            builder.HasData(
                new ApplicationRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", ConcurrencyStamp = "da8e4f70-8be9-4d8f-a684-5b97f19d252c", Name = "Master", NormalizedName = "MASTER".ToUpper() 
                },
                new ApplicationRole 
                {
                    Id = "b3a5b61d-7ff4-43cb-bad4-a945b150fc72", ConcurrencyStamp = "194c8eaf-4f2e-4d0e-9b45-ab664a763c1e", Name = "Servicos_Todos", NormalizedName = "SERVICOS_TODOS".ToUpper() 
                }
            );
        }
    }
}