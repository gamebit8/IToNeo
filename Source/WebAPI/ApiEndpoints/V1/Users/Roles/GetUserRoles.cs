using Ardalis.ApiEndpoints;
using IToNeo.Infrastructure.Identity.Entities;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.UserRoles
{
    [Route("api/v1/users/roles")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetUserRoles : EndpointBaseAsync.WithRequest<GetUserRolesRequest>.WithActionResult<GetUserRolesResult>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<Controller> _logger;

        public GetUserRoles(ILogger<Controller> logger, RoleManager<ApplicationRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a User roles",
            Description = "Get a User roles",
            OperationId = "GetUserRoles",
            Tags = new[] { "UserRoles" })
        ]
        public override async Task<ActionResult<GetUserRolesResult>> HandleAsync([FromQuery] GetUserRolesRequest request, CancellationToken cancellationToken = default)
        {
            var roles = await _roleManager.Roles.Select(r => new GetUserRolesResult{Id = r.Id, Name = r.Name}).ToArrayAsync(cancellationToken);

            var response = new BaseWithHateoasResponse<IEnumerable<GetUserRolesResult>>
            {
                Data = roles,
                Link = default
            };

            return Ok(response);
        }
    }
}

