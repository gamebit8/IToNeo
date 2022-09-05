using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Employees;
using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.EmployeesTest
{
    public class GetEmployees
    {
        private readonly Mock<IReadOnlyAsyncRepository<Employee>> _mockEmployeeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<Controller>> _mockLogger;
        private readonly Mock<ICacheService<BaseListWithHateoasResponse<GetEmployeesResult>>> _cacheService;

        public GetEmployees()
        {
            var employee = new Employee(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            _mockEmployeeRepository = new Mock<IReadOnlyAsyncRepository<Employee>>();
            _mockEmployeeRepository.Setup(r => r.ListAsync(It.IsAny<EmployeeWithSpecification>())).ReturnsAsync(new List<Employee> { employee });
            
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<Controller>>();
            _cacheService = new Mock<ICacheService<BaseListWithHateoasResponse<GetEmployeesResult>>>();
        }

        [Fact]
        public async Task NotReturnNullIfEmployeesArePresIent()
        {
            var request = new GetEmployeesRequest();

            var handler = new WebAPI.ApiEndpoints.V1.Employees.GetEmployees(_mockEmployeeRepository.Object, _mockMapper.Object, _mockLogger.Object, _cacheService.Object);
            handler.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            var result = await handler.HandleAsync(request, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
