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
    [Route("api/v1/organizations/short")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetOrganizationsShort : GetListBase<Organization, GetOrganizationsShortRequest, GetOrganizationsShortResult>
    {
        public GetOrganizationsShort(
            IReadOnlyAsyncRepository<Organization> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetOrganizationsShortResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Organization short",
            Description = "Get a Organization short",
            OperationId = "GetOrganizationsShort",
            Tags = new[] { "Organizations" })
        ]
        public override async Task<ActionResult<GetOrganizationsShortResult>> HandleAsync([FromQuery] GetOrganizationsShortRequest request, CancellationToken cancellationToken)
        {
            var organization = _mapper.Map<GetOrganizationsShortRequest, Organization>(request);
            var spec = new OrganizationWithSpecification(request.Offset, request.Limit, organization, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
