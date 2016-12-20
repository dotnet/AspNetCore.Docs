public class ContosoChatHub : Hub
{
    public Task JoinRoom(string roomName)
    {
        return Groups.Add(Context.ConnectionId, roomName);
    }

    public Task LeaveRoom(string roomName)
    {
        return Groups.Remove(Context.ConnectionId, roomName);
    }
}