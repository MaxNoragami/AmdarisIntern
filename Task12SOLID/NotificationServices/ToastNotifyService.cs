using Task12SOLID.Entities;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Task12SOLID.NotificationServices;

public class ToastNotifyService : INotificationService
{
    public void SendNotification(User user, string message)
        => new ToastContentBuilder()
            .AddText("NotificationService")
            .AddText(message)
            .Show();
}
