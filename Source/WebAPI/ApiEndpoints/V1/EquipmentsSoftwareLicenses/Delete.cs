using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    [Route("api/v1/equipmentsSoftwareLicenses")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Delete : EndpointBaseAsync.WithRequest<DeleteEquipmentSoftwareLicenseRequest>.WithActionResult<DeleteEquipmentSoftwareLicenseResult>
    {
        protected readonly IAsyncRepository<EquipmentSoftwareLicense> _repositoryAsync;
        protected readonly IMapper _mapper;
        protected readonly ILogger<Controller> _logger;

        public Delete(IAsyncRepository<EquipmentSoftwareLicense> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpDelete()]
        [SwaggerOperation(
            Summary = "Deletes a new Equipment Software license relationship",
            Description = "Deletes a new Equipment Software license relationship",
            OperationId = "DeleteEquipmentsSoftwareLicense",
            Tags = new[] { "EquipmentsSoftwareLicenses" })
        ]
        public override async Task<ActionResult<DeleteEquipmentSoftwareLicenseResult>> HandleAsync([FromQuery] DeleteEquipmentSoftwareLicenseRequest request, CancellationToken cancellationToken)
        {

            var esl = new EquipmentSoftwareLicense { EquipmentId = request.EquipmentId, SoftwareLicenceId = request.SoftwareLicenseId };
            var spec = new EquipmentSoftwareLicenseWithSpecification(esl);

            IReadOnlyList<EquipmentSoftwareLicense> el = await _repositoryAsync.ListAsync(spec);
            EquipmentSoftwareLicense entity = el.FirstOrDefault();

            if (entity == null) return NotFound();
            await _repositoryAsync.DeleteAsync(entity);

            return NoContent();
        }
    }
}
