using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete
{
    [ApiController]
    public class DeleteBase<TEntity, TRequest, TResult> 
        : EndpointBaseAsync.WithRequest<TRequest>.WithActionResult<TResult>
        where TEntity : BaseEntity, IUpdateEntity<TEntity>
        where TRequest : DeleteBaseRequest
        where TResult : DeleteBaseResult
    {
        protected readonly IAsyncRepository<TEntity> _repositoryAsync;
        protected readonly IMapper _mapper;
        protected readonly ILogger<Controller> _logger;

        public DeleteBase(IAsyncRepository<TEntity> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<TResult>> HandleAsync([FromRoute]TRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }

        protected async Task<ActionResult> DeleteEntityAsync(string id)
        {
            TEntity entity = await _repositoryAsync.GetByIdAsync(id);

            if (entity == null) return NotFound();

            await _repositoryAsync.DeleteAsync(entity);
            return NoContent();
        }
    }
}
