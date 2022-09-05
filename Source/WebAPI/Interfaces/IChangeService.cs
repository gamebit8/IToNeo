using System;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public interface IChangeService
    {
        bool ChangeEquipment(EquipmentChangeMessage message);
        IObservable<EquipmentChangeMessage> Message();
    }
}
