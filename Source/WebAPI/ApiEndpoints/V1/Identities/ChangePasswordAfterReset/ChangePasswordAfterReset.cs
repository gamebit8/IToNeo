using Ardalis.ApiEndpoints;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using IToNeo.WebAPI.ApiEndpoints.V1.Identities;
using Swashbuckle.AspNetCore.Annotations;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ChangePasswordAfterReset
{
    [Route("api/v1/identities")]
    public class ChangePasswordAfterReset : EndpointBaseAsync.WithRequest<ChangePasswordAfterResetRequest>.WithActionResult
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePasswordAfterReset(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("changePasswordAfterReset")]
        [AllowAnonymous]
        [HttpPost()]
        [SwaggerOperation(
            Summary = "Change password after reset",
            Description = "Change password after reset",
            OperationId = "ChangePasswordAfterReset",
            Tags = new[] { "Identities" })
        ]
        public override async Task<ActionResult> HandleAsync([FromQuery] ChangePasswordAfterResetRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) return BadRequest("User is not found");

            if (!user.EmailConfirmed) return BadRequest("Email not confirmed");

            var reuslt = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(request.Token), request.NewPassword);
            if (reuslt.Succeeded) return Ok();

            return BadRequest();
        }
    }
}
