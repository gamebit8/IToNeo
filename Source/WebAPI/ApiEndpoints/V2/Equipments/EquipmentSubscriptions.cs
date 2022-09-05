using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Reactive.Linq;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentSubscriptions : ObjectGraphType
    {
        private readonly IChangeService _changeService;
        public EquipmentSubscriptions(IChangeService changeService)
        {
            _changeService = changeService;

            AddField(new FieldType
            {
                Name = "changedEquipment",
                Arguments = new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
                Type = typeof(EquipmentChangeMessageType),
                Resolver = new FuncFieldResolver<EquipmentChangeMessage>(ResolveMessage),
                StreamResolver = new SourceStreamResolver<EquipmentChangeMessage>(SubscribeById)
            });
        }

        private EquipmentChangeMessage ResolveMessage(IResolveFieldContext context)
        {
            var message = context.Source as EquipmentChangeMessage;

            return message;
        }

        private IObservable<EquipmentChangeMessage> SubscribeById(IResolveFieldContext context)
        {
            var equipmentId = context.GetArgument<string>("id");
            return _changeService.Message().Where(x => x.EquipmentId == equipmentId);
        }
    }
}
