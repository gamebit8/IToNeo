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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    [Route("api/v1/places")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<Place, GetByIdPlaceRequest, GetByIdPlaceResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<Place> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdPlaceResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Place by Id",
            Description = "Get a Place by Id",
            OperationId = "GetByIdPlace",
            Tags = new[] { "Places" })
        ]
        public override async Task<ActionResult<GetByIdPlaceResult>> HandleAsync([FromRoute] GetByIdPlaceRequest request, CancellationToken cancellationToken)
        {
            var specification = new PlaceWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
