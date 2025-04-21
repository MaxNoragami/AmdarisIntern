using Task12SOLID.Entities;

namespace Task12SOLID.NotificationServices;

public class SMSNotifyService : INotificationService
{
    public void SendNotification(User user, string message)
        => Console.WriteLine($"SMS sent to {user.PhoneNum}.\nContent: {message}");
}
