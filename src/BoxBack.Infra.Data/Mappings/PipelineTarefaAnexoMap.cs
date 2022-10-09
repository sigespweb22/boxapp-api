using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineTarefaAnexoMap : IEntityTypeConfiguration<PipelineTarefaAnexo>
    {
        public void Configure(EntityTypeBuilder<PipelineTarefaAnexo> builder)
        {
            builder.ToTable("PipelineTarefaAnexos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Anexo)
                .IsRequired();
            
            //Relationships
            builder
                .HasOne(c => c.PipelineTarefa)
                .WithMany(c => c.PipelineTarefaAnexos)
                .HasForeignKey(c => c.PipelineTarefaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(c => c.PipelineTarefaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}