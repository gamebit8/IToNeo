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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Types
{
    [Route("api/v1/equipments/types")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Delete : DeleteBase<EquipmentType, DeleteEquipmentTypeRequest, DeleteEquipmentTypeResult>
    {
        public Delete(IAsyncRepository<EquipmentType> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a new Equipment type",
            Description = "Deletes a new Equipment type",
            OperationId = "DeleteEquipmentType",
            Tags = new[] { "EquipmentTypes" })
        ]
        public override async Task<ActionResult<DeleteEquipmentTypeResult>> HandleAsync([FromRoute] DeleteEquipmentTypeRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
