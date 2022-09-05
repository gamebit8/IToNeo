using AutoMapper;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Developers
{
    [Route("api/v1/developers")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Delete : DeleteBase<SoftwareDeveloper, DeleteDeveloperRequest, DeleteDeveloperResult>
    {
        public Delete(IAsyncRepository<SoftwareDeveloper> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a delete Developer",
            Description = "Deletes a delete Developer",
            OperationId = "DeleteDeveloper",
            Tags = new[] { "Developers" })
        ]
        public override async Task<ActionResult<DeleteDeveloperResult>> HandleAsync([FromRoute] DeleteDeveloperRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
