

MemoryCacheEntryOptions Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions`








Syntax
------

.. code-block:: csharp

   public class MemoryCacheEntryOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.Abstractions/MemoryCacheEntryOptions.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.AbsoluteExpiration
    
        
    
        Gets or sets an absolute expiration date for the cache entry.
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? AbsoluteExpiration { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow
    
        
    
        Gets or sets an absolute expiration time, relative to now.
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.ExpirationTokens
    
        
    
        Gets the :any:`Microsoft.Extensions.Primitives.IChangeToken` instances which cause the cache entry to expire.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Extensions.Primitives.IChangeToken}
    
        
        .. code-block:: csharp
    
           public IList<IChangeToken> ExpirationTokens { get; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.PostEvictionCallbacks
    
        
    
        Gets or sets the callbacks will be fired after the cache entry is evicted from the cache.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration}
    
        
        .. code-block:: csharp
    
           public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks { get; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.Priority
    
        
    
        Gets or sets the priority for keeping the cache entry in the cache during a
        memory pressure triggered cleanup. The default is :dn:field:`Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal`\.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.CacheItemPriority
    
        
        .. code-block:: csharp
    
           public CacheItemPriority Priority { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.SlidingExpiration
    
        
    
        Gets or sets how long a cache entry can be inactive (e.g. not accessed) before it will be removed.
        This will not extend the entry lifetime beyond the absolute expiration (if set).
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? SlidingExpiration { get; set; }
    

