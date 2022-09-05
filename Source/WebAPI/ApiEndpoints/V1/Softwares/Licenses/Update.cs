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

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    [Route("api/v1/softwares/licenses")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Update : UpdateBase<SoftwareLicense, UpdateSoftwareLicenseRequestBody, UpdateSoftwareLicenseResult>
    {
        public Update(IAsyncRepository<SoftwareLicense> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Software license",
            Description = "Update Software license",
            OperationId = "Update Software license",
            Tags = new[] { "SoftwareLicenses" })
        ]
        public override async Task<ActionResult<UpdateSoftwareLicenseResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateSoftwareLicenseRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
