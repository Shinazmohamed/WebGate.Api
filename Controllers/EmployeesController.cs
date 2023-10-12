using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGate.Api.Extensions;
using WebGate.Services.Contracts;
using WebGate.Shared;
using WebGate.Shared.Requests;

namespace WebGate.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class EmployeesController : WebGateControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("employees/create")]
        [Authorize(Constants.UserRole)]
        [ProducesResponseType(typeof(AbstractResponse), 201)]
        public async Task<IActionResult> CreateUser([FromBody] EmployeeRequest request)
        {
            var userId = User.GetUserId();
            var response = await _employeeService.CreateEmployee(userId, request);
            return GetActionResult(response);
        }
    }
}
