using Ardalis.ApiEndpoints;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Users
{
    [Route("api/v1/users")]
    [Authorize(Roles = "Administrator")]
    public class Update : EndpointBaseAsync.WithRequest<UpdateUserRequest<UpdateUserRequestBody>>.WithActionResult<UpdateUserResult>
    {
        private readonly ILogger<Controller> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAsyncRepository<Employee> _asyncRepository;

        public Update(ILogger<Controller> logger, UserManager<ApplicationUser> userManager, IAsyncRepository<Employee> asyncRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _asyncRepository = asyncRepository;
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Usres",
            Description = "Update User",
            OperationId = "UpdateUser",
            Tags = new[] { "Users" })
        ]
        public override async Task<ActionResult<UpdateUserResult>> HandleAsync([FromQuery] UpdateUserRequest<UpdateUserRequestBody> request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            var roles = request.Entity?.Roles;
            var employeeId = request.Entity?.EmployeeId;

            if (user is null) return NotFound("User not found");

            await UpdateUserAsync(user, request.Entity);
            await UpdateUserRolesAsync(user, roles);
            await UpdateEmployeeAsync(user, employeeId);

            return Ok();

        }

        private async Task<bool> UpdateUserAsync(ApplicationUser appUser, UpdateUserRequestBody userRequest)
        {
            appUser.UserName = userRequest.UserName;
            appUser.Email = userRequest.Email;
            appUser.PhoneNumber = userRequest.PhoneNumber;
            appUser.EmployeeId = userRequest.EmployeeId;

            var result = await _userManager.UpdateAsync(appUser);

            return (result != null);
        }

        private async Task<bool> UpdateUserRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            if (roles != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var addedRoles = roles.Except(userRoles);
                var deletedRoles = userRoles.Except(roles);

                var addReuslt = await _userManager.AddToRolesAsync(user, addedRoles);
                var deleteResult = await _userManager.RemoveFromRolesAsync(user, deletedRoles);

                return (addReuslt != null & deleteResult != null);
            }

            return false;
        }

        private async Task<bool> UpdateEmployeeAsync(ApplicationUser user, string employeeId)
        {
            if (user != null && employeeId != null)
            {
                var employee = await _asyncRepository.GetByIdAsync(employeeId);
                employee.Username = user.UserName;
                await _asyncRepository.UpdateAsync(employee);
                return true;
            }

            return false;
        }
    }
}
