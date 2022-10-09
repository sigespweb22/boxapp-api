using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineTarefaAssinanteMap : IEntityTypeConfiguration<PipelineTarefaAssinante>
    {
        public void Configure(EntityTypeBuilder<PipelineTarefaAssinante> builder)
        {
            builder.ToTable("PipelineTarefaAssinantes");

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
                .WithMany(c => c.PipelineTarefaAssinantes)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.PipelineTarefa)
                .WithMany(c => c.PipelineTarefaAssinantes)
                .HasForeignKey(c => c.UserId)
                .HasForeignKey(c => c.PipelineTarefaId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.ApplicationUser)
                .WithMany(c => c.PipelineTarefaAssinantes)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.UserId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.PipelineTarefaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}