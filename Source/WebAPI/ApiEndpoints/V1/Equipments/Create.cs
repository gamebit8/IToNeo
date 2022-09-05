using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using System.Threading;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    [Route("api/v1/equipments")]
    [Authorize(Roles = "Administrator,Operator")]
    public class Create : CreateBase<Equipment, CreateEquipmentRequest, CreateEquipmentResult>
    {
        public Create(IAsyncRepository<Equipment> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Equipment",
            Description = "Creates a new Equipment",
            OperationId = "CreateEquipment",
            Tags = new[] { "Equipments" })
        ]
        public override async Task<ActionResult<CreateEquipmentResult>> HandleAsync([FromBody] CreateEquipmentRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
