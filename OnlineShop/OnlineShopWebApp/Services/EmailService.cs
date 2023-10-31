using MailKit;
using MimeKit;
using System.Net.Mail;

namespace OnlineShopWebApp.Services
{
    public class EmailService : IMailService
    {
        private readonly MailSettings mailSettings;

        public EmailService(IOptions<MailService> mailSettings)
        {
            this.mailSettings = mailSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            emailMessage.To.Add(new MailboxAddress(_mailSettings.DisplayName, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_mailSettings.Host, _mailSetting.Port);
                await client.AuthenticateAsync(_mailSettings.Mail, _mailSetting.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
