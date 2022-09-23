using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineEtapaTarefaTagMap : IEntityTypeConfiguration<PipelineEtapaTarefaTag>
    {
        public void Configure(EntityTypeBuilder<PipelineEtapaTarefaTag> builder)
        {
            builder.ToTable("PipelineEtapaTarefaTags");

           builder.HasKey(c => new { c.TarefaTagId, c.PipelineEtapaTarefaId });

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            //Relationships
            builder
                .HasOne(c => c.TarefaTag)
                .WithMany(c => c.Tarefas)
                .ForeignKey(c => c.TarefaTagId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.PipelineEtapaTarefa)
                .WithMany(c => c.Tarefas)
                .ForeignKey(c => c.PipelineEtapaTarefaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}