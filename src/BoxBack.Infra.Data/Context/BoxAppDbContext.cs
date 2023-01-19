using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BoxBack.Infra.CrossCutting.Identity.Services;

namespace BoxBack.Infra.Data.Context
{
    public class BoxAppDbContext : IdentityDbContext<
                                            ApplicationUser, ApplicationRole, string,
                                            ApplicationUserClaim, ApplicationUserRole, IdentityUserLogin<string>,
                                            IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly UserResolverService _userResolverService;

        public BoxAppDbContext(DbContextOptions<BoxAppDbContext> options, 
                                UserResolverService userResolverService)
            : base(options)
        {
            _userResolverService = userResolverService;
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteServico> ClientesServicos { get; set; }
        public DbSet<ClienteProduto> ClientesProdutos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<FornecedorServico> FornecedorServicos { get; set; }
        public DbSet<FornecedorProduto> FornecedorProdutos { get; set; }
        public DbSet<Pipeline> Pipelines { get; set; }
        public DbSet<PipelineEtapa> PipelineEtapas { get; set; }
        public DbSet<PipelineAssinante> PipelineAssinantes { get; set; }
        public DbSet<PipelineTarefa> PipelineTarefas { get; set; }
        public DbSet<PipelineTarefaApontamento> PipelineTarefaApontamentos { get; set; }
        public DbSet<PipelineTarefaAssinante> PipelineTarefaAssinantes { get; set; }
        public DbSet<PipelineTarefaTag> PipelineTarefaTags { get; set; }
        public DbSet<PipelineTarefaAnexo> PipelineTarefaAnexos { get; set; }
        public DbSet<PipelineTarefaApontamentoAnexo> PipelineTarefaApontamentoAnexos { get; set; }
        public DbSet<TarefaTag> TarefaTags { get; set; }
        public DbSet<ChaveApiTerceiro> ChavesApiTerceiro { get; set; }
        public DbSet<ClienteContrato> ClientesContratos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<VendedorComissao> VendedoresComissoes { get; set; }
        public DbSet<VendedorContrato> VendedoresContratos { get; set; }
        public DbSet<ClienteContratoFatura> ClientesContratosFaturas { get; set; }
        public DbSet<Rotina> Rotinas { get; set; }
        public DbSet<RotinaEventHistory> RotinasEventsHistories { get; set; }
        public DbSet<VerticalNavItem> VerticalNavItems { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // NpgsqlConnection.GlobalTypeMapper.MapEnum<InstrumentoPrisaoTipoEnum>();
            // NpgsqlConnection.GlobalTypeMapper.MapComposite<InstrumentoPrisaoTipoEnum>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserClaimMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserMap());
            modelBuilder.ApplyConfiguration(new ApplicationRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationGroupMap());
            modelBuilder.ApplyConfiguration(new ApplicationRoleGroupMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserGroupMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ClienteServicoMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new FornecedorServicoMap());
            modelBuilder.ApplyConfiguration(new PipelineMap());
            modelBuilder.ApplyConfiguration(new PipelineEtapaMap());
            modelBuilder.ApplyConfiguration(new PipelineAssinanteMap());
            modelBuilder.ApplyConfiguration(new PipelineTarefaMap());
            modelBuilder.ApplyConfiguration(new PipelineTarefaApontamentoMap());
            modelBuilder.ApplyConfiguration(new PipelineTarefaAssinanteMap());
            modelBuilder.ApplyConfiguration(new PipelineTarefaTagMap());
            modelBuilder.ApplyConfiguration(new PipelineTarefaAnexoMap());
            modelBuilder.ApplyConfiguration(new PipelineTarefaApontamentoAnexoMap());
            modelBuilder.ApplyConfiguration(new TarefaTagMap());
            modelBuilder.ApplyConfiguration(new ChaveApiTerceiroMap());
            modelBuilder.ApplyConfiguration(new ClienteContratoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new FornecedorProdutoMap());
            modelBuilder.ApplyConfiguration(new ClienteProdutoMap());
            modelBuilder.ApplyConfiguration(new VendedorMap());
            modelBuilder.ApplyConfiguration(new VendedorComissaoMap());
            modelBuilder.ApplyConfiguration(new VendedorContratoMap());
            modelBuilder.ApplyConfiguration(new ClienteContratoFaturaMap());
            modelBuilder.ApplyConfiguration(new RotinaMap());
            modelBuilder.ApplyConfiguration(new RotinaEventHistoryMap());
            modelBuilder.ApplyConfiguration(new VerticalNavItemMap());

            modelBuilder.HasSequence<Int32>("OrderNumbers")
                        .StartsAt(1)
                        .IncrementsBy(1);
                        
            modelBuilder.Entity<Rotina>()
                        .Property(c => c.ChaveSequencial)
                        .HasDefaultValueSql("nextval('\"OrderNumbers\"')");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void OnBeforeSaving()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is EntityAudit)
                .ToList();

            var entitiesTracker = ChangeTracker.Entries().ToList();

            UpdateSoftDelete(entities);
            UpdateTimestamps(entities);
        }
        private void UpdateSoftDelete(List<EntityEntry> entries)
        {
            var filtered = entries
                .Where(x => x.State == EntityState.Added
                    || x.State == EntityState.Deleted);

            foreach (var entry in filtered)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.CurrentValues["IsDeleted"] = false;
                        ((EntityAudit)entry.Entity).IsDeleted = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        //entry.CurrentValues["IsDeleted"] = true;
                        ((EntityAudit)entry.Entity).IsDeleted = true;
                        break;
                }
            }
        }
        private void UpdateTimestamps(List<EntityEntry> entries)
        {
            var filtered = entries
                .Where(x => x.State == EntityState.Added
                    || x.State == EntityState.Modified);

            // TODO: Get real current user id
            var currentUserId = _userResolverService.GetUserId();

            foreach (var entry in filtered)
            {
                if (entry.State == EntityState.Added)
                {
                    ((EntityAudit)entry.Entity).CreatedAt = DateTime.UtcNow;
                    ((EntityAudit)entry.Entity).CreatedBy = currentUserId;
                }

                ((EntityAudit)entry.Entity).UpdatedAt = DateTime.UtcNow;
                ((EntityAudit)entry.Entity).UpdatedBy = currentUserId;
            }
        }
    }
}