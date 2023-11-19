using System.Net;
using API.Controllers;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API;
using Hangfire;
using Hangfire.SqlServer;
using System.Net.Mail;
public class HangFireScheduler
{
    private static IList<string> emailsToSend = new List<string>();

    public static void sendEmails()
    {
        SmtpClient smtpClient = createSMTPClient();
        MailMessage mailMessage = new MailMessage();
        
        mailMessage.From = new MailAddress("manueldocs512@gmail.com");
        mailMessage.Subject = "Recordatorio";
        mailMessage.Body = "Recuerda llenar el formulario de datos!";
        foreach (string mail in emailsToSend)
        {
            mailMessage.To.Add(mail);
            Console.WriteLine(mail);
        }
        smtpClient.Send(mailMessage);
    }
    public static void getEmailsForNotification(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataInfo>();
        optionsBuilder.UseSqlServer(connectionString);
        DataInfo context = new DataInfo(optionsBuilder.Options);
        
        try
        { 
            emailsToSend = context.funcionarios.FromSqlRaw($"Select distinct Email from dbo.Funcionarios f inner join dbo.Actualizacion_funcionario a on a.CI = f.CI where a.completado = 0").Select(f => f.Email).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine(emailsToSend.ToString());
    }
    private static SmtpClient createSMTPClient()
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("manuel5mongelos@gmail.com", "aebxoidveufiwczf");
        return smtpClient;
    }
    
}