using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineEtapaTarefaAssinanteMap : IEntityTypeConfiguration<PipelineEtapaTarefaAssinante>
    {
        public void Configure(EntityTypeBuilder<PipelineEtapaTarefaAssinante> builder)
        {
            builder.ToTable("PipelineEtapaTarefaAssinantes");

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
                .WithMany(c => c.TarefaAssinantes)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.PipelineEtapaTarefa)
                .WithMany(c => c.TarefaAssinantes)
                .HasForeignKey(c => c.UserId)
                .HasForeignKey(c => c.PipelineEtapaTarefaId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.ApplicationUser)
                .WithMany(c => c.TarefaAssinantes)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.UserId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.PipelineEtapaTarefaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}