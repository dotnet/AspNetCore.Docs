using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace BasicChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        public void SendChatMessage(string who, string message)
        {
            string name = Context.User.Identity.Name;

            Clients.Group(who).addChatMessage(name + ": " + message);
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }
    }
}