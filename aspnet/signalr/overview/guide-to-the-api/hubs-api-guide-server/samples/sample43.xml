public class ContosoChatHub : Hub
{
    public Task JoinGroup(string groupName)
    {
        return Groups.Add(Context.ConnectionId, groupName);
    }

    public Task LeaveGroup(string groupName)
    {
        return Groups.Remove(Context.ConnectionId, groupName);
    }
}