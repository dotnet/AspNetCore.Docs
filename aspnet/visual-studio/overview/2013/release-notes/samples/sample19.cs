[Fact]
public interface IClientContract
{
    void send(string message);
}
public void HubsAreMockableViaType()
{
    var hub = new MyHub();
    var mockClients = new Mock<IHubCallerConnectionContext>();
    var all = new Mock<IClientContract>();
    hub.Clients = mockClients.Object;
    all.Setup(m => m.send(It.IsAny<string>())).Verifiable();
    mockClients.Setup(m => m.All).Returns(all.Object);
    hub.Send("foo");
    all.VerifyAll();