using AutoMapper;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Developers
{
    [Route("api/v1/developers")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<SoftwareDeveloper, GetByIdDeveloperRequest, GetByIdDeveloperResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<SoftwareDeveloper> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, ICacheService<BaseWithHateoasResponse<GetByIdDeveloperResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Developer by Id",
            Description = "Get a Developer by Id",
            OperationId = "GetByIdDeveloper",
            Tags = new[] { "Developers" })
        ]
        public override async Task<ActionResult<GetByIdDeveloperResult>> HandleAsync([FromRoute] GetByIdDeveloperRequest request, CancellationToken cancellationToken)
        {
            var specification = new SoftwareDeveloperWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
