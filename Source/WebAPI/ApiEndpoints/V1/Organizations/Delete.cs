using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
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
    public class Delete : DeleteBase<Organization, DeleteOrganizationRequest, DeleteOrganizationResult>
    {
        public Delete(IAsyncRepository<Organization> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a Organization",
            Description = "Deletes a Organization",
            OperationId = "DeleteOrganization",
            Tags = new[] { "Organizations" })
        ]
        public override async Task<ActionResult<DeleteOrganizationResult>> HandleAsync([FromRoute] DeleteOrganizationRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
