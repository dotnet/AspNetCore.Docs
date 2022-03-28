using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        // <HubMethods>
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task SendMessageToCaller(string user, string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }

        public Task SendMessageToGroup(string user, string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
        }
        // </HubMethods>

        // <HubMethodName>
        [HubMethodName("SendMessageToUser")]
        public Task DirectMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", user, message);
        }
        // </HubMethodName>

        // <ThrowHubException>
        public Task ThrowException()
        {
            throw new HubException("This error will be sent to the client!");
        }
        // </ThrowHubException>

        // <OnConnectedAsync>
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        // </OnConnectedAsync>

        // <OnDisconnectedAsync>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
        // </OnDisconnectedAsync>
    }
}
