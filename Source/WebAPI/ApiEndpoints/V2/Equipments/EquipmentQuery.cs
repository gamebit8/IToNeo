using GraphQL;
using GraphQL.Types;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V2.Equipments.Types;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using IToNeo.ApplicationCore.Specifications;
using IToNeo.ApplicationCore.Constants;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentQuery : ObjectGraphType
    {
        public EquipmentQuery()
        {
            this.AuthorizeWithPolicy("GraphQLRW");
            FieldAsync<ListGraphType<EquipmentGraphType>>(
                "equipments",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "name"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "typeId"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "statusId"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "placeId"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "organizationId"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "employeeId"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "inventoryNumber"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "serialNumber"
                    },
                    new QueryArgument<IntGraphType>
                    {
                        Name = "skip"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "orderBy"
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "isDescending"
                    },
                }),
                resolve: async context =>
                {
                    var equipment = new Equipment
                    {
                        Name = context.GetArgument<string>("name"),
                        TypeId = context.GetArgument<string>("typeId"),
                        StatusId = context.GetArgument<string>("statusId"),
                        PlaceId = context.GetArgument<string>("placeId"),
                        OrganizationId = context.GetArgument<string>("organizationId"),
                        EmployeeId = context.GetArgument<string>("employeeId"),
                        InventoryNumber = context.GetArgument<string>("inventoryNumber"),
                        SerialNumber = context.GetArgument<string>("serialNumber"),
                    };   
                    int take = 100;
                    int skip = context.GetArgument<int>("skip");
                    var orderBy = context.GetArgument<string>("orderBy");
                    var isDescending = context.GetArgument<bool>("isDescending");

                    var equipmentSpetification = new EquipmentWithSpecification(skip, take, equipment, orderBy, isDescending);

                    return await context.RequestServices.GetRequiredService<IReadOnlyAsyncRepository<Equipment>>().ListAsync(equipmentSpetification);
                });

            FieldAsync<EquipmentGraphType>(
                "equipment",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<StringGraphType>{Name = "id"},
                }),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var repository = context.RequestServices.GetRequiredService<IReadOnlyAsyncRepository<Equipment>>();
                    var equipmentSpecification = new EquipmentWithSpecification(id);

                    var equipments = await repository.ListAsync(equipmentSpecification);
                    var equipment = equipments.FirstOrDefault();

                    return equipment ?? default;
                });
        }
    }
}
