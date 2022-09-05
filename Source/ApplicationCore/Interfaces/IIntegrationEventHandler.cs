using IToNeo.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace IToNeo.ApplicationCore.Interfaces
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
        {
            Task Handle(TIntegrationEvent @event);
        }

    public interface IIntegrationEventHandler
    {

    }
}
