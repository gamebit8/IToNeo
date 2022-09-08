using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Helpers;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.Infrastructure.Data;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Users
{
    [Route("api/v1/users")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetUsers : EndpointBaseAsync.WithRequest<GetUsersRequest>.WithActionResult<GetUsersResult>
    {
        private readonly ILogger<Controller> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetUsers(ILogger<Controller> logger, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Users",
            Description = "Get a Users",
            OperationId = "GetUsers",
            Tags = new[] { "Users" })
        ]
        public override async Task<ActionResult<GetUsersResult>> HandleAsync([FromQuery]GetUsersRequest request, CancellationToken cancellationToken = default)
        {
            var spec = new UserWithSpecification(request.Offset, request.Limit, request, request.SortBy, request.SortDescending);
            var users = await SpecificationEvaluator<ApplicationUser>.GetQuery(_userManager.Users.AsQueryable(), spec).ToArrayAsync(cancellationToken: cancellationToken);
           
            var usersResponse = _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<GetUsersResult>>(users);
            var response = new BaseListWithHateoasResponse<GetUsersResult>
            {
                Data = usersResponse,
                Link = default
            };

            return Ok(response);
        }
    }
}
