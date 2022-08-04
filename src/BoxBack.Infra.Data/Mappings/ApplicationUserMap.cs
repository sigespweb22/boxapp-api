using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("UserId");

            builder
                .HasOne(c => c.ContaUsuario)
                .WithOne(d => d.ApplicationUser)
                .HasForeignKey<ContaUsuario>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasMany(c => c.ApplicationUserRoles)
                .WithOne(d => d.ApplicationUser)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            builder
                .HasMany(c => c.ApplicationUserClaims)
                .WithOne()
                .HasForeignKey(c => c.UserId)
                .IsRequired();
            
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "alan.rezende@boxtecnologia.com.br",
                    NormalizedUserName = "ALAN.REZENDE@BOXTECNOLOGIA.COM.BR",
                    ConcurrencyStamp = "ca431822-360a-4ee6-b978-66564d429fc7",
                    SecurityStamp = "c9514850-61dd-4cc1-b909-88b79b035643",
                    PasswordHash = "AQAAAAEAACcQAAAAEFGbgHKOKiDDs5fvXN8kHviorntHToMKurnVJNmsFQNInxhQOyZTwJ2w0SpbyCdZbA==",
                }
            );
        }
    }
}