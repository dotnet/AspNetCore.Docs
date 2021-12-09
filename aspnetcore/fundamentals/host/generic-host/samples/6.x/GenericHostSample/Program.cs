using GenericHostSample.Services;

// <snippet_Host>
await Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SampleHostedService>();
    })
    .Build()
    .RunAsync();
// </snippet_Host>
