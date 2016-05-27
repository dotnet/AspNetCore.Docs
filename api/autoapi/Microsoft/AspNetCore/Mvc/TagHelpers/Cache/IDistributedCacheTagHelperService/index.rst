

IDistributedCacheTagHelperService Interface
===========================================






An implementation of this interface provides a service to process
the content or fetches it from cache for distributed cache tag helpers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDistributedCacheTagHelperService








.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService.ProcessContentAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput, Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey, Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)
    
        
    
        
        Processes the html content of a distributed cache tag helper.
    
        
    
        
        :param output: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput`\.
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        :param key: The key in the storage.
        
        :type key: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey
    
        
        :param options: The :any:`Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions`\.
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: A cached or new content for the cache tag helper.
    
        
        .. code-block:: csharp
    
            Task<IHtmlContent> ProcessContentAsync(TagHelperOutput output, CacheTagKey key, DistributedCacheEntryOptions options)
    

