stockTickerHub.On<Stock>("notify", () =>
    // Context is a reference to SynchronizationContext.Current
    Context.Post(delegate
    {
        textBox.Text += "Notified!";
    }, null)
);