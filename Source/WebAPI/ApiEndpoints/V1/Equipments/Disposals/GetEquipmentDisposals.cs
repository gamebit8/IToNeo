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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Disposals
{
    [Route("api/v1/equipments/disposals")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentDisposals : GetListBase<EquipmentDisposal, GetEquipmentDisposalsRequest, GetEquipmentDisposalsResult>
    {
        public GetEquipmentDisposals(
            IReadOnlyAsyncRepository<EquipmentDisposal> repositoryAsync,
            IMapper mapper,
            ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentDisposalsResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipments disposals",
            Description = "Get a Equipment disposals",
            OperationId = "GetEquipmentDisposals",
            Tags = new[] { "EquipmentDisposals" })
        ]
        public override async Task<ActionResult<GetEquipmentDisposalsResult>> HandleAsync([FromQuery] GetEquipmentDisposalsRequest request, CancellationToken cancellationToken)
        {
            var equipmentDisposal = _mapper.Map<GetEquipmentDisposalsRequest, EquipmentDisposal>(request);
            var spec = new DisposalWithSpecification(request.Offset, request.Limit, equipmentDisposal, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
