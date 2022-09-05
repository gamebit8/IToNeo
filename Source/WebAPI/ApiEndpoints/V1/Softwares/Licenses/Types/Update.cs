using AutoMapper;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
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
    public class Update : UpdateBase<SoftwareLicenseType, UpdateSoftwareLicenseTypeRequestBody, UpdateSoftwareLicenseTypeResult>
    {
        public Update(IAsyncRepository<SoftwareLicenseType> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Software license type",
            Description = "Update Software license type",
            OperationId = "UpdateSoftwareLicenseType",
            Tags = new[] { "SoftwareLicenseTypes" })
        ]
        public override async Task<ActionResult<UpdateSoftwareLicenseTypeResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateSoftwareLicenseTypeRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
