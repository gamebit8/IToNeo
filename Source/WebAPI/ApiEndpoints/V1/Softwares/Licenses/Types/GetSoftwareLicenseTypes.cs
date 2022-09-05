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

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenseTypes
{
    [Route("api/v1/software/licenses/types")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetSoftwareLicenseTypes : GetListBase<SoftwareLicenseType, GetSoftwareLicenseTypesRequest, GetSoftwareLicenseTypesResult>
    {
        public GetSoftwareLicenseTypes(
            IReadOnlyAsyncRepository<SoftwareLicenseType> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetSoftwareLicenseTypesResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Software License Type",
            Description = "Get a Software License Type",
            OperationId = "GetSoftwareLicenseType",
            Tags = new[] { "SoftwareLicenseTypes" })
        ]
        public override async Task<ActionResult<GetSoftwareLicenseTypesResult>> HandleAsync([FromQuery] GetSoftwareLicenseTypesRequest request, CancellationToken cancellationToken)
        {
            var softwareLicenseType = _mapper.Map<GetSoftwareLicenseTypesRequest, SoftwareLicenseType>(request);
            var spec = new SoftwareLicenseTypeWithSpecification(request.Offset, request.Limit, softwareLicenseType, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
