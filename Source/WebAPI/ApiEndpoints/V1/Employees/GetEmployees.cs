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
    [Authorize(Roles = "Administrator,Operator")]
    [Route("api/v1/employees")]
    [ApiController]
    public class GetEmployees : GetListBase<Employee, GetEmployeesRequest, GetEmployeesResult>
    {
        public GetEmployees(
            IReadOnlyAsyncRepository<Employee> repositoryAsync, 
            IMapper mapper, ILogger<Controller> logger, 
            ICacheService<BaseListWithHateoasResponse<GetEmployeesResult>> cacheService) 
            : base(repositoryAsync, mapper, logger, cacheService)
        {

        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get a Employees",
            Description = "Get a Employees",
            OperationId = "GetEmployees",
            Tags = new[] { "Employees" })
        ]
        public override async Task<ActionResult<GetEmployeesResult>> HandleAsync([FromQuery] GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<GetEmployeesRequest, Employee>(request);
            var spec = new EmployeeWithSpecification(request.Offset, request.Limit, employee, request.SortBy, request.SortDescending);

            return await GetListAsync(spec, request);
        }
    }
}
