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
                        Actions = GetActionsEnumFromRoleName(role).ToArray(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        Description = EnumHelper.Parse<PermissionEnum>(role).GetDescription()
                    };

                    builder.HasData(tmp);
                } else {
                    var actionToRoleMasters = new List<CASLJSActionsEnum>()
                    {
                        CASLJSActionsEnum.manage
                    };

                    var tmp = new ApplicationRole()
                    {
                        Id = "b0f96d85-3647-4651-9f78-b7529b577ec0",
                        Name = "Master",
                        NormalizedName = "MASTER",
                        Subject = "all",
                        Actions = actionToRoleMasters.ToArray(),
                        ConcurrencyStamp = "4629cea3-3b65-43b9-9c4e-7cc68fe4e4e4",
                        Description = "Pode realizar todas as ações/operações, bem como ter acesso a todos os dados e funcionalidades"
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
                for (var i = 0; i < entities.Count() - 1; i++)
                {
                    if (i != 1)
                    {
                        subject = $"{subject}{StringHelpers.FirstCharToUpper(entities[i])}";
                    } else {
                        subject = $"{subject}{entities[i]}"; 
                    }
                }
            }
            catch { throw new Exception("Problemas ao criar subject."); }
            #endregion

            return $"ac-{subject}-page";
        }

        private List<CASLJSActionsEnum> GetActionsEnumFromRoleName(string roleName)
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
            
            #region Convert action to enums number
            var actionsMap = new List<CASLJSActionsEnum>();
            if (actionExtract == "All")
            {
                try
                {
                    foreach (var item in Enum.GetValues(typeof(CASLJSActionsEnum)))
                    {
                        var newItem = (CASLJSActionsEnum)item;
                        if (newItem != 0)
                        {
                            actionsMap.Add(newItem);
                        }
                    }
                }
                catch { throw; }
            } else {
                try
                {
                    actionsMap.Add(Enum.Parse<CASLJSActionsEnum>(actionExtract.ToLower()));
                }
                catch { throw; }
            }
            #endregion

            return actionsMap;
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
                entities.Add(roleNameSlice[i]?.ToLower());
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

            try
            {
                Array.Reverse(roleNameSlice);
            }
            catch { throw new Exception("Problemas ao mapear a(s) action(s) a partir do nome da role."); }

            return roleNameSlice[0] ?? string.Empty;
        }
    }
}