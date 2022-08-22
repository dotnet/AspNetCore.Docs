namespace todo_group.Services
{
    public interface IEmailService
    {
        Task Send(string emaidAddress, string body);
    }
}
