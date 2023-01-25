using System.Dynamic;
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
            
             builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.ApplicationUsers)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.PipelineAssinantes)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.PipelineTarefaAssinantes)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TelefoneCelular)
                .HasDefaultValue(99999999999)
                .HasMaxLength(20);
            
            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"));
            
            //a hasher to hash the password before seeding the user to the db
            // var hasher = new PasswordHasher<ApplicationUser>();

            // builder.HasData(
            //     new ApplicationUser
            //     {
            //         Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
            //         UserName = "alan.rezende@boxtecnologia.com.br",
            //         Email = "alan.rezende@boxtecnologia.com.br",
            //         NormalizedEmail = "ALAN.REZENDE@BOXTECNOLOGIA.COM.BR",
            //         EmailConfirmed = true,
            //         FullName = "ALAN LEITE DE REZENDE",
            //         Avatar = string.Empty,
            //         Setor = 0,
            //         Funcao = 0,
            //         NormalizedUserName = "ALAN.REZENDE@BOXTECNOLOGIA.COM.BR",
            //         ConcurrencyStamp = "ca431822-360a-4ee6-b978-66564d429fc7",
            //         SecurityStamp = "c9514850-61dd-4cc1-b909-88b79b035643",
            //         PasswordHash = "AQAAAAEAACcQAAAAEFGbgHKOKiDDs5fvXN8kHviorntHToMKurnVJNmsFQNInxhQOyZTwJ2w0SpbyCdZbA==",
            //         TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            //     }
            // );
        }
    }
}