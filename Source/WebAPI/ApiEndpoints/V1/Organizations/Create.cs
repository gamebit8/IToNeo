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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Organizations
{
    [Route("api/v1/organizations")]
    [Authorize(Roles = "Administrator")]
    public class Create : CreateBase<Organization, CreateOrganizationRequest, CreateOrganizationResult>
    {
        public Create(IAsyncRepository<Organization> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Organization",
            Description = "Creates a new Organization",
            OperationId = "CreateOrganization",
            Tags = new[] { "Organizations" })
        ]
        public override async Task<ActionResult<CreateOrganizationResult>> HandleAsync([FromBody] CreateOrganizationRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
