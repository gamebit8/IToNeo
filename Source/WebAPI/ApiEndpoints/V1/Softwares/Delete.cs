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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Softwares
{
    [Route("api/v1/softwares")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Delete : DeleteBase<Software, DeleteSoftwareRequest, DeleteSoftwareResult>
    {
        public Delete(IAsyncRepository<Software> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a Software",
            Description = "Deletes a Software",
            OperationId = "DeleteSoftware",
            Tags = new[] { "Softwares" })
        ]
        public override async Task<ActionResult<DeleteSoftwareResult>> HandleAsync([FromRoute] DeleteSoftwareRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
