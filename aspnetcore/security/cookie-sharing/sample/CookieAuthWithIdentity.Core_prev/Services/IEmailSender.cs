using System.Threading.Tasks;

namespace CookieAuthWithIdentityCore.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
