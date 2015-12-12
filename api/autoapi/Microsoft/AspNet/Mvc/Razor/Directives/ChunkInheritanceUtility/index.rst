

ChunkInheritanceUtility Class
=============================



.. contents:: 
   :local:



Summary
-------

A utility type for supporting inheritance of directives into a page from applicable <c>_ViewImports</c> pages.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility`








Syntax
------

.. code-block:: csharp

   public class ChunkInheritanceUtility





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/ChunkInheritanceUtility.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility.ChunkInheritanceUtility(Microsoft.AspNet.Mvc.Razor.MvcRazorHost, Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.Chunk>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility`\.
    
        
        
        
        :param razorHost: The  used to parse _ViewImports pages.
        
        :type razorHost: Microsoft.AspNet.Mvc.Razor.MvcRazorHost
        
        
        :param chunkTreeCache: that caches  instances.
        
        :type chunkTreeCache: Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache
        
        
        :param defaultInheritedChunks: Sequence of s inherited by default.
        
        :type defaultInheritedChunks: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           public ChunkInheritanceUtility(MvcRazorHost razorHost, IChunkTreeCache chunkTreeCache, IReadOnlyList<Chunk> defaultInheritedChunks)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility.GetInheritedChunkTreeResults(System.String)
    
        
    
        Gets an ordered :any:`System.Collections.Generic.IReadOnlyList\`1` of parsed :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree`\s and
        file paths for each <c>_ViewImports</c> that is applicable to the page located at
        ``pagePath``. The list is ordered so that the :any:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult`\'s 
        :dn:prop:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult.ChunkTree` for the <c>_ViewImports</c> closest to the
        ``pagePath`` in the file system appears first.
    
        
        
        
        :param pagePath: The path of the page to locate inherited chunks for.
        
        :type pagePath: System.String
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult}
        :return: A <see cref="T:System.Collections.Generic.IReadOnlyList`1" /> of parsed <c>_ViewImports</c><see cref="T:Microsoft.AspNet.Razor.Chunks.ChunkTree" />s and their file paths.
    
        
        .. code-block:: csharp
    
           public virtual IReadOnlyList<ChunkTreeResult> GetInheritedChunkTreeResults(string pagePath)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility.MergeInheritedChunkTrees(Microsoft.AspNet.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.ChunkTree>, System.String)
    
        
    
        Merges :any:`Microsoft.AspNet.Razor.Chunks.Chunk` inherited by default and :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree` instances produced by parsing
        <c>_ViewImports</c> files into the specified ``chunkTree``.
    
        
        
        
        :param chunkTree: The  to merge in to.
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        
        
        :param inheritedChunkTrees: inherited from _ViewImports
            files.
        
        :type inheritedChunkTrees: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.ChunkTree}
        
        
        :param defaultModel: The default model  name.
        
        :type defaultModel: System.String
    
        
        .. code-block:: csharp
    
           public void MergeInheritedChunkTrees(ChunkTree chunkTree, IReadOnlyList<ChunkTree> inheritedChunkTrees, string defaultModel)
    

