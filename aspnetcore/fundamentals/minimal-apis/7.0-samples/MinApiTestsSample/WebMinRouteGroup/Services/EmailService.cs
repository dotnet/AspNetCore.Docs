namespace WebMinRouteGroup.Services;

public class EmailService : IEmailService
{
    public Task Send(string emailAddress, string body)
    {
        // Code for sending mails to a configured host
        return Task.CompletedTask;
    }
}
