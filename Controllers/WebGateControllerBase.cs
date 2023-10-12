using Microsoft.AspNetCore.Mvc;
using WebGate.Shared;

namespace WebGate.Api.Controllers
{
    [ApiController]
    public abstract class WebGateControllerBase : ControllerBase
    {
        protected IActionResult GetActionResult(SuccessResponse response)
        {
            if (!response.Success)
            {
                switch (response.Error.Code)
                {
                    case Shared.Enums.StatusCode.UserUnauthorized:
                        return Forbid();
                    case Shared.Enums.StatusCode.EmployeeNotFound:
                        return NotFound(response);
                    default:
                        return BadRequest(response);
                }
            }

            return Ok(response);
        }

        protected IActionResult GetActionResult(AbstractResponse response, object routeVaules = null, string MethodName = "Get")
        {
            if (response.Success)
            {
                switch (response.ResponseStatusCode)
                {
                    case Shared.Enums.StatusCode.Created:
                        return CreatedAtAction(MethodName, routeVaules, response);
                    case Shared.Enums.StatusCode.Updated:
                    case Shared.Enums.StatusCode.Deleted:
                        return Ok(response);
                    default:
                        return BadRequest(response);
                }
            }
            else
            {
                switch (response.ResponseStatusCode)
                {
                    case Shared.Enums.StatusCode.UserUnauthorized:
                        return Forbid();
                    case Shared.Enums.StatusCode.EmployeeNotFound:
                        return NotFound(response);
                    default:
                        return BadRequest(response);
                }
            }
        }

        // TODO: implement or remove all actions using this method
        /// <summary>
        /// Use as a return value for actions that are not yet implemented
        /// </summary>
        /// <returns><see cref="EmptyResult"/></returns>
        protected async Task<ActionResult> GetDummyResponse()
        {
            return await Task.FromResult(new EmptyResult());
        }
    }
}
