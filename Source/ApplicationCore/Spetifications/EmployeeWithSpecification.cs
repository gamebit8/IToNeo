using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Helpers.Query;
using System;
using System.Globalization;

namespace IToNeo.ApplicationCore.Specifications
{
    public class EmployeeWithSpecification : BaseSpecification<Employee>
    {
        public EmployeeWithSpecification(string id) : base(i => i.Id == id)
        {
            AddIncludes(query => query.Include(o => o.Organization).Include(o => o.File));
        }

        public EmployeeWithSpecification(int skip, int take, Employee employee, string orderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(employee.Name) || i.Name.StartsWith(employee.Name)) &&
                (string.IsNullOrEmpty(employee.Username) || i.Username.StartsWith(employee.Username)) &&
                (string.IsNullOrEmpty(employee.OrganizationId) || i.OrganizationId == employee.OrganizationId) &&
                (string.IsNullOrEmpty(employee.Department) || i.Department.StartsWith(employee.Department)) &&
                (string.IsNullOrEmpty(employee.Position) || i.Position.StartsWith(employee.Position)))
        {
            ApplyPaging(skip, take);

            AddIncludes(query => query.Include(o => o.Organization).Include(o => o.File));

            if (!string.IsNullOrEmpty(orderBy))
                ApplyOrderBy(orderBy, isDescending);
        }
    }
}
