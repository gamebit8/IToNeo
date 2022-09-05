using Ardalis.ApiEndpoints;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ConfirmEmail
{
    [Route("api/v1/identities")]
    [AllowAnonymous]
    public class ConfirmEmail : EndpointBaseAsync.WithRequest<ConfirmEmailRequest>.WithActionResult
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmail(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("confirmEmail")]
        [AllowAnonymous]
        [HttpGet()]
        [SwaggerOperation(
            Summary = "Confirm email",
            Description = "Confirm email",
            OperationId = "ConfirmEmail",
            Tags = new[] { "Identities" })
        ]
        public override async Task<ActionResult> HandleAsync([FromQuery]ConfirmEmailRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) return BadRequest("Wrong query");

            var result = await _userManager.ConfirmEmailAsync(user, HttpUtility.UrlDecode(request.Token));
            if (result.Succeeded) return Ok();

            return BadRequest("Wrong query");
        }
    }
}
