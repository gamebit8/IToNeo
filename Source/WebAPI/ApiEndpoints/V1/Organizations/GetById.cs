using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
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
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<Organization, GetByIdOrganizationRequest, GetByIdOrganizationResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<Organization> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdOrganizationResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Organization by Id",
            Description = "Get a Organization by Id",
            OperationId = "GetByIdOrganization",
            Tags = new[] { "Organizations" })
        ]
        public override async Task<ActionResult<GetByIdOrganizationResult>> HandleAsync([FromRoute] GetByIdOrganizationRequest request, CancellationToken cancellationToken)
        {
            var specification = new OrganizationWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
