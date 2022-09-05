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

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenseTypes
{
    [Route("api/v1/softwares/licenses/types")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Delete : DeleteBase<SoftwareLicenseType, DeleteSoftwareLicenseTypeRequest, DeleteSoftwareLicenseTypeResult>
    {
        public Delete(IAsyncRepository<SoftwareLicenseType> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a Software license type",
            Description = "Deletes a Software license type",
            OperationId = "DeleteSoftwareLicenseType",
            Tags = new[] { "SoftwareLicenseTypes" })
        ]
        public override async Task<ActionResult<DeleteSoftwareLicenseTypeResult>> HandleAsync([FromRoute] DeleteSoftwareLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
