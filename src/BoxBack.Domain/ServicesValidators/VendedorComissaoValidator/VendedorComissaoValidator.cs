using BoxBack.Domain.Models;
using FluentValidation;

namespace BoxBack.Domain.Validators.VendedorComissaoValidator
{
    public class VendedorComissaoValidator : AbstractValidator<VendedorComissao>
    {
        public VendedorComissaoValidator()
        {
            RuleFor(vendedorComissao => vendedorComissao).Empty().WithMessage("Nenhum comissão de vendedor encontrada.");
            RuleFor(vendedorComissao => vendedorComissao.VendedorId).NotNull().WithMessage("Id vendedor requerido.");
            RuleFor(vendedorComissao => vendedorComissao.VendedorId).NotEmpty().WithMessage("Id vendedor requerido.");
        }
    }
}