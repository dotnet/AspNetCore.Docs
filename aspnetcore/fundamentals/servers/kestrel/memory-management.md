---
title: Memory management in Kestrel
ai-usage: ai-assisted
author: tdykstra
description: Learn about memory management in Kestrel, including automatic eviction from memory pools and using memory pool metrics.
monikerRange: '>= aspnetcore-10.0'
ms.author: tdykstra
ms.date: 01/29/2026
uid: fundamentals/servers/kestrel/memory-management
---

# Memory management in Kestrel

By [Tom Dykstra](https://github.com/tdykstra)

This article provides guidance for managing memory in Kestrel, including automatic eviction from memory pools and using memory pool metrics.

## Automatic eviction from memory pool

The memory pools used by Kestrel, IIS, and HTTP.sys automatically evict memory blocks when the application is idle or under low load. The feature runs automatically and doesn't need to be enabled or configured manually.

This automatic eviction feature reduces overall memory usage and helps applications stay responsive under varying workloads. In versions of .NET earlier than 10, memory allocated by the pool remained reserved even when not in use.

### Use memory pool metrics

The default memory pool used by the ASP.NET Core server implementations includes metrics, which can be used to monitor and analyze memory usage patterns. The metrics are under the name `"Microsoft.AspNetCore.MemoryPool"`.

For information about metrics and how to use them, see <xref:log-mon/metrics/metrics>.

## Manage memory pools

Besides using memory pools efficiently by evicting unneeded memory blocks, ASP.NET Core provides a built-in [IMemoryPoolFactory](https://source.dot.net/#Microsoft.AspNetCore.Connections.Abstractions/IMemoryPoolFactory.cs) interface and its default implementation, which are available through dependency injection.

The following code example shows a simple background service that uses the built-in memory pool factory implementation to create memory pools. These pools benefit from the automatic eviction feature:

:::code language="csharp" source="~/fundamentals/servers/snippets/10.x/my-background-service.cs":::

To use a custom memory pool factory, make a class that implements `IMemoryPoolFactory` and register it with dependency injection, as the following example does. Memory pools created this way do not benefit from the automatic eviction feature unless you implement similar eviction logic in your custom factory:

:::code language="csharp" source="~/fundamentals/servers/snippets/10.x/memory-pool-factory.cs":::

When you're using a memory pool, be aware of the pool's <xref:System.Buffers.MemoryPool`1.MaxBufferSize>.
