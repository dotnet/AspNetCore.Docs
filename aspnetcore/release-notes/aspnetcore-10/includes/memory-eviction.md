### Automatic eviction from memory pool

The memory pools used by Kestrel, IIS, and HTTP.sys now automatically evict memory blocks when the application is idle or under less load. The feature  runs automatically and doesn't need to be enabled or configured manually.

#### Why memory eviction matters

Previously, memory allocated by the pool would remain reserved, even when not in use. This feature releases memory back to the system when the app is idle for a period of time. This eviction reduces overall memory usage and helps applications stay responsive under varying workloads.

#### Use memory eviction metrics

Metrics have been added to the default memory pool used by our server implementations. The new metrics are under the name `"Microsoft.AspNetCore.MemoryPool"`.

For information about metrics and how to use them, see <xref:log-mon/metrics/metrics>.

#### Manage memory pools

Besides using memory pools more efficiently by evicting unneeded memory blocks, .NET 10 improves the experience of creating memory pools. It does this by providing a built-in [IMemoryPoolFactory](https://source.dot.net/#Microsoft.AspNetCore.Connections.Abstractions/IMemoryPoolFactory.cs)MemoryPoolFactorymplementation. It makes the implementation available to your application through dependency injection.

The following code example shows a simple background service that uses the built-in memory pool factory implementation to create memory pools. These pools benefit from the automatic eviction feature:

```csharp
public class MyBackgroundService : BackgroundService
{
    private readonly MemoryPool<byte> _memoryPool;

    public MyBackgroundService(IMemoryPoolFactory<byte> factory)
    {
        _memoryPool = factory.Create();
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

To use your own memory pool factory, make a class that implements `IMemoryPoolFactory` and register it with dependency injection, as the following example does. Memory pools created this way also benefit from the automatic eviction feature:

```csharp
services.AddSingleton<IMemoryPoolFactory<byte>,
CustomMemoryPoolFactory>();

public class CustomMemoryPoolFactory : IMemoryPoolFactory<byte>
{
    public MemoryPool<byte> Create()
    {
        // Return a custom MemoryPool implementation
        // or the default, as is shown here.
        return MemoryPool<byte>.Shared;
    }
}
```
