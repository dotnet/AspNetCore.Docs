In Memory Caching
=================

By `Steve Smith`_

Caching involves keeping a copy of data in a location that can be accessed more quickly than the source 
data. ASP.NET 5 has rich support for caching in a variety of ways, including keeping data in memory on the 
local server, which is referred to as *in memory caching*.

In this article:
	- `Caching Basics`_
	- `Configuring In Memory Caching`_
	- `Reading and Writing to a Memory Cache`_
	- `Cache Dependencies and Callbacks`_

`View or download sample from GitHub <https://github.com/aspnet/Docs/tree/1.0.0-beta8/aspnet/fundamentals/caching/sample>`_.

Caching Basics
--------------
Caching can dramatically improve the performance and scalability of ASP.NET applications, by eliminating unnecessary requests to external data sources for data that changes less frequently than it is read. ASP.NET supports several different kinds of caches, the simplest of which is represented by the `IMemoryCache <https://github.com/aspnet/Caching/blob/dev/src/Microsoft.Extensions.Caching.Abstractions/IMemoryCache.cs>`_ interface, which represents a cache stored in the memory of the local web server.

An in-memory cache is stored in the memory of a single server hosting an ASP.NET application. Thus, if an application is hosted by multiple servers in a web farm or cloud hosting environment, it is possible that different servers will have different values in their local in-memory caches. If this is an issue for the application, a :doc:`distributed-cache` may be a better alternative.

.. note:: Caching in all forms (in-memory or distributed, including session state) involves making a copy of data in order to optimize performance. The copied data should be considered ephemeral - it could disappear at any time. You should always write your application such that it can use cached data if it's available, but otherwise will work correctly using the underlying data source.

Configuring In Memory Caching
-----------------------------
To get started working with an in memory cache in your ASP.NET application, you should first add the following dependencies to your ``project.json`` file:

.. literalinclude:: caching/sample/src/CachingSample/project.json
	:linenos:
	:lines: 4-11
	:emphasize-lines: 4-5

Caching in ASP.NET 5 is a *service* that should be referenced from your application via :doc:`dependency-injection`. To register the caching service and make it available within your application, add the following line to your ``ConfigureServices`` method in ``Startup``:

.. literalinclude:: caching/sample/src/CachingSample/Startup.cs
	:linenos:
	:lines: 12-15
	:dedent: 8
	:emphasize-lines: 3

Once this is done, you can work with caching within your application by requesting an instance of ``IMemoryCache`` in your controller or middleware constructor. In the sample for this article, we are using a simple piece of middleware to handle requests with a customized greeting. The constructor is shown here:

.. literalinclude:: caching/sample/src/CachingSample/Middleware/GreetingMiddleware.cs
	:linenos:
	:lines: 19-28
	:dedent: 8
	:emphasize-lines: 2,7
	
Reading and Writing to a Memory Cache
-------------------------------------
The middleware's ``Invoke`` method uses caching to avoid having to reproduce the same result again and again when the inputs and underlying data haven't changed. A common example of this kind of caching is data-driven navigation menus, which rarely change but are frequently ready for display within an application. Caching results that do not vary often but which are requested frequently can greatly improve performance by reducing round trips to out of process data stores or unnecessary computation.

There are two approaches to attempting to read entries from the cache: ``Get`` and ``TryGet``. ``Get`` will return the value if it exists, but otherwise returns ``null``. ``TryGet`` will assign the cached value to an ``out`` parameter and return true if the entry exists, otherwise it returns false.

Writing to the cache is done via the ``Set`` method, which accepts the key to use to look up the value, the value to be cached, and a set of ``MemoryCacheEntryOptions``. These options allow you to specify absolute or sliding time-based cache expiration, caching priority, callbacks, and dependencies.

In the ``GreetingMiddleware`` example, greetings are cached for one minute. This is implemented using the ``SetAbsoluteExpiration`` method on ``MemoryCacheEntryOptions`` as shown here:

.. literalinclude:: caching/sample/src/CachingSample/Middleware/GreetingMiddleware.cs
	:linenos:
	:lines: 30-58
	:dedent: 8
	:emphasize-lines: 7,10,16-18

