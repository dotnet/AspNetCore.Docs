

Microsoft.Extensions.Caching.Memory Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/CacheEntryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/CacheExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/CacheItemPriority/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/EvictionReason/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/ICacheEntry/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/IMemoryCache/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCache/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCacheEntryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCacheEntryOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCacheOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/PostEvictionCallbackRegistration/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/PostEvictionDelegate/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.Extensions.Caching.Memory


    .. rubric:: Interfaces


    interface :dn:iface:`ICacheEntry`
        .. object: type=interface name=Microsoft.Extensions.Caching.Memory.ICacheEntry

        
        Represents an entry in the :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` implementation.


    interface :dn:iface:`IMemoryCache`
        .. object: type=interface name=Microsoft.Extensions.Caching.Memory.IMemoryCache

        
        Represents a local in-memory cache whose values are not serialized.


    .. rubric:: Delegates


    delegate :dn:del:`PostEvictionDelegate`
        .. object: type=delegate name=Microsoft.Extensions.Caching.Memory.PostEvictionDelegate

        
        Signature of the callback which gets called when a cache entry expires.


    .. rubric:: Classes


    class :dn:cls:`CacheEntryExtensions`
        .. object: type=class name=Microsoft.Extensions.Caching.Memory.CacheEntryExtensions

        


    class :dn:cls:`CacheExtensions`
        .. object: type=class name=Microsoft.Extensions.Caching.Memory.CacheExtensions

        


    class :dn:cls:`MemoryCache`
        .. object: type=class name=Microsoft.Extensions.Caching.Memory.MemoryCache

        
        An implementation of :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` using a dictionary to
        store its entries.


    class :dn:cls:`MemoryCacheEntryExtensions`
        .. object: type=class name=Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions

        


    class :dn:cls:`MemoryCacheEntryOptions`
        .. object: type=class name=Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions

        


    class :dn:cls:`MemoryCacheOptions`
        .. object: type=class name=Microsoft.Extensions.Caching.Memory.MemoryCacheOptions

        


    class :dn:cls:`PostEvictionCallbackRegistration`
        .. object: type=class name=Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration

        


    .. rubric:: Enumerations


    enum :dn:enum:`CacheItemPriority`
        .. object: type=enum name=Microsoft.Extensions.Caching.Memory.CacheItemPriority

        
        Specifies how items are prioritized for preservation during a memory pressure triggered cleanup.


    enum :dn:enum:`EvictionReason`
        .. object: type=enum name=Microsoft.Extensions.Caching.Memory.EvictionReason

        


