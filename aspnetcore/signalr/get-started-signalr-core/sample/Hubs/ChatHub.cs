using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
       public Task Send(string user, string message)
        {
            string timestamp = DateTime.Now.ToShortTimeString();            
            return Clients.All.InvokeAsync("Send", timestamp, user, message);
        }
    }
}