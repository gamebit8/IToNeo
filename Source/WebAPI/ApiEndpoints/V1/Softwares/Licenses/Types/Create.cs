using AutoMapper;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenseTypes
{
    [Route("api/v1/softwares/license/types")]
    [Authorize(Roles = "Administrator")]
    public class Create : CreateBase<SoftwareLicenseType, CreateSoftwareLicenseTypeRequest, CreateSoftwareLicenseTypeResult>
    {
        public Create(IAsyncRepository<SoftwareLicenseType> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Software license type",
            Description = "Creates a new Software license type",
            OperationId = "CreateSoftwareLicenseType",
            Tags = new[] { "SoftwareLicenseTypes" })
        ]
        public override async Task<ActionResult<CreateSoftwareLicenseTypeResult>> HandleAsync([FromBody] CreateSoftwareLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
