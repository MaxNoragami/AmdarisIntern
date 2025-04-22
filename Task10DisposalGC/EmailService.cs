using System.Net;
using System.Net.Mail;
namespace Task10DisposalGC;

public class EmailService : IDisposable
{
    private readonly SmtpClient _smtpClient;
    private bool _disposed = false;
    private readonly string _smtpUsername;

    public EmailService()
    {
        _smtpUsername = Environment.GetEnvironmentVariable("SMTP_USERNAME") ?? 
            throw new ArgumentNullException("The username for the SMTP is 'null'");

        _smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(_smtpUsername,
                                                Environment.GetEnvironmentVariable("SMTP_PASSWORD")),
            EnableSsl = true
        };
    }

    public void SendMessage(string toEmail)
    {
        using var mailMessage = new MailMessage
        {
            From = new MailAddress(Environment.GetEnvironmentVariable(_smtpUsername)!),
            Subject = "Newsletter Subscription",
            Body = "<h1>Thank you!</h1>\n<p>Now you will receive weekly emails from our Newsletter! :)</p>",
            IsBodyHtml = true
        };
        mailMessage.To.Add(toEmail);
        _smtpClient.Send(mailMessage);
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
