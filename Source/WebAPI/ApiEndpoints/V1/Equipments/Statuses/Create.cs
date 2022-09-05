using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Statuses
{
    [Route("api/v1/equipments/statuses")]
    [Authorize(Roles = "Administrator")]
    public class Create : CreateBase<EquipmentStatus, CreateEquipmentStatusRequest, CreateEquipmentStatusResult>
    {
        public Create(IAsyncRepository<EquipmentStatus> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Equipment status",
            Description = "Creates a new Equipment status",
            OperationId = "CreateEquipmentStatus",
            Tags = new[] { "EquipmentStatuses" })
        ]
        public override async Task<ActionResult<CreateEquipmentStatusResult>> HandleAsync([FromBody] CreateEquipmentStatusRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
