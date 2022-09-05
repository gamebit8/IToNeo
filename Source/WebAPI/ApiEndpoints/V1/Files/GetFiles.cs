using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
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
    public class GetFiles : GetListBase<FileEntity, GetFilesRequest, GetFilesResult>
    {
        public GetFiles(
            IReadOnlyAsyncRepository<FileEntity> repositoryAsync,
            IMapper mapper,
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetFilesResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Files",
            Description = "Get a Files",
            OperationId = "GetFiles",
            Tags = new[] { "Files" })
        ]
        public override async Task<ActionResult<GetFilesResult>> HandleAsync([FromQuery] GetFilesRequest request, CancellationToken cancellationToken)
        {
            var spec = new FileEntityWithSpecification(request.Offset, request.Limit, request.SortBy, request.SortDescending);
            return await GetListAsync(spec, request);
        }
    }
}
