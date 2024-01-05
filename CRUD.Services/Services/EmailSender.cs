using CRUD.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace CRUD.Services.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        
        public EmailSender(IConfiguration config )
        {
            _config = config;
           
        }
        public void SendEmail(string to, string subject, string plainTextBody, string htmlBody)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailAddress").Value));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

          
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = plainTextBody;
            bodyBuilder.HtmlBody = htmlBody;

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }


    }
}
