using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
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
    public class Update : UpdateBase<EquipmentDisposal, UpdateEquipmentDisposalRequestBody, UpdateEquipmentDisposalResult>
    {
        public Update(IAsyncRepository<EquipmentDisposal> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Equipment disposal",
            Description = "Update Equipment disposal",
            OperationId = "UpdateEquipmentDisposal",
            Tags = new[] { "EquipmentDisposals" })
        ]
        public override async Task<ActionResult<UpdateEquipmentDisposalResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateEquipmentDisposalRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
