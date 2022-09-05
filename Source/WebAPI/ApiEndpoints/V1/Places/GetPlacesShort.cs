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
    [Route("api/v1/places/short")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetPlacesShort : GetListBase<Place, GetPlacesShortRequest, GetPlacesShortResult>
    {
        public GetPlacesShort(
            IReadOnlyAsyncRepository<Place> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetPlacesShortResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Places short",
            Description = "Get a Places short",
            OperationId = "GetPlacesShort",
            Tags = new[] { "Places" })
        ]
        public override async Task<ActionResult<GetPlacesShortResult>> HandleAsync([FromQuery] GetPlacesShortRequest request, CancellationToken cancellationToken)
        {
            var places = _mapper.Map<GetPlacesShortRequest, Place>(request);
            var spec = new PlaceWithSpecification(request.Offset, request.Limit, places, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
