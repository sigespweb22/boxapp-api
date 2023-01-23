using BoxBack.Domain.Models;
using FluentValidation;

namespace BoxBack.Domain.Validators.VendedorComissaoValidator
{
    public class VendedorComissaoAlterStatusValidator : AbstractValidator<VendedorComissao>
    {
        public VendedorComissaoAlterStatusValidator()
        {
            RuleFor(vendedorComissao => vendedorComissao.Id).NotNull().WithMessage("Id é requerido.");
            RuleFor(vendedorComissao => vendedorComissao.Id).NotEmpty().WithMessage("Id é requerido.");
            RuleFor(vendedorComissao => vendedorComissao).Empty().WithMessage("Nenhum comissão de vendedor encontrada com o id informado para atualizar seu status.");
        }
    }
}