using System.Threading.Tasks;

namespace DependencyInjectionSample.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
