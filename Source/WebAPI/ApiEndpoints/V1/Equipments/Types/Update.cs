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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Types
{
    [Route("api/v1/equipments/types")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Update : UpdateBase<EquipmentType, UpdateEquipmentTypeRequestBody, UpdateEquipmentTypeResult>
    {
        public Update(IAsyncRepository<EquipmentType> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Equipment type",
            Description = "Update Equipment type",
            OperationId = "UpdateEquipmentType",
            Tags = new[] { "EquipmentTypes" })
        ]
        public override async Task<ActionResult<UpdateEquipmentTypeResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateEquipmentTypeRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
