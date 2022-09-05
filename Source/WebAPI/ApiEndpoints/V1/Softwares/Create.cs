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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Softwares
{
    [Route("api/v1/softwares")]
    [Authorize(Roles = "Administrator,Operator")]
    public class Create : CreateBase<Software, CreateSoftwareRequest, CreateSoftwareResult>
    {
        public Create(IAsyncRepository<Software> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Software",
            Description = "Creates a new Software",
            OperationId = "CreateSoftware",
            Tags = new[] { "Softwares" })
        ]
        public override async Task<ActionResult<CreateSoftwareResult>> HandleAsync([FromBody] CreateSoftwareRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
