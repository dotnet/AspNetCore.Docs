using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace WebRole1.PersistentConnections
{
    public class MyPersistentConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            //Return data to calling user
            return Connection.Send(connectionId, data);        
        }
    }
}