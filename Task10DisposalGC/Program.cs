using Task10DisposalGC;

EnvReader.Load(".env");

using(var emailService = new EmailService())
{
    try
    {
        emailService.SendMessage(Environment.GetEnvironmentVariable("SMTP_TO_EMAIL")!);
    }
    catch(ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}