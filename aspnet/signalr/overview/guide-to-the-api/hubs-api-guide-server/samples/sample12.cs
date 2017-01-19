public class StrongHub : Hub<IClient>
{
    public void Send(string message)
    {
        Clients.All.NewMessage(message);
    }
}

public interface IClient
{
    void NewMessage(string message);
}