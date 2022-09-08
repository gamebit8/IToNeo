using Ardalis.ApiEndpoints;
using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.Shared;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList
{
    [ApiController]
    public class GetListBase<TEntity, TRequest, TResult>         
        : EndpointBaseAsync.WithRequest<TRequest>.WithActionResult<TResult>
            where TEntity : BaseEntity, IUpdateEntity<TEntity> 
            where TRequest : GetListBaseRequest
            where TResult: GetListBaseResult
    {
        protected readonly IReadOnlyAsyncRepository<TEntity> _repositoryAsync;
        protected readonly IMapper _mapper;
        protected readonly ILogger<Controller> _logger;
        private readonly ICacheService<BaseListWithHateoasResponse<TResult>> _cacheService;
       
        public GetListBase(
            IReadOnlyAsyncRepository<TEntity> repositoryAsync, 
            IMapper mapper, ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<TResult>> cacheService)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
            _cacheService = cacheService;
        }

        public override Task<ActionResult<TResult>> HandleAsync([FromQuery]TRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }


        protected async Task<ActionResult> GetListAsync(ISpecification<TEntity> specification, BaseFilterRequest filter)
        {
            var entities = await _repositoryAsync.ListAsync(specification);
            if (entities is null) NotFound();

            var cacheKey = HttpContext.Request.Path + "/" + HttpContext.Request.QueryString;
            var responseFromCache = await _cacheService.GetAsync(cacheKey);
            if (responseFromCache != null) return Ok(responseFromCache);

            var data = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TResult>>(entities);
            var hateos = GenerateHateosForGetEntities(filter, entities.Count);
            var response = new BaseListWithHateoasResponse<TResult>
            {
                Data = data,
                Link = hateos
            };

            await _cacheService.SetAsync(cacheKey, response);

            return Ok(response);
        }

        private IEnumerable<HateoasResponse> GenerateHateosForGetEntities(BaseFilterRequest filter, int previousCountResult)
        {
            string nextPageUrl = (filter.Limit <= previousCountResult) ? GenerateNextPageLink(filter) : null;
            var nextPageHateos = new HateoasResponse("NextPage", nextPageUrl);

            var hateos = new List<HateoasResponse>() { nextPageHateos };
            return hateos;
        }

        private string GenerateNextPageLink(BaseFilterRequest filter)
        {
            string controllerName = ControllerContext.ActionDescriptor.ControllerName;
            string controllerActionName = ControllerContext.ActionDescriptor.ActionName;
            BaseFilterRequest filterNextPage = GenerateFilterNextPage(filter);

            var nextPageUrl = Url.Action(controllerActionName, controllerName, filterNextPage);
            return nextPageUrl;
        }

        private BaseFilterRequest GenerateFilterNextPage(BaseFilterRequest filter)
        {
            filter.Offset += filter.Limit;
            return filter;
        }
    }
}
