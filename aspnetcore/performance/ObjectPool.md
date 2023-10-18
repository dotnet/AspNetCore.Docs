---
title: Object reuse with ObjectPool in ASP.NET Core
author: rick-anderson
description: Tips for increasing performance in ASP.NET Core apps using ObjectPool.
monikerRange: '>= aspnetcore-1.1'
ms.author: riande
ms.date: 4/21/2023
uid: performance/ObjectPool
---
# Object reuse with ObjectPool in ASP.NET Core

By [Günther Foidl](https://github.com/gfoidl), [Steve Gordon](https://twitter.com/stevejgordon), and [Samson Amaugo](https://github.com/sammychinedu2ky)

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

<xref:Microsoft.Extensions.ObjectPool> is part of the ASP.NET Core infrastructure that supports keeping a group of objects in memory for reuse rather than allowing the objects to be garbage collected. All the static and instance methods in `Microsoft.Extensions.ObjectPool` are thread-safe.

Apps might want to use the object pool if the objects that are being managed are:

- Expensive to allocate/initialize.
- Represent a limited resource.
- Used predictably and frequently.

For example, the ASP.NET Core framework uses the object pool in some places to reuse <xref:System.Text.StringBuilder> instances. `StringBuilder` allocates and manages its own buffers to hold character data. ASP.NET Core regularly uses `StringBuilder` to implement features, and reusing them provides a performance benefit.

Object pooling doesn't always improve performance:

- Unless the initialization cost of an object is high, it's usually slower to get the object from the pool.
- Objects managed by the pool aren't de-allocated until the pool is de-allocated.

Use object pooling only after collecting performance data using realistic scenarios for your app or library.

**NOTE: The ObjectPool doesn't place a limit on the number of objects that it allocates, it places a limit on the number of objects it retains.**

## ObjectPool concepts

When <xref:Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider> is used and `T` implements `IDisposable`:

* Items that are ***not*** returned to the pool will be disposed.
* When the pool gets disposed by DI, all items in the pool are disposed.

NOTE: After the pool is disposed:

* Calling `Get` throws an `ObjectDisposedException`.
* Calling `Return` disposes the given item.

Important `ObjectPool` types and interfaces:

* <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1> : The basic object pool abstraction. Used to get and return objects.
* <xref:Microsoft.Extensions.ObjectPool.PooledObjectPolicy%601> : Implement this to customize how an object is created and how it's reset when returned to the pool. This can be passed into an object pool that's constructed directly.
* <xref:Microsoft.Extensions.ObjectPool.IResettable> : Automatically resets the object when returned to an object pool.

The ObjectPool can be used in an app in multiple ways:

* Instantiating a pool.
* Registering a pool in [Dependency injection](xref:fundamentals/dependency-injection) (DI) as an instance.
* Registering the `ObjectPoolProvider<>` in DI and using it as a factory.

## How to use ObjectPool

Call <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1.Get*> to get an object and <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1.Return*> to return the object.  There's no requirement to return every object. If an object isn't returned, it will be garbage collected.

## ObjectPool sample

The following code:

* Adds `ObjectPoolProvider` to the [Dependency injection](xref:fundamentals/dependency-injection) (DI) container.
* Implements the `IResettable` interface to automatically clear the contents of the buffer when returned to the object pool.

[!code-csharp[](~/performance/ObjectPool/ObjectPoolSample8/Program.cs)]

**NOTE:** When the pooled type `T` doesn't implement `IResettable`, then a custom `PooledObjectPolicy<T>` can be used to reset the state of the objects before they are returned to the pool.

:::moniker-end

[!INCLUDE[](~/performance/ObjectPool/includes/ObjectPool6.md)]

[!INCLUDE[](~/performance/ObjectPool/includes/ObjectPool1-5.md)]
