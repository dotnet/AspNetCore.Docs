

CacheTagHelper Class
====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.TagHelper` implementation targeting &lt;cache&gt; elements.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper`








Syntax
------

.. code-block:: csharp

   public class CacheTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/CacheTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.CacheTagHelper(Microsoft.Extensions.Caching.Memory.IMemoryCache)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper`\.
    
        
        
        
        :param memoryCache: The .
        
        :type memoryCache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           public CacheTagHelper(IMemoryCache memoryCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.ProcessAsync(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.CacheKeyPrefix
    
        
    
        Prefix used by :any:`Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper` instances when creating entries in :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.MemoryCache`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string CacheKeyPrefix
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.Enabled
    
        
    
        Gets or sets the value which determines if the tag helper is enabled or not.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Enabled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.ExpiresAfter
    
        
    
        Gets or sets the duration, from the time the cache entry was added, when it should be evicted.
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? ExpiresAfter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.ExpiresOn
    
        
    
        Gets or sets the exact :any:`System.DateTimeOffset` the cache entry should be evicted.
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? ExpiresOn { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.ExpiresSliding
    
        
    
        Gets or sets the duration from last access that the cache entry should be evicted.
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? ExpiresSliding { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.MemoryCache
    
        
    
        Gets the :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` instance used to cache entries.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           protected IMemoryCache MemoryCache { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.Priority
    
        
    
        Gets or sets the :any:`Microsoft.Extensions.Caching.Memory.CacheItemPriority` policy for the cache entry.
    
        
        :rtype: System.Nullable{Microsoft.Extensions.Caching.Memory.CacheItemPriority}
    
        
        .. code-block:: csharp
    
           public CacheItemPriority? Priority { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.VaryBy
    
        
    
        Gets or sets a :any:`System.String` to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryBy { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.VaryByCookie
    
        
    
        Gets or sets a comma-delimited set of cookie names to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryByCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.VaryByHeader
    
        
    
        Gets or sets the name of a HTTP request header to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryByHeader { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.VaryByQuery
    
        
    
        Gets or sets a comma-delimited set of query parameters to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryByQuery { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.VaryByRoute
    
        
    
        Gets or sets a comma-delimited set of route data parameters to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryByRoute { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.VaryByUser
    
        
    
        Gets or sets a value that determines if the cached result is to be varied by the Identity for the logged in 
        :dn:prop:`Microsoft.AspNet.Http.HttpContext.User`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool VaryByUser { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.ViewContext
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.CacheTagHelper.ViewContext` for the current executing View.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

