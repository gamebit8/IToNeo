using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    [Route("api/v1/equipmentsSoftwareLicenses")]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetById : GetByIdBase<EquipmentSoftwareLicense, GetByIdEquipmentSoftwareLicenseRequest, GetByIdEquipmentSoftwareLicenseResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<EquipmentSoftwareLicense> repositoryAsync,
            IMapper mapper,
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdEquipmentSoftwareLicenseResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Equipment Software license relationship by Id",
            Description = "Get a Equipment Software license relationship by Id",
            OperationId = "GetByIdEquipmentSoftwareLicense",
            Tags = new[] { "EquipmentsSoftwareLicenses" })
        ]
        public override async Task<ActionResult<GetByIdEquipmentSoftwareLicenseResult>> HandleAsync([FromRoute] GetByIdEquipmentSoftwareLicenseRequest request, CancellationToken cancellationToken)
        {
            return await GetAsync(request.Id);
        }
    }
}
