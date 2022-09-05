using Ardalis.ApiEndpoints;
using IToNeo.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.Authenticate
{
    [Route("api/v1/identities")]
    [AllowAnonymous]
    public class Authenticate : EndpointBaseAsync.WithRequest<AuthenticateRequest>.WithActionResult<AuthenticateResult>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenClaimsService _tokenClaimsService;

        public Authenticate(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ITokenClaimsService tokenClaimsService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenClaimsService = tokenClaimsService;
        }

        [Route("authenticate")]
        [AllowAnonymous]
        [HttpPost()]
        [SwaggerOperation(
            Summary = "Authenticate user",
            Description = "Authenticate user",
            OperationId = "Authenticate",
            Tags = new[] { "Identities" })
        ]
        public override async Task<ActionResult<AuthenticateResult>> HandleAsync(AuthenticateRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);

            if (result.Succeeded)
            {
                var token = await _tokenClaimsService.GetTokenAsync(request.Username);
                var user = await _userManager.FindByNameAsync(request.Username);
                var roles = await _userManager.GetRolesAsync(user);

                var response = new AuthenticateResult()
                {
                    Result = result.Succeeded,
                    IsLockedOut = result.IsLockedOut,
                    IsNotAllowed = result.IsNotAllowed,
                    RequiresTwoFactor = result.RequiresTwoFactor,
                    Roles = roles,
                    Username = request.Username,
                    Token = token
                };

                return Ok(response);
            }

            return BadRequest("Bad username or password");
        }
    }
}
