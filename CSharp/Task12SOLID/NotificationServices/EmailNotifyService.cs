using Task12SOLID.Entities;
using Task12SOLID.OtherServices;

namespace Task12SOLID.NotificationServices;

public class EmailNotifyService : INotificationService
{
    private readonly IEmailService _emailService;

    public EmailNotifyService() 
        => _emailService = new EmailService();

    public void SendNotification(User user, string message)
    {
        using (_emailService)
        {
            try
            {
                _emailService.SendMessage(message, user.EmailAddress);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
