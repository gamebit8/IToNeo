using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
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
    public class Delete : DeleteBase<EquipmentStatus, DeleteEquipmentStatusRequest, DeleteEquipmentStatusResult>
    {
        public Delete(IAsyncRepository<EquipmentStatus> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a new Equipment status",
            Description = "Deletes a new Equipment status",
            OperationId = "DeleteEquipmentStatus",
            Tags = new[] { "EquipmentStatuses" })
        ]
        public override async Task<ActionResult<DeleteEquipmentStatusResult>> HandleAsync([FromRoute] DeleteEquipmentStatusRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
