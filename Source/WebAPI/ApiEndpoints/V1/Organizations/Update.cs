using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Organizations
{
    [Route("api/v1/organizations")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Update : UpdateBase<Organization, UpdateOrganizationRequestBody, UpdateOrganizationResult>
    {
        public Update(IAsyncRepository<Organization> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Organization",
            Description = "Update Organization",
            OperationId = "UpdateOrganization",
            Tags = new[] { "Organizations" })
        ]
        public override async Task<ActionResult<UpdateOrganizationResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateOrganizationRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
