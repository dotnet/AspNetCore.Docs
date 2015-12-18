Working with a Distributed Cache
================================
By `Steve Smith`_

Distributed caches can improve the performance and scalability of ASP.NET 5 applications, especially when hosted in a cloud or server farm environment. This article explains how to work with ASP.NET 5's built-in distributed cache abstractions and supported implementations.

.. contents:: In this article:
  :local:
  :depth: 1

`Download sample from GitHub <https://github.com/aspnet/docs/aspnet/fundamentals/distributed-cache/sample>`_. 

What is a Distributed Cache
---------------------------
A distributed cache is an implementation of a cache that is shared by multiple application servers (see :ref:`caching-basics` to learn more). The information in the cache is not stored in the memory of individual web servers, and the cached data is available to all of the application's servers. This provides several advantages:

1. Cached data is the same between all web servers, so users don't see different results depending on which web server handles their request
2. Cached data survives web server restarts and deployments. Individual web servers can be removed or added without impacting the cache.
3. The source data store has fewer requests made to it (than with multiple in-memory caches or no cache at all).

Of course, like any cache, a distributed cache can dramatically improve an application's responsiveness, since typically data can be retrieved from the cache much faster than from a relational database (or web service).

Configuring a distributed cache for use by your ASP.NET 5 applications depends on the specific implementation chosen. This article describes how to configure both Redis and SQL Server implementations below. Regardless of which implementation is selected, the application interacts with the cache using a common `IDistributedCache <https://github.com/aspnet/Caching/blob/1.0.0-rc1/src/Microsoft.Extensions.Caching.Abstractions/IDistributedCache.cs>`_ interface.

The IDistributedCache Interface
-------------------------------
The ``IDistributedCache`` interface includes both synchronous and async methods. The interface allows items to get added, retrieved, and removed from the distributed cache implementation. The complete list of methods supported by the interface is:

Connect, ConnectAsync
	*Deprecated*

Get, GetAsync
	Takes a string key and retrieves a cached item as a ``byte[]`` if found in the cache.
	
Set, SetAsync
	Adds an item (as ``byte[]``) to the cache using a string key.
	
Refresh, RefreshAsync
	Refreshes an item in the cache based on its key, resetting its sliding expiration timeout (if any).
	
Remove, RemoveAsync
	Removes a cache entry based on its key.

In your ASP.NET 5 application, you can configure the specific implementation of ``IDistributedCache`` in your ``Startup`` class, and add it to the container in the ``ConfigureServices`` method. Of course, you will also need to specify any necessary dependencies in ``project.json``. Once this configuration is in place, your application's :doc:`middleware` or MVC Controller classes can request an instance of ``IDistributedCache`` via their constructor, and these will be provided via :doc:`dependency-injection` (DI).

.. note:: There is no need to use a Singleton or Scoped lifetime for ``IDistributedCache`` instances (at least for the built-in implementations). You can also create an instance wherever you might need one (instead of using :doc:`dependency-injection`), but this can make your code harder to test, and violates the `Explicit Dependencies Principle <http://deviq.com/explicit-dependencies-principle/>`_.

The following code example shows how to use an instance of ``IDistributedCache`` in one of your ASP.NET 5 application's classes (in this case, a simple middleware):

.. literalinclude:: dist-cache/sample/src/DistCacheSample/StartTimeFooter.cs
  :language: c#
  :linenos:
  :lines: 1-
  :emphasize-lines: 14,17,20,28-32

In the above example, the value is read from, but never written to, the cache. This is because in this case the value is only written when the server starts up. Since getting and setting values from the cache must use a ``byte[]``, the string value being stored must be converted using ``Encoding.UTF8.GetString``. Similarly, the string value is converted into a ``byte[]`` (in this case using ``Encoding.UTF8.GetBytes``) when it is set during application startup. The following code from ``Startup.cs`` shows the value being set:

.. literalinclude:: dist-cache/sample/src/DistCacheSample/Startup.cs
  :language: c#
  :linenos:
  :lines: 59-68
  :emphasize-lines: 6,9

.. note:: Normally you would request an instance of ``IDistributedCache`` via DI, rather than fetching it from ``ApplicationServices`` (as shown above on line 8). However, during application startup only certain types are available via DI, so this service locator pattern approach when access to cache instances is needed within the ``Configure`` method.

Using a Redis Distributed Cache
-------------------------------
`Redis <redis.io>`_ is an open source in-memory data store, which is often used as a distributed cache. In addition to downloading and configuring it locally, you can also easily configure an `Azure Redis Cache <https://azure.microsoft.com/en-us/services/cache/>`_ for your Azure-hosted ASP.NET 5 applications. Once you have an instance of Redis configured, you can configure ASP.NET to use a ``RedisDistributedCache`` instance.

Working with a Redis instance of ``IDistributedCache`` should be completely transparent to your application code. You should request an instance of ``IDistributedCache``, as shown above, and use that interface to set and get values from the cache. The only place in your application where you should reference the Redis implementation is in your ``ConfigureServices`` method, where you will configure the Redis implementation.

In the sample code associated with this article, a ``RedisCache`` implementation is used when the server is configured for a ``Staging`` environment. Thus ``ConfigureStagingServices`` has the required code to configure the ``RedisCache``:

.. literalinclude:: dist-cache/sample/src/DistCacheSample/Startup.cs
  :language: c#
  :linenos:
  :lines: 27-40
  :emphasize-lines: 8-13

.. note:: To install Redis on your local machine, install the chocolatey package http://chocolatey.org/packages/redis-64/ and run ``redis-server`` from a command prompt.

Using a SQL Server Distributed Cache
------------------------------------
The `SqlServerCache <https://github.com/aspnet/Caching/tree/1.0.0-rc1/src/Microsoft.Extensions.Caching.SqlServer>`_ implementation allows the distributed cache to use a SQL Server database as its backing store. The installation script installs a table with whatever name you configure and the following schema:

.. image:: dist-cache/_static/SqlServerCacheTable.png

Just as with a Redis implementation, working with a ``SqlServerCache`` implementation should be transparent to your application code. Your application code should simply request an instance of type ``IDistributedCache`` and get and set cached values through this interface. You should only configure ``SqlServerCache`` in your application's ``ConfigureServices`` method.

In the sample code associated with this article, a ``SqlServerCache`` implementation is used when the server is configured for a ``Production`` environment. Thus, ``ConfigureProductionServices`` has the required code to configure the ``SqlServerCache``:

.. literalinclude:: dist-cache/sample/src/DistCacheSample/Startup.cs
  :language: c#
  :linenos:
  :lines: 42-56
  :emphasize-lines: 9-14

.. note:: The ``ConnectionString`` (and optionally, ``SchemaName`` and ``TableName``) should typically be stored in :doc:`configuration` in real-world applications, rather than hard-coded here where a code change is required to update the values.

Recommendations
---------------
When deciding which implementation of ``IDistributedCache`` is right for your application, choose between Redis and SQL Server based on your existing infrastructure and environment and your team's experience. If your team is more comfortable working with Redis, it's an excellent choice. If your team prefers SQL Server, you can be confident in that implementation as well. Avoid using the in-memory implementation (``MemoryCache``) in production environements.

.. warning:: The in-memory implementation of ``IDistributedCache`` is only provided for testing purposes and should not be used in production.

