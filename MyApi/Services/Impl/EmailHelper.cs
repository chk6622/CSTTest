using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MyApi.Services.Impl
{
    /// <summary>
    /// This class implements IEmailhelper.
    /// In the future, we can refactor it using message queue.
    /// </summary>
    public class EmailHelper : IEmailHelper
    {
        private readonly string from = "mytestxt@gmail.com";
        private readonly string password = "xhy_121230";
        private readonly string subject = "Verification Code";
        private readonly string host = "smtp.gmail.com";
        private readonly int port = 587;

        public bool SendEmail(string emailAddress, string message)
        {
            bool sendState = false;

            if (!string.IsNullOrWhiteSpace(emailAddress) && !string.IsNullOrWhiteSpace(message))
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(emailAddress);
                msg.From = new MailAddress(from, "Ethan", Encoding.UTF8);
                msg.Subject = subject;
                msg.SubjectEncoding = Encoding.UTF8;
                msg.Body = message;
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = false;
                msg.Priority = MailPriority.High;

                var client = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(from, password),
                };

                try
                {
                    client.SendAsync(msg, new { });  //send email.
                    sendState = true;
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return sendState;
        }
    }
}
