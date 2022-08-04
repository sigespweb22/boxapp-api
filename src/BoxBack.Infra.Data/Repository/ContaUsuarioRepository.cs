using System.Net.Mime;
using System.Xml;
using System.Security.AccessControl;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BoxBack.Infra.Data.Repository
{
    public class ContaUsuarioRepository : Repository<ContaUsuario>, IContaUsuarioRepository
    {
        public ContaUsuarioRepository(BoxAppDbContext context)
            : base(context)
        {

        }


        public ContaUsuario GetByIdWithInclude(Guid id)
        {
            var contaUsuario = DbSet
                                .AsNoTracking()
                                .Include(x => x.ApplicationUser)
                                .FirstOrDefault(x => x.Id == id);
            return contaUsuario;
        }

        public new async Task<ContaUsuario> GetByIdAsync(Guid id)
        {
            var contaUsuario = await DbSet.FindAsync(id);
            
            return contaUsuario;
        }

         public new ContaUsuario GetById(Guid id)
        {
            var contaUsuario = DbSet.Find(id);
            
            return contaUsuario;
        }

        public ContaUsuario GetByUserId(string usuarioId)
        {
            var contaUsuario =  DbSet
                                    .AsNoTracking()
                                    .Include(x => x.ApplicationUser)
                                    .FirstOrDefault(x => x.UserId == usuarioId.ToString());
            
            return contaUsuario;
        }
        public ContaUsuario GetByUserIdNotIncludes(string usuarioId)
        {
            var contaUsuario =  DbSet
                                    .AsNoTracking()
                                    .FirstOrDefault(x => x.UserId == usuarioId.ToString());
            
            return contaUsuario;
        }

        public new Task<IEnumerable<ContaUsuario>> GetAll()
        {
            // var temp = await DbSet.Include(a => a.ApplicationUser).ToListAsync();
            // return temp;

            // (from cli in db.Clientes
            //               select new {
            //                     cliente. Codigo,
            //                     cliente.Nome
            //                }). ToList ();

            // var filteredBlogs = context.Blogs
            //         .Include(
            //             blog => blog.Posts
            //                 .Where(post => post.BlogId == 1)
            //                 .OrderByDescending(post => post.Title)
            //                 .Take(5))
            //         .ToList();

            var contaUsuarios =  from contaUsuario in DbSet
                                    select new ContaUsuario
                                    {
                                        UserId = contaUsuario.UserId,
                                        Nome = contaUsuario.Nome,
                                        ApplicationUser = new ApplicationUser
                                        {
                                            NormalizedUserName = contaUsuario.ApplicationUser.NormalizedUserName,
                                            UserName = contaUsuario.ApplicationUser.UserName
                                        }
                                    };

            return (Task<IEnumerable<ContaUsuario>>)contaUsuarios;
        }
    }
}