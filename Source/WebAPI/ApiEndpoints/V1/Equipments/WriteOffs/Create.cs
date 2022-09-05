using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.WriteOffs
{
    [Route("api/v1/equipments/writeoffs")]
    [Authorize(Roles = "Administrator,Operator")]
    public class Create : CreateBase<EquipmentWriteOff, CreateEquipmentWriteOffRequest, CreateEquipmentWriteOffResult>
    {
        public Create(IAsyncRepository<EquipmentWriteOff> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Equipment WriteOff",
            Description = "Creates a new Equipment WriteOff",
            OperationId = "CreateEquipmentWriteOff",
            Tags = new[] { "EquipmentWriteOffs" })
        ]
        public override async Task<ActionResult<CreateEquipmentWriteOffResult>> HandleAsync([FromBody] CreateEquipmentWriteOffRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
