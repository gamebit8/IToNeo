using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.EmployeesTest
{
    public class CreateEmployee
    {
        private readonly Mock<IAsyncRepository<Employee>> _mockEmployeeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<Controller>> _mockLogger;
        private readonly ControllerContext _testControllerContext;
        private readonly IUrlHelper _testUrlHelper;

        public CreateEmployee()
        {
            var employee = new Employee();
            _mockEmployeeRepository = new Mock<IAsyncRepository<Employee>>();
            _mockEmployeeRepository.Setup(er => er.UpdateAsync(employee)).Returns(Task.FromResult(employee));

            _mockMapper = new Mock<IMapper>();

            _mockLogger = new Mock<ILogger<Controller>>();

            var actionDescriptor = new ControllerActionDescriptor() { ActionName = "" };
            _testControllerContext = new ControllerContext() { ActionDescriptor = actionDescriptor };
            
            _testUrlHelper = new UrlHelper(new ActionContext()
            {
                ActionDescriptor = new ActionDescriptor(),
                RouteData = new RouteData()
            });
        } 

        [Fact]
        public async Task NotNullResultAfterCreateEmployee()
        {
            var request = new CreateEmployeeRequest();

            var handler = new IToNeo.WebAPI.ApiEndpoints.V1.Employees.Create(_mockEmployeeRepository.Object, _mockMapper.Object, _mockLogger.Object)
            {
                ControllerContext = _testControllerContext,
                Url = _testUrlHelper
            };

            var result = await handler.HandleAsync(request, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
