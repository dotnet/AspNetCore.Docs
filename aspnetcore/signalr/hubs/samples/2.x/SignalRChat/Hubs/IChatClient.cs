using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    // <snippet_IChatClient>
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
    }
    // </snippet_IChatClient>
}
