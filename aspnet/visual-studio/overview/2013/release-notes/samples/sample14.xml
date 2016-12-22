public class MyHub : Hub
{
    public void Send(string userId, string message)
    {
        Clients.User(userId).send(message);
    }
}