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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    [Route("api/v1/files")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Delete : DeleteBase<FileEntity, DeleteFileRequest, DeleteFileResult>
    {
        public Delete(IAsyncRepository<FileEntity> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a File",
            Description = "Deletes a File",
            OperationId = "DeleteFile",
            Tags = new[] { "Files" })
        ]
        public override async Task<ActionResult<DeleteFileResult>> HandleAsync([FromRoute] DeleteFileRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
