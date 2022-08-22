namespace todo_group.Services
{
    public class EmailService : IEmailService
    {
        public Task Send(string emaidAddress, string body)
        {
            // Code for sending mails to a configured host
            return Task.CompletedTask;
        }
    }
}
