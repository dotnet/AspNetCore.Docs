using Microsoft.AspNetCore.SignalR;

namespace SignalRAuthenticationSample;

#region NameUserIdProvider
public class NameUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return connection.User?.Identity?.Name!;
    }
}
#endregion
