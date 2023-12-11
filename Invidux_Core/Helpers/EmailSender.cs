using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
//using SendGrid.Helpers.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Invidux_Domain.Models;
using Microsoft.Extensions.Options;

namespace Invidux_Core.Helpers
{
    public class EmailSender: IEmailSender
    {
        //private readonly Sendgrid sendGrid;
        private readonly MailSettings mailSettings;
        public EmailSender(IOptions<MailSettings> _mailSettings)
        {
            mailSettings = _mailSettings.Value;
        }

        /*public async Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = sendGrid.APIKey;
            var sendGridEmail = sendGrid.Email;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(sendGridEmail, "");
            var to = new EmailAddress(email, "User");
            var plainTextContent = "Verification";
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Body: {await response.Body.ReadAsStringAsync()}");
            Console.WriteLine($"Headers: {response.Headers}");
        }*/

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var host = mailSettings.Host;
            var port = mailSettings.Port;
            var mail = mailSettings.Mail;
            var displayName = mailSettings.DisplayName;
            var password = mailSettings.Password;
            var message = new MimeMessage();
            var myemailfrom = new MailboxAddress(displayName, mail);
            message.From.Add(myemailfrom);
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = "<html><body>" + htmlMessage + "</body></html>";
            message.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mail, password);
            await smtp.SendAsync(message);
            smtp.Disconnect(true);
        }
    }
}
