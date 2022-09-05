using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.Update
{
    [ApiController]
    public class UpdateBase<TEntity, TRequestBody, TResult> 
        : EndpointBaseAsync.WithRequest<UpdateBaseRequest<TRequestBody>>.WithActionResult<TResult> 
        where TEntity : BaseEntity, IUpdateEntity<TEntity>
        where TResult : UpdateBaseResult
        where TRequestBody: UpdateBaseRequestBody
    {
        protected readonly IAsyncRepository<TEntity> _repositoryAsync;
        protected readonly IMapper _mapper;
        protected readonly ILogger<Controller> _logger;

        public UpdateBase(IAsyncRepository<TEntity> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult<TResult>> HandleAsync([FromRoute] UpdateBaseRequest<TRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }

        protected async Task<ActionResult> UpdateAsync(string id, TRequestBody entityRequest)
        {
            if (!ModelState.IsValid) return BadRequest(entityRequest);

            var mapEnt = _mapper.Map<TRequestBody, TEntity>(entityRequest);
            var entity = await _repositoryAsync.GetByIdAsync(id);

            if (entity == null) return NotFound();

            entity.Update(mapEnt);
            await _repositoryAsync.UpdateAsync(entity);

            var response = _mapper.Map<TEntity, TResult>(entity);
            return Ok(response);
        }
    }
}
