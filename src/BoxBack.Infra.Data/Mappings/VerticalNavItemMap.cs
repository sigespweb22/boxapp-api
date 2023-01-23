using System;
using System.Collections.Generic;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class VerticalNavItemMap : IEntityTypeConfiguration<VerticalNavItem>
    {
        public void Configure(EntityTypeBuilder<VerticalNavItem> builder)
        {
            builder.ToTable("VerticalNavItems");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            // var dashboardMain = new VerticalNavItem()
            // {
            //     Id = Guid.NewGuid(),
            //     Position = 1,
            //     Title = "Dashboards",
            //     Icon = "HomeAnalytics",
            //     BadgeContent = "novo",
            //     BadgeColor = "primary",
            //     Children = new List<VerticalNavItem>()
            // };

            // var dashboardComercial = new VerticalNavItem()
            // {
            //     Id = Guid.NewGuid(),
            //     Position = 1,
            //     Title = "Comercial",
            //     Path = "/dashboards/comercial",
            //     Action = "list",
            //     Subject = "ac-dashboardComercial-page"
            // };

            // builder.HasData(dashboardMain);
        }
    }
}