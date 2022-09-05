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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.WriteOffs
{
    [Route("api/v1/equipments/writeoffs")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Update : UpdateBase<EquipmentWriteOff, UpdateEquipmentWriteOffRequestBody, UpdateEquipmentWriteOffResult>
    {
        public Update(IAsyncRepository<EquipmentWriteOff> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Equipment WriteOff",
            Description = "Update Equipment WriteOff",
            OperationId = "UpdateEquipmentWriteOff",
            Tags = new[] { "EquipmentWriteOffs" })
        ]
        public override async Task<ActionResult<UpdateEquipmentWriteOffResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateEquipmentWriteOffRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
