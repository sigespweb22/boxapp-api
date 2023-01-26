using System;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxBack.Infra.Data.Mappings
{
    public class RotinaMap : IEntityTypeConfiguration<Rotina>
    {
        public void Configure(EntityTypeBuilder<Rotina> builder)
        {
            builder.ToTable("Rotinas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(2500);

            //Relationships
            // builder
            //     .HasMany(c => c.RotinasEventsHistories)
            //     .WithOne(x => x.Rotina)
            //     .OnDelete(DeleteBehavior.NoAction);
            
            // builder
            //     .HasOne(c => c.Tenant)
            //     .WithMany(c => c.Rotinas)
            //     .HasForeignKey(c => c.TenantId)
            //     .OnDelete(DeleteBehavior.NoAction);
            
            // // Seed
            // var rotina1 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Sincronização de clientes com o sistema Bom Controle",
            //     Descricao = "Esta rotina insere automaticamente no boxapp os clientes ativos do sistema Bom Controle",
            //     ChaveSequencial = 1,
            //     DispatcherRoute = "dispatch-clientes-sync",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina1);

            // var rotina2 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Sincronização de contratos de clientes com o sistema Bom Controle",
            //     Descricao = "Esta rotina insere automaticamente no boxapp os contratos de clientes ainda não existente, a partir do sistema Bom Controle.",
            //     Observacao = "",
            //     ChaveSequencial = 2,
            //     DispatcherRoute = "dispatch-contratos-sync",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina2);

            // var rotina3 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Atualização de contratos de clientes com o sistema Bom Controle",
            //     Descricao = "Esta rotina atualiza a periodicidade dos novos contratos sincronizados a partir da rotina 2.",
            //     Observacao = "A atualização de periodicidade que ocorre logo após a importação dos contratos só se faz necessária uma vez que, o método da api do sistema Bom Controle que retorna os contratos não traz este dado. Portanto, se faz necessário buscá-lo em um outro método da api do Bom Controle.",
            //     ChaveSequencial = 3,
            //     DispatcherRoute = "dispatch-contratos-update",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina3);

            // var rotina4 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Sincronização de faturas quitadas de contratos de clientes com o sistema Bom Controle",
            //     Descricao = "Esta rotina insere automaticamente no boxapp todas as faturas quitadas de contratos de clientes do bom controle",
            //     ChaveSequencial = 4,
            //     DispatcherRoute = "dispatch-faturas-quitadas-sync",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina4);

            // var rotina5 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Sincronização de faturas não quitadas de contratos de clientes com o sistema Bom Controle",
            //     Descricao = "Esta rotina insere automaticamente no boxapp todas as faturas não quitadas de contratos de clientes do bom controle",
            //     ChaveSequencial = 5,
            //     DispatcherRoute = "dispatch-faturas-nao-quitadas-sync",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina5);

            // var rotina6 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Atualização dos dados de faturas de contratos de clientes com o sistema Bom Controle",
            //     Descricao = "Esta rotina atualiza automaticamente no boxapp os dados de faturas a partir de informações do sistema Bom Controle.",
            //     ChaveSequencial = 6,
            //     DispatcherRoute = "dispatch-faturas-update",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina6);

            // var rotina7 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Gerar comissão de vendedores ativos no Boxapp",
            //     Descricao = "Esta rotina interna gera as comissões de vendedores. As comissões são obtidas a partir dos dados de comissão (Em real ou Porcentagem), parametrizados ao vincular um contrato a um vendedor, bem como são geradas comissões apenas de contratos com faturas pagas (Em dia).",
            //     Observacao = "É recomendado que antes de rodar esta rotina, seja rodado a rotina de ChaveSequencial - 2, 3 e 4 -, afim de atualizar os contratos e suas faturas.",
            //     ChaveSequencial = 7,
            //     DispatcherRoute = "dispatch-vendedores-comissoes-create",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina7);

            // var rotina8 = new Rotina()
            // {
            //     Id = Guid.NewGuid(),
            //     Nome = "Gerar comissões para um vendedor ativo no Boxapp",
            //     Descricao = "Esta rotina interna gera as comissões de um vendedor apenas. As comissões são obtidas a partir dos dados de comissão (Em real ou Porcentagem), parametrizados ao vincular um contrato a um vendedor, bem como são geradas comissões apenas de contratos com faturas pagas (Em dia).",
            //     Observacao = "É recomendado que antes de rodar esta rotina, seja rodado a rotina de ChaveSequencial - 2, 3 e 4 -, afim de atualizar os contratos e suas faturas.",
            //     ChaveSequencial = 8,
            //     DispatcherRoute = "dispatch-vendedores-comissoes-create-by-vendedorId",
            //     CreatedAt = DateTimeOffset.Now,
            //     CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     UpdatedAt = DateTimeOffset.Now,
            //     UpdatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     TenantId = Guid.Parse("d8fe3845-3f2e-4b4e-aeb6-53222d60ff45")
            // };
            // builder.HasData(rotina8);
        }
    }
}