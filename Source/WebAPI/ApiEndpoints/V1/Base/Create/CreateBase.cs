using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.Create
{
    [ApiController]
    public class CreateBase<TEntity, TRequest, TResult> 
        : EndpointBaseAsync.WithRequest<TRequest>.WithActionResult<TResult>
        where TEntity : BaseEntity, IUpdateEntity<TEntity>
        where TRequest : CreateBaseRequest
        where TResult : CreateBaseResult
    {
        protected readonly IAsyncRepository<TEntity> _repositoryAsync;
        protected readonly IMapper _mapper;
        protected readonly ILogger<Controller> _logger;

        public CreateBase(IAsyncRepository<TEntity> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost()]
        public override async Task<ActionResult<TResult>> HandleAsync([FromBody]TRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }

        protected async Task<ActionResult> CreateAsync(TRequest request)
        {
            if (!ModelState.IsValid) 
                return BadRequest(request);

            TEntity mapEnt = _mapper.Map<TRequest, TEntity>(request);

            await _repositoryAsync.AddAsync(mapEnt);

            return Status201(mapEnt);
        }

        private ActionResult Status201(TEntity mapEnt)
        {
            try
            {
                HateoasResponse hateos = GenerateHateosForGetEntities(mapEnt);

                Response.StatusCode = StatusCodes.Status201Created;

                return new JsonResult(hateos);
            }
            catch
            {
                return new JsonResult(default);
            }
        }

        private CreateBaseResult GenerateHateosForGetEntities(TEntity mapEnt)
        {
            try
            {
                var baseEntitiesUrl = HttpContext.Request.GetEncodedUrl();
                string entityUrl = baseEntitiesUrl + "/" + mapEnt.Id;
                var hateos = new CreateBaseResult("Location", entityUrl);
                return hateos;
            }
            catch
            {
                return default;
            }
        }
    }
}
