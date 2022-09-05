using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    [Route("api/v1/files")]
    [Authorize(Roles = "Administrator,Operator")]
    public class Create : EndpointBaseAsync.WithRequest<CreateFileRequest>.WithActionResult<CreateFileResult>
    {
        private readonly IAsyncRepository<FileEntity> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<Controller> _logger;
        private readonly IFileHelper _fileHelper;

        public Create(IAsyncRepository<FileEntity> repositoryAsync, IMapper mapper, ILogger<Controller> logger, IFileHelper fileHelper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
            _fileHelper = fileHelper;
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new File",
            Description = "Creates a new File",
            OperationId = "CreateFile",
            Tags = new[] { "Files" })
        ]
        public override async Task<ActionResult<CreateFileResult>> HandleAsync([FromForm] CreateFileRequest request, CancellationToken cancellationToken)
        {
            if (_fileHelper.CheckFileIsValid(request.Content))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var fileName = _fileHelper.GetFileName(request.Content);
                    await request.Content.CopyToAsync(memoryStream, cancellationToken);

                    var f = new FileEntity()
                    {
                        Name = fileName,
                        Content = memoryStream.ToArray(),

                        EquipmentId = request.EquipmentId
                    };

                    await _repositoryAsync.AddAsync(f as FileEntity);

                    Response.StatusCode = StatusCodes.Status201Created;
                    string locationUrl = Url.Action("GetFileById", "GetById", new { id = f.Id }, Url.ActionContext.HttpContext.Request.Scheme);

                    return new JsonResult(locationUrl);
                }
            }

            return BadRequest();
        }
    }
}
