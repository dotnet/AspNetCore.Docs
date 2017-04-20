[Fact]
public void HubsAreMockableViaDynamic()
{
    bool sendCalled = false;
    var hub = new MyHub();
    var mockClients = new Mock<IHubCallerConnectionContext>();
    hub.Clients = mockClients.Object;
    dynamic all = new ExpandoObject();
    all.send = new Action<string>(message =>
    {
        sendCalled = true;
    });
    mockClients.Setup(m => m.All).Returns((ExpandoObject)all);
    hub.Send("foo");
    Assert.True(sendCalled);
}