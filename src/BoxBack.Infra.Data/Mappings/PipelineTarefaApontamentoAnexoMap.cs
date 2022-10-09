using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineTarefaApontamentoAnexoMap : IEntityTypeConfiguration<PipelineTarefaApontamentoAnexo>
    {
        public void Configure(EntityTypeBuilder<PipelineTarefaApontamentoAnexo> builder)
        {
            builder.ToTable("PipelineTarefaApontamentoAnexos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Anexo)
                .IsRequired();
            
            //Relationships
            builder
                .HasOne(c => c.PipelineTarefaApontamento)
                .WithMany(c => c.PipelineTarefaApontamentoAnexos)
                .HasForeignKey(c => c.PipelineTarefaApontamentoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(c => c.PipelineTarefaApontamentoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}