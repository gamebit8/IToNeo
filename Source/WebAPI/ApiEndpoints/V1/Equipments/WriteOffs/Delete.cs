using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
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
    public class Delete : DeleteBase<EquipmentWriteOff, DeleteEquipmentWriteOffRequest, DeleteEquipmentWriteOffResult>
    {
        public Delete(IAsyncRepository<EquipmentWriteOff> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a new Equipment WriteOff",
            Description = "Deletes a new Equipment WriteOff",
            OperationId = "DeleteEquipmentWriteOff",
            Tags = new[] { "EquipmentWriteOffs" })
        ]
        public override async Task<ActionResult<DeleteEquipmentWriteOffResult>> HandleAsync([FromRoute] DeleteEquipmentWriteOffRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
