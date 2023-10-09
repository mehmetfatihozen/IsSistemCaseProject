using IsSistemCase.Core.Models.Options;
using IsSistemCase.Core.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace IsSistemCase.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendEmail(string recipient, string subject, string message)
        {
            var smtpClient = new SmtpClient
            {
                Host = _emailSettings.Host,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(recipient);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
