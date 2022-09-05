using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.Infrastructure.Identity.Entities;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Users
{
    [Route("api/v1/users")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdUserRequest>.WithActionResult<GetByIdUserResult>
    {
        private readonly ILogger<Controller> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetById(ILogger<Controller> logger, UserManager<ApplicationUser> userManager,IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a User by Id",
            Description = "Get a User by Id",
            OperationId = "GetByIdUser",
            Tags = new[] { "Users" })
        ]
        public override async Task<ActionResult<GetByIdUserResult>> HandleAsync([FromRoute]GetByIdUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users.Where(u => u.Id == request.Id).Include(u => u.Roles).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            var userResponse = _mapper.Map<ApplicationUser, GetByIdUserResult>(user);

            var response = new BaseWithHateoasResponse<GetByIdUserResult>
            {
                Data = userResponse,
                Link = default
            };

            return Ok(response);
        }
    }
}
