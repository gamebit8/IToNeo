using IToNeo.ApplicationCore.Entities;

namespace IToNeo.WebAPI.IntegrationEvents
{
    public record NewUserRegistredIntegrationEvent : IntegrationEvent
    {
        public string UserName { get; }
        public string Email { get; }
        public string ConfirmedEmailUrl { get; }
        public NewUserRegistredIntegrationEvent(string userName, string email, string confirmedEmailUrl) 
        { 
            UserName = userName; 
            Email = email; 
            ConfirmedEmailUrl = confirmedEmailUrl; 
        }
    }
}
