

GlobbingUrlBuilder Class
========================



.. contents:: 
   :local:



Summary
-------

Utility methods for :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s that support
attributes containing file globbing patterns.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder`








Syntax
------

.. code-block:: csharp

   public class GlobbingUrlBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/GlobbingUrlBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.GlobbingUrlBuilder(Microsoft.AspNet.FileProviders.IFileProvider, Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.AspNet.Http.PathString)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder`\.
    
        
        
        
        :param fileProvider: The file provider.
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
        
        
        :param cache: The cache.
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :param requestPathBase: The request path base.
        
        :type requestPathBase: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public GlobbingUrlBuilder(IFileProvider fileProvider, IMemoryCache cache, PathString requestPathBase)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.BuildUrlList(System.String, System.String, System.String)
    
        
    
        Builds a list of URLs.
    
        
        
        
        :param staticUrl: The statically declared URL. This will always be added to the result.
        
        :type staticUrl: System.String
        
        
        :param includePattern: The file globbing include pattern.
        
        :type includePattern: System.String
        
        
        :param excludePattern: The file globbing exclude pattern.
        
        :type excludePattern: System.String
        :rtype: System.Collections.Generic.IEnumerable{System.String}
        :return: The list of URLs
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<string> BuildUrlList(string staticUrl, string includePattern, string excludePattern)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.Cache
    
        
    
        The :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` to cache globbing results in.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           public IMemoryCache Cache { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.FileProvider
    
        
    
        The :any:`Microsoft.AspNet.FileProviders.IFileProvider` used to watch for changes to file globbing results.
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public IFileProvider FileProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.RequestPathBase
    
        
    
        The base path of the current request (i.e. :dn:prop:`Microsoft.AspNet.Http.HttpRequest.PathBase`\).
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString RequestPathBase { get; }
    

