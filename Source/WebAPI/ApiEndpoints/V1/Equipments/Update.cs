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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    [Route("api/v1/equipments")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Update : UpdateBase<Equipment, UpdateEquipmentRequestBody, UpdateEquipmentResult>
    {
        public Update(IAsyncRepository<Equipment> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Equipment",
            Description = "Update Equipment",
            OperationId = "UpdateEquipment",
            Tags = new[] { "Equipments" })
        ]
        public override async Task<ActionResult<UpdateEquipmentResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateEquipmentRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
