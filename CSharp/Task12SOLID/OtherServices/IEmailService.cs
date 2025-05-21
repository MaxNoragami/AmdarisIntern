namespace Task12SOLID.OtherServices;

public interface IEmailService : IDisposable
{
    public void SendMessage(string message, string toEmail);
}
