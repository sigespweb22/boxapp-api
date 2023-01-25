using System;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data
{
    public class ChaveApiTerceiroMap : IEntityTypeConfiguration<ChaveApiTerceiro>
    {
        public void Configure(EntityTypeBuilder<ChaveApiTerceiro> builder)
        {
            builder.ToTable("ChavesApiTerceiro");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Descricao)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.Key)
                .IsRequired(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
            
            // builder.HasData(
            //     new ChaveApiTerceiro
            //     {
            //         Id = Guid.NewGuid(),
            //         ApiTerceiro = ApiTerceiroEnum.BOM_CONTROLE
            //     }
            // );
        }
    }
}