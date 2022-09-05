using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    [Route("api/v1/files")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<FileEntity, GetByIdFileRequest, GetByIdFileResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<FileEntity> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdFileResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [ActionName("GetFileById")]
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a File by Id",
            Description = "Get a File by Id",
            OperationId = "GetByIdFile",
            Tags = new[] { "Files" })
        ]
        public override async Task<ActionResult<GetByIdFileResult>> HandleAsync([FromRoute] GetByIdFileRequest request, CancellationToken cancellationToken)
        {
            var file = await _repositoryAsync.GetByIdAsync(request.Id) as FileEntity;

            if (file != null)
                return File(file.Content, "application/octet-stream", file.Name);

            return NotFound();
        }
    }
}
