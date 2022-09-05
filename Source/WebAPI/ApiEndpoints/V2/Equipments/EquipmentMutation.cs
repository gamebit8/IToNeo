using GraphQL;
using GraphQL.Types;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.WebAPI.ApiEndpoints.V2.Equipments.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentMutation : ObjectGraphType
    {
        private readonly IChangeService _changeService;
        public EquipmentMutation(IChangeService changeService)
        {
            _changeService = changeService;
            FieldAsync<EquipmentGraphType>(
                "createEquipment",
                arguments: GetQueryArgumentsForCreate(),
                resolve: async context =>
                {
                    var equipment = CreateEquipmentFromQueryArguments(context);
                    await context.RequestServices.GetRequiredService<IAsyncRepository<Equipment>>().AddAsync(equipment);
                    return equipment;
                });

            FieldAsync<EquipmentGraphType>(
               "updateEquipment",
               arguments: GetQueryArgumentsForUpdate(),
               resolve: async context =>
               {
                   var repository = context.RequestServices.GetRequiredService<IAsyncRepository<Equipment>>();
                   var equipmentId = context.GetArgument<string>("id");
                   var newEquipmentData = CreateEquipmentFromQueryArguments(context);
                   var updatableEquipment = await repository.GetByIdAsync(equipmentId);

                   if (updatableEquipment is null) return default;

                   updatableEquipment.Update(newEquipmentData);   
                   await context.RequestServices.GetRequiredService<IAsyncRepository<Equipment>>().UpdateAsync(updatableEquipment);

                   var changeMessage = new EquipmentChangeMessage
                   {
                       EquipmentId = equipmentId,
                       User = "testuser",
                       UserId = "userID",
                       ChangedEquipment = newEquipmentData
                   };
                   _changeService.ChangeEquipment(changeMessage);
                   return updatableEquipment;
               });

            FieldAsync<BooleanGraphType>(
                "deleteEquipment",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<StringGraphType> { Name = "id" },
                }),
                resolve: async context =>
                {
                    var repository = context.RequestServices.GetRequiredService<IAsyncRepository<Equipment>>();
                    var id = context.GetArgument<string>("id");
                    var equipment = await repository.GetByIdAsync(id);

                    if (equipment is null) return false;

                    await repository.DeleteAsync(equipment);
                    return true;
                });
        }

        private static QueryArguments GetQueryArgumentsForCreate()
        {
            return new QueryArguments(GetBaseQueryArgumentsForUpdateAndCreate());
        }

        private static QueryArguments GetQueryArgumentsForUpdate()
        {
            var queryArguments = GetBaseQueryArgumentsForUpdateAndCreate();
            queryArguments.Add(new QueryArgument<StringGraphType> { Name = "id" });

            return new QueryArguments(queryArguments);
        }

        private static List<QueryArgument> GetBaseQueryArgumentsForUpdateAndCreate()
        {
            return new List<QueryArgument>
            {
                new QueryArgument<StringGraphType> { Name = "name" },
                new QueryArgument<StringGraphType> { Name = "typeId" },
                new QueryArgument<StringGraphType> { Name = "organizationId" },
                new QueryArgument<StringGraphType> { Name = "statusId" },
                new QueryArgument<StringGraphType> { Name = "placeId" },
                new QueryArgument<StringGraphType> { Name = "employeeId" },
                new QueryArgument<StringGraphType> { Name = "serialNumber" },
                new QueryArgument<StringGraphType> { Name = "note" },
                new QueryArgument<StringGraphType> { Name = "dateOfInstallation" },
            };
        }

        private Equipment CreateEquipmentFromQueryArguments(IResolveFieldContext context)
        {
            return new Equipment
            {
                Name = context.GetArgument<string>("name"),
                TypeId = context.GetArgument<string>("typeId"),
                OrganizationId = context.GetArgument<string>("organizationId"),
                StatusId = context.GetArgument<string>("statusId"),
                PlaceId = context.GetArgument<string>("placeId"),
                EmployeeId = context.GetArgument<string>("employeeId"),
                SerialNumber = context.GetArgument<string>("serialNumber"),
                Note = context.GetArgument<string>("note"),
                DateOfInstallation = context.GetArgument<DateTime>("dateOfInstallation"),
            };
        }
    }
}
