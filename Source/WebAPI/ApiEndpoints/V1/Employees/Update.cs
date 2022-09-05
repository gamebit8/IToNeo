using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    [Route("api/v1/employees")]
    [ApiController]
    [Authorize(Roles = "Administrator,Operator")]
    public class Update : UpdateBase<Employee, UpdateEmployeeRequestBody, UpdateEmployeeResult>
    {
        public Update(IAsyncRepository<Employee> repositoryAsync, IMapper mapper, ILogger<Controller> logger)
            : base(repositoryAsync, mapper, logger)
        {

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Employee",
            Description = "Update Employee",
            OperationId = "UpdateEmployee",
            Tags = new[] { "Employees" })
        ]
        public override async Task<ActionResult<UpdateEmployeeResult>> HandleAsync([FromRoute] UpdateBaseRequest<UpdateEmployeeRequestBody> request, CancellationToken cancellationToken)
        {
            return await UpdateAsync(request.Id, request.Entity);
        }
    }
}
