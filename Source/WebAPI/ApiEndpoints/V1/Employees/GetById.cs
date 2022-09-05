using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    [Authorize(Roles = "Administrator,Operator")]
    [Route("api/v1/employees")]
    public class GetById : GetByIdBase<Employee, GetByIdEmployeeRequest, GetByIdEmployeeResult>
    {
        public GetById(
            IReadOnlyAsyncRepository<Employee> repositoryAsync, 
            IMapper mapper, 
            ILogger<Controller> logger, 
            ICacheService<BaseWithHateoasResponse<GetByIdEmployeeResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Employee by Id",
            Description = "Get a Employee by Id",
            OperationId = "GetByIdEmployee",
            Tags = new[] { "Employees" })
        ]
        public override async Task<ActionResult<GetByIdEmployeeResult>> HandleAsync([FromRoute] GetByIdEmployeeRequest request, CancellationToken cancellationToken)
        {
            var specification = new EmployeeWithSpecification(request.Id);
            return await GetAsync(specification);
        }
    }
}
