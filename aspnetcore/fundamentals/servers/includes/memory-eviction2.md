## Automatic eviction from memory pool

The memory pools used by Kestrel, IIS, and HTTP.sys automatically evict memory blocks when the application is idle or under low load. The feature runs automatically and doesn't need to be enabled or configured manually.

In versions of .NET earlier than 10, memory allocated by the pool remains reserved, even when not in use. This automatic eviction feature reduces overall memory usage and helps applications stay responsive under varying workloads.

### Use memory pool metrics

The default memory pool used by the ASP.NET Core server implementations includes metrics, which can be used to monitor and analyze memory usage patterns. The metrics are under the name `"Microsoft.AspNetCore.MemoryPool"`.

For information about metrics and how to use them, see <xref:log-mon/metrics/metrics>.

## Manage memory pools

Besides using memory pools efficiently by evicting unneeded memory blocks, ASP.NET Core provides a built-in [IMemoryPoolFactory](https://source.dot.net/#Microsoft.AspNetCore.Connections.Abstractions/IMemoryPoolFactory.cs) and an implementation. It makes the implementation available to your application through dependency injection.

The following code example shows a simple background service that uses the built-in memory pool factory implementation to create memory pools. These pools benefit from the automatic eviction feature:

:::code language="csharp" source="~/fundamentals/servers/snippets/10.x/my-background-service.cs":::

To use a custom memory pool factory, make a class that implements `IMemoryPoolFactory` and register it with dependency injection, as the following example does. Memory pools created this way do not benefit from the automatic eviction feature unless you implement similar eviction logic in your custom factory:

:::code language="csharp" source="~/fundamentals/servers/snippets/10.x/memory-pool-factory.cs":::

When you're using a memory pool, be aware of the pool's <xref:System.Buffers.MemoryPool`1.MaxBufferSize>.

