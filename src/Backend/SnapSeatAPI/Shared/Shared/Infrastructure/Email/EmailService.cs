using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Shared.Application.Interfaces;
using Shared.Domain.Models;


namespace Shared.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly EmailSettings _emailSettings;

        public EmailService(IConfiguration config)
        {
            _config = config;
            _emailSettings = _config.GetSection("EmailSettings")
                .Get<EmailSettings>();
        }


        public async Task SendEmailAsync(string recipientEmail, string subject
            , string message)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailSettings.SenderEmail);
            email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;

            var builder = new BodyBuilder
            {
                TextBody = message
            };

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_emailSettings.SmtpServer
                , _emailSettings.SmtpPort
                , _emailSettings.UseSSL ?
                SecureSocketOptions.StartTls : SecureSocketOptions.Auto);
            await smtp.AuthenticateAsync(_emailSettings.Username
                , _emailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

    }
}