using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineEtapaTarefaApontamentoAnexoMap : IEntityTypeConfiguration<PipelineEtapaTarefaApontamentoAnexo>
    {
        public void Configure(EntityTypeBuilder<PipelineEtapaTarefaApontamentoAnexo> builder)
        {
            builder.ToTable("PipelineEtapaTarefaApontamentoAnexos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Anexo)
                .IsRequired();
            
            //Relationships
            builder
                .HasOne(c => c.PipelineEtapaTarefaApontamento)
                .WithMany(c => c.Anexos)
                .HasForeignKey(c => c.PipelineEtapaTarefaApontamentoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(c => c.PipelineEtapaTarefaApontamentoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}