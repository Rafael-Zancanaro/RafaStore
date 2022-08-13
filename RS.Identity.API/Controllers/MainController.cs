using HelperExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RS.Identity.API.Models.JwtToken;
using System.Linq;

namespace RS.Identity.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ActionResult CustomResponse<T>(ResultViewModel<T> result = null)
        {
            return result.ValidOperation
                ? Ok(result)
                : BadRequest(result);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var result = new ResultViewModel<UserToken>();
            var errors = modelState.Values.SelectMany(x => x.Errors);

            foreach (var error in errors)
            {
                result.AddError(error.ErrorMessage);
            }

            return CustomResponse(result);
        }
    }
}