---
title: Use ObjectPool to keep groups of object in memory in ASP.NET Core
author: rick-anderson
description: Use ObjectPool to keep groups of object in memory rather than allowing the objects to be garbage collected.
monikerRange: '>= aspnetcore-2.2'
ms.author: riande
ms.date: 07/10/2019
uid: performance/objectPool
---
# Use ObjectPool to keep groups of object in memory in ASP.NET Core

By [Steve Gordon](https://twitter.com/stevejgordon?), [Ryan Nowak](https://github.com/rynowak) and  [Rick Anderson](https://twitter.com/RickAndMSFT)

The <xref:Microsoft.Extensions.ObjectPool> is infrastructure that supports keeping a group of objects in memory for reuse rather than allowing the objects to be garbage collected.

Objects that may benefit from the object pool include objects that are:

- Expensive to allocate or initialize
- A limited resource
- Used predictably and frequently

For example, the ASP.NET Core framework uses the object pool in some places to reuse <xref:System.Text.StringBuilder> instances. `StringBuilder` allocates and manages its own buffers to hold character data. Because ASP.NET Core regularly uses `StringBuilder` to implement features, reusing them provides a performance benefit.

Every decision has performance tradeoffs. You should only use a technique like object pooling after collecting performance data about realistic scenarios for your app or library.

Using a pool to get an object:

* Is typically slower than allocating an object. It's faster when the initialization or allocation cost of the object is high.
* Prevents objects managed by the pool from being de-allocated until you de-allocate the pool.

> [!WARNING]
> The `ObjectPool` doesn't implement `IDisposable`. We don't recommend using it with types that need disposal.
>
> The `ObjectPool` doesn't place a limit on the number of objects that it will allocate, it places a limit on the number of object it will retain.

## Concepts

<xref:Microsoft.Extensions.ObjectPool.ObjectPool`1> - The basic object pool abstraction. This is used to get and return objects.

<xref:Microsoft.Extensions.ObjectPool.PooledObjectPolicy`1> - Implement this to customize how an object is created and how it is *reset* when returned to the pool. This can be passed into an object pool that you construct directly. Alternatively, [ObjectPoolProvider.Create\<T>](xref:Microsoft.Extensions.ObjectPool.ObjectPoolProvider.Create*) acts as a factory for creating object pools.

An `ObjectPool` can be initialized by:

- Instantiating a pool.
- Registering a pool in [dependency injection](xref:fundamentals/dependency-injection) as an instance.
- Registering the `ObjectPoolProvider<>` in dependency injection and using it as a factory.

## How to use ObjectPool

Call [ObjectPool\<T>.Get](/dotnet/api/microsoft.extensions.objectpool.objectpool-1.get) to get an object and [ObjectPool\<T>.Return(T)](/dotnet/api/microsoft.extensions.objectpool.objectpool-1.return) to return it.  There's no requirement that you return every object. If you don't return an object, it will be garbage collected.

## ObjectPool sample

The following sample creates an `ObjectPool` to contain a `StringBuilder`. [View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/performance/objectPool) ([how to download](xref:index#how-to-download-a-sample))

 The `StringBuilderPooledObjectPolicy.Create` method is called the first time an `ObjectPool<StringBuilder>` is requested. Subsequent requests for `ObjectPool<StringBuilder>` are returned by the `ObjectPool`:

[!code-csharp[](objectPool/ObjectPoolSample/StringBuilderPooledObjectPolicy.cs?name=snippet)]

The following code shows the birthday middleware that uses the `ObjectPool<StringBuilder>`:

[!code-csharp[](objectPool/ObjectPoolSample/BirthdayMiddleware.cs?name=snippet&highlight=21,50)]

In the preceding code, the `builderPool.Get` call requests an `ObjectPool<StringBuilder>` object. The first time `builderPool.Get` is called, `StringBuilderPooledObjectPolicy.Create` is called. Subsequent requests for `ObjectPool<StringBuilder>` are returned by the `ObjectPool`.

`builderPool.Return(stringBuilder);` invokes the `StringBuilderPooledObjectPolicy.Return` method, which clears the `StringBuilder` object.

The following code initializes the `ObjectPool<StringBuilder>` and adds the `BirthdayMiddleware` to the request pipeline:

[!code-csharp[](objectPool/ObjectPoolSample/Startup.cs?name=snippet)]