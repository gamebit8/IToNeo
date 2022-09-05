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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Softwares
{
    [Route("api/v1/softwares")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Update : UpdateBase<Software, UpdateSoftwareRequestBody, UpdateSoftwareResult>
    {
        public Update(IAsyncRepository<Software> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Software",
            Description = "Update Software",
            OperationId = "UpdateSoftware",
            Tags = new[] { "Softwares" })
        ]
        public override async Task<ActionResult<UpdateSoftwareResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateSoftwareRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
