using System.Net.Mail;
using System.Net;

namespace Task12SOLID.OtherServices;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
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

    public void SendMessage(string message, string toEmail)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(Environment.GetEnvironmentVariable("SMTP_USERNAME")!),
            Subject = "NotificationService",
            Body = message,
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
        if (!_disposed)
        {
            if (disposing)
                _smtpClient.Dispose();
            _disposed = true;
        }
    }

    ~EmailService()
    {
        Dispose(false);
    }
}
