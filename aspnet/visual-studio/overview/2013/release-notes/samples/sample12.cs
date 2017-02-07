using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
public class ChatHub : Hub
{
    static List<string> ConnectionIds = new List<string>();
    static List<string> groups = new List<string> { "chatGroup", "chatGroup2" };
    public void Send(string name, string message)
    {
        // Call the broadcastMessage method to update clients.
        Clients.Clients(ConnectionIds).broadcastMessage(name, message);
        Clients.Groups(groups).broadcastMessage(name, message);
    }
    public override System.Threading.Tasks.Task OnConnected()
    {
        ConnectionIds.Add(Context.ConnectionId);
        Groups.Add(Context.ConnectionId, "chatGroup");
        return base.OnConnected();
    }
    public override System.Threading.Tasks.Task OnDisconnected()
    {
        ConnectionIds.Remove(Context.ConnectionId);
        return base.OnDisconnected();
    }
}