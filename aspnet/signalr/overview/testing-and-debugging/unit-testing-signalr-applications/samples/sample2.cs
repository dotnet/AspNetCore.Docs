using Xunit;
using SignalRChat;
using Microsoft.AspNet.SignalR.Hubs;
using Moq;

namespace TestLibrary
{
    public class Tests
    {
       
       public interface IClientContract
       {
           void broadcastMessage(string name, string message);
       }
       [Fact]
       public void HubsAreMockableViaType()
       {
           var hub = new ChatHub();
           var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
           var all = new Mock<IClientContract>();
           hub.Clients = mockClients.Object;
           all.Setup(m => m.broadcastMessage(It.IsAny<string>(), 
           		It.IsAny<string>())).Verifiable();
           mockClients.Setup(m => m.All).Returns(all.Object);
           hub.Send("TestUser", "TestMessage");
           all.VerifyAll();
       }
    }
}