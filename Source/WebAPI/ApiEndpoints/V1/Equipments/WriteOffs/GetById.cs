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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.WriteOffs
{
    [Route("api/v1/equipments/writeoffs")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<EquipmentWriteOff, GetByIdEquipmentWriteOffRequest, GetByIdEquipmentWriteOffResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<EquipmentWriteOff> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdEquipmentWriteOffResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Equipment WriteOff by Id",
            Description = "Get a Equipment WriteOff by Id",
            OperationId = "GetByIdEquipmentWriteOff",
            Tags = new[] { "EquipmentWriteOffs" })
        ]
        public override async Task<ActionResult<GetByIdEquipmentWriteOffResult>> HandleAsync([FromRoute] GetByIdEquipmentWriteOffRequest request, CancellationToken cancellationToken)
        {
            var specification = new WriteOffWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
