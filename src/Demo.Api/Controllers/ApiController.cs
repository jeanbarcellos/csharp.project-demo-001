using Demo.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Demo.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult ResponseValidation(ModelStateDictionary modelState)
        {
            var viewModel = new ValidationErrorResultViewModel();
            viewModel.Success = false;
            viewModel.Message = "Validation error";

            foreach (var item in modelState)
            {
                var key = item.Key;
                var errors = item.Value.Errors.SelectMany(e => e.ErrorMessage);

                foreach (var erro in item.Value.Errors.ToList())
                {
                    viewModel.AddError(key, erro.ErrorMessage);
                }
            }

            return UnprocessableEntity(viewModel);
        }
    }
}
