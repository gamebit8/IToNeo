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

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    [Route("api/v1/softwares/licenses")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Delete : DeleteBase<SoftwareLicense, DeleteSoftwareLicenseRequest, DeleteSoftwareLicenseResult>
    {
        public Delete(IAsyncRepository<SoftwareLicense> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a Software License",
            Description = "Deletes a Software License",
            OperationId = "DeleteSoftwareLicense",
            Tags = new[] { "SoftwareLicenses" })
        ]
        public override async Task<ActionResult<DeleteSoftwareLicenseResult>> HandleAsync([FromRoute] DeleteSoftwareLicenseRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
