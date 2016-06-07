

ICacheEntry Interface
=====================






Represents an entry in the :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` implementation.


Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICacheEntry : IDisposable








.. dn:interface:: Microsoft.Extensions.Caching.Memory.ICacheEntry
    :hidden:

.. dn:interface:: Microsoft.Extensions.Caching.Memory.ICacheEntry

Properties
----------

.. dn:interface:: Microsoft.Extensions.Caching.Memory.ICacheEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.AbsoluteExpiration
    
        
    
        
        Gets or sets an absolute expiration date for the cache entry.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            DateTimeOffset? AbsoluteExpiration
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.AbsoluteExpirationRelativeToNow
    
        
    
        
        Gets or sets an absolute expiration time, relative to now.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            TimeSpan? AbsoluteExpirationRelativeToNow
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.ExpirationTokens
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Primitives.IChangeToken` instances which cause the cache entry to expire.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            IList<IChangeToken> ExpirationTokens
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.Key
    
        
    
        
        Gets the key of the cache entry.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object Key
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.PostEvictionCallbacks
    
        
    
        
        Gets or sets the callbacks will be fired after the cache entry is evicted from the cache.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration<Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration>}
    
        
        .. code-block:: csharp
    
            IList<PostEvictionCallbackRegistration> PostEvictionCallbacks
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.Priority
    
        
    
        
        Gets or sets the priority for keeping the cache entry in the cache during a
        memory pressure triggered cleanup. The default is :dn:field:`Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal`\.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.CacheItemPriority
    
        
        .. code-block:: csharp
    
            CacheItemPriority Priority
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.SlidingExpiration
    
        
    
        
        Gets or sets how long a cache entry can be inactive (e.g. not accessed) before it will be removed.
        This will not extend the entry lifetime beyond the absolute expiration (if set).
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            TimeSpan? SlidingExpiration
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.ICacheEntry.Value
    
        
    
        
        Gets or set the value of the cache entry.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object Value
            {
                get;
                set;
            }
    

