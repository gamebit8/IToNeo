using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
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
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class GetEquipmentsSoftwareLicenses : GetListBase<EquipmentSoftwareLicense, GetEquipmentsSoftwareLicensesRequest, GetEquipmentsSoftwareLicensesResult>
    {
        public GetEquipmentsSoftwareLicenses(
            IReadOnlyAsyncRepository<EquipmentSoftwareLicense> repositoryAsync,
            IMapper mapper, ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEquipmentsSoftwareLicensesResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Equipments Software licenses relationship",
            Description = "Get a Equipments Software licenses relationship",
            OperationId = "GetEquipmentsSoftwareLicenses",
            Tags = new[] { "EquipmentsSoftwareLicenses" })
        ]
        public override Task<ActionResult<GetEquipmentsSoftwareLicensesResult>> HandleAsync([FromQuery] GetEquipmentsSoftwareLicensesRequest request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
