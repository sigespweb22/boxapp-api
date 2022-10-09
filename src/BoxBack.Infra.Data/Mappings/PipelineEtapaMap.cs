using System.Data;
using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Infra.Data.Mappings
{
    public class PipelineEtapaMap : IEntityTypeConfiguration<PipelineEtapa>
    {
        public void Configure(EntityTypeBuilder<PipelineEtapa> builder)
        {
            builder.ToTable("PipelineEtapas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(1500);
            
            builder.Property(c => c.Posicao)
                .IsRequired();
            
            builder.Property(c => c.AlertaEstagnacao)
                .HasDefaultValue(0)
                .IsRequired();

            //Relationships
            builder
                .HasOne(c => c.Pipeline)
                .WithMany(c => c.PipelineEtapas)
                .HasForeignKey(c => c.PipelineId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(c => c.PipelineId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
        }
    }
}