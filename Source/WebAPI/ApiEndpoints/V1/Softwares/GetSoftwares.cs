using AutoMapper;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Softwares
{
    [Route("api/v1/softwares")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetSoftwares : GetListBase<Software, GetSoftwaresRequest, GetSoftwaresResult>
    {
        public GetSoftwares(
            IReadOnlyAsyncRepository<Software> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetSoftwaresResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Softwares",
            Description = "Get a Softwares",
            OperationId = "GetSoftwares",
            Tags = new[] { "Softwares" })
        ]
        public override async Task<ActionResult<GetSoftwaresResult>> HandleAsync([FromQuery] GetSoftwaresRequest request, CancellationToken cancellationToken)
        {
            var software = _mapper.Map<GetSoftwaresRequest, Software>(request);
            var spec = new SoftwareWithSpecification(request.Offset, request.Limit, software, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
