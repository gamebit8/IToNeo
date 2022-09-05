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
    public class GetEmployeeById
    {
        private readonly Mock<IReadOnlyAsyncRepository<Employee>> _mockEmployeeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<Controller>> _mockLogger;
        private readonly Mock<ICacheService<BaseWithHateoasResponse<GetByIdEmployeeResult>>> _cacheService;

        public GetEmployeeById()
        {
            var employee = new Employee(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            _mockEmployeeRepository = new Mock<IReadOnlyAsyncRepository<Employee>>();
            _mockEmployeeRepository.Setup(r => r.ListAsync(It.IsAny<EmployeeWithSpecification>())).ReturnsAsync(new List<Employee> { employee });

            _cacheService = new Mock<ICacheService<BaseWithHateoasResponse<GetByIdEmployeeResult>>>();
            _cacheService.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync(It.IsAny<BaseWithHateoasResponse<GetByIdEmployeeResult>>());

            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<Controller>>();
        }

        [Fact]
        public async Task NotReturnNullIfEmployeeArePresIent()
        {
            var request = new GetByIdEmployeeRequest();

            var handler = new GetById(_mockEmployeeRepository.Object, _mockMapper.Object, _mockLogger.Object, _cacheService.Object);
            handler.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            var result = await handler.HandleAsync(request, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
