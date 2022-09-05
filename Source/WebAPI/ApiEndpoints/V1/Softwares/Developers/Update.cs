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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Developers
{
    [Route("api/v1/developers")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Update : UpdateBase<SoftwareDeveloper, UpdateDeveloperRequestBody, UpdateDeveloperResult>
    {
        public Update(IAsyncRepository<SoftwareDeveloper> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Developer",
            Description = "Update Developer",
            OperationId = "UpdateDeveloper",
            Tags = new[] { "Developers" })
        ]
        public override async Task<ActionResult<UpdateDeveloperResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateDeveloperRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
