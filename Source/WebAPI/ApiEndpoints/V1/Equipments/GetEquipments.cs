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
    [Authorize(Roles = "Administrator,Operator")]
    [Route("api/v1/equipments")]
    [ApiController]
    public class GetEquipments : GetListBase<Equipment, GetEquipmentsRequest, GetEquipmentsResult>
    {
        public GetEquipments(
            IReadOnlyAsyncRepository<Equipment> repositoryAsync,
            IMapper mapper, ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentsResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }
        
        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipments",
            Description = "Get a Equipments",
            OperationId = "GetEquipments",
            Tags = new[] { "Equipments" })
        ]
        public override async Task<ActionResult<GetEquipmentsResult>> HandleAsync([FromQuery] GetEquipmentsRequest request, CancellationToken cancellationToken)
        {
            var equipment = _mapper.Map<GetEquipmentsRequest, Equipment>(request);
            var spec = new EquipmentWithSpecification(
                request.Offset,
                request.Limit, 
                equipment, 
                request.SortBy, 
                request.SortDescending,
                request.DateOfCreationFrom,
                request.DateOfCreationTo,
                request.DateOfInstallationFrom,
                request.DateOfInstallationTo);

            return await GetListAsync(spec, request);
        }
    }
}
