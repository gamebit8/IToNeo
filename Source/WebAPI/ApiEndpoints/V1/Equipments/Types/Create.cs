using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Types
{
    [Route("api/v1/equipments/types")]
    [Authorize(Roles = "Administrator")]
    public class Create : CreateBase<EquipmentType, CreateEquipmentTypeRequest, CreateEquipmentTypeResult>
    {
        public Create(IAsyncRepository<EquipmentType> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Equipment type",
            Description = "Creates a new Equipment type",
            OperationId = "CreateEquipmentType",
            Tags = new[] { "EquipmentTypes" })
        ]
        public override async Task<ActionResult<CreateEquipmentTypeResult>> HandleAsync([FromBody] CreateEquipmentTypeRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
