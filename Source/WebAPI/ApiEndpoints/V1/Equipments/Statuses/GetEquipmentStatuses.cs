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
    [Route("api/v1/equipments/statuses")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentStatuses : GetListBase<EquipmentStatus, GetEquipmentStatusesRequest, GetEquipmentStatusesResult>
    {
        public GetEquipmentStatuses(
            IReadOnlyAsyncRepository<EquipmentStatus> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentStatusesResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipment statuses",
            Description = "Get a Equipment statuses",
            OperationId = "GetEquipment statuses",
            Tags = new[] { "EquipmentStatuses" })
        ]
        public override async Task<ActionResult<GetEquipmentStatusesResult>> HandleAsync([FromQuery] GetEquipmentStatusesRequest request, CancellationToken cancellationToken)
        {
            var equipmentStatus = _mapper.Map<GetEquipmentStatusesRequest, EquipmentStatus>(request);
            var spec = new EquipmentStatusWithSpecification(request.Offset, request.Limit, equipmentStatus, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
