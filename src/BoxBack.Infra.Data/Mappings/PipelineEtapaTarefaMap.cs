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
                .HasForeignKey(c => c.PipelineEtapaId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.PipelineEtapaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}