

IChunkTreeCache Interface
=========================



.. contents:: 
   :local:



Summary
-------

A cache for parsed :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree`\s.











Syntax
------

.. code-block:: csharp

   public interface IChunkTreeCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/IChunkTreeCache.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache.GetOrAdd(System.String, System.Func<Microsoft.AspNet.FileProviders.IFileInfo, Microsoft.AspNet.Razor.Chunks.ChunkTree>)
    
        
    
        Get an existing :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree`\, or create and add a new one if it is
        not available in the cache or is expired.
    
        
        
        
        :param pagePath: The application relative path of the Razor page.
        
        :type pagePath: System.String
        
        
        :param getChunkTree: A delegate that creates a new .
        
        :type getChunkTree: System.Func{Microsoft.AspNet.FileProviders.IFileInfo,Microsoft.AspNet.Razor.Chunks.ChunkTree}
        :rtype: Microsoft.AspNet.Razor.Chunks.ChunkTree
        :return: The <see cref="T:Microsoft.AspNet.Razor.Chunks.ChunkTree" /> if a file exists at <paramref name="pagePath" />,
            <c>null</c> otherwise.
    
        
        .. code-block:: csharp
    
           ChunkTree GetOrAdd(string pagePath, Func<IFileInfo, ChunkTree> getChunkTree)
    

