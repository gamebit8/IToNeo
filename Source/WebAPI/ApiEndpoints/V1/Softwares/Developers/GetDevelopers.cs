using AutoMapper;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Developers
{
    [Route("api/v1/developers")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetDevelopers : GetListBase<SoftwareDeveloper, GetDevelopersRequest, GetDevelopersResult>
    {
        public GetDevelopers(
            IReadOnlyAsyncRepository<SoftwareDeveloper> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetDevelopersResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Developers",
            Description = "Get a Developers",
            OperationId = "GetDevelopers",
            Tags = new[] { "Developers" })
        ]
        public override async Task<ActionResult<GetDevelopersResult>> HandleAsync([FromQuery] GetDevelopersRequest request, CancellationToken cancellationToken)
        {
            var developer = _mapper.Map<GetDevelopersRequest, SoftwareDeveloper>(request);
            var spec = new SoftwareDeveloperWithSpecification(request.Offset, request.Limit, developer, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
