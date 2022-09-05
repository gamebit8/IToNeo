using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V1.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.EmployeesTest
{
    public class DeleteEmployee
    {
        private readonly string _testEmployeeId = Guid.NewGuid().ToString();
        private readonly Employee _testEmployee;
        private readonly Mock<IAsyncRepository<Employee>> _mockEmployeeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<Controller>> _mockLogger;

        public DeleteEmployee()
        {
           _testEmployee = new Employee();
            
            _mockEmployeeRepository = new Mock<IAsyncRepository<Employee>>();
            _mockEmployeeRepository.Setup(er => er.GetByIdAsync(_testEmployeeId)).ReturnsAsync(_testEmployee);
            _mockEmployeeRepository.Setup(er => er.DeleteAsync(_testEmployee));
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<Controller>>();
        }

        [Fact]
        public async Task NotNullResultAfterDeleteEmployee()
        {
            var request = new DeleteEmployeeRequest() { Id = _testEmployeeId };

            var handler = new IToNeo.WebAPI.ApiEndpoints.V1.Employees.Delete(_mockEmployeeRepository.Object, _mockMapper.Object, _mockLogger.Object);

            var result = await handler.HandleAsync(request, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
