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

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    [Route("api/v1/softwares/licenses")]
    [Authorize(Roles = "Administrator,Operator")]
    public class Create : CreateBase<SoftwareLicense, CreateSoftwareLicenseRequest, CreateSoftwareLicenseResult>
    {
        public Create(IAsyncRepository<SoftwareLicense> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Software License",
            Description = "Creates a new Software License",
            OperationId = "CreateSoftwareLicense",
            Tags = new[] { "SoftwareLicenses" })
        ]
        public override async Task<ActionResult<CreateSoftwareLicenseResult>> HandleAsync([FromBody] CreateSoftwareLicenseRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
