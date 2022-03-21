using HubServiceInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace Server;

#region ClockHub
public class ClockHub : Hub<IClock>
{
    public async Task SendTimeToClients(DateTime dateTime)
    {
        await Clients.All.ShowTime(dateTime);
    }
}
#endregion
