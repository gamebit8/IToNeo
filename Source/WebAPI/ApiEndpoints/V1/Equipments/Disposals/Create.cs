using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
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
    [Authorize(Roles = "Administrator,Operator")]
    public class Create : CreateBase<EquipmentDisposal, CreateEquipmentDisposalRequest, CreateEquipmentDisposalResult>
    {
        public Create(IAsyncRepository<EquipmentDisposal> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Equipment disposal",
            Description = "Creates a new Equipment disposal",
            OperationId = "CreateEquipmentDisposal",
            Tags = new[] { "EquipmentDisposals" })
        ]
        public override async Task<ActionResult<CreateEquipmentDisposalResult>> HandleAsync([FromBody] CreateEquipmentDisposalRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
