:::moniker range="< aspnetcore-6.0"

<xref:Microsoft.Extensions.ObjectPool> is part of the ASP.NET Core infrastructure that supports keeping a group of objects in memory for reuse rather than allowing the objects to be garbage collected.

You might want to use the object pool if the objects that are being managed are:

- Expensive to allocate/initialize.
- Represent some limited resource.
- Used predictably and frequently.

For example, the ASP.NET Core framework uses the object pool in some places to reuse <xref:System.Text.StringBuilder> instances. `StringBuilder` allocates and manages its own buffers to hold character data. ASP.NET Core regularly uses `StringBuilder` to implement features, and reusing them provides a performance benefit.

Object pooling doesn't always improve performance:

- Unless the initialization cost of an object is high, it's usually slower to get the object from the pool.
- Objects managed by the pool aren't de-allocated until the pool is de-allocated.

Use object pooling only after collecting performance data using realistic scenarios for your app or library.

:::moniker-end
:::moniker range="< aspnetcore-3.0"
**WARNING: The `ObjectPool` doesn't implement `IDisposable`. We don't recommend using it with types that need disposal.** `ObjectPool` in ASP.NET Core 3.0 and later supports `IDisposable`.
:::moniker-end
:::moniker range="< aspnetcore-6.0"

**NOTE: The ObjectPool doesn't place a limit on the number of objects that it will allocate, it places a limit on the number of objects it will retain.**

## Concepts

<xref:Microsoft.Extensions.ObjectPool.ObjectPool`1> - the basic object pool abstraction. Used to get and return objects.

<xref:Microsoft.Extensions.ObjectPool.PooledObjectPolicy%601> - implement this to customize how an object is created and how it is *reset* when returned to the pool. This can be passed into an object pool that you construct directly.... OR

<xref:Microsoft.Extensions.ObjectPool.ObjectPoolProvider.Create*> acts as a factory for creating object pools.
<!-- REview, there is no ObjectPoolProvider<T> -->

The ObjectPool can be used in an app in multiple ways:

* Instantiating a pool.
* Registering a pool in [Dependency injection](xref:fundamentals/dependency-injection) (DI) as an instance.
* Registering the `ObjectPoolProvider<>` in DI and using it as a factory.

## How to use ObjectPool

Call <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1.Get*> to get an object and <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1.Return*> to return the object.  There's no requirement that you return every object. If you don't return an object, it will be garbage collected.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

## ObjectPool sample

The following code:

* Adds `ObjectPoolProvider` to the [Dependency injection](xref:fundamentals/dependency-injection) (DI) container.
* Adds and configures `ObjectPool<StringBuilder>` to the DI container.
* Adds the `BirthdayMiddleware`.

[!code-csharp[](~/performance/ObjectPool/ObjectPoolSample/Startup.cs?name=snippet)]

The following code implements `BirthdayMiddleware`

[!code-csharp[](~/performance/ObjectPool/ObjectPoolSample/BirthdayMiddleware.cs?name=snippet)]

:::moniker-end