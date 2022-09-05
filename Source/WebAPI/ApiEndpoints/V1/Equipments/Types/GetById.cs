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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Types
{
    [Route("api/v1/equipments/types")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<EquipmentType, GetByIdEquipmentTypeRequest, GetByIdEquipmentTypeResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<EquipmentType> repositoryAsync,
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdEquipmentTypeResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Equipment type by Id",
            Description = "Get a Equipment type by Id",
            OperationId = "GetByIdEquipmentType",
            Tags = new[] { "EquipmentTypes" })
        ]
        public override async Task<ActionResult<GetByIdEquipmentTypeResult>> HandleAsync([FromRoute] GetByIdEquipmentTypeRequest request, CancellationToken cancellationToken)
        {
            var specification = new EquipmentTypeWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
