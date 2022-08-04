using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoxBack.Domain.Models;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationUserRoleMap : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.HasData(
                //ROLES USER ADM

                //ROLE MASTER
                new ApplicationUserRole
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                //ROLE SERVIÇOS TODOS
                new ApplicationUserRole
                {
                    RoleId = "b3a5b61d-7ff4-43cb-bad4-a945b150fc72",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
        }
    }
}