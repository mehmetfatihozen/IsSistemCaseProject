namespace IsSistemCase.Core.Services
{
    public interface IEmailService
    {
        Task SendEmail(string recipient, string subject, string message);
    }
}
