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
    [Route("api/v1/equipments/types")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentTypes : GetListBase<EquipmentType, GetEquipmentTypesRequest, GetEquipmentTypesResult>
    {
        public GetEquipmentTypes(
            IReadOnlyAsyncRepository<EquipmentType> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentTypesResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipment types",
            Description = "Get a Equipment types",
            OperationId = "GetEquipmentTypes",
            Tags = new[] { "EquipmentTypes" })
        ]
        public override async Task<ActionResult<GetEquipmentTypesResult>> HandleAsync([FromQuery] GetEquipmentTypesRequest request, CancellationToken cancellationToken)
        {

            var equipmentType = _mapper.Map<GetEquipmentTypesRequest, EquipmentType>(request);
            var spec = new EquipmentTypeWithSpecification(request.Offset, request.Limit, equipmentType, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
