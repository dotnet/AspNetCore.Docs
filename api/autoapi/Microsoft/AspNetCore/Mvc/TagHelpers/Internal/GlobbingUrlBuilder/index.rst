

GlobbingUrlBuilder Class
========================






Utility methods for :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s that support
attributes containing file globbing patterns.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder`








Syntax
------

.. code-block:: csharp

    public class GlobbingUrlBuilder








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.Cache
    
        
    
        
        The :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` to cache globbing results in.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            public IMemoryCache Cache
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.FileProvider
    
        
    
        
        The :any:`Microsoft.Extensions.FileProviders.IFileProvider` used to watch for changes to file globbing results.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider FileProvider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.RequestPathBase
    
        
    
        
        The base path of the current request (i.e. :dn:prop:`Microsoft.AspNetCore.Http.HttpRequest.PathBase`\).
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString RequestPathBase
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.GlobbingUrlBuilder(Microsoft.Extensions.FileProviders.IFileProvider, Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder`\.
    
        
    
        
        :param fileProvider: The file provider.
        
        :type fileProvider: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        :param cache: The cache.
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :param requestPathBase: The request path base.
        
        :type requestPathBase: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public GlobbingUrlBuilder(IFileProvider fileProvider, IMemoryCache cache, PathString requestPathBase)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder.BuildUrlList(System.String, System.String, System.String)
    
        
    
        
        Builds a list of URLs.
    
        
    
        
        :param staticUrl: The statically declared URL. This will always be added to the result.
        
        :type staticUrl: System.String
    
        
        :param includePattern: The file globbing include pattern.
        
        :type includePattern: System.String
    
        
        :param excludePattern: The file globbing exclude pattern.
        
        :type excludePattern: System.String
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.String<System.String>}
        :return: The list of URLs
    
        
        .. code-block:: csharp
    
            public virtual IReadOnlyList<string> BuildUrlList(string staticUrl, string includePattern, string excludePattern)
    

