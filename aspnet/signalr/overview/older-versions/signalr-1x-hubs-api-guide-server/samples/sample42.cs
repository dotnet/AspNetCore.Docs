public void JoinGroup(string groupName)
{
    (Groups.Add(Context.ConnectionId, groupName) as Task).ContinueWith(antecedent =>
        Clients.Group(groupName).addContosoChatMessageToPage(Context.ConnectionId + " added to group"));
}