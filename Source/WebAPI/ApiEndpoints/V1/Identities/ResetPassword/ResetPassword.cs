using Ardalis.ApiEndpoints;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ResetPassword
{
    [Route("api/v1/identities")]
    [AllowAnonymous]
    public class ResetPassword : EndpointBaseAsync.WithRequest<ResetPasswordRequest>.WithActionResult<ResetPasswordResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPassword(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("resetPassword")]
        [AllowAnonymous]
        [HttpPost()]
        [SwaggerOperation(
            Summary = "Reset password user",
            Description = "Reset password user",
            OperationId = "ResetPassword",
            Tags = new[] { "Identities" })
        ]
        public override async Task<ActionResult<ResetPasswordResult>> HandleAsync([FromBody]ResetPasswordRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) return BadRequest("User is not found");

            if (!user.EmailConfirmed) return BadRequest("Email not confirmed");

            var passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passResetUrl = Url.Action("Handle", "ChangePasswordAfterReset", new { email = user.Email, token = HttpUtility.UrlEncode(passResetToken) });

            var response = new ResetPasswordResult(passResetUrl);
            return Ok(response);
        }
    }
}
