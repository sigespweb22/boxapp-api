using System;
using System.Text.RegularExpressions;
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
                        Subject = CreateSubjectToRole(role),
                        Actions = (CASLJSActionsEnum[])Enum.GetValues(typeof(CASLJSActionsEnum)),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        Description = EnumHelper.Parse<PermissionEnum>(role).GetDescription()
                    };
                    builder.HasData(tmp);
                }
            }
        }

        private string CreateSubjectToRole(string roleName)
        {
            #region Generals validations
            if (string.IsNullOrEmpty(roleName)) throw new ArgumentException("Role name requerida.");
            #endregion
            
            #region Get entities to create subject
            var entities = new List<string>();
            try
            {
                entities = ExtractEntityFromRoleName(roleName);
            }
            catch { throw new Exception("Problemas ao extrair o nome da entidade a partir do nome da role."); }
            #endregion

            #region Create subject
            String subject = String.Empty;
            try
            {
                for (var i = 0; i < entities?.Count() -1; i++)
                {
                    if (i == 1)
                    {
                        subject = $"{subject}{entities[i]?.ToLower()}";
                    } else {
                        subject = $"{subject}{entities[i]}";    
                    }
                }
            }
            catch { throw new Exception("Problemas ao criar subject."); }
            #endregion

            return $"ac-{subject}-page";
        }

        private List<string> ExtractEntityFromRoleName(string roleName)
        {
            #region Generals validations
            if (string.IsNullOrEmpty(roleName)) throw new ArgumentException("Role name requerida.");
            #endregion

            #region Extract entity
            var stringPatter = "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)";
            string[] roleNameSlice;
            try
            {
                roleNameSlice = Regex.Matches(roleName, stringPatter)
                                     .OfType<Match>()
                                     .Select(m => m.Value).ToArray();
            }
            catch { throw; }
            #endregion

            #region Clear extracted entities
            try
            {
                Array.Clear(roleNameSlice, 0, 1);
                Array.Clear(roleNameSlice, (roleNameSlice.Count() - 1), 1);
            }
            catch { throw; }
            #endregion

            #region Create array to return
            var entities = new List<string>();
            for (int i = 0; i < roleNameSlice?.Length; i++) 
            {
                entities.Add(roleNameSlice[i]);
            }
            #endregion
            
            return entities;
        }

        private string ExtractActionFromRoleName(string roleName)
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
            catch { throw new Exception("Problemas ao extrair a ação a partir do nome da role."); }

            return roleNameSlice[2].ToUpper();
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
                actionExtract = ExtractActionFromRoleName(roleName);
            }
            catch { throw; }
            #endregion        
            
            #region Get enuns data and map
            CASLJSActionsEnum[] actions;
            if (actionExtract == "ALL")
            {
                try
                {
                    Console.Write(Enum.GetValues(typeof(CASLJSActionsEnum)));

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