using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class Ativo : EntityAudit
    {        
        public Ativo(string nome, string referencia, string codigoUnico,
                       ClienteAtivoTipoEnum tipo, decimal valorCusto, decimal valorVenda, 
                       AtivoUnidadeMedidaEnum unidadeMedida, ClienteAtivoTipoServicoTipoEnum clienteAtivoTipoServicoTipo,
                       string caracteristica, string observacao)
        {
            Nome = nome;
            Referencia = referencia;
            CodigoUnico = codigoUnico;
            Tipo = tipo;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
            UnidadeMedida = unidadeMedida;
            ClienteAtivoTipoServicoTipo = clienteAtivoTipoServicoTipo;
            Caracteristica = caracteristica;
            Observacao = observacao;
        }

        // Constructor empty for EF
        public Ativo() {}

        public string Nome { get; set; }
        public string Referencia { get; set; }
        public string CodigoUnico { get; set; }
        public ClienteAtivoTipoEnum Tipo { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
        public AtivoUnidadeMedidaEnum UnidadeMedida { get; set; }
        public ClienteAtivoTipoServicoTipoEnum ClienteAtivoTipoServicoTipo { get; set; }
        public string Caracteristica { get; set; }
        public string Observacao { get; set; }


        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<ClienteAtivo> Clientes { get; set; }
    }
}
