using System.Threading.Tasks;

namespace IToNeo.Infrastructure.EventBus
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
