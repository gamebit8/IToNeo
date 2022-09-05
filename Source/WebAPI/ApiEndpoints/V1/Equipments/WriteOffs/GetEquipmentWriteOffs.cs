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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.WriteOffs
{
    [Route("api/v1/equipments/writeoffs")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentWriteOffs : GetListBase<EquipmentWriteOff, GetEquipmentWriteOffsRequest, GetEquipmentWriteOffsResult>
    {
        public GetEquipmentWriteOffs(
            IReadOnlyAsyncRepository<EquipmentWriteOff> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentWriteOffsResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipments WriteOffs",
            Description = "Get a Equipments WriteOffs",
            OperationId = "GetEquipmentWriteOffs",
            Tags = new[] { "EquipmentWriteOffs" })
        ]
        public override async Task<ActionResult<GetEquipmentWriteOffsResult>> HandleAsync([FromQuery] GetEquipmentWriteOffsRequest request, CancellationToken cancellationToken)
        {
            var writeOff = _mapper.Map<GetEquipmentWriteOffsRequest, EquipmentWriteOff>(request);

            var spec = new WriteOffWithSpecification(request.Offset, request.Limit, writeOff, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
