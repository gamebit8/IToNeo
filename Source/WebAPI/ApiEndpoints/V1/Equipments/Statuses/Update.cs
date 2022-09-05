using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
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
    [Authorize(Roles = "Administrator")]
    public class Update : UpdateBase<EquipmentStatus, UpdateEquipmentStatusRequestBody, UpdateEquipmentStatusResult>
    {
        public Update(IAsyncRepository<EquipmentStatus> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Equipment status",
            Description = "Update Equipment status",
            OperationId = "UpdateEquipmentStatus",
            Tags = new[] { "EquipmentStatuses" })
        ]
        public override async Task<ActionResult<UpdateEquipmentStatusResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateEquipmentStatusRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
