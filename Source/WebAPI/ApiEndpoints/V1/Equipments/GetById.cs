using AutoMapper;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    [Route("api/v1/equipments")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<Equipment, GetByIdEquipmentRequest, GetByIdEquipmentResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<Equipment> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger,
            ICacheService<BaseWithHateoasResponse<GetByIdEquipmentResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Equipment by Id",
            Description = "Get a Equipment by Id",
            OperationId = "GetByIdEquipment",
            Tags = new[] { "Equipments" })
        ]
        public override async Task<ActionResult<GetByIdEquipmentResult>> HandleAsync([FromRoute] GetByIdEquipmentRequest request, CancellationToken cancellationToken)
        {
            var specification = new EquipmentWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
