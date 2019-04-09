---
title: Object reuse with ObjectPool in ASP.NET Core
author: rick-anderson
description: Tips for increasing performance in ASP.NET Core apps using ObjectPool.
monikerRange: '>= aspnetcore-1.1'
ms.author: riande
ms.date: 4/11/2019
uid: performance/ObjectPool
---
# Object reuse with ObjectPool in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

<xref:Microsoft.Extensions.ObjectPool> is part of the ASP.NET Core infrastructure that supports keeping a group of objects in memory for reuse rather than allowing the objects to be garbage collected.

You might want to use the object pool if the objects that are being managed are:

- Expensive to allocate/initialize.
- Represent some limited resource.
- Used predictably and frequently.

For example, the ASP.NET Core framework uses the object pool in some places to reuse <xref:System.Text.StringBuilder> instances. `StringBuilder` allocates and manages its own buffers to hold character data. ASP.NET Core regularly uses `StringBuilder` to implement features, and reusing them provides a performance benefit.

Using `ObjectPool` has performance tradeoffs. You should only use a technique like pooling after collecting performance data about realistic scenarios for your app or library. In particular, getting an object from the pool will usually be slower then allocating an object unless the initialization or allocation cost of that type of object is high. Additionally, by using the pool, you will prevent objects managed by the pool from being de-allocated until you de-allocate the pool.

**WARNING: The `ObjectPool` doesn't implement `IDisposable`. We don't recommend using it with types that need disposal.**

**NOTE: The ObjectPool doesn't place a limit on the number of objects that it will allocate, it places a limit on the number of object it will retain.**

## Concepts

<xref:Microsoft.Extensions.ObjectPool.ObjectPool%601> - the basic object pool abstraction. This is what your code should use to get and return objects.

<xref:Microsoft.Extensions.ObjectPool.PooledObjectPolicy%601> - implement this to customize how an object is created and how it is *reset* when returned to the pool. This can be passed into an object pool that you construct directly.... OR

`ObjectPoolProvider<T>` acts as a factory for creating object pools.
<!-- REview, there is no ObjectPoolProvider<T> -->

The ObjectPool can be used in an app in multiple ways:

* Instantiating a pool.
* Registering a pool in [Dependency injection](xref:fundamentals/dependency-injection) (DI) as an instance.
* Registering the `ObjectPoolProvider<>` in DI and using it as a factory.

<!-- REview, there is no ObjectPoolProvider<T> -->

## How to use ObjectPool

Call <xref:Microsoft.Extensions.ObjectPool.ObjectPool*> to get an object and <xref:Microsoft.Extensions.ObjectPool.ObjectPool*> to return the object.  There's no requirement that you return every object - if you don't return an object, then it will be garbage collected.

## ObjectPool sample

The following code:

* Adds `ObjectPoolProvider` to the DI container.
* Adds and configures `ObjectPool<StringBuilder>` to the DI container.
* Adds the `BirthdayMiddleware`.

[!code-csharp[](ObjectPool/ObjectPoolSample/BirthdayMiddleware.cs?name=snippet)]

The following code implements `BirthdayMiddleware`

