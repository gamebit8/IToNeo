using IToNeo.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace IToNeo.Infrastructure.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IAppLogger<EmailSender> _logger;
        public EmailSender(IAppLogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            _logger.LogInformation($"send mail {subject} to {email} with message: {message}");
            return Task.CompletedTask;
        }
    }
}
