using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BoxBack.Application;
using BoxBack.Domain.Models.DataTable;

namespace BoxBack.WebApi.Controllers
{
    [ApiController]
    public abstract class ApiController : Controller
    {
        private readonly ICollection<string> _errors = new List<string>();
        private readonly ICollection<object> _objects = new List<object>();

        protected ActionResult CustomResponse(int? statusCode, object result = null)
        {
            if (IsOperationValid())
            {
                statusCode = statusCode == 0 ? 200 : statusCode;
                return StatusCode((int)statusCode, result);
            }

            statusCode = statusCode == 0 ? 500 : statusCode;
            return StatusCode((int) statusCode, new Dictionary<string, string[]>
            {
                { "errors", _errors.ToArray() }
            });
        }

        protected ActionResult CustomResponse(int statusCode, ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse(statusCode);
        }

        protected ActionResult CustomResponse(int statusCode, ValidationResult validationResult)
        {
            foreach (var error in validationResult.ErrorMessages)
            {
                AddError(error);
            }

            foreach (var obj in validationResult.Objects)
            {
                AddObject(obj);                
            }

            if (validationResult.Objects.Any())
                return CustomResponse(statusCode, validationResult.Objects);
            return CustomResponse(statusCode);
        }

        protected bool IsOperationValid()
        {
            var errors = !_errors.Any();
            return errors;
        }

        protected void  AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void  AddErrorToTryCatch(Exception erro)
        {
            if (erro.InnerException != null){
                _errors.Add(erro.InnerException.Message);
            }
            else
            {
                _errors.Add(erro.Message);
            }
        }

        protected void AddObject(object obj)
        {
            _objects.Add(obj);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}