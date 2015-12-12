

Microsoft.Extensions.Caching.Memory Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/CacheExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/CacheItemPriority/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/EntryLink/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/EvictionReason/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/IEntryLink/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/IMemoryCache/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCache/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCacheEntryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCacheEntryOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/MemoryCacheOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/PostEvictionCallbackRegistration/index
   
   
   
   /autoapi/Microsoft/Extensions/Caching/Memory/PostEvictionDelegate/index
   
   











.. dn:namespace:: Microsoft.Extensions.Caching.Memory


    .. rubric:: Classes


    class :dn:cls:`Microsoft.Extensions.Caching.Memory.CacheExtensions`
        


    class :dn:cls:`Microsoft.Extensions.Caching.Memory.EntryLink`
        


    class :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCache`
        


    class :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions`
        


    class :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions`
        


    class :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCacheOptions`
        


    class :dn:cls:`Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.Extensions.Caching.Memory.IEntryLink`
        Used to flow expiration information from one entry to another. :any:`Microsoft.Extensions.Primitives.IChangeToken` instances and minimum absolute
        expiration will be copied from the dependent entry to the parent entry. The parent entry will not expire if the
        dependent entry is removed manually, removed due to memory pressure, or expires due to sliding expiration.


    interface :dn:iface:`Microsoft.Extensions.Caching.Memory.IMemoryCache`
        


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.Extensions.Caching.Memory.CacheItemPriority`
        Specifies how items are prioritized for preservation during a memory pressure triggered cleanup.


    enum :dn:enum:`Microsoft.Extensions.Caching.Memory.EvictionReason`
        


    .. rubric:: Delegates


    delegate :dn:del:`Microsoft.Extensions.Caching.Memory.PostEvictionDelegate`
        Signature of the callback which gets called when a cache entry expires.


