using GraphQL;
using GraphQL.Types;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.WebAPI.ApiEndpoints.V2.Equipments.Types;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentGraphType : ObjectGraphType<Equipment>
    {
        public EquipmentGraphType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.InventoryNumber);
            Field(e => e.SerialNumber);
            Field(e => e.Note);
            Field(e => e.DateOfCreation, nullable: true);
            Field(e => e.DateOfInstallation, nullable: true);
            Field(e => e.Type, type: typeof(EquipmentTypeGraphType))
                .Resolve(e => e.Source.Type)
                .Description("Type equipment");
            Field(e => e.Status, type: typeof(EquipmentStatusGraphType))
                .Resolve(e => e.Source.Status)
                .Description("Status equipment");
            Field(e => e.Place, type: typeof(PlaceGraphType))
                .Resolve(e => e.Source.Place)
                .Description("Location of equipment");
            Field(e => e.Organization, type: typeof(OrganizationGraphType))
                .Resolve(e => e.Source.Organization)
                .Description("The organization that owns the equipment");
            Field(e => e.Employee, type: typeof(EmployeeGraphType))
                .Resolve(e => e.Source.Employee)
                .Description("Person responsible for the equipment");
        }
    }
}