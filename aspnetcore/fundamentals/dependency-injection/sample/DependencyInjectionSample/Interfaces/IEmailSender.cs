using System.Threading.Tasks;

namespace DependencyInjectionSample.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
