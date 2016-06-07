

DistributedCacheTagHelperService Class
======================================






Implements :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService` and ensures
multiple concurrent requests are gated.
The entries are stored like this:
<ul><li>Int32 representing the hashed cache key size.</li><li>The UTF8 encoded hashed cache key.</li><li>The UTF8 encoded cached content.</li></ul>


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService`








Syntax
------

.. code-block:: csharp

    public class DistributedCacheTagHelperService : IDistributedCacheTagHelperService








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService.DistributedCacheTagHelperService(Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage, Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter, System.Text.Encodings.Web.HtmlEncoder, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type storage: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage
    
        
        :type formatter: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter
    
        
        :type HtmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public DistributedCacheTagHelperService(IDistributedCacheTagHelperStorage storage, IDistributedCacheTagHelperFormatter formatter, HtmlEncoder HtmlEncoder, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperService.ProcessContentAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput, Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey, Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        :type key: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey
    
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
    
        
        .. code-block:: csharp
    
            public Task<IHtmlContent> ProcessContentAsync(TagHelperOutput output, CacheTagKey key, DistributedCacheEntryOptions options)
    

