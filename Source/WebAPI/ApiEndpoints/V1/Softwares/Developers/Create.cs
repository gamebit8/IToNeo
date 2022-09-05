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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Developers
{
    [Route("api/v1/developers")]
    [Authorize(Roles = "Administrator")]
    public class Create : CreateBase<SoftwareDeveloper, CreateDeveloperRequest, CreateDeveloperResult>
    {
        public Create(IAsyncRepository<SoftwareDeveloper> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Developer",
            Description = "Creates a new Developer",
            OperationId = "CreateDeveloper",
            Tags = new[] { "Developers" })
        ]
        public override async Task<ActionResult<CreateDeveloperResult>> HandleAsync([FromBody] CreateDeveloperRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
