using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineEtapaTarefaAnexoMap : IEntityTypeConfiguration<PipelineEtapaTarefaAnexo>
    {
        public void Configure(EntityTypeBuilder<PipelineEtapaTarefaAnexo> builder)
        {
            builder.ToTable("PipelineEtapaTarefaAnexos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Anexo)
                .IsRequired();
            
            //Relationships
            builder
                .HasOne(c => c.PipelineEtapaTarefa)
                .WithMany(c => c.Anexos)
                .HasForeignKey(c => c.PipelineEtapaTarefaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(c => c.PipelineEtapaTarefaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}