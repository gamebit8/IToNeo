using IToNeo.ApplicationCore.Entities;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class EmployeeWithSpecification
    {
        private readonly IQueryable<Employee> _testEmployees;

        public EmployeeWithSpecification()
        {
            _testEmployees = new EmployeesBuilder().Build().AsQueryable();
        }

        [Fact]
        public void ReturnEquipmentEmployeeWithFilter()
        {
            var employeeAsFilter = _testEmployees.First();

            var spec = new IToNeo.ApplicationCore.Specifications.EmployeeWithSpecification(0, 100, employeeAsFilter);
            var result = SpecificationEvaluator<Employee>.GetQuery(_testEmployees, spec).ToList();

            Assert.Single(result);
            Assert.Equal(employeeAsFilter, result.First());
        }

        [Theory]
        [InlineData("0", 0, 100, 0)]
        [InlineData("1", 0, 100, 1)]
        [InlineData("3", 0, 100, 2)]
        [InlineData(null, 0, 1, 1)]
        [InlineData(null, 1, 100, 3)]
        public void ReturnEquipmentEmployeesWithFilter(string orgId, int skip, int take, int count)
        {
            var employeeAsFilter = new Employee() { OrganizationId = orgId };
            var spec = new IToNeo.ApplicationCore.Specifications.EmployeeWithSpecification(skip, take, employeeAsFilter);
            var result = SpecificationEvaluator<Employee>.GetQuery(_testEmployees, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
