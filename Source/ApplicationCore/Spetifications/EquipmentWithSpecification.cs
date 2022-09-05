using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Helpers.Query;
using System;

namespace IToNeo.ApplicationCore.Specifications
{
    public class EquipmentWithSpecification : BaseSpecification<Equipment>
    {
        public EquipmentWithSpecification(string id) : base(i => i.Id == id)
        {
            ApplyInclude();
        }

        public EquipmentWithSpecification(
            int skip, 
            int take, 
            Equipment equipment, 
            string orderBy = null, 
            bool isDescending = false, 
            DateTime? dateOfCreationFrom = null,
            DateTime? dateOfCreationTo = null,
            DateTime? dateOfInstallationFrom = null,
            DateTime? dateOfInstallationTo = null)
            : base(i => (string.IsNullOrEmpty(equipment.Name) || i.Name.StartsWith(equipment.Name)) &&
             (string.IsNullOrEmpty(equipment.TypeId) || i.TypeId == equipment.TypeId) &&
             (string.IsNullOrEmpty(equipment.StatusId) || i.StatusId == equipment.StatusId) &&
             (string.IsNullOrEmpty(equipment.PlaceId) || i.PlaceId == equipment.PlaceId) &&
             (string.IsNullOrEmpty(equipment.OrganizationId) || i.OrganizationId == equipment.OrganizationId) &&
             (string.IsNullOrEmpty(equipment.EmployeeId) || i.EmployeeId == equipment.EmployeeId) &&
             (string.IsNullOrEmpty(equipment.InventoryNumber) || i.InventoryNumber.StartsWith(equipment.InventoryNumber)) &&
             (string.IsNullOrEmpty(equipment.SerialNumber) || i.SerialNumber.StartsWith(equipment.SerialNumber)) &&
             (!dateOfCreationFrom.HasValue || i.DateOfCreation >= dateOfCreationFrom) &&
             (!dateOfCreationTo.HasValue || i.DateOfCreation <= dateOfCreationTo) &&
             (!dateOfInstallationFrom.HasValue || i.DateOfCreation >= dateOfInstallationFrom) &&
             (!dateOfInstallationTo.HasValue || i.DateOfCreation <= dateOfInstallationTo))
        {
            ApplyInclude();

            ApplyPaging(skip, take);

            ApplyOrderBy(orderBy, isDescending);

        }

        private void ApplyInclude()
        {
            AddIncludes(query => query.Include(e => e.Place)
                .Include(e => e.SoftwareLicenses).ThenInclude(sl => sl.File)
                .Include(e => e.SoftwareLicenses).ThenInclude(sl => sl.Software)
                .Include(e => e.SoftwareLicenses).ThenInclude(sl => sl.Software).ThenInclude(s => s.Developer)
                .Include(e => e.SoftwareLicenses).ThenInclude(sl => sl.Type)
                .Include(e => e.SoftwareLicenses).ThenInclude(sl => sl.Organization)
                .Include(e => e.Status)
                .Include(e => e.Employee)
                .Include(e => e.Type)
                .Include(e => e.Organization)
                .Include(e => e.Disposal)
                .Include(e => e.WriteOff)
                .Include(e => e.File));
        }
    }
}