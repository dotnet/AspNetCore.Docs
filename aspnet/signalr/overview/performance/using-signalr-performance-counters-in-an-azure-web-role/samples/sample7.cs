using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace WebRole1.Hubs
{
    public class MyHub : Hub
    {
        public async Task Increment(int x)
        {
            await this.Clients.Caller.sendResult(x + 1);
        }
    }
}