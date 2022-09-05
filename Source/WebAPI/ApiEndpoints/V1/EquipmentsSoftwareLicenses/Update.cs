using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
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
    public class Update : UpdateBase<EquipmentSoftwareLicense, UpdateEquipmentSoftwareLicenseRequestBody, UpdateEquipmentSoftwareLicenseResult>
    {
        public Update(IAsyncRepository<EquipmentSoftwareLicense> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Equipment Software license relationship",
            Description = "Update Equipment Software license relationship",
            OperationId = "UpdateEquipmentSoftwareLicense",
            Tags = new[] { "EquipmentsSoftwareLicenses" })
        ]
        public override async Task<ActionResult<UpdateEquipmentSoftwareLicenseResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateEquipmentSoftwareLicenseRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
