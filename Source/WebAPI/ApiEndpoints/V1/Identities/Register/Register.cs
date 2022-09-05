using Ardalis.ApiEndpoints;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.Infrastructure.Identity.Entities;
using IToNeo.WebAPI.IntegrationEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.Register
{
    [Route("api/v1/identities")]
    [AllowAnonymous]
    public class Register : EndpointBaseAsync.WithRequest<RegisterRequest>.WithActionResult<RegisterResult>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEventBus _eventBus;

        public Register(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IEventBus eventBus)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _eventBus = eventBus;
        }

        [Route("register")]
        [AllowAnonymous]
        [HttpPost()]
        [SwaggerOperation(
            Summary = "Register user",
            Description = "Register user",
            OperationId = "Register",
            Tags = new[] { "Identities" })
        ]
        public override async Task<ActionResult<RegisterResult>> HandleAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var user = new ApplicationUser() { UserName = request.username, Email = request.Email };
            var reuslt = await _userManager.CreateAsync(user, request.Password);
            if (reuslt.Succeeded)
            {
                var emailConfCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var emailСonfirmationUrl = Url.Action("Handle", "ConfirmEmail", new { email = user.Email, token = HttpUtility.UrlEncode(emailConfCode) }, Request.Scheme);

                NewEvent(request.username, request.Email, emailСonfirmationUrl);

                var response = new RegisterResult(emailСonfirmationUrl);
                return Ok(response);
            }

            return BadRequest();
        }

        private void NewEvent(string userName, string email, string confirmEmailUrl)
        {
            var ev = new NewUserRegistredIntegrationEvent(userName, email, confirmEmailUrl);
            _eventBus.Publish(ev);
        }
    }
}
