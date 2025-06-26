### Automatic eviction from memory pool

The memory pools used by Kestrel, IIS, and HTTP.ss now automatically evict memory blocks when the application is idle or under less load. The feature does not need to be enabled or configured manually. it runs automatically

#### Why memory eviction matters

Previously, memory allocated by the pool would remain reserved, even when not in use. This feature releases memory back to the system when the app is idle for a period of time. This eviction reduces overall memory usage and helps applications stay responsive under varying workloads.

#### Memory eviction metrics

Metrics have been added to the default memory pool used by our server implementations. The new metrics are under the name `"Microsoft.AspNetCore.MemoryPool"`.

For information about metrics and how to use them, <xref:log-mon/metrics/metrics>.

We have also enabled the ability to use:
```csharp
public class MyBackgroundService : BackgroundService
{
    private readonly MemoryPool<byte> _memoryPool;

    public MyBackgroundService(IMemoryPoolFactory<byte> factory)
    {
        _memoryPool = factory.CreatePool();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(20, stoppingToken);
                // do work that needs memory
                var rented = _memoryPool.Rent(100);
                rented.Dispose();
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}
```

or replace the memory pool being used:
```csharp
services.AddSingleton<IMemoryPoolFactory<byte>, CustomMemoryPoolFactory>();

public class CustomMemoryPoolFactory : IMemoryPoolFactory<byte>
{
    public MemoryPool<byte> Create()
    {
        // Return a custom MemoryPool implementation or the default.
        return MemoryPool<byte>.Shared;
    }
}
```
