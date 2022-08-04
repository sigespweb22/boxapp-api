using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BoxBack.Domain.Models
{
    public class ContaUsuario : EntityAudit
    {
        public ContaUsuario(string nome, string perfilFoto, SetorEnum setor, FuncaoEnum funcao)
        {
            Nome = nome;
            PerfilFoto = perfilFoto;
            Setor = setor;
            Funcao = funcao;
        }

        // Construtor vazio para o EF
        public ContaUsuario() { }

        public string Nome { get; set; }

        public string PerfilFoto { get; set; }
        
        public SetorEnum Setor { get; set; }

        public FuncaoEnum Funcao { get; set; }


        //Foreign Key ApplicationUser
        public string UserId { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}