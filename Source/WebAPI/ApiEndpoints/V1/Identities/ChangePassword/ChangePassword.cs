using Ardalis.ApiEndpoints;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ChangePassword
{
    [Route("api/v1/identities")]
    [AllowAnonymous]
    public class ChangePassword : EndpointBaseAsync.WithRequest<ChangePasswordRequest>.WithActionResult
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePassword(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("changePassword")]
        [AllowAnonymous]
        [HttpPut()]
        [SwaggerOperation(
            Summary = "Change password user",
            Description = "Change password user",
            OperationId = "ChangePassword",
            Tags = new[] { "Identities" })
        ]
        public override async Task<ActionResult> HandleAsync([FromBody] ChangePasswordRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                return BadRequest("User not found or wrong password");

            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            if (result.Succeeded)
                return Ok();

            return BadRequest("Invalid current password or new password does not meet requirements");
        }
    }
}
