

DefaultChunkTreeCache Class
===========================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Directives`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache`








Syntax
------

.. code-block:: csharp

    public class DefaultChunkTreeCache : IChunkTreeCache, IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache.DefaultChunkTreeCache(Microsoft.Extensions.FileProviders.IFileProvider)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache`\.
    
        
    
        
        :param fileProvider: The application's :any:`Microsoft.Extensions.FileProviders.IFileProvider`\.
        
        :type fileProvider: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public DefaultChunkTreeCache(IFileProvider fileProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache.GetOrAdd(System.String, System.Func<Microsoft.Extensions.FileProviders.IFileInfo, Microsoft.AspNetCore.Razor.Chunks.ChunkTree>)
    
        
    
        
        :type pagePath: System.String
    
        
        :type getChunkTree: System.Func<System.Func`2>{Microsoft.Extensions.FileProviders.IFileInfo<Microsoft.Extensions.FileProviders.IFileInfo>, Microsoft.AspNetCore.Razor.Chunks.ChunkTree<Microsoft.AspNetCore.Razor.Chunks.ChunkTree>}
        :rtype: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            public ChunkTree GetOrAdd(string pagePath, Func<IFileInfo, ChunkTree> getChunkTree)
    

