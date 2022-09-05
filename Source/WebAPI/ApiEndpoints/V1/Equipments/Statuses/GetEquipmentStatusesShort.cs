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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Statuses
{
    [Route("api/v1/equipments/statuses/short")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentStatusesShort : GetListBase<EquipmentStatus, GetEquipmentStatusesShortRequest, GetEquipmentStatusesShortResult>
    {
        public GetEquipmentStatusesShort(
            IReadOnlyAsyncRepository<EquipmentStatus> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentStatusesShortResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipment statuses short",
            Description = "Get a Equipment statuses short",
            OperationId = "GetEquipmentStatusesShort",
            Tags = new[] { "EquipmentStatuses" })
        ]
        public override async Task<ActionResult<GetEquipmentStatusesShortResult>> HandleAsync([FromQuery] GetEquipmentStatusesShortRequest request, CancellationToken cancellationToken)
        {
            var equipmentStatus = _mapper.Map<GetEquipmentStatusesShortRequest, EquipmentStatus>(request);
            var spec = new EquipmentStatusWithSpecification(request.Offset, request.Limit, equipmentStatus, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
