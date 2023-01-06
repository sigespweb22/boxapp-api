using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using FluentValidation;

namespace BoxBack.WebApi.ViewModelsValidators.VendedorComissaoViewModelValidator
{
    public class VendedorComissaoAlterStatusViewModelValidator : AbstractValidator<VendedorComissaoViewModel>
    {
        public VendedorComissaoAlterStatusViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id é requerido.");
        }
    }
}