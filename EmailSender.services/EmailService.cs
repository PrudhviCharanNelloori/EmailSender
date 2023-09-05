using System.Net;
using System.Net.Mail;

namespace EmailSender.EmailSender.services
{
    public class EmailService
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;

        public EmailService(string host, int port, string username, string password)
        {
            smtpHost = host;
            smtpPort = port;
            smtpUsername = username;
            smtpPassword = password;
        }

        public void SendEmail(string to, string subject, string body, List<string> attachments = null)
        {
            using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage(smtpUsername, to, subject, body);
                mailMessage.IsBodyHtml = true;

                if (attachments != null)
                {
                    foreach (string attachmentPath in attachments)
                    {
                        mailMessage.Attachments.Add(new Attachment(attachmentPath));
                    }
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}