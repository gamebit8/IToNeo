using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    [Route("api/v1/places")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Delete : DeleteBase<Place, DeletePlaceRequest, DeletePlaceResult>
    {
        public Delete(IAsyncRepository<Place> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a new Place",
            Description = "Deletes a new Place",
            OperationId = "DeletePlace",
            Tags = new[] { "Places" })
        ]
        public override async Task<ActionResult<DeletePlaceResult>> HandleAsync([FromRoute] DeletePlaceRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
