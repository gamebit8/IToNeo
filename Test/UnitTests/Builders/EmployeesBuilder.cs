using IToNeo.ApplicationCore.Entities;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class EmployeesBuilder
    {
        private readonly IEnumerable<Employee> _employees;

        public EmployeesBuilder()
        {
            _employees = WithDefaultValues();
        }

        private static IEnumerable<Employee> WithDefaultValues()
        {
            return new List<Employee>()
            {
                new Employee("Иван", "Иванов", "Иванович", "i.ivanov", "1",
                    "Информационные технологии", "Специалист"),
                new Employee("Иван", "Сидоров", "Иванович", "i.sidorov", "2",
                    "Юридическая служба", "Специалист"),
                new Employee("Иван", "Петров", "Иванович", "i.petrov", "3",
                    "Планово-экономический отдел", "Специалист"),
                new Employee("Иван", "Лебедев", "Иванович", "i.petrov", "3",
                    "Планово-экономический отдел", "Специалист")
            };
        }

        public IEnumerable<Employee> Build() => _employees;
    }
}
