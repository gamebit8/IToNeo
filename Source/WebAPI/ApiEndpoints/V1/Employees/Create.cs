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

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    [Authorize(Roles = "Administrator,Operator")]
    [Route("api/v1/employees")]
    public class Create : CreateBase<Employee, CreateEmployeeRequest, CreateEmployeeResult>
    {
        public Create(IAsyncRepository<Employee> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Creates a new Employee",
            Description = "Creates a new Employee",
            OperationId = "CreateEmployee",
            Tags = new[] { "Employees" })
        ]
        public override async Task<ActionResult<CreateEmployeeResult>> HandleAsync([FromBody] CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            return await CreateAsync(request);
        }
    }
}
