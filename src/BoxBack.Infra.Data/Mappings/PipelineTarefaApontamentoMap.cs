using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineTarefaApontamentoMap : IEntityTypeConfiguration<PipelineTarefaApontamento>
    {
        public void Configure(EntityTypeBuilder<PipelineTarefaApontamento> builder)
        {
            builder.ToTable("PipelineTarefaApontamentos");

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
                .HasOne(c => c.PipelineTarefa)
                .WithMany(c => c.PipelineTarefaApontamentos)
                .HasForeignKey(c => c.PipelineTarefaId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.PipelineTarefaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}