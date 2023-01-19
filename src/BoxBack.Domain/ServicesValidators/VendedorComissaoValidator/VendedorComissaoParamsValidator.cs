using BoxBack.Domain.Models;
using FluentValidation;

namespace BoxBack.Domain.Validators.VendedorComissaoValidator
{
    public class VendedorComissaoParamsValidator : AbstractValidator<VendedorComissao>
    {
        public VendedorComissaoParamsValidator()
        {
            RuleFor(vendedorComissao => vendedorComissao.VendedorId).NotNull().WithMessage("Id vendedor requerido.");
            RuleFor(vendedorComissao => vendedorComissao.VendedorId).NotEmpty().WithMessage("Id vendedor requerido.");
        }
    }
}