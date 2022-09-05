using AutoMapper;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenseTypes
{
    [Route("api/v1/softwares/licenses/types")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<SoftwareLicenseType, GetByIdSoftwareLicenseTypeRequest, GetByIdSoftwareLicenseTypeResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<SoftwareLicenseType> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdSoftwareLicenseTypeResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Software license type by Id",
            Description = "Get a Software license type by Id",
            OperationId = "GetByIdSoftwareLicenseType",
            Tags = new[] { "SoftwareLicenseTypes" })
        ]
        public override async Task<ActionResult<GetByIdSoftwareLicenseTypeResult>> HandleAsync([FromRoute] GetByIdSoftwareLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            var specification = new SoftwareLicenseTypeWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
