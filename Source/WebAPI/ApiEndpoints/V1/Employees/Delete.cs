using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
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
    public class Delete : DeleteBase<Employee, DeleteEmployeeRequest, DeleteEmployeeResult>
    {
        public Delete(IAsyncRepository<Employee> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a new Employee",
            Description = "Deletes a new Employee",
            OperationId = "DeleteEmployee",
            Tags = new[] { "Employees" })
        ]
        public override async Task<ActionResult<DeleteEmployeeResult>> HandleAsync([FromRoute] DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEntityAsync(request.Id);
        }
    }
}
