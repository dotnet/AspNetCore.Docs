using System.Threading.Tasks;

#region snippet_IChatClient
public interface IChatClient
{
    Task ReceiveMessage(string user, string message);
    Task ReceiveMessage(string message);
}
#endregion