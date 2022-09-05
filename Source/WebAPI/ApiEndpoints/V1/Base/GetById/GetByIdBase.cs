using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById
{
    [ApiController]
    public class GetByIdBase<TEntity, TRequest, TResult>
        : EndpointBaseAsync.WithRequest<TRequest>.WithActionResult<TResult> 
        where TEntity : BaseEntity, IUpdateEntity<TEntity>
        where TRequest : GetByIdBaseRequest
        where TResult : GetByIdBaseResult
    {
        protected readonly IReadOnlyAsyncRepository<TEntity> _repositoryAsync;
        protected readonly IMapper _mapper;
        protected readonly ILogger<Controller> _logger;
        protected readonly ICacheService<BaseWithHateoasResponse<TResult>> _cacheService;

        public GetByIdBase(
            IReadOnlyAsyncRepository<TEntity> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<TResult>> cacheService)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<TResult>> HandleAsync([FromRoute]TRequest request, CancellationToken cancellationToken)
        {
            return await GetAsync(request.Id);
        }

        protected async Task<ActionResult> GetAsync(ISpecification<TEntity> specification)
        {
            var entities = await _repositoryAsync.ListAsync(specification);
            TEntity entity = entities.FirstOrDefault();
            if (entity is null) return NotFound();

            var cacheKey = HttpContext.Request.Path;
            var resultFromCache = await _cacheService.GetAsync(cacheKey);
            if (resultFromCache != null) return Ok(resultFromCache);

            var result = GenerateResponse(entity);
            await _cacheService.SetAsync(cacheKey, resultFromCache);
            return Ok(result);
        }

        protected async Task<ActionResult> GetAsync(string id)
        {
            TEntity entity = await _repositoryAsync.GetByIdAsync(id);

            if (entity is null) return NotFound();

            BaseWithHateoasResponse<TResult> result = GenerateResponse(entity);
            return Ok(result);
        }

        private BaseWithHateoasResponse<TResult> GenerateResponse(TEntity entity)
        {
            TResult data = _mapper.Map<TEntity, TResult>(entity);
            BaseWithHateoasResponse<TResult> response = new()
            {
                Data = data,
                Link = default
            };

            return response;
        }
    }
}
