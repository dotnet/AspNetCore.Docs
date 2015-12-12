

DistributedCacheEntryOptions Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions`








Syntax
------

.. code-block:: csharp

   public class DistributedCacheEntryOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Abstractions/DistributedCacheEntryOptions.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions.AbsoluteExpiration
    
        
    
        Gets or sets an absolute expiration date for the cache entry.
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? AbsoluteExpiration { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions.AbsoluteExpirationRelativeToNow
    
        
    
        Gets or sets an absolute expiration time, relative to now.
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions.SlidingExpiration
    
        
    
        Gets or sets how long a cache entry can be inactive (e.g. not accessed) before it will be removed.
        This will not extend the entry lifetime beyond the absolute expiration (if set).
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? SlidingExpiration { get; set; }
    

