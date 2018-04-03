using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
