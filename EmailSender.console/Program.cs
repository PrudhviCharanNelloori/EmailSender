

using EmailSender.EmailSender.services;

namespace EmailSender.EmailSender.console
{
    public class Program
    {
        static void Main(string[] args)
        {
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = Constants.SmtpUsername;
            string smtpPassword = Constants.SmtpPassword;

            EmailService emailService = new EmailService(smtpHost, smtpPort, smtpUsername, smtpPassword);

            Console.Write("Enter Email Id to Send Email: ");
            string to = Console.ReadLine();
            Console.Write("Enter Subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter body content: ");
            string content = Console.ReadLine();

            string templatePath = "C:\\Users\\Prudhvi.N\\Desktop\\New folder\\EmailSender\\EmailTemplates\\EmailTemplate.html"; // Relative path
            string htmlTemplate;

            if (File.Exists(templatePath))
            {
                htmlTemplate = File.ReadAllText(templatePath);
                string emailBody = htmlTemplate
                    .Replace("{subject}", subject)
                    .Replace("{title}", title)
                    .Replace("{content}", content);
                //List<string> attachments = new List<string>
                //    {
                //        "attachment1.pdf",
                //        "attachment2.png"
                //    };

                try
                {
                    emailService.SendEmail(to, subject, emailBody);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }
            else
            {
                Console.WriteLine("Email template file not found.");
            }
        }
    }

}
