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

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    [Route("api/v1/equipmentsSoftwareLicenses")]
    [Authorize(Roles = "Administrator,Operator")]
    public class Create : CreateBase<EquipmentSoftwareLicense, CreateEquipmentSoftwareLicenseRequest, CreateEquipmentSoftwareLicenseResult>
    {
        public Create(IAsyncRepository<EquipmentSoftwareLicense> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Equipment Software license relationship",
            Description = "Creates a new Equipment Software license relationship",
            OperationId = "CreateEquipmentSoftwareLicense",
            Tags = new[] { "EquipmentsSoftwareLicenses" })
        ]
        public override async Task<ActionResult<CreateEquipmentSoftwareLicenseResult>> HandleAsync([FromBody] CreateEquipmentSoftwareLicenseRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
