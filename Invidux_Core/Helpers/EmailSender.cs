using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Invidux_Core.Helpers
{
    public class EmailSender: IEmailSender
    {
        private readonly IConfiguration config;
        public EmailSender(IConfiguration config) 
        {
            this.config = config;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = config.GetSection("SendGrid:apiKey").Value;
            var sendGridEmail = config.GetSection("SendGrid:Email").Value;
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
        }
    }
}
