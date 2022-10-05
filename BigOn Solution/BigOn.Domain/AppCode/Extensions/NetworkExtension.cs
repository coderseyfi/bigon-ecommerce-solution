using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        static public bool SendMail(this IConfiguration configuration, string toEmail, string textBody, string subject)
        {
            try
            {
                string userName = configuration["emailAccount:userName"];
                string password = configuration["emailAccount:password"];
                string smtpHostName = configuration["emailAccount:smtpServer"];
                int smtpPort = Convert.ToInt32(configuration["emailAccount:smtpPort"]);

                SmtpClient client = new SmtpClient(smtpHostName, smtpPort);
                client.EnableSsl = true;

                client.Credentials = new NetworkCredential(userName, password);

                MailAddress from = new MailAddress(userName, "BigOn Info Service");
                MailAddress to = new MailAddress(toEmail);

                MailMessage message = new MailMessage(from, to);

                message.Subject = subject;
                message.Body = textBody;
                message.IsBodyHtml = true;

                client.Send(message);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
