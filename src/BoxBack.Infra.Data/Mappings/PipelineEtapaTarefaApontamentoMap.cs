using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineEtapaTarefaApontamentoMap : IEntityTypeConfiguration<PipelineEtapaTarefaApontamento>
    {
        public void Configure(EntityTypeBuilder<PipelineEtapaTarefaApontamento> builder)
        {
            builder.ToTable("PipelineEtapaTarefaApontamentos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Titulo)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.Conteudo)
                .IsRequired();
            
            //Relationships
            builder
                .HasOne(c => c.PipelineEtapaTarefa)
                .WithMany(c => c.Tarefas)
                .ForeignKey(c => c.PipelineEtapaTarefaId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.PipelineEtapaTarefaApontamento)
                .WithMany(c => c.Anexos)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}