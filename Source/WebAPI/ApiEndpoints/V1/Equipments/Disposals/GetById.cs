using AutoMapper;
using IToNeo.ApplicationCore.Entities;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Disposals
{
    [Route("api/v1/equipments/disposals")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<EquipmentDisposal, GetByIdEquipmentDisposalRequest, GetByIdEquipmentDisposalResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<EquipmentDisposal> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdEquipmentDisposalResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Equipment disposal by Id",
            Description = "Get a Equipment disposal by Id",
            OperationId = "GetByIdEquipmentDisposal",
            Tags = new[] { "EquipmentDisposals" })
        ]
        public override async Task<ActionResult<GetByIdEquipmentDisposalResult>> HandleAsync([FromRoute] GetByIdEquipmentDisposalRequest request, CancellationToken cancellationToken)
        {
            var specification = new DisposalWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
