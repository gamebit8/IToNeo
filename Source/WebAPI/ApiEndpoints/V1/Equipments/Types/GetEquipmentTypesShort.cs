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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Types
{
    [Route("api/v1/equipments/types/short")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentTypesShort : GetListBase<EquipmentType, GetEquipmentTypesShortRequest, GetEquipmentTypesShortResult>
    {
        public GetEquipmentTypesShort(
            IReadOnlyAsyncRepository<EquipmentType> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentTypesShortResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipment type short",
            Description = "Get a Equipment type short",
            OperationId = "GetEquipmentTypesShort",
            Tags = new[] { "EquipmentTypes" })
        ]
        public override async Task<ActionResult<GetEquipmentTypesShortResult>> HandleAsync([FromQuery] GetEquipmentTypesShortRequest request, CancellationToken cancellationToken)
        {
            var equipmentType = _mapper.Map<GetEquipmentTypesShortRequest, EquipmentType>(request);
            var spec = new EquipmentTypeWithSpecification(request.Offset, request.Limit, equipmentType, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