In addition to setting an absolute expiration, a sliding expiration can be used to keep frequently requested items in the cache:

.. code-block:: c#

	// keep item in cache as long as it is requested at least
	// once every 5 minutes
	new MemoryCacheEntryOptions()
		.SetSlidingExpiration(TimeSpan.FromMinutes(5))

To avoid having very active cache entries growing too stale, you can combine absolute and sliding expirations:

.. code-block:: c#

	// keep item in cache as long as it is requested at least
	// once every 5 minutes...
	// but in any case make sure to refresh it every hour
	new MemoryCacheEntryOptions()
		.SetSlidingExpiration(TimeSpan.FromMinutes(5))
		.SetAbsoluteExpiration(TimeSpan.FromHours(1))

By default, an instance of ``MemoryCache`` will automatically manage the items stored, removing entries when necessary in response to memory pressure in the application. You can influence the way cache entries are managed by setting their `CacheItemPriority <https://github.com/aspnet/Caching/blob/dev/src/Microsoft.Extensions.Caching.Abstractions/CacheItemPriority.cs>`_ when adding the item to the cache. For instance, if you have an item you want to keep in the cache unless you explicitly remove it, you would use the ``NeverRemove`` priority option:

.. code-block:: c#

	// keep item in cache indefinitely unless explicitly removed
	new MemoryCacheEntryOptions()
		.SetPriority(CacheItemPriority.NeverRemove))

When you do want to explicitly remove an item from the cache, you can do so easily using the ``Remove`` method:

.. code-block:: c#

	cache.Remove(cacheKey);

Cache Dependencies and Callbacks
--------------------------------
You can also configure cache entries to depend on other cache entries, the file system, or programmatic tokens, evicting the entry in response to changes. In addition, when a cache entry is evicted, you can register a callback to allow you to execute some code in response to this event. 

.. literalinclude:: caching/sample/test/CachingSample.Tests/MemoryCacheTests.cs
	:linenos:
	:lines: 22-41
	:dedent: 8
	:emphasize-lines: 6-11,18

This callback is fired on a separate thread from the code that removes the item from the cache.

.. warning:: If the callback is used to repopulate the cache it is possible other requests for the cache will take place (and find it empty) before the callback completes, possibly resulting in several threads repopulating the cached value.

Possible `eviction reasons <https://github.com/aspnet/Caching/blob/dev/src/Microsoft.Extensions.Caching.Abstractions/EvictionReason.cs>`_ are:

None
	No reason known.

Removed
	The item was manually removed by a call to ``Remove()``
	
Replaced
	The item was overwritten.
	
Expired
	The item timed out.
	
TokenExpired
	The token the item depended upon fired an event.
	
Capacity
	The item was removed as part of the cache's memory management process.

You can specify that one or more cache entries depend on a ``CancellationTokenSource`` by adding the expiration token to the ``MemoryCacheEntryOptions`` object. Then, when something occurs that requires the cached item(s) to be invalidated, you simply call ``Cancel`` on the token, and all of the associated cache entries will be expired from the cache (with a readon of ``TokenExpired``). This unit test demonstrates this behavior:

.. literalinclude:: caching/sample/test/CachingSample.Tests/MemoryCacheTests.cs
	:linenos:
	:lines: 43-64
	:dedent: 8
	:emphasize-lines: 7,16,21

Using a ``CancellationTokenSource`` allows multiple cache entries to all be expired without the need to create a dependency between cache entries themselves (in which case, care must be taken that the source cache entry exists before it is used as a dependency for other entries).

You can use a cache entry link, ``IEntryLink`` to specify that one cache entry is linked to the same cancellation token and/or time-based expiration as another. In this way, subordinate cache entries can be configured to expire at the same time as related entries.

.. literalinclude:: caching/sample/test/CachingSample.Tests/MemoryCacheTests.cs
	:linenos:
	:lines: 66-94
	:dedent: 8
	:emphasize-lines: 5,13,22-23

.. note:: When one cache entry is linked to another, it copies that entry's expiration token and time-based expiration settings, if any. It is not expired in response to manual removal or updating of the linked entry.

Other Resources
---------------
- :doc:`distributed-cache`
