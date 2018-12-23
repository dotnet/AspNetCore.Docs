#region ParameterBasedOldVersion
public async Task<string> GetTotalLength(string param1)
{
    return param1.Length;
}
#endregion

#region ParameterBasedNewVersion
public async Task<string> GetTotalLength(string param1, string param2)
{
    return param1.Length + param2.Length;
}
#endregion

#region ObjectBasedOldVersion
public class TotalLengthRequest
{
    public string Param1 { get; set; }
}

public async Task GetTotalLength(TotalLengthRequest req)
{
    return req.Param1.Length;
}
#endregion

#region ObjectBasedNewVersion
public class TotalLengthRequest
{
    public string Param1 { get; set; }
    public string Param2 { get; set; }
}

public async Task GetTotalLength(TotalLengthRequest req)
{
    var length = req.Param1.Length;
    if (req.Param2 != null)
    {
        length += req.Param2.Length;
    }
    return length;
}
#endregion

#region ClientSideObjectBasedOld
public async Task Broadcast(string message)
{
    await Clients.All.SendAsync("ReceiveMessage", new
    {
        Message = message
    });
}
#endregion

#region ClientSideObjectBasedNew
public async Task Broadcast(string message)
{
    await Clients.All.SendAsync("ReceiveMessage", new
    {
        Sender = Context.User.Identity.Name,
        Message = message
    });
}
#endregion

#region StringlyTyped
public async Task Broadcast(string message)
{
    await Clients.All.SendAsync("ReceiveMessage", new
    {
        Sender = Context.User.Identity.Name,
        Message = message
    });
}
#endregion

#region ClientInterface
public class ChatHubMessage
{
    public string Sender { get; set; }
    public string Message { get; set; }
}

public interface IChatHubClient
{
    Task ReceiveMessage(ChatHubMessage message);
}
#endregion

#region ClientInterfaceHub
public class ChatHub : Hub<IChatHubClient>
{
    public async Task Broadcast(string message)
    {
        await Clients.Add.ReceiveMessage(new ChatHubMessage()
        {
            Sender = Context.User.Identity.Name,
            Message = message
        });
    }
}
#endregion