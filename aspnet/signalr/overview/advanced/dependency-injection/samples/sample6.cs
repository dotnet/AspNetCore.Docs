public interface IChatRepository
{
    void Add(string name, string message);
    // Other methods not shown.
}

public class ChatHub : Hub
{
    private IChatRepository _repository;

    public ChatHub(IChatRepository repository)
    {
        _repository = repository;
    }

    public void Send(string name, string message)
    {
        _repository.Add(name, message);
        Clients.All.addMessage(name, message);
    }