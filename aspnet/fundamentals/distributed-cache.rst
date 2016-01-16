Working with a Distributed Cache
================================
By `Steve Smith`_

Distributed caches can improve the performance and scalability of ASP.NET 5 apps, especially when hosted in a cloud or server farm environment. This article explains how to work with ASP.NET 5's built-in distributed cache abstractions and implementations.

.. contents:: Sections:
  :local:
  :depth: 1

`Download sample from GitHub <https://github.com/aspnet/docs/aspnet/fundamentals/distributed-cache/sample>`_. 

What is a Distributed Cache
---------------------------
A distributed cache is shared by multiple app servers (see :ref:`caching-basics`). The information in the cache is not stored in the memory of individual web servers, and the cached data is available to all of the app's servers. This provides several advantages:

1. Cached data is coherent on all web servers. Users don't see different results depending on which web server handles their request
2. Cached data survives web server restarts and deployments. Individual web servers can be removed or added without impacting the cache.
3. The source data store has fewer requests made to it (than with multiple in-memory caches or no cache at all).

.. note:: If using a SQL Server Distributed Cache, some of these advantages are only true if a separate database instance is used for the cache than for the app's source data.

Like any cache, a distributed cache can dramatically improve an app's responsiveness, since typically data can be retrieved from the cache much faster than from a relational database (or web service).

Cache configuration is implementation specific. This article describes how to configure both Redis and SQL Server distributed caches. Regardless of which implementation is selected, the app interacts with the cache using a common `IDistributedCache <https://github.com/aspnet/Caching/blob/1.0.0-rc1/src/Microsoft.Extensions.Caching.Abstractions/IDistributedCache.cs>`_ interface.

The IDistributedCache Interface
-------------------------------
The ``IDistributedCache`` interface includes synchronous and asynchronous methods. The interface allows items to be added, retrieved, and removed from the distributed cache implementation. The ``IDistributedCache`` interface includes the following methods:

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

To use the ``IDistributedCache`` interface:

	1. Specify the dependencies needed in ``project.json``.
	2. Configure the specific implementation of ``IDistributedCache`` in your ``Startup`` class's ``ConfigureServices`` method, and add it to the container there.
	3. From the app's :doc:`middleware` or MVC controller classes, request an instance of ``IDistributedCache`` from the constructor. The instance will be provided by :doc:`dependency-injection` (DI).

.. note:: There is no need to use a Singleton or Scoped lifetime for ``IDistributedCache`` instances (at least for the built-in implementations). You can also create an instance wherever you might need one (instead of using :doc:`dependency-injection`), but this can make your code harder to test, and violates the `Explicit Dependencies Principle <http://deviq.com/explicit-dependencies-principle/>`_.

The following example shows how to use an instance of ``IDistributedCache`` in a simple middleware component:

.. literalinclude:: dist-cache/sample/src/DistCacheSample/StartTimeHeader.cs
  :language: c#
  :linenos:
  :emphasize-lines: 13,16,19,25-29

In the code above, the cached value is read, but never written. In this sample, the value is only set when a server starts up, and doesn't change. In a multi-server scenario, the most recent server to start will overwrite any previous values that were set by other servers. The ``Get`` and ``Set`` methods use the ``byte[]`` type. Therefore, the string value must be converted using ``Encoding.UTF8.GetString`` (for ``Get``) and ``Encoding.UTF8.GetBytes`` (for ``Set``).

The following code from ``Startup.cs`` shows the value being set:

.. literalinclude:: dist-cache/sample/src/DistCacheSample/Startup.cs
  :language: c#
  :linenos:
  :lines: 59-68
  :emphasize-lines: 2,6-8

.. note:: Since ``IDistributedCache`` is configured in the ``ConfigureServices`` method, it is available to the ``Configure`` method as a parameter. Adding it as a parameter will allow the configured instance to be provided through DI.

Using a Redis Distributed Cache
-------------------------------
`Redis <redis.io>`_ is an open source in-memory data store, which is often used as a distributed cache. You can use it locally, and you can configure an `Azure Redis Cache <https://azure.microsoft.com/en-us/services/cache/>`_ for your Azure-hosted ASP.NET 5 apps. Your ASP.NET 5 app configures the cache implementation using a ``RedisDistributedCache`` instance.

You configure the Redis implementation in ``ConfigureServices`` and access it in your app code by requesting an instance of ``IDistributedCache`` (see the code above).

In the sample code, a ``RedisCache`` implementation is used when the server is configured for a ``Staging`` environment. Thus the ``ConfigureStagingServices`` method configures the ``RedisCache``:

.. literalinclude:: dist-cache/sample/src/DistCacheSample/Startup.cs
  :language: c#
  :linenos:
  :lines: 27-40
  :emphasize-lines: 8-13

.. note:: To install Redis on your local machine, install the chocolatey package http://chocolatey.org/packages/redis-64/ and run ``redis-server`` from a command prompt.

Using a SQL Server Distributed Cache
------------------------------------
The `SqlServerCache <https://github.com/aspnet/Caching/tree/1.0.0-rc1/src/Microsoft.Extensions.Caching.SqlServer>`_ implementation allows the distributed cache to use a SQL Server database as its backing store. The installation script installs a table with the name you specify. The table will have the following schema:

.. image:: dist-cache/_static/SqlServerCacheTable.png

.. note:: If you're working with the RC1 version of ``SqlServerCache``, there isn't a working installer. You can install the required table using the scripts found in the `SqlQueries.cs file <https://github.com/aspnet/Caching/blob/1.0.0-rc1/src/Microsoft.Extensions.Caching.SqlConfig/SqlQueries.cs>`_. This will be addressed in RC2.

Like all cache implementations, your app should get and set cache values using an instance of ``IDistributedCache``, not a ``SqlServerCache``. The sample implements ``SqlServerCache`` in the ``Production`` environment (so it is configured in ``ConfigureProductionServices``).

.. literalinclude:: dist-cache/sample/src/DistCacheSample/Startup.cs
  :language: c#
  :linenos:
  :lines: 42-56
  :emphasize-lines: 9-14

.. note:: The ``ConnectionString`` (and optionally, ``SchemaName`` and ``TableName``) should typically be stored outside of source control (such as UserSecrets), as they may contain credentials.

Recommendations
---------------
When deciding which implementation of ``IDistributedCache`` is right for your app, choose between Redis and SQL Server based on your existing infrastructure and environment, your performance requirements, and your team's experience. If your team is more comfortable working with Redis, it's an excellent choice. If your team prefers SQL Server, you can be confident in that implementation as well. Note that A traditional caching solution stores data in-memory which allows for fast retrieval of data. You should store commonly used data in a cache and store the entire data in a backend persistent store such as SQL Server or Azure Storage.
Redis Cache is a caching solution which gives you high throughput and low latency as compared to SQL Cache. Also, you should avoid using the in-memory implementation (``MemoryCache``) in multi-server environments.

Azure Resources:
	- `Redis Cache on Azure <https://azure.microsoft.com/en-us/documentation/services/redis-cache/>`_
	- `SQL Database on Azure <https://azure.microsoft.com/en-us/documentation/services/sql-database/>`_

.. tip:: The in-memory implementation of ``IDistributedCache`` should only be used for testing purposes or for applications that are hosted on just one server instance.

