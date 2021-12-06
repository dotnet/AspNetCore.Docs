using GenericHostSample.Services;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<HostApplicationLifetimeEventsHostedService>();
    })
    .Build()
    .RunAsync();
