using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineTarefaTagMap : IEntityTypeConfiguration<PipelineTarefaTag>
    {
        public void Configure(EntityTypeBuilder<PipelineTarefaTag> builder)
        {
            builder.ToTable("PipelineTarefaTags");

           builder.HasKey(c => new { c.TarefaTagId, c.PipelineTarefaId });

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            //Relationships
            
            builder
                .HasOne(c => c.PipelineTarefa)
                .WithMany(c => c.PipelineTarefaTags)
                .HasForeignKey(c => c.PipelineTarefaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.TarefaTag)
                .WithMany(c => c.PipelineTarefaTags)
                .HasForeignKey(c => c.TarefaTagId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.PipelineTarefaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.TarefaTagId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}