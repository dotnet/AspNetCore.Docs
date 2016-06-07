

ChunkInheritanceUtility Class
=============================






A utility type for supporting inheritance of directives into a page from applicable <code>_ViewImports</code> pages.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility`








Syntax
------

.. code-block:: csharp

    public class ChunkInheritanceUtility








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility.ChunkInheritanceUtility(Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost, Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.Chunk>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility`\.
    
        
    
        
        :param razorHost: The :any:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost` used to parse <code>_ViewImports</code> pages.
        
        :type razorHost: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost
    
        
        :param chunkTreeCache: :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache` that caches :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` instances.
            
        
        :type chunkTreeCache: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache
    
        
        :param defaultInheritedChunks: Sequence of :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk`\s inherited by default.
        
        :type defaultInheritedChunks: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            public ChunkInheritanceUtility(MvcRazorHost razorHost, IChunkTreeCache chunkTreeCache, IReadOnlyList<Chunk> defaultInheritedChunks)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility.GetInheritedChunkTreeResults(System.String)
    
        
    
        
        Gets an ordered :any:`System.Collections.Generic.IReadOnlyList\`1` of parsed :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree`\s and
        file paths for each <code>_ViewImports</code> that is applicable to the page located at
        <em>pagePath</em>. The list is ordered so that the :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult`\'s
        :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult.ChunkTree` for the <code>_ViewImports</code> closest to the
        <em>pagePath</em> in the file system appears first.
    
        
    
        
        :param pagePath: The path of the page to locate inherited chunks for.
        
        :type pagePath: System.String
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult<Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult>}
        :return: A :any:`System.Collections.Generic.IReadOnlyList\`1` of parsed <code>_ViewImports</code> 
            :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree`\s and their file paths.
    
        
        .. code-block:: csharp
    
            public virtual IReadOnlyList<ChunkTreeResult> GetInheritedChunkTreeResults(string pagePath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility.MergeInheritedChunkTrees(Microsoft.AspNetCore.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.ChunkTree>, System.String)
    
        
    
        
        Merges :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` inherited by default and :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` instances produced by parsing
        <code>_ViewImports</code> files into the specified <em>chunkTree</em>.
    
        
    
        
        :param chunkTree: The :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` to merge in to.
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        :param inheritedChunkTrees: :any:`System.Collections.Generic.IReadOnlyList\`1` inherited from <code>_ViewImports</code>
            files.
        
        :type inheritedChunkTrees: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.ChunkTree<Microsoft.AspNetCore.Razor.Chunks.ChunkTree>}
    
        
        :param defaultModel: The default model :any:`System.Type` name.
        
        :type defaultModel: System.String
    
        
        .. code-block:: csharp
    
            public void MergeInheritedChunkTrees(ChunkTree chunkTree, IReadOnlyList<ChunkTree> inheritedChunkTrees, string defaultModel)
    

