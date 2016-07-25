

MemoryCacheEntryExtensions Class
================================





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
* :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions`








Syntax
------

.. code-block:: csharp

    public class MemoryCacheEntryExtensions








.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.AddExpirationToken(Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions, Microsoft.Extensions.Primitives.IChangeToken)
    
        
    
        
        Expire the cache entry if the given :any:`Microsoft.Extensions.Primitives.IChangeToken` expires.
    
        
    
        
        :param options: The :any:`Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions`\.
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        :param expirationToken: The :any:`Microsoft.Extensions.Primitives.IChangeToken` that causes the cache entry to expire.
        
        :type expirationToken: Microsoft.Extensions.Primitives.IChangeToken
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static MemoryCacheEntryOptions AddExpirationToken(this MemoryCacheEntryOptions options, IChangeToken expirationToken)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.RegisterPostEvictionCallback(Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions, Microsoft.Extensions.Caching.Memory.PostEvictionDelegate)
    
        
    
        
        The given callback will be fired after the cache entry is evicted from the cache.
    
        
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        :type callback: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static MemoryCacheEntryOptions RegisterPostEvictionCallback(this MemoryCacheEntryOptions options, PostEvictionDelegate callback)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.RegisterPostEvictionCallback(Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions, Microsoft.Extensions.Caching.Memory.PostEvictionDelegate, System.Object)
    
        
    
        
        The given callback will be fired after the cache entry is evicted from the cache.
    
        
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        :type callback: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate
    
        
        :type state: System.Object
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static MemoryCacheEntryOptions RegisterPostEvictionCallback(this MemoryCacheEntryOptions options, PostEvictionDelegate callback, object state)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetAbsoluteExpiration(Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions, System.DateTimeOffset)
    
        
    
        
        Sets an absolute expiration date for the cache entry.
    
        
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        :type absolute: System.DateTimeOffset
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static MemoryCacheEntryOptions SetAbsoluteExpiration(this MemoryCacheEntryOptions options, DateTimeOffset absolute)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetAbsoluteExpiration(Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions, System.TimeSpan)
    
        
    
        
        Sets an absolute expiration time, relative to now.
    
        
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        :type relative: System.TimeSpan
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static MemoryCacheEntryOptions SetAbsoluteExpiration(this MemoryCacheEntryOptions options, TimeSpan relative)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetPriority(Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions, Microsoft.Extensions.Caching.Memory.CacheItemPriority)
    
        
    
        
        Sets the priority for keeping the cache entry in the cache during a memory pressure tokened cleanup.
    
        
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        :type priority: Microsoft.Extensions.Caching.Memory.CacheItemPriority
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static MemoryCacheEntryOptions SetPriority(this MemoryCacheEntryOptions options, CacheItemPriority priority)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetSlidingExpiration(Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions, System.TimeSpan)
    
        
    
        
        Sets how long the cache entry can be inactive (e.g. not accessed) before it will be removed.
        This will not extend the entry lifetime beyond the absolute expiration (if set).
    
        
    
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        :type offset: System.TimeSpan
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    
        
        .. code-block:: csharp
    
            public static MemoryCacheEntryOptions SetSlidingExpiration(this MemoryCacheEntryOptions options, TimeSpan offset)
    

