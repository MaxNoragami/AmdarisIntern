using System.Net;
using System.Net.Mail;
namespace Task10DisposalGC;

public class EmailService : IDisposable
{
    private SmtpClient _smtpClient;
    private bool _disposed = false;

    public EmailService()
    {
        _smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("SMTP_USERNAME"),
                                                Environment.GetEnvironmentVariable("SMTP_PASSWORD")),
            EnableSsl = true
        };
    }

    public void SendMessage(string toEmail)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(Environment.GetEnvironmentVariable("SMTP_USERNAME")!),
            Subject = "Newsletter Subscription",
            Body = "<h1>Thank you!</h1>\n<p>Now you will receive weekly emails from our Newsletter! :)</p>",
            IsBodyHtml = true
        };
        mailMessage.To.Add(toEmail);
        _smtpClient.Send(mailMessage);
        mailMessage.Dispose();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if(!_disposed)
        {
            if(disposing)
                _smtpClient.Dispose();
            _disposed = true;
        }    
    }

    ~EmailService()
    {
        Dispose(false);
    }
}
