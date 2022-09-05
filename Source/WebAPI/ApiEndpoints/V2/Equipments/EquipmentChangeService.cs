using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentChangeService : IChangeService
    {
        private readonly ISubject<EquipmentChangeMessage> _messageStream = new ReplaySubject<EquipmentChangeMessage>();
        
        public EquipmentChangeService()
        {

        }

        public bool ChangeEquipment(EquipmentChangeMessage message)
        {
            _messageStream.OnNext(message);
            return true;
        }

        public IObservable<EquipmentChangeMessage> Message()
        {
            return _messageStream.AsObservable();
        }
    }
}
