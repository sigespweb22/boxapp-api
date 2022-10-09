using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineAssinanteMap : IEntityTypeConfiguration<PipelineAssinante>
    {
        public void Configure(EntityTypeBuilder<PipelineAssinante> builder)
        {
            builder.ToTable("PipelineAssinantes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(255);
            
            //Relationships
            builder
                .HasOne(c => c.ApplicationUser)
                .WithMany(c => c.PipelineAssinantes)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Pipeline)
                .WithMany(c => c.PipelineAssinantes)
                .HasForeignKey(c => c.PipelineId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.ApplicationUser)
                .WithMany(c => c.PipelineAssinantes)
                .OnDelete(DeleteBehavior.NoAction);
        
            builder
                .HasIndex(c => c.UserId)
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.PipelineId)
                // .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}