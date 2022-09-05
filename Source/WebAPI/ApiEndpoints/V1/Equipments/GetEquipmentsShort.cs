using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    [Route("api/v1/equipments/short")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentsShort : GetListBase<Equipment, GetEquipmentsShortRequest, GetEquipmentsShortResult>
    {
        public GetEquipmentsShort(
            IReadOnlyAsyncRepository<Equipment> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentsShortResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipments short",
            Description = "Get a Equipments short",
            OperationId = "GetEquipmentsShort",
            Tags = new[] { "Equipments" })
        ]
        public override async Task<ActionResult<GetEquipmentsShortResult>> HandleAsync([FromQuery] GetEquipmentsShortRequest request, CancellationToken cancellationToken)
        {
            var equipment = _mapper.Map<GetEquipmentsShortRequest, Equipment>(request);
            var spec = new EquipmentWithSpecification(request.Offset, request.Limit, equipment, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
