using System.Collections.Generic;
namespace BoxBack.Domain.ModelsServices
{
    public class BCClienteModelService
    {
        public int Id { get; set; }
        public string TipoPessoa { get; set; }
        public string PaisOrigem { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public bool Bloqueado { get; set; }
        public Endereco Endereco { get; set; }
        public List<Contato> Contatos { get; set; }
    }

    public class Endereco
    {
        public int Id { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }

    public class PessoaFisica
    {
        public string Documento {get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set;}
        public string DataNascimento { get; set; }
    }

    public class PessoaJuridica
    {
        public string Documento { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public bool IsentoInscricaoEstadual { get; set; }
        public string InscricaoEstadual { get; set; }
        public string UFInscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string RamoAtividade { get; set; }
    }

    public class Contato
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFornecedor { get; set; }
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Padrao { get; set; }
        public bool Cobranca { get; set; }
    }

    
}