

IChunkTreeCache Interface
=========================






A cache for parsed :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Directives`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IChunkTreeCache : IDisposable








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache.GetOrAdd(System.String, System.Func<Microsoft.Extensions.FileProviders.IFileInfo, Microsoft.AspNetCore.Razor.Chunks.ChunkTree>)
    
        
    
        
        Get an existing :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree`\, or create and add a new one if it is
        not available in the cache or is expired.
    
        
    
        
        :param pagePath: The application relative path of the Razor page.
        
        :type pagePath: System.String
    
        
        :param getChunkTree: A delegate that creates a new :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree`\.
        
        :type getChunkTree: System.Func<System.Func`2>{Microsoft.Extensions.FileProviders.IFileInfo<Microsoft.Extensions.FileProviders.IFileInfo>, Microsoft.AspNetCore.Razor.Chunks.ChunkTree<Microsoft.AspNetCore.Razor.Chunks.ChunkTree>}
        :rtype: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
        :return: The :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` if a file exists at <em>pagePath</em>,
            <code>null</code> otherwise.
    
        
        .. code-block:: csharp
    
            ChunkTree GetOrAdd(string pagePath, Func<IFileInfo, ChunkTree> getChunkTree)
    

