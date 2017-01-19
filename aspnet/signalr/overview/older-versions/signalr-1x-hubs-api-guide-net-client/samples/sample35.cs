stockTickerHub.On<Stock>("notify", () =>
    Dispatcher.InvokeAsync(() =>
        {
            SignalRTextBlock.Text += string.Format("Notified!");
        })
);