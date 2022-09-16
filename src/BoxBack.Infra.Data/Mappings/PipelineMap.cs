using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineMap : IEntityTypeConfiguration<Pipeline>
    {
        public void Configure(EntityTypeBuilder<Pipeline> builder)
        {
            builder.ToTable("Pipelines");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.TenantId)
                .HasDefaultValue(new Guid("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45"))
                .IsRequired();
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Pipelines)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}