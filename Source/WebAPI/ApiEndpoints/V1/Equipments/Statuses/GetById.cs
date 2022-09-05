using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
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
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Statuses
{
    [Route("api/v1/equipments/statuses")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<EquipmentStatus, GetByIdEquipmentStatusRequest, GetByIdEquipmentStatusResult>
    {
        public GetById(IReadOnlyAsyncRepository<EquipmentStatus> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, ICacheService<BaseWithHateoasResponse<GetByIdEquipmentStatusResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Equipment status by Id",
            Description = "Get a Equipment status by Id",
            OperationId = "GetByIdEquipmentStatus",
            Tags = new[] { "EquipmentStatuses" })
        ]
        public override async Task<ActionResult<GetByIdEquipmentStatusResult>> HandleAsync([FromRoute] GetByIdEquipmentStatusRequest request, CancellationToken cancellationToken)
        {
            var specification = new EquipmentStatusWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
