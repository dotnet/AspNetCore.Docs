namespace WebMinRouteGroup.Services;

public interface IEmailService
{
    Task Send(string emailAddress, string body);
}
