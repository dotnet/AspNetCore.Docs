using todo_group.Services;

namespace MinApiTests.IntegrationTests.Helpers
{
    public class TestEmailService : IEmailService
    {
        public Task Send(string emaidAddress, string body)
        {
            // You don't want to send real email when running integration tests
            return Task.CompletedTask;
        }
    }
}
