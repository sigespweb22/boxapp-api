using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationUserClaimMap : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            // //Seeding
            // builder.HasData(
            //     new ApplicationUserClaim 
            //     {
            //         Id = 1, UserId = "1e526008-75f7-4a01-9942-d178f2b38888", ClaimType = "Todos Role", ClaimValue = "Todos Role" 
            //     },
            //     new ApplicationUserClaim 
            //     {
            //         Id = 2, UserId = "1e526008-75f7-4a01-9942-d178f2b38888", ClaimType = "Relatorios Role", ClaimValue = "Relatorios Role" 
            //     }
            // );
        }
    }
}