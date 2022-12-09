using System;
using System.Text.RegularExpressions;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationRoleClaimMap : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        private readonly BoxAppDbContext _dbContext;
        
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
        }
    }
}