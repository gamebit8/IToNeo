using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    [Route("api/v1/employees/short")]
    [Authorize(Roles = "Administrator,Operator")]
    [ApiController]
    public class GetEmployeesShort : GetListBase<Employee, GetEmployeesShortRequest, GetEmployeesShortResult>
    {
        public GetEmployeesShort(
            IReadOnlyAsyncRepository<Employee> repositoryAsync, 
            IMapper mapper, ILogger<Controller> logger,
            ICacheService<BaseListWithHateoasResponse<GetEmployeesShortResult>> cacheService)
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Employees short",
            Description = "Get a Employees short",
            OperationId = "GetEmployeesShort",
            Tags = new[] { "Employees" })
        ]
        public override async Task<ActionResult<GetEmployeesShortResult>> HandleAsync([FromQuery] GetEmployeesShortRequest request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<GetEmployeesShortRequest, Employee>(request);
            var spec = new EmployeeWithSpecification(request.Offset, request.Limit, employee, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
