using System.Net;

namespace API;
using Hangfire;
using Hangfire.SqlServer;
using System.Net.Mail;
public class HangFireScheduler
{
    public static void ScheduleFire()
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("manuel5mongelos@gmail.com", "aebxoidveufiwczf");
        
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("manueldocs512@gmail.com");
        mailMessage.To.Add("manueldocs512@gmail.com");
        mailMessage.Subject = "Hello from .NET";
        mailMessage.Body = "This is a test email sent through Gmail SMTP in .NET.";
        smtpClient.Send(mailMessage);
        
        Console.WriteLine("Enviado!");
    }
}