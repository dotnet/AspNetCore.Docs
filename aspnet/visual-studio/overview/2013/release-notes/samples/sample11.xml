using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
public class ChatConnection : PersistentConnection
{
    static List<string> ConnectionIds = new List<string>();
    static List<string> groups = new List<string>{"chatGroup", "chatGroup2"};
    protected override System.Threading.Tasks.Task OnReceived(IRequest request, string connectionId, string data)
    {
        Connection.Send(ConnectionIds, data);
        Groups.Send(groups, data);
        return base.OnReceived(request, connectionId, data);
    }
    protected override System.Threading.Tasks.Task OnConnected(IRequest request, string connectionId)
    {
        ConnectionIds.Add(connectionId);
        Groups.Add(connectionId, "chatGroup");
        return base.OnConnected(request, connectionId);
    }
    protected override System.Threading.Tasks.Task OnDisconnected(IRequest request, string connectionId)
    {
        ConnectionIds.Remove(connectionId);
        return base.OnDisconnected(request, connectionId);
    }
}