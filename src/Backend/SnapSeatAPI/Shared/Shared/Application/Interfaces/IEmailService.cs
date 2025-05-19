namespace Shared.Application.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string recipientEmail, string subject
            , string message);
    }
}
