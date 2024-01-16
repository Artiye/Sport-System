using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sport_System.Application.Utility.Interfaces;
using Sport_System.Application.Utility.Options;

namespace Sport_System.Application.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _options;
        public EmailSender(IOptions<EmailOptions> options)
        {
            _options = options.Value;
        }

        public async Task SendEmailAsync(string toAddress, string subject, string bodyMessage)
        {
            string fromMail = _options.FromMail;
            string fromPassword = _options.FromPassword;
            string host = _options.Host;
            int port = _options.Port;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.To.Add(new MailAddress(toAddress));
            message.Subject = subject;
            message.Body = bodyMessage;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.SendMailAsync(message);
        }
    }
}
