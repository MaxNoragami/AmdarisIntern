using Task12SOLID.NotificationServices;

namespace Task12SOLID;

public static class NotificationServiceFactory
{
    public static INotificationService Create(NotificationServiceType notificationServiceType) =>
        notificationServiceType switch
        {
            NotificationServiceType.EmailNotify => new EmailNotifyService(),
            NotificationServiceType.SMSNotify => new SMSNotifyService(),
            NotificationServiceType.ToastNotify => new ToastNotifyService(),
            _ => throw new NotSupportedException($"Invalid Notification Service {notificationServiceType}")
        };
}
