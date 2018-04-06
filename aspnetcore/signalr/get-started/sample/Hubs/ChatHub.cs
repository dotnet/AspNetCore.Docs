using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRCoreChat.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            string timestamp = DateTime.Now.ToShortTimeString();
            return Clients.All.SendAsync("ReceiveMessage", timestamp, user, message);
        }
    }
}