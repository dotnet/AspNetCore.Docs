namespace GenericHostSample.Services;

public class SampleHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
