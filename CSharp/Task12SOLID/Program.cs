using Task12SOLID;
using Task12SOLID.Entities;
using Task12SOLID.NotificationServices;
using Task12SOLID.OtherServices;

EnvReader.Load(".env");

var local = new User("Maxim", "Alexei", "yolo@gmail.com", "061234567");

INotificationService toastNotificationService = NotificationServiceFactory.Create(NotificationServiceType.ToastNotify);
INotificationService emailNotificationService = NotificationServiceFactory.Create(NotificationServiceType.EmailNotify);
INotificationService smsNotificationService = NotificationServiceFactory.Create(NotificationServiceType.SMSNotify);

toastNotificationService.SendNotification(local, $"{local.Name}, your package has been delivered!");
emailNotificationService.SendNotification(local, $"{local.Name}, your package has been delivered!");
smsNotificationService.SendNotification(local, $"{local.Name}, your package has been delivered!");