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

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    [Route("api/v1/softwares/licenses")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetSoftwareLicenses : GetListBase<SoftwareLicense, GetSoftwareLicensesRequest, GetSoftwareLicensesResult>
    {
        public GetSoftwareLicenses(
            IReadOnlyAsyncRepository<SoftwareLicense> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetSoftwareLicensesResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Software Licenses",
            Description = "Get a Software Licenses",
            OperationId = "GetSoftwareLicenses",
            Tags = new[] { "SoftwareLicenses" })
        ]
        public override async Task<ActionResult<GetSoftwareLicensesResult>> HandleAsync([FromQuery] GetSoftwareLicensesRequest request, CancellationToken cancellationToken)
        {
            var softwareLicense = _mapper.Map<GetSoftwareLicensesRequest, SoftwareLicense>(request);
            var spec = new SoftwareLicenseWithSpecification(request.Offset, request.Limit, softwareLicense, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
