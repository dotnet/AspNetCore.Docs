using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public Task SendMessageToAll(string user, string message)
        {
            var timestamp = DateTime.Now.ToShortDateString();
            return Clients.All.SendAsync("ReceiveMessage", timestamp, user, message);           
        }
        public Task SendMessageToSingleConnection(string user, string message, string connection)
        {
            var timestamp = DateTime.Now.ToShortDateString();
            return Clients.Client(connection).SendAsync("ReceiveMessage", timestamp, user, message, connection);
        }
        public Task SendMessageToMultipleConnections(string user, string message, List<string> connections)
        {          
            var timestamp = DateTime.Now.ToShortDateString();
            return Clients.Clients(connections.ToArray()).SendAsync("ReceiveMessage", timestamp, user, message);
        }
        public Task SendMessageToGroup(string user, string message, string group)
        {
            var timestamp = DateTime.Now.ToShortDateString();
            return Clients.Group(group).SendAsync("ReceiveMessage", timestamp, user, message, group);
        }


        private string _connectionID;
        public override Task OnConnectedAsync()
        { 
            _connectionID = Context.ConnectionId;
            return base.OnConnectedAsync();
        }
        private void JoinGroup(string connection, string group)
        {
            Groups.AddAsync(connection, group);
        }
    }
}
