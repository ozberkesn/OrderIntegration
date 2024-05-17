using Microsoft.AspNetCore.Mvc;
using OrderIntegration.ACompany.Shared.Dtos;

namespace OrderIntegration.ACompany.Shared.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
