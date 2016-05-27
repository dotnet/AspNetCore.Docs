

CacheTagHelper Class
====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper` implementation targeting <cache> elements.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper`








Syntax
------

.. code-block:: csharp

    public class CacheTagHelper : CacheTagHelperBase, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper.MemoryCache
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` instance used to cache entries.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            protected IMemoryCache MemoryCache
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper.Priority
    
        
    
        
        Gets or sets the :any:`Microsoft.Extensions.Caching.Memory.CacheItemPriority` policy for the cache entry.
    
        
        :rtype: System.Nullable<System.Nullable`1>{Microsoft.Extensions.Caching.Memory.CacheItemPriority<Microsoft.Extensions.Caching.Memory.CacheItemPriority>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("priority")]
            public CacheItemPriority? Priority
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper.CacheTagHelper(Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper`\.
    
        
    
        
        :param memoryCache: The :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache`\.
        
        :type memoryCache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder` to use.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public CacheTagHelper(IMemoryCache memoryCache, HtmlEncoder htmlEncoder)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper.CacheKeyPrefix
    
        
    
        
        Prefix used by :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper` instances when creating entries in :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper.MemoryCache`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string CacheKeyPrefix
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

