using AutoMapper;
using IToNeo.ApplicationCore.Entities;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Disposals
{
    [Route("api/v1/equipments/disposals")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Delete : DeleteBase<EquipmentDisposal, DeleteEquipmentDisposalRequest, DeleteEquipmentDisposalResult>
    {
        public Delete(IAsyncRepository<EquipmentDisposal> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a new Equipment disposal",
            Description = "Deletes a new Equipment disposal",
            OperationId = "DeleteEquipmentDisposal",
            Tags = new[] { "EquipmentDisposals" })
        ]
        public override async Task<ActionResult<DeleteEquipmentDisposalResult>> HandleAsync([FromRoute] DeleteEquipmentDisposalRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
