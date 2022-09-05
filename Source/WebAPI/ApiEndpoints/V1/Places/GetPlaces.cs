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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    [Route("api/v1/places")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetPlaces : GetListBase<Place, GetPlacesRequest, GetPlacesResult>
    {
        public GetPlaces(
            IReadOnlyAsyncRepository<Place> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetPlacesResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Places",
            Description = "Get a Places",
            OperationId = "GetPlaces",
            Tags = new[] { "Places" })
        ]
        public override async Task<ActionResult<GetPlacesResult>> HandleAsync([FromQuery] GetPlacesRequest request, CancellationToken cancellationToken)
        {
            var place = _mapper.Map<GetPlacesRequest, Place>(request);
            var spec = new PlaceWithSpecification(request.Offset, request.Limit, place, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
