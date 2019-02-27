var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/my/hub/url")
    .ConfigureLogging(logging =>
    {
        // Register your providers

        // Set the default log level to Information, but to Debug for SignalR-related loggers.
        logging.SetMinimumLevel(LogLevel.Information);
        logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
        logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);
    })
    .Build();