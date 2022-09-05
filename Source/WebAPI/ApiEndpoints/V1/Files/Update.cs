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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    [Route("api/v1/files")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Update : UpdateBase<FileEntity, UpdateFileRequestBody, UpdateFileResult>
    {
        public Update(IAsyncRepository<FileEntity> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update File",
            Description = "Update File",
            OperationId = "UpdateFile",
            Tags = new[] { "Files" })
        ]
        public override Task<ActionResult<UpdateFileResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateFileRequestBody> request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
