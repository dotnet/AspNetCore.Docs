

DefaultChunkTreeCache Class
===========================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache`








Syntax
------

.. code-block:: csharp

   public class DefaultChunkTreeCache : IChunkTreeCache





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/DefaultChunkTreeCache.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache.DefaultChunkTreeCache(Microsoft.AspNet.FileProviders.IFileProvider)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache`\.
    
        
        
        
        :param fileProvider: The application's .
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public DefaultChunkTreeCache(IFileProvider fileProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache.GetOrAdd(System.String, System.Func<Microsoft.AspNet.FileProviders.IFileInfo, Microsoft.AspNet.Razor.Chunks.ChunkTree>)
    
        
        
        
        :type pagePath: System.String
        
        
        :type getChunkTree: System.Func{Microsoft.AspNet.FileProviders.IFileInfo,Microsoft.AspNet.Razor.Chunks.ChunkTree}
        :rtype: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           public ChunkTree GetOrAdd(string pagePath, Func<IFileInfo, ChunkTree> getChunkTree)
    

