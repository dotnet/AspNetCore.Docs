public class StrongHub : Hub<IClient>
{
    public async Task Send(string message)
    {
        await Clients.All.NewMessage(message);
    }
}

public interface IClient
{
    Task NewMessage(string message);
}
