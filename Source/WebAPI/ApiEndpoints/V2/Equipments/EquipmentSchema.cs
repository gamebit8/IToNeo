using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.WebAPI.ApiEndpoints.V2.Equipments;
using IToNeo.ApplicationCore.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentSchema : GraphQL.Types.Schema
    {
        public EquipmentSchema(IChangeService changeService, IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<EquipmentQuery>();
            Mutation = provider.GetRequiredService<EquipmentMutation>();
            Subscription = provider.GetRequiredService<EquipmentSubscriptions>();
        }
    }
}
