// using System;
// using System.Collections.Generic;

// namespace BoxBack.Domain.Models
// {
//     public class Tenant : EntityAudit
//     {
//         public Tenant(string nome,
//                       string nomeExibicao,
//                       string razaoSocial,
//                       string nomeFantasia,
//                       string whatsAppPrincipal,
//                       string emailPrincipal,
//                       Guid apiKey)
//         {
//             Nome = nome;
//             NomeExibicao = nomeExibicao;
//             RazaoSocial = razaoSocial;
//             NomeFantasia = nomeFantasia;
//             WhatsAppPrincipal = whatsAppPrincipal;
//             EmailPrincipal = emailPrincipal;
//             ApiKey = apiKey;
//         }

//         //Construtor vazio para o EF
//         public Tenant() { }

//         public string Nome { get; set; }
//         public string NomeExibicao { get; set; }
//         public string RazaoSocial { get; set; }
//         public string NomeFantasia { get; set; }
//         public string WhatsAppPrincipal { get; set; }
//         public string EmailPrincipal { get; set; }
//         public Guid ApiKey { get; set; }


//         // Relationships
//         public ICollection<ApplicationUser> ApplicationsUsers { get; set; }
//     }
// }