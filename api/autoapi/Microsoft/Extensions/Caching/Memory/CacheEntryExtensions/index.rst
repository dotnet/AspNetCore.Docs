

CacheEntryExtensions Class
==========================





Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Memory.CacheEntryExtensions`








Syntax
------

.. code-block:: csharp

    public class CacheEntryExtensions








.. dn:class:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.AddExpirationToken(Microsoft.Extensions.Caching.Memory.ICacheEntry, Microsoft.Extensions.Primitives.IChangeToken)
    
        
    
        
        Expire the cache entry if the given :any:`Microsoft.Extensions.Primitives.IChangeToken` expires.
    
        
    
        
        :param entry: The :any:`Microsoft.Extensions.Caching.Memory.ICacheEntry`\.
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :param expirationToken: The :any:`Microsoft.Extensions.Primitives.IChangeToken` that causes the cache entry to expire.
        
        :type expirationToken: Microsoft.Extensions.Primitives.IChangeToken
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry AddExpirationToken(this ICacheEntry entry, IChangeToken expirationToken)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.RegisterPostEvictionCallback(Microsoft.Extensions.Caching.Memory.ICacheEntry, Microsoft.Extensions.Caching.Memory.PostEvictionDelegate)
    
        
    
        
        The given callback will be fired after the cache entry is evicted from the cache.
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type callback: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry RegisterPostEvictionCallback(this ICacheEntry entry, PostEvictionDelegate callback)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.RegisterPostEvictionCallback(Microsoft.Extensions.Caching.Memory.ICacheEntry, Microsoft.Extensions.Caching.Memory.PostEvictionDelegate, System.Object)
    
        
    
        
        The given callback will be fired after the cache entry is evicted from the cache.
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type callback: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate
    
        
        :type state: System.Object
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry RegisterPostEvictionCallback(this ICacheEntry entry, PostEvictionDelegate callback, object state)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.SetAbsoluteExpiration(Microsoft.Extensions.Caching.Memory.ICacheEntry, System.DateTimeOffset)
    
        
    
        
        Sets an absolute expiration date for the cache entry.
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type absolute: System.DateTimeOffset
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry SetAbsoluteExpiration(this ICacheEntry entry, DateTimeOffset absolute)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.SetAbsoluteExpiration(Microsoft.Extensions.Caching.Memory.ICacheEntry, System.TimeSpan)
    
        
    
        
        Sets an absolute expiration time, relative to now.
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type relative: System.TimeSpan
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry SetAbsoluteExpiration(this ICacheEntry entry, TimeSpan relative)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.SetOptions(Microsoft.Extensions.Caching.Memory.ICacheEntry, Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions)
    
        
    
        
        Applies the values of an existing :any:`Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions` to the entry.
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry SetOptions(this ICacheEntry entry, MemoryCacheEntryOptions options)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.SetPriority(Microsoft.Extensions.Caching.Memory.ICacheEntry, Microsoft.Extensions.Caching.Memory.CacheItemPriority)
    
        
    
        
        Sets the priority for keeping the cache entry in the cache during a memory pressure tokened cleanup.
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type priority: Microsoft.Extensions.Caching.Memory.CacheItemPriority
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry SetPriority(this ICacheEntry entry, CacheItemPriority priority)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.SetSlidingExpiration(Microsoft.Extensions.Caching.Memory.ICacheEntry, System.TimeSpan)
    
        
    
        
        Sets how long the cache entry can be inactive (e.g. not accessed) before it will be removed.
        This will not extend the entry lifetime beyond the absolute expiration (if set).
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type offset: System.TimeSpan
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry SetSlidingExpiration(this ICacheEntry entry, TimeSpan offset)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.CacheEntryExtensions.SetValue(Microsoft.Extensions.Caching.Memory.ICacheEntry, System.Object)
    
        
    
        
        Sets the value of the cache entry.
    
        
    
        
        :type entry: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        :type value: System.Object
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
    
        
        .. code-block:: csharp
    
            public static ICacheEntry SetValue(this ICacheEntry entry, object value)
    

