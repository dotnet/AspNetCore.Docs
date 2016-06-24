

Microsoft.AspNetCore.Mvc.TagHelpers.Cache Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/CacheTagKey/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/DistributedCacheTagHelperFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/DistributedCacheTagHelperFormattingContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/DistributedCacheTagHelperService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/DistributedCacheTagHelperStorage/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/IDistributedCacheTagHelperFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/IDistributedCacheTagHelperService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/TagHelpers/Cache/IDistributedCacheTagHelperStorage/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache


    .. rubric:: Interfaces


    interface :dn:iface:`IDistributedCacheTagHelperFormatter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter

        
        An implementation of this interface provides a service to
        serialize html fragments for being store by :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage`


    interface :dn:iface:`IDistributedCacheTagHelperService`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService

        
        An implementation of this interface provides a service to process
        the content or fetches it from cache for distributed cache tag helpers.


    interface :dn:iface:`IDistributedCacheTagHelperStorage`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage

        
        An implementation of this interface provides a service to 
        cache distributed html fragments from the <distributed-cache>
        tag helper.


    .. rubric:: Classes


    class :dn:cls:`CacheTagKey`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey

        
        An instance of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey` represents the state of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper`
        or :any:`Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper` keys.


    class :dn:cls:`DistributedCacheTagHelperFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormatter

        
        Implements :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter` by serializing the content
        in UTF8.


    class :dn:cls:`DistributedCacheTagHelperFormattingContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormattingContext

        
        Represents an object containing the information to serialize with :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter`\.


    class :dn:cls:`DistributedCacheTagHelperService`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService

        
        Implements :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService` and ensures
        multiple concurrent requests are gated.
        The entries are stored like this:
        <ul><li>Int32 representing the hashed cache key size.</li><li>The UTF8 encoded hashed cache key.</li><li>The UTF8 encoded cached content.</li></ul>


    class :dn:cls:`DistributedCacheTagHelperStorage`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperStorage

        
        Implements :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage` by storing the content
        in using :any:`Microsoft.Extensions.Caching.Distributed.IDistributedCache` as the store.


