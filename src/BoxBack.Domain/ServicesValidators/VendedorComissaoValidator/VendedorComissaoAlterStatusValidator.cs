using BoxBack.Domain.Models;
using FluentValidation;

namespace BoxBack.Domain.Validators.VendedorComissaoValidator
{
    public class VendedorComissaoAlterStatusValidator : AbstractValidator<VendedorComissao>
    {
        public VendedorComissaoAlterStatusValidator()
        {
            RuleFor(vendedorComissao => vendedorComissao.Id).NotNull();
            RuleFor(vendedorComissao => vendedorComissao).NotNull();
        }
    }
}