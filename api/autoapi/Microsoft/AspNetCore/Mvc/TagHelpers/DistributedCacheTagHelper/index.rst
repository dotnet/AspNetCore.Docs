

DistributedCacheTagHelper Class
===============================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper` implementation targeting <distributed-cache> elements.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("distributed-cache", Attributes = "name")]
    public class DistributedCacheTagHelper : CacheTagHelperBase, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper.DistributedCacheTagHelper(Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper`\.
    
        
    
        
        :param distributedCacheService: The :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService`\.
        
        :type distributedCacheService: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public DistributedCacheTagHelper(IDistributedCacheTagHelperService distributedCacheService, HtmlEncoder htmlEncoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper.MemoryCache
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` instance used to cache workers.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            protected IMemoryCache MemoryCache { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper.Name
    
        
    
        
        Gets or sets a unique name to discriminate cached entries.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("name")]
            public string Name { get; set; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper.CacheKeyPrefix
    
        
    
        
        Prefix used by :any:`Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper` instances when creating entries in :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string CacheKeyPrefix
    

