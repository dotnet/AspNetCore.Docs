public void JoinRoom(string roomName)
{
    (Groups.Add(Context.ConnectionId, roomName) as Task).ContinueWith(antecedent =>
      Clients.Group(roomName).addChatMessage(Context.User.Identity.Name + " joined."));
}