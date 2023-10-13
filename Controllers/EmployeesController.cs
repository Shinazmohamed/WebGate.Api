using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGate.Api.Extensions;
using WebGate.Business.Contracts;
using WebGate.Shared;
using WebGate.Shared.Requests;

namespace WebGate.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class EmployeesController : WebGateControllerBase
    {
        private readonly IEmployeeBusiness _service;

        public EmployeesController(IEmployeeBusiness service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("employees/create")]
        [Authorize(Constants.UserRole)]
        [ProducesResponseType(typeof(AbstractResponse), 201)]
        public async Task<IActionResult> CreateUser([FromBody] EmployeeRequest request)
        {
            var userId = User.GetUserId();
            var response = await _service.CreateEmployeeAsync(userId, request);
            return GetActionResult(response);
        }
    }
}
