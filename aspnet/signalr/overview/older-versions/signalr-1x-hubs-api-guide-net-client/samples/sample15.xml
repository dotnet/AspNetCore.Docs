var hubConnection = new HubConnection("http://www.contoso.com/");
IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("StockTickerHub");
stockTickerHub.On("notify", () =>
    // Context is a reference to SynchronizationContext.Current
    Context.Post(delegate
    {
        textBox.Text += "Notified!\n";
    }, null)
);
await hubConnection.Start();