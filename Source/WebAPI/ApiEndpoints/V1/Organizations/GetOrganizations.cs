using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Organizations
{
    [Route("api/v1/organizations")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetOrganizations : GetListBase<Organization, GetOrganizationsRequest, GetOrganizationsResult>
    {
        public GetOrganizations(
            IReadOnlyAsyncRepository<Organization> repositoryAsync, 
            IMapper mapper, ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetOrganizationsResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Organizations",
            Description = "Get a Organizations",
            OperationId = "GetOrganizations",
            Tags = new[] { "Organizations" })
        ]
        public override async Task<ActionResult<GetOrganizationsResult>> HandleAsync([FromQuery] GetOrganizationsRequest request, CancellationToken cancellationToken)
        {
            var organizaton = _mapper.Map<GetOrganizationsRequest, Organization>(request);
            var spec = new OrganizationWithSpecification(request.Offset, request.Limit, organizaton, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
