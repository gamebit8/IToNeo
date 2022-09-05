using Ardalis.ApiEndpoints;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Users
{
    [Route("api/v1/users")]
    [Authorize(Roles = "Administrator")]
    public class Delete : EndpointBaseAsync.WithRequest<DeleteUserRequest>.WithActionResult<DeleteUserResult>
    {
        private readonly ILogger<Controller> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public Delete(
            ILogger<Controller> logger,
            UserManager<ApplicationUser> userManager
        )
        {
            _logger = logger;
            _userManager = userManager;
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a User",
            Description = "Deletes a User",
            OperationId = "DeleteUser",
            Tags = new[] { "Users" })
        ]
        public override async Task<ActionResult<DeleteUserResult>> HandleAsync([FromRoute] DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null) return NotFound("User not found");

            await _userManager.DeleteAsync(user);
            return StatusCode(204);
        }
    }
}
