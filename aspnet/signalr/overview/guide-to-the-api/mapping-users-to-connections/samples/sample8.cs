using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.AspNet.SignalR;

namespace MapUsersSample
{
    [Authorize]
    public class ChatHub : Hub
    {
        public void SendChatMessage(string who, string message)
        {
            var name = Context.User.Identity.Name;
            using (var db = new UserContext())
            {
                var user = db.Users.Find(who);
                if (user == null)
                {
                    Clients.Caller.showErrorMessage("Could not find that user.");
                }
                else
                {
                    db.Entry(user)
                        .Collection(u => u.Connections)
                        .Query()
                        .Where(c => c.Connected == true)
                        .Load();

                    if (user.Connections == null)
                    {
                        Clients.Caller.showErrorMessage("The user is no longer connected.");
                    }
                    else
                    {
                        foreach (var connection in user.Connections)
                        {
                            Clients.Client(connection.ConnectionID)
                                .addChatMessage(name + ": " + message);
                        }
                    }
                }
            }
        }

        public override Task OnConnected()
        {
            var name = Context.User.Identity.Name;
            using (var db = new UserContext())
            {
                var user = db.Users
                    .Include(u => u.Connections)
                    .SingleOrDefault(u => u.UserName == name);
                
                if (user == null)
                {
                    user = new User
                    {
                        UserName = name,
                        Connections = new List<Connection>()
                    };
                    db.Users.Add(user);
                }

                user.Connections.Add(new Connection
                {
                    ConnectionID = Context.ConnectionId,
                    UserAgent = Context.Request.Headers["User-Agent"],
                    Connected = true
                });
                db.SaveChanges();
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            using (var db = new UserContext())
            {
                var connection = db.Connections.Find(Context.ConnectionId);
                connection.Connected = false;
                db.SaveChanges();
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}