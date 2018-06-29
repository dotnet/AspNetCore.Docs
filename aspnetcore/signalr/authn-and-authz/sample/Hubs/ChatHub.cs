using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRAuthenticationSample.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveSystemMessage", $"{Context.User.Identity.Name} joined.");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("ReceiveSystemMessage", $"{Context.User.Identity.Name} left.");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendToUser(string user, string message)
        {
            await Clients.User(user).SendAsync("ReceiveDirectMessage", $"{Context.User.Identity.Name}: {message}");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("ReceiveChatMessage", $"{Context.User.Identity.Name}: {message}");
        }
    }
}
