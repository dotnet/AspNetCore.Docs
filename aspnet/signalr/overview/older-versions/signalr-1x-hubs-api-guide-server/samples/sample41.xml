async public Task JoinGroup(string groupName)
{
    await Groups.Add(Context.ConnectionId, groupName);
    Clients.Group(groupname).addContosoChatMessageToPage(Context.ConnectionId + " added to group");
}