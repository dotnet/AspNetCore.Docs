using System.Threading.Tasks;

public interface IChatClient
{
    Task ReceiveMessage(string user, string message);
    Task ReceiveMessage(string message);
}