using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BoxBack.WebApi.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected bool ResponseHasErrors(ValidationResult result)
        {
            if (result == null || result.IsValid) return false;

            foreach (var error in result.ErrorMessages)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return true;
        }

        protected void AddProcessError(string erro)
        {
            _errors.Add(erro);
        }

        public bool IsValidOperation()
        {
            return !_errors.Any();
        }
    }
}
