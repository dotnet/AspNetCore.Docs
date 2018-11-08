public async Task JoinGroup(string groupName)
{
    await Groups.Add(Context.ConnectionId, groupName);
    await Clients.Group(groupname).addContosoChatMessageToPage(Context.ConnectionId + " added to group");
}