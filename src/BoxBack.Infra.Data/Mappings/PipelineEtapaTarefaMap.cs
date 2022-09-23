using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineEtapaTarefaMap : IEntityTypeConfiguration<PipelineEtapaTarefa>
    {
        public void Configure(EntityTypeBuilder<PipelineEtapaTarefa> builder)
        {
            builder.ToTable("PipelineEtapaTarefas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.Descricao)
                .IsRequired(false);
            
            builder.Property(c => c.Posicao)
                .IsRequired();

            //Relationships
            builder
                .HasOne(c => c.PipelineEtapa)
                .WithMany(c => c.Tarefas)
                .ForeignKey(c => c.PipelineEtapaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Pipeline)
                .WithMany(c => c.Assinantes)
                .ForeignKey(c => c.PipelineId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.PipelineEtapaTarefa)
                .WithMany(c => c.Assinantes)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.PipelineEtapaTarefaApontamento)
                .WithMany(c => c.Apontamentos)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.PipelineEtapaTarefaAnexo)
                .WithMany(c => c.Anexos)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.PipelineEtapaTarefaTag)
                .WithMany(c => c.Tags)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}