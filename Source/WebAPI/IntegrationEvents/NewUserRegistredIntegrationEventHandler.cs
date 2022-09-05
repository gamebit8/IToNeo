using IToNeo.ApplicationCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.IntegrationEvents
{
    public class NewUserRegistredIntegrationEventHandler : IIntegrationEventHandler<NewUserRegistredIntegrationEvent>
    {
        private readonly IEmailSender _emailSender;
        public NewUserRegistredIntegrationEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task Handle(NewUserRegistredIntegrationEvent @event)
        {
            await _emailSender.SendEmailAsync(@event.Email, "confirm email", @event.ConfirmedEmailUrl);
        }
    }
}
