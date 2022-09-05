using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    [Route("api/v1/equipments")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Delete : DeleteBase<Equipment, DeleteEquipmentRequest, DeleteEquipmentResult>
    {
        public Delete(IAsyncRepository<Equipment> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a new Equipment",
            Description = "Deletes a new Equipment",
            OperationId = "DeleteEquipment",
            Tags = new[] { "Equipments" })
        ]
        public override async Task<ActionResult<DeleteEquipmentResult>> HandleAsync([FromRoute] DeleteEquipmentRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
