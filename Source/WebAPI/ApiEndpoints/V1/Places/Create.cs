using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    [Route("api/v1/places")]
    [Authorize(Roles = "Administrator")]
    public class Create : CreateBase<Place, CreatePlaceRequest, CreatePlaceResult>
    {
        public Create(IAsyncRepository<Place> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Place",
            Description = "Creates a new Place",
            OperationId = "CreatePlace",
            Tags = new[] { "Places" })
        ]
        public override async Task<ActionResult<CreatePlaceResult>> HandleAsync([FromBody] CreatePlaceRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
