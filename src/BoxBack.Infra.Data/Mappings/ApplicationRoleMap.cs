using System.ComponentModel;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using System;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Helpers;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Collections.Generic;

namespace BoxBack.Infra.Data.Mappings
{
    public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .HasMany(c => c.ApplicationUserRoles)
                .WithOne(d => d.ApplicationRole)
                .HasForeignKey(c => c.RoleId)
                .IsRequired();
            
            builder
                .HasMany(c => c.ApplicationRoleClaims)
                .WithOne(d => d.ApplicationRole)
                .HasForeignKey(c => c.RoleId)
                .IsRequired();
            
            builder.HasData(new ApplicationRole()
            {
                Id = "b0f96d85-3647-4651-9f78-b7529b577ec0",
                Name = "Master",
                NormalizedName = "MASTER",
                ConcurrencyStamp = "4629cea3-3b65-43b9-9c4e-7cc68fe4e4e4",
                Description = "Pode realizar todas as ações/operações, bem como ter acesso a todos os dados e funcionalidades"
            });

            //Initial seed
            var roles = EnumHelper.GetNames<PermissionEnum>();
            foreach (var role in roles)
            {
                if (!role.Equals("Master"))
                {
                    var tmp = new ApplicationRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = role,
                        NormalizedName = role.ToUpper(),
                        Subject = $"ac-{ExtractEntityOrActionFromRoleName(role, "ENTITY")}-page",
                        Actions = GetActionsEnumFromRoleName(role),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        Description = EnumHelper.Parse<PermissionEnum>(role).GetDescription()
                    };
                    builder.HasData(tmp);
                }
            }
        }

        private string ExtractEntityOrActionFromRoleName(string roleName, string extractType)
        {
            #region Generals validations
            if (string.IsNullOrEmpty(roleName)) throw new ArgumentException("Role name requerida.");
            #endregion

            var stringPatter = "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)";
            string[] roleNameSlice;
            try
            {
                roleNameSlice = Regex.Matches(roleName, stringPatter)
                                          .OfType<Match>()
                                          .Select(m => m.Value).ToArray();
            }
            catch { throw; }

            switch(extractType)
            {
                case "ENTITY":
                    return roleNameSlice[1];
                case "ACTION":
                    return roleNameSlice[2].ToUpper();
                default: 
                    throw new ArgumentException("Extract type requerida.");
            }
        }

        private CASLJSActionsEnum[] GetActionsEnumFromRoleName(string roleName)
        {
            #region Generals validations
            if (string.IsNullOrEmpty(roleName)) throw new ArgumentException("Role name requerida.");
            #endregion

            #region Actions extract
            String actionExtract;
            try
            {
                actionExtract = ExtractEntityOrActionFromRoleName(roleName, "ACTION");    
            }
            catch { throw; }
            #endregion        
            
            #region Get enuns data and map
            CASLJSActionsEnum[] actions;
            if (actionExtract == "ALL")
            {
                try
                {
                    actions = (CASLJSActionsEnum[])Enum.GetValues(typeof(CASLJSActionsEnum));    
                }
                catch { throw; }
            } else {
                try
                {
                    actions = (CASLJSActionsEnum[])Enum.Parse(typeof(CASLJSActionsEnum), actionExtract);    
                }
                catch { throw; }
            }
            #endregion

            return actions;
        }
    }
}