using Task12SOLID.Entities;

namespace Task12SOLID.NotificationServices;

public interface INotificationService
{
    public void SendNotification(User user, string message);
}
