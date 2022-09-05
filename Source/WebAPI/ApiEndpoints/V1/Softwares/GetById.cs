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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Softwares
{
    [Route("api/v1/softwares")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<Software, GetByIdSoftwareRequest, GetByIdSoftwareResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<Software> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdSoftwareResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Software by Id",
            Description = "Get a Software by Id",
            OperationId = "GetByIdSoftware",
            Tags = new[] { "Softwares" })
        ]
        public override async Task<ActionResult<GetByIdSoftwareResult>> HandleAsync([FromRoute] GetByIdSoftwareRequest request, CancellationToken cancellationToken)
        {
            var specification = new SoftwareWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
