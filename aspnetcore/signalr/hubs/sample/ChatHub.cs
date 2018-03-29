using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);    
        }

        public Task SendMessageToOneConnection(string message)
        {
            return Clients.Client(Context.User.Identity.Name).SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToManyConnections(string message, List<string> connections)
        {          
            return Clients.Clients(connections).SendAsync("ReceiveMessage", message);
        }

        public override Task OnConnectedAsync()
        {
            Groups.AddAsync(Context.User.Identity.Name, "SignalR Users");
            return base.OnConnectedAsync();
        }
    }
}
