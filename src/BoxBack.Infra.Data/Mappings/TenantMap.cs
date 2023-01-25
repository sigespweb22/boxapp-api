using System;
using System.Reflection.Emit;
using System.Collections.Immutable;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenants");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Cnpj)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasIndex(c => c.Cnpj)
                .IsUnique();
            
            builder.Property(c => c.Nome)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(c => c.NomeExibicao)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(c => c.RazaoSocial)
                .IsRequired(false);
            
            builder.Property(c => c.NomeFantasia)
                .IsRequired(false);
            
            builder.Property(c => c.WhatsAppPrincipal)
                .IsRequired(false);
            
            builder.Property(c => c.EmailPrincipal)
                .IsRequired();
            
            builder.Property(c => c.ApiKey)
                .IsRequired();

            builder
                .HasIndex(c => c.ApiKey)
                .IsUnique();
 
            // //Seed init
            // builder.HasData(
            //     new Tenant
            //     {
            //         Id = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"),
            //         IsDeleted = false,
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //         Cnpj = "12.368.943/0001-50",
            //         Nome = "Box Tecnologia Ltda",
            //         NomeExibicao = "Box Tecnologia",
            //         EmailPrincipal = "rafale@boxtecnologia.com.br",
            //         ApiKey = Guid.Parse("57d390e7-2b87-47fe-9bc8-0bae3a388499")
            //     }
            // );
        }
    }
}