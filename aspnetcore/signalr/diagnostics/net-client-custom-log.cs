var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/my/hub/url")
    .ConfigureLogging(logging =>
    {
        // Log to your custom provider
        logging.AddProvider(new MyCustomLoggingProvider());

        // This will set ALL logging to Debug level
        logging.SetMinimumLevel(LogLevel.Debug)
    })
    .Build();