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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    [Route("api/v1/places")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class Update : UpdateBase<Place, UpdatePlaceRequestBody, UpdatePlaceResult>
    {
        public Update(IAsyncRepository<Place> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Place",
            Description = "Update Place",
            OperationId = "UpdatePlace",
            Tags = new[] { "Places" })
        ]
        public override async Task<ActionResult<UpdatePlaceResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdatePlaceRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
