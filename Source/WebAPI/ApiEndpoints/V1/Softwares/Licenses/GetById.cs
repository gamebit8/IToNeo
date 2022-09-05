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

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    [Route("api/v1/softwares/licenses")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<SoftwareLicense, GetByIdSoftwareLicenseRequest, GetByIdSoftwareLicenseResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<SoftwareLicense> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdSoftwareLicenseResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Software License by Id",
            Description = "Get a Software License by Id",
            OperationId = "GetByIdSoftwareLicense",
            Tags = new[] { "SoftwareLicenses" })
        ]
        public override async Task<ActionResult<GetByIdSoftwareLicenseResult>> HandleAsync([FromRoute] GetByIdSoftwareLicenseRequest request, CancellationToken cancellationToken)
        {
            var specification = new SoftwareLicenseWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
